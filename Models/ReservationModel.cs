using System;
using System.ComponentModel.DataAnnotations;

namespace MVC2nd.Models
{
    public class ReservationModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Cas { get; set; }

        public RoomModel Room { get; set; }
    }
}

