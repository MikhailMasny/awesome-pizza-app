﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Masny.Pizza.Data.Models
{
    public class User : IdentityUser
    {
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<DeliveryAddress> DeliveryAddresses { get; set; }

        //public Profile Profile { get; set; }
    }
}
