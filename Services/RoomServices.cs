using System;
using Microsoft.EntityFrameworkCore;
using MVC2nd.Interface;
using MVC2nd.Models;

namespace MVC2nd.Services
{
    public class RoomServices : IRoom
    {
        private readonly RoomsDbContext _db;
        private readonly IReservation _reservation;
        public RoomServices(RoomsDbContext db, IReservation reservation)
        {
            _reservation = reservation;
            _db = db;
        }

        public async Task<IEnumerable<RoomModel>> GetAllAsync()
        {
            var room = await _db.Rooms.ToListAsync();

            return room;
        }

        public async Task<RoomModel> GetRoom(int? id)
        {
            var room = await _db.Rooms.Include(r => r.Rezervations)
                 .FirstOrDefaultAsync(i => i.Id == id);
            return room;
        }

        public async Task<Dictionary<DateTime, List<DateTime>>> GetTimes(int id, DateTime dateTime)
        {

            Dictionary<DateTime, List<DateTime>> hours = new Dictionary<DateTime, List<DateTime>>();
            var room = await GetRoom(id);
            var reservations = await _reservation.GetAllResAsync();

            int i = room.Open;
            while (i < room.Close)
            {
                DateTime from = dateTime.Add(TimeSpan.FromHours(i));
                DateTime to = dateTime.Add(TimeSpan.FromHours(++i));


                if (reservations.Any(t => t.Cas == from && t.Room.Id == room.Id) || new DateTime() > from)
                {
                    
                }
                else
                {
                    hours.Add(from, new List<DateTime> { from, to });
                }
            }

            return hours;
        }
    }
}
