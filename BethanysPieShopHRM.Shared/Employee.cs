using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BethanysPieShopHRM.Shared
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
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
    }
}
