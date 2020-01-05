using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class Contact
    {
        public int ContactId { get; set;}
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string EmergencyPhoneNumber { get; set; }

        public string EmergencyName { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
