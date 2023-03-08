using System;
using MVC2nd.Models;

namespace MVC2nd.Interface
{
    
        public interface IRoom
        {
        Task<RoomModel> GetRoom(int? id);
        Task<RoomModel> GetRoomAPI(int id,DateTime date);
        Task<IEnumerable<RoomModel>> GetAllAsync();
        Task<Dictionary<DateTime,List<DateTime>>> GetTimes(int id,DateTime dateTime);
        }
    
}

