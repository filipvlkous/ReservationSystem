using System;
using Microsoft.EntityFrameworkCore;
using MVC2nd.Interface;
using MVC2nd.Models;

namespace MVC2nd.Services
{
    public class ReservationService : IReservation
    {
        private RoomsDbContext _db;

        public ReservationService(RoomsDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ReservationModel>> GetAllResAsync()
        {

            List<ReservationModel> reservation = await _db.Reservations.ToListAsync();
            return reservation;
        }

        public async Task CreateReservation(ReservationModel reservationModel, DateTime date, RoomModel room)
        {
            reservationModel.Cas = date;
            reservationModel.Room = room;
            bool exist = await _db.Reservations.AnyAsync(x => x.Cas == date && x.Room.Id == reservationModel.Room.Id);

            if (!exist)
            {
                await _db.Reservations.AddAsync(reservationModel);
                await _db.SaveChangesAsync();
            }
        }
    }
}


