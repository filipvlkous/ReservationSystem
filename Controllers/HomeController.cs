using System.Diagnostics;
using System.Net.Mail;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MVC2nd.Interface;
using MVC2nd.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC2nd.Controllers;

public class HomeController : Controller
{
    private readonly IRoom _room;
    private readonly IReservation _reservation;


    public HomeController(IRoom room, IReservation reservation)
    {
        _room = room;
        _reservation = reservation;
    }
   
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Rooms()
    {
        try
        {
            List<RoomModel> rooms = await _room.GetAllAsync();

            return View(rooms);
        }
        catch
        {
            return NotFound("Neco se pokazilo");
        }
    }
        

    public async Task<IActionResult> Room(int? id)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var room = await _room.GetRoom(id);
            ViewBag.ShowModal = TempData.ContainsKey("ShowModal") && (bool)TempData["ShowModal"];
            TempData["RoomName"] = room.Name;
            return View(room);
        }
        catch
        {
            return NotFound("Neco se pokazilo");
        }


    }
    
    public async Task<IActionResult> DateSelect(DateTime dateTime,int id)
    {
        try { 
        TempData["Id"] = id;
        TempData["ShowModal"] = false;
        if (dateTime.Date >=  DateTime.Now.Date)
        {
            return PartialView("Times", await _room.GetTimes(id,dateTime));
        }
        return PartialView("WrongTime");
        }
        catch
        {
            return NotFound("Neco se pokazilo");
        }
    }

    [HttpGet]
    [Route("Home/Room/Create_reservation")]
    public async Task<IActionResult> CreateReservation(DateTime date)
    {
        TempData["Date"] = date;

        return View(new ReservationModel { Cas = date});
    }

    [HttpPost]
    [Route("Home/Room/Create_reservation")]
    public async Task<IActionResult> CreateReservation([Bind("Name, Email, LastName, Phone, Text")] ReservationModel reservationModel)
    {
        try
        {
            RoomModel r = await _room.GetRoom((int)TempData["Id"]);
            bool value = await _reservation.CreateReservation(reservationModel, (DateTime)TempData["Date"], r);
            if (value != true)
            {
                TempData["ShowModal"] = true;
                
                return RedirectToAction("Room", new { r.Id });
            }

            return RedirectToAction("Index");
        } 
        catch
        {
            return NotFound("Neco se pokazilo");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

