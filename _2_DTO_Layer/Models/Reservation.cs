using DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Reservation")]
    public class Reservation
    {
        #region Reservation persisted properties

            #region Data base normalisation propreties

                #region PK Reservation - Identity

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int? IdReservation { get; set; }

                #endregion

                #region FK to Room - Reservation belongs to one Room

            [ForeignKey("Room")]
            public int? IdRoom { get; set; }

        #endregion

        #endregion

            #region Reservation state properties

        [Required(ErrorMessage= "Owner reservation firstname is required")]
        [RegularExpression("^[A-Z][a-z]+-? ?[A-Za-z][a-z]+)")]
        [MaxLength(50)]

        public string FirstName { get; set; }

        [Required(ErrorMessage="Owner reservation lastname is required")]
        [RegularExpression("^[A-Z][a-z]+-? ?[A-Za-z][a-z]+)")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Reservation checkin Date is required")]
        [CheckInDate(daysover:1)]
        public DateTime? CheckIn { get; set; }

        [Required(ErrorMessage = "Reservation checkout Date is required")]
        [CheckOutDate(daysover:1)]
        public DateTime? CheckOut { get; set; }

        [Required(ErrorMessage = "Reservation amount is required")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Amount { get; set; }

            #endregion

        #endregion

        #region Reservation Runtime Links

            #region Reservation belongs to one Room

        public Room Room { get; set; }

        #endregion

        #endregion

        #region Reservation Validation logic

        /// <summary>
        /// 
        /// </summary>
        /// <param name="daysOver"></param>
        /// <returns></returns>
        public bool CheckInFuturValidation(int daysOver)
        {
            return ((TimeSpan)(CheckIn - DateTime.Now)).TotalDays >= daysOver;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="daysOver"></param>
        /// <returns></returns>
        public bool CheckOutAfterCheckInValidation(int daysOver)
        {
            return ((TimeSpan)(CheckOut - CheckIn)).TotalDays >= daysOver;
        }

        #endregion

    }
}