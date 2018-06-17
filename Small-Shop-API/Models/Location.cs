using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Small_Shop_API.Models
{
    public class Location
    {
        public int Id { get; set; }
        public long VariantId { get; set; }
        public string Name { get; set; }
        public int Available { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}