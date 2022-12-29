using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Garage_my_version.Models
{
    public class Vehicle
    {
        //Vissa input vill vi inte att användaren skall kunna skriva hur de vill i fritext. Inte för långa
        //namn.Inga minus värden på antal hjul osv.
        public int Id { get; set; }

        public VehicleColor VehicleColor { get; set; }

        public VehicleBrand VehicleBrand { get; set; } //

        public VehicleType VehicleType { get; set; } //buss bil cykel osv?

        [Range(0, 16)]
        public int Wheels { get; set; }

        [Required]
        [MaxLength(8)]
        [MinLength(0)]
        public string RegistrationNr { get; set; } = string.Empty;

        [MaxLength(10)]
        [MinLength(0)]
        public string Model { get; set; }

        [Required]
        DateTime TimeOfArrival { get; set; }
    }
}
