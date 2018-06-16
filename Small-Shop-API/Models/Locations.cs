using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Small_Shop_API.Models
{
    public class Locations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Available { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}