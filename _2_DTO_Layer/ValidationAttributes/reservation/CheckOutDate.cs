
using System.ComponentModel.DataAnnotations;


namespace DTO
{
    public class CheckOutDate : ValidationAttribute
    {
        #region Validation reservation checkout date - properties

        public int DefaultDaysover { get; private set; }

        #endregion

        #region Validation reservation checkout date - constructors

        public CheckOutDate(int daysover) { DefaultDaysover = daysover; }

        #endregion

        #region Validation reservation checkout date - process

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var reservation = validationContext.ObjectInstance as Reservation;
            if (!(reservation.CheckOutAfterCheckInValidation(DefaultDaysover)))
            {
                return new ValidationResult($"Checkout date has to be minimum {DefaultDaysover} day(s) over checkin date");
            }
            return ValidationResult.Success;
        }

        #endregion
    }
}
