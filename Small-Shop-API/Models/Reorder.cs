using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace Small_Shop_API.Models
{
    public class Reorder
    {
        public long id { get; set; }
        public long variantId { get; set; }
        public int quantity { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime dateReceived { get; set; }
        public int quantityRecieved { get; set; }
    }
}