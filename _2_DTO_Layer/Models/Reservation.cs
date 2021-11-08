using DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Reservation")]
    public class Reservation
    {

        public int? ReservationId { get; set; }

        [ForeignKey("Room")]
        public int? RoomId { get; set; }


        [Required(ErrorMessage= "Owner reservation firstname is required")]
        [RegularExpression("^[A-Z][a-z]+-? ?[A-Za-z][a-z]+)")]
        [MaxLength(50)]

        public string FirstName { get; set; }

        [Required(ErrorMessage="Owner reservation lastname is required")]
        [RegularExpression("^[A-Z][a-z]+-? ?[A-Za-z][a-z]+)")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Reservation checkin Date is required")]
        [CheckInDateAttribute(daysover:1)]
        public DateTime? CheckIn { get; set; }

        [Required(ErrorMessage = "Reservation checkout Date is required")]
        [CheckOutDateAttribute(daysover:1)]
        public DateTime? CheckOut { get; set; }

        [Required(ErrorMessage = "Reservation amount is required")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Amount { get; set; }

        public Room Room { get; set; }

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

    }
}