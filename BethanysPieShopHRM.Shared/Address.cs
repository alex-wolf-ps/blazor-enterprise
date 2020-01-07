using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class Address : IValidatableObject
    {
        public int AddressId { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (Latitude != 0 && Longitude == 0)
            {
                errors.Add(new ValidationResult(
                    "Longitude is required if Latitude has a value.",
                    new[] { nameof(Longitude) }));
            }
            else if (Longitude != 0 && Latitude == 0)
            {
                errors.Add(new ValidationResult(
                    "Latitude is required if Longitude has a value.",
                    new[] { nameof(Latitude) }));
            }

            return errors;
        }
    }
}
