using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2nd.Models
{
    public class ReservationModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Cas { get; set; }

        public int RoomId { get; set; }  // foreign key to RoomModel entity

        public RoomModel Room { get; set; }

        public ReservationModel()
        {

        }

        public ReservationModel(int id, string name, DateTime cas, int roomId)
        {
            Id = id;
            Name = name;
            Cas = cas;
            RoomId = roomId;
        }
    }
}

