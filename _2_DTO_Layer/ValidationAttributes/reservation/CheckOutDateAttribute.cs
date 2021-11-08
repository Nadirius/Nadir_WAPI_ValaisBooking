
using System.ComponentModel.DataAnnotations;


namespace DTO
{
    public class CheckOutDateAttribute : ValidationAttribute
    {
        public int DefaultDaysover { get; private set; }

        public CheckOutDateAttribute(int daysover) { DefaultDaysover = daysover; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var reservation = validationContext.ObjectInstance as Reservation;
            if (!(reservation.CheckOutAfterCheckInValidation(DefaultDaysover)))
            {
                return new ValidationResult($"Checkout date has to be minimum {DefaultDaysover} day(s) over checkin date");
            }
            return ValidationResult.Success;
        }
    }
}
