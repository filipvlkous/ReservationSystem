using System;
using Microsoft.EntityFrameworkCore;

namespace MVC2nd.Models
{
    public class RoomsDbContext: DbContext
    {
        public RoomsDbContext(DbContextOptions<RoomsDbContext> options):base(options)
        {
        }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }
    }
}

