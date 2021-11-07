using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;


namespace EF
{
    public class WAPIContext : DbContext
    {
        #region Database context - properties

        private static string ConnectionString { get; set; } = @"Server=(localDB)\MSSQLLocalDB;Database=ValaisBooking;" +
                                                              "Trusted_Connection=True;App=EFCoreApp2021";

        #endregion

        #region Database context - constructors

        public WAPIContext(DbContextOptions options) : base(options) { }

        public WAPIContext() : base(
            new DbContextOptionsBuilder()
                .LogTo(Console.WriteLine, LogLevel.Information)
                .UseSqlServer(ConnectionString)
                .Options)
        {
        }

        #endregion

        #region Database context - Querys results containers declaration

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        #endregion

        //#region Database context - on model creating configuration

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    #region Mapping to runtime the database relationnal constraints 
            
        //    modelBuilder.Entity<Hotel>().HasMany<Room>(h => h.Rooms).WithOne(r => r.Hotel).HasForeignKey(r => r.IdHotel);
        //    modelBuilder.Entity<Room>().HasMany<Reservation>(r => r.Reservations).WithOne(res => res.Room).HasForeignKey(res => res.IdRoom);
        //    modelBuilder.Entity<Room>().HasMany<Picture>(r => r.Pictures).WithOne(p => p.Room).HasForeignKey(p => p.IdRoom);

        //    #endregion
        //}

        //#endregion
    }
}
