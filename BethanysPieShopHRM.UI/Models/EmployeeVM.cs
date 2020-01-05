using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BethanysPieShopHRM.Shared
{
    public class EmployeeVM : IValidatableObject
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name is too long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name is too long.")]
        public string LastName { get; set; }

        [BirthdayValidator]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [ValidateComplexType]
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool Smoker { get; set; }
        public bool IsOPEX { get; set; }
        public bool IsFTE { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Gender Gender { get; set; }
        [StringLength(1000, ErrorMessage = "Comment length can't exceed 1000 characters.")]
        public string Comment { get; set; }
        public DateTime? JoinedDate { get; set; }
        public DateTime? ExitDate { get; set; }

        public int JobCategoryId { get; set; }
        public JobCategory JobCategory { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (Latitude != 0 && Longitude == 0)
            {
                errors.Add(new ValidationResult("Longitude is required if Latitude is not empty.", new[] { nameof(Longitude) }));
            }

            if (Longitude != 0 && Latitude == 0)
            {
                errors.Add(new ValidationResult("Latitude is required if Longitude is not empty.", new[] { nameof(Latitude) }));
            }

            return errors;
        }
    }
}
