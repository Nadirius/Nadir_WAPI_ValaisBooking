
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    class HotelCategory : ValidationAttribute
    {
        #region Validation hotel category - properties

        private int? DefaultminStar { get; set; } = 1;
        private int? DefaultmaxStar { get; set; } = 5;

        #endregion

        #region Validation hotel category - constructors

        public HotelCategory(int minStar, int maxStar) {
            DefaultminStar = minStar;
            DefaultmaxStar = maxStar;
        }

        public HotelCategory(){}

        #endregion

        #region Validation hotel category - process

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var hotel = validationContext.ObjectInstance as Hotel;
            if (!hotel.HotelCategoryValidation(DefaultminStar, DefaultmaxStar))
            {
                return new ValidationResult($"Hotel category has to be between {DefaultminStar} and {DefaultmaxStar} stars");
            }
            return ValidationResult.Success;
        }

        #endregion
    }
}
