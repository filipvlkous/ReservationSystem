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

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[+]\d{12}$")]
        public string Phone { get; set; }

        [StringLength(500)]
        public string? Text { get; set; }

        [Required]
        public DateTime Cas { get; set; }

        public int RoomId { get; set; }  // foreign key to RoomModel entity

        public virtual RoomModel Room { get; set; }

        public ReservationModel()
        {

        }

        public ReservationModel(int id, string name, DateTime cas, int roomId,string lastName,string email,string phone,string text)
        {
            Id = id;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Name = name;
            Cas = cas;
            RoomId = roomId;
            Text = text;
        }
    }
}

