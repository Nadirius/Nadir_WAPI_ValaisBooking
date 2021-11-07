
using System.ComponentModel.DataAnnotations;


namespace DTO
{
    public class CheckInDate : ValidationAttribute
    {
        #region Validation reservation checkin date - properties

        private int DefaultDaysover { get; set; }

        #endregion

        #region Validation reservation checkin date - constructors

        public CheckInDate(int daysover) { DefaultDaysover = daysover; }

        #endregion

        #region Validation reservation checkin date - process

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var reservation = validationContext.ObjectInstance as Reservation;
            if (!reservation.CheckInFuturValidation(DefaultDaysover))
            {
                return new ValidationResult($"Checkin Date has to be minimum {DefaultDaysover} day(s) over in the future");
            }
            return ValidationResult.Success;
        }

        #endregion
    }
}
