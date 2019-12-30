using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class Order
    {
        [Required]
        public string Title { get; set; }

        [ValidateComplexType]
        public Address DeliveryAddress { get; set; }
    }
}
