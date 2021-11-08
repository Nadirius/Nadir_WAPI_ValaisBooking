using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Picture")]
    public class Picture
    {

        public int? PictureId { get; set; }


        [ForeignKey("Room")]
        public int? RoomId { get; set; }

        [Required(ErrorMessage ="Picture url is required")]
        [Url]
        [MaxLength(255)]
        public string Url { get; set; }

        public Room Room { get; set; }


    }
}