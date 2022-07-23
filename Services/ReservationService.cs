using System;
using Microsoft.EntityFrameworkCore;
using MVC2nd.Interface;
using MVC2nd.Models;

namespace MVC2nd.Services
{
    public class ReservationService : IReservation
    {
        private RoomsDbContext _db;
        private IRoom _roomModel;

        public ReservationService(RoomsDbContext db, IRoom room)
        {
            _db = db;
            _roomModel = room;
        }

        public async Task<IEnumerable<ReservationModel>> GetAllResAsync()
        {

            List<ReservationModel> reservation = await _db.Reservations.ToListAsync();
            return reservation;
        }



        public async Task CreateReservation(ReservationModel reservationModel, DateTime date, int _id)
        {
            reservationModel.Cas = date;
            reservationModel.Room = await _roomModel.GetRoom(_id);

            bool exist = _db.Reservations.Any(x => x.Cas == date && x.Room.Name == reservationModel.Name);


            if (exist)
            {
                try
                {
                    await _db.Reservations.AddAsync(reservationModel);
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        }


    }
}


