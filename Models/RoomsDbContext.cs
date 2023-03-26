using System;
using Microsoft.EntityFrameworkCore;

namespace MVC2nd.Models
{
    public class RoomsDbContext: DbContext
    {
        public RoomsDbContext(DbContextOptions<RoomsDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomModel>().HasData(
                new RoomModel { Id = 4, Name = "Kuchyne", Open = 11,Close = 20,Text = "dsadsd sdasdasd asdasdasd adasdasda sdad" },
                new RoomModel { Id = 2, Name = "Obejvak", Open = 10, Close = 20, Text = "dsadsd sdasdasd asdasdasd adasdasda sdad" },
                new RoomModel { Id = 3, Name = "Pokoj", Open = 9, Close = 20, Text = "dsadsd sdasdasd asdasdasd adasdasda sdad" }
            );
        }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }
    }
}

