using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DTO
{
    [Table("Room")]
    public class Room
    {
        #region Room persisted properties

            #region Data base normalisation properties

                #region PK Room - Identity

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdRoom { get; set; }

                #endregion

                #region FK to Hotel - Room belongs to one Hotel

        [ForeignKey("Hotel")]
        public int? IdHotel { get; set; }

                #endregion

            #endregion

            #region Room state properties

        public int? Number { get; set; }

        [Required(ErrorMessage = "Room description is required")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Room Type is required")]
        [RoomType]
        public int? Type { get; set; }

        [Required(ErrorMessage = "Room Price is required")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Find out if Room has TV is required")]
        public bool HasTV { get; set; }

        [Required(ErrorMessage = "Find out if Room has hair dryer is required")]
        public bool HasHairDryer { get; set; }

            #endregion

        #endregion

        #region Room Runtime Links

            #region Room belongs to one Hotel 

        public Hotel Hotel { get; set; }

            #endregion

            #region Room has many Picture (s)

        public ICollection<Picture> Pictures { get; set; }

            #endregion

            #region Room has many Reservation (s)

        public ICollection<Reservation> Reservations { get; set; }

            #endregion

        #endregion

        #region Room Validation logic

        public bool RoomTypeValidation()
        {
            return Type >= 1 && Type <= Enum.GetValues(typeof(EnumeratedRoomTypes)).Length;
        }

        #endregion

    }
}
