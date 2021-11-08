using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DTO
{
    [Table("Room")]
    public class Room
    {
        public int? RoomId { get; set; }

        [ForeignKey("Hotel")]
        public int? HotelId { get; set; }

        public int? Number { get; set; }

        [Required(ErrorMessage = "Room description is required")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Room Type is required")]
        [RoomType]
        public int? Type { get; set; }

        [Required(ErrorMessage = "Room price is required")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Find out if Room has TV is required")]
        public bool HasTV { get; set; }

        [Required(ErrorMessage = "Find out if Room has hair dryer is required")]
        public bool HasHairDryer { get; set; }

        public Hotel Hotel { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public bool RoomTypeValidation()
        {
            return Type >= 1 && Type <= Enum.GetValues(typeof(EnumeratedRoomTypes)).Length;
        }

    }
}
