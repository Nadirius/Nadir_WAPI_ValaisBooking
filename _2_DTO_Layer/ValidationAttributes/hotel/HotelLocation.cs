using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTO
{
    public class HotelLocation : ValidationAttribute
    {
        public string [] locations { get; set; }

        public HotelLocation(string[] locations)
        {

        }
 
    }
}
