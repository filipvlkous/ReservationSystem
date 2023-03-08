using System;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MVC2nd.Interface;
using MVC2nd.Models;
using static System.Reflection.Metadata.BlobBuilder;

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
            RoomModel room = await _db.Rooms.FirstOrDefaultAsync(i => i.Id == id);
            return room;
        }

        private Task<Dictionary<DateTime, List<DateTime>>>? GetReservations()
        {
            return null;
        }

        public void AddDateTimeIfBetweenOpenAndClose(Dictionary<DateTime, List<DateTime>> hours, RoomModel room, DateTime time)
        {
            if (time.TimeOfDay >= TimeSpan.FromHours(room.Open) && time.TimeOfDay <= TimeSpan.FromHours(room.Close))
            {
                if (!hours.ContainsKey(time.Date))
                {
                    hours.Add(time.Date, new List<DateTime>());
                }
                hours[time.Date].Add(time);
            }
        }

        public async Task<Dictionary<DateTime, List<DateTime>>> GetTimes(int id, DateTime dateTime)
        {
            Dictionary<DateTime, List<DateTime>> hours = new Dictionary<DateTime, List<DateTime>>();
            RoomModel room = await GetRoom(id);
            List<ReservationModel> reservations = (await _reservation.GetAllResAsync()).ToList();

            int i = room.Open;
            while (i < room.Close)
            {
                DateTime from = dateTime.AddHours(i);
                DateTime to = dateTime.AddHours(++i);
                bool exist = await _db.Reservations.AnyAsync(x => x.Cas == from && x.Room.Id == room.Id);


                if (!exist)
                {
                   hours.Add(from, new List<DateTime> { from, to });
                }
            }

            return hours;
        }

        public async Task<RoomModel> GetRoomAPI(int id,DateTime date)
        {
            RoomModel room = await GetRoom(id);
            List<ReservationModel> reservations = (await _reservation.GetAllResAsync()).ToList();

            return room;
        }
    }
}
