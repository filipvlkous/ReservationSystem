using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC2nd.Interface;
using MVC2nd.Models;

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
        var rooms = await _room.GetAllAsync();

        return View(rooms);
    }

    public async Task<IActionResult> Room(int? id)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var room = await _room.GetRoom(id);

        return View(room);
    }
    
    public async Task<IActionResult> DateSelect(DateTime dateTime,int id)
    {
        //js
        TempData["Id"] = id;
        if(dateTime.Date >=  DateTime.Now.Date)
        {
            return PartialView("Times", await _room.GetTimes(id,dateTime));
        }
        return PartialView("WrongTime");
    }

    [HttpGet]
    [Route("Home/Room/Create_reservation")]
    public IActionResult CreateReservation(DateTime date)
    {
        TempData["Date"] = date;
        return View(new ReservationModel());
    }

    [HttpPost]
    [Route("Home/Room/Create_reservation")]
    public async Task<IActionResult> CreateReservation([Bind("Name")] ReservationModel reservationModel)
    {
        await _reservation.CreateReservation(reservationModel,(DateTime)TempData["Date"], (int)TempData["Id"]);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

