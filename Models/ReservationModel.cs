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
        
        public RoomModel Room { get; set; }

        public ReservationModel()
        {

        }

        public ReservationModel(int id,string name,DateTime cas,RoomModel room)
        {
            Id = id;
            Name = name;
            Cas = cas;
            Room = room;
        }
    }
}

