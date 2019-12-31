using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
