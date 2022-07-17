using System;
using MVC2nd.Models;

namespace MVC2nd.Interface
{
    public interface IReservation
    {
        Task<IEnumerable<ReservationModel>> GetAllResAsync();
        Task CreateReservation(ReservationModel reservationModel,DateTime dateTime,int _id);
    }
}

