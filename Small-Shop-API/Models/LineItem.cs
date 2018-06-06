using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Small_Shop_API.Models
{
    public partial class LineItem
    {
        [JsonProperty("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [JsonProperty("variant_id")]
        public string VariantId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("variant_title")]
        public string VariantTitle { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("fulfillment_service")]
        public string FulfillmentService { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("requires_shipping")]
        public bool RequiresShipping { get; set; }

        [JsonProperty("taxable")]
        public bool Taxable { get; set; }

        [JsonProperty("gift_card")]
        public bool GiftCard { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("variant_inventory_management")]
        public string VariantInventoryManagement { get; set; }

        [JsonProperty("properties")]
        public List<object> Properties { get; set; }

        [JsonProperty("product_exists")]
        public bool ProductExists { get; set; }

        [JsonProperty("fulfillable_quantity")]
        public int FulfillableQuantity { get; set; }

        [JsonProperty("grams")]
        public int Grams { get; set; }

        [JsonProperty("total_discount")]
        public string TotalDiscount { get; set; }

        [JsonProperty("fulfillment_status")]
        public object FulfillmentStatus { get; set; }

        [JsonProperty("tax_lines")]
        public List<object> TaxLines { get; set; }
    }
}
