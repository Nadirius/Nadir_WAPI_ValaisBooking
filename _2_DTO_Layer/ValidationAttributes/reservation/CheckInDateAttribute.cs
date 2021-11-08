
using System.ComponentModel.DataAnnotations;


namespace DTO
{
    public class CheckInDateAttribute : ValidationAttribute
    {

        private int DefaultDaysover { get; set; }

        public CheckInDateAttribute(int daysover) { DefaultDaysover = daysover; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var reservation = validationContext.ObjectInstance as Reservation;
            if (!reservation.CheckInFuturValidation(DefaultDaysover))
            {
                return new ValidationResult($"Checkin Date has to be minimum {DefaultDaysover} day(s) over in the future");
            }
            return ValidationResult.Success;
        }
    }
}
