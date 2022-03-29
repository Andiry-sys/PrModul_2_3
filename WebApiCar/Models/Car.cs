using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace WebApiCar.Models
{
    public class Car
    {
        [Required]
        public string NameCar { get; set; }
        public string Color { get; set; }
        public string Manufacturer { get; set; }
        public DateTime DateCreate { get; set; }
        public string Engine { get; set; }
    }
}
