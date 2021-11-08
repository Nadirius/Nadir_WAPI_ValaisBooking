
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    class HotelCategoryAttribute : ValidationAttribute
    {

        private int? DefaultminStar { get; set; } = 1;
        private int? DefaultmaxStar { get; set; } = 5;

        public HotelCategoryAttribute(int minStar, int maxStar) {
            DefaultminStar = minStar;
            DefaultmaxStar = maxStar;
        }

        public HotelCategoryAttribute(){}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var hotel = validationContext.ObjectInstance as Hotel;
            if (!hotel.HotelCategoryValidation(DefaultminStar, DefaultmaxStar))
            {
                return new ValidationResult($"Hotel category has to be between {DefaultminStar} and {DefaultmaxStar} stars");
            }
            return ValidationResult.Success;
        }
    }
}
