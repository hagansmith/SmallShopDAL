using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Small_Shop_API.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public long VariantId { get; set; }
        public int Available { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}