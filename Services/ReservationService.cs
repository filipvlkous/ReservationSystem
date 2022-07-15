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
            
        public ReservationService(RoomsDbContext db,IRoom room)
        {
            _db = db;
            _roomModel = room;
        }
        public async Task<IEnumerable<ReservationModel>> GetAllResAsync()
        {

            var reservation = await _db.Reservations.ToListAsync();
            return reservation;
        }


        public async Task<ReservationModel> PrepareModel(DateTime date,int _id)
        {
            ReservationModel reservationModel = new ReservationModel();
            reservationModel.Cas = date;
            reservationModel.Room = await _roomModel.GetRoom(_id);
            reservationModel.Id = _id;
            return reservationModel;
        }
    }
}

