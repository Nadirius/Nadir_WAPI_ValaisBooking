using DTO;
using Fare;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EF
{
    static class DBInitializer
    {
        private static readonly IDictionary<string, (string, int, int)[]> _data = new Dictionary<string, (string, int, int)[]>()
        {
            {"Martigny", new []{("Octodure",4,5),("Constantin Palace",2,7) }},
            {"Sion", new [] { ("Valais Palace", 3, 8), ("Grand Duc", 4, 2) }},
            {"Brig", new[] { ("Walliser Palace", 4, 3), ("Matterhorn Palace", 5, 2) }}

        };

        public static void InitDB()
        {
            using WAPIContext ctx = new();
            //ctx.Database.EnsureDeleted();
            if (ctx.Database.EnsureCreated())
            {
                //Console.WriteLine("Database has been created");
                Seed_data(ctx);
            }
            else
                //Console.WriteLine("Database already exists");
                ctx.SaveChanges();
        }

        private static void Seed_data(WAPIContext ctx)
        {
            foreach (KeyValuePair<string, (string, int, int)[]> d in _data)
            {
                InsertData(d, ctx);
            }
        }

        private static void InsertData(KeyValuePair<string, (string, int, int)[]> d, WAPIContext ctx)
        {
            foreach (var v in d.Value)
            {
                (string HotelName, int nbrSingle, int nbrDouble) = v;
                Hotel hotel = new()
                {
                    Name = HotelName,
                    Description = "Magnifique",
                    Category = new Random().Next(1, 5),
                    Location = d.Key,
                    HasParking = new Random().Next(2) == 1,
                    HasWifi = new Random().Next(2) == 1,
                    Phone = new Xeger(@"\+41 [1-9]{2} [1-9]{3} [0-9]{2} [0-9]{2}").Generate().ToString(),
                    Email = $"info@{HotelName.Replace(" ", "")}.ch",
                    Website = $"www.{HotelName.Replace(" ", "")}.ch"
                };
                ctx.Hotels.Add(hotel);
                hotel.HotelId = ctx.Hotels.Where(h => h.Name.Equals(HotelName)).Select(h => h.HotelId).FirstOrDefault();
                for (int i = 1; i <= nbrSingle + nbrDouble; i++)
                {
                    Room room = new()
                    {
                        Number = i,
                        Description = "Waww!!!",
                        Type = (i <= nbrSingle) ? 1 : 2,
                        Price = decimal.Parse(new Xeger(@"[1-2][0-5][0-9]").Generate().ToString()),
                        HasTV = new Random().Next(2) == 1,
                        HasHairDryer = new Random().Next(2) == 1,
                        HotelId = hotel.HotelId,
                        Hotel = hotel
                    };
                    ctx.Rooms.Add(room);
                    room.RoomId = ctx.Rooms.Where(r => (r.Hotel.Name + r.Number).Equals(hotel.Name + i)).Select(r => r.RoomId).FirstOrDefault();
                    for (int j = 1; j <= 3; j++)
                    {
                        ctx.Pictures.Add(new Picture()
                        {
                            Url = "www.google.com",
                            RoomId = room.RoomId,
                            Room = room
                        }); ;
                    }
                }
            }
        }

    }
}
