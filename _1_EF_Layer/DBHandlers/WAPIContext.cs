using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;


namespace EF
{
    public class WAPIContext : DbContext
    {

        private static string ConnectionString { get; set; } = @"Server=(localDB)\MSSQLLocalDB;Database=ValaisBooking;" +
                                                              "Trusted_Connection=True;App=EFCoreApp2021";


        /// <summary>
        /// Ctor used 
        /// </summary>
        /// <param name="options"></param>
        public WAPIContext(DbContextOptions options) : base(options) { }


        /// <summary>
        /// Ctor used to seed initial data to SQLServer DataBase
        /// </summary>
        public WAPIContext() : base(
            new DbContextOptionsBuilder()
                .LogTo(Console.WriteLine, LogLevel.Information)
                .UseSqlServer(ConnectionString)
                .Options)
        {
        }


        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasMany<Room>(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<Room>()
                .HasMany<Reservation>(r => r.Reservations)
                .WithOne(res => res.Room)
                .HasForeignKey(res => res.RoomId);

            modelBuilder.Entity<Room>()
                .HasMany<Picture>(r => r.Pictures)
                .WithOne(p => p.Room)
                .HasForeignKey(p => p.RoomId);

        }
    }
}
