using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Small_Shop_API.Models
{
    public partial class ShippingLine
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("requested_fulfillment_service_id")]
        public int RequestedFulfillmentServiceId { get; set; }

        [JsonProperty("delivery_category")]
        public int DeliveryCategory { get; set; }

        [JsonProperty("carrier_identifier")]
        public string CarrierIdentifier { get; set; }

        [JsonProperty("discounted_price")]
        public string DiscountedPrice { get; set; }

        [JsonProperty("tax_lines")]
        public List<object> TaxLines { get; set; }
    }
}
