using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class Address
    {
        [Required]
        public string Street { get; set; }
        public string Zip { get; set; }
    }
}
