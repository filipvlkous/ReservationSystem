using System;
using System.Collections;
using System.Collections.Generic;
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
            IEnumerable<RoomModel> room = await _db.Rooms.ToListAsync();

            return room;
        }

        public async Task<RoomModel> GetRoom(int? id)
        {
            RoomModel room = await _db.Rooms.FirstOrDefaultAsync(i => i.Id == id);
            return room;
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
                bool exist = await _db.Reservations.AnyAsync(x => x.Cas == from && x.RoomId == room.Id);


                if (!exist)
                {
                   hours.Add(from, new List<DateTime> { from, to });
                }
            }

            return hours;
        }

        public async Task<List<RoomsTimesModel>> GetRoomAPI(DateTime date)
        {
            List<RoomsTimesModel> roomsTimes = new List<RoomsTimesModel>();
            IEnumerable<RoomModel> rooms = await GetAllAsync();
            foreach(var room in rooms)
            {
                RoomsTimesModel newRoom = new RoomsTimesModel(room.Name,room.Open,room.Close);
                var times = await GetTimes(room.Id, date);
                newRoom.Times = times;

                roomsTimes.Add(newRoom);
            }

            return roomsTimes;
        }
    }
}
