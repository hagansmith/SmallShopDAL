using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Small_Shop_API.Dto
{
    public class ProductCountDto
    {
        public long Id { get; set; }
        public int inventory_quantity { get; set; }
        public int option2 { get; set; }
        public string location { get; set; }
    }
}