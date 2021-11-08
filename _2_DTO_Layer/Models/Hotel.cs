using DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Hotel")]
    public class Hotel
    {

        public int? HotelId { get; set; }

        [Required(ErrorMessage = "Hotel name is required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Hotel description is required")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Hotel location is required")]
        [MaxLength(100)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Hotel category is required")]
        [HotelCategory(minStar:1,maxStar:5)]
        public int? Category { get; set; }

        [Required(ErrorMessage = "Find out if Hotel has wifi is required")]
        public bool HasWifi { get; set; }

        [Required(ErrorMessage = "Find out if Hotel has parking is required")]
        public bool HasParking { get; set; }

        [Required(ErrorMessage = "Hotel phone is required")]
        [Phone]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Hotel email is required")]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Website { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public bool HotelCategoryValidation(int? minStar, int? maxStar)
        {
            return Category >= minStar && Category <= maxStar;
        }
    }
}
