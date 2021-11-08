
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class RoomTypeAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var room = validationContext.ObjectInstance as Room;
            if (!room.RoomTypeValidation())
            {
                return new ValidationResult($"Room types not provided");
            }
            return ValidationResult.Success;
        }
    }
}
