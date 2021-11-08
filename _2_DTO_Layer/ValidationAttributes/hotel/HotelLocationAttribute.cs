using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTO
{
    public class HotelLocationAttribute : ValidationAttribute
    {
        public string [] locations { get; set; }

        public HotelLocationAttribute(string[] locations)
        {

        }
 
    }
}
