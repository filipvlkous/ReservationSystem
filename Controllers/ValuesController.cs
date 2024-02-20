using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC2nd.Interface;
using MVC2nd.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC2nd.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IRoom _room;
        private readonly IReservation _reservation;

        public ValuesController(IRoom room, IReservation reservation)
        {
            _room = room;
            _reservation = reservation;
        }

        [HttpGet("{id}/{date}")]
        public async Task<IActionResult> Get(int id, string date)
        {

            DateTime parsedDate;
            bool isDateValid = DateTime.TryParseExact(date, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate);

            if (!isDateValid)
            {
                return BadRequest("Invalid date format. Please use dd.mm.yyyy format.");
            }

            var times = await _room.GetTimes(id, parsedDate);
            RoomModel room = await _room.GetRoom(id);

            var response = new
            {
                open = room.Open,
                close=room.Close,
                free = times,
            };

            return Ok(response);
        }


        [HttpGet("{date}")]
        public async Task<IActionResult> GetByDate(string date)
        {
            DateTime parsedDate;
            bool isDateValid = DateTime.TryParseExact(date, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate);

            if (!isDateValid)
            {
                return BadRequest("Invalid date format. Please use dd.mm.yyyy format.");
            }

            List<RoomsTimesModel> rooms = await _room.GetRoomAPI(parsedDate);

            object response = new
            {
                Rooms = rooms,
            };
            return Ok(response);
        }
    }
}

