using System;
using System.ComponentModel.DataAnnotations;

namespace MVC2nd.Models
{
    public class RoomModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 50, ErrorMessage = "The {0} needs to be at least {2} and less than {1} characters long.", MinimumLength = 1)]
        public string Name { get; set; }

        [Required, StringLength(maximumLength: 500, ErrorMessage = "The {0} needs to be at least {2} and less than {1} characters long.", MinimumLength = 50)]
        public string Text { get; set; }

        public int Open { get; set; }

        public int Close { get; set; }

        public List<ReservationModel> Rezervations { get; set; }


    }
}

