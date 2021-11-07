
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class RoomType : ValidationAttribute
    {
        #region Validation room type - process

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var room = validationContext.ObjectInstance as Room;
            if (!room.RoomTypeValidation())
            {
                return new ValidationResult($"Room types not provided");
            }
            return ValidationResult.Success;
        }

        #endregion
    }
}
