using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Small_Shop_API.Models
{
    public partial class Variant
    {
        [JsonProperty("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("inventory_policy")]
        public string InventoryPolicy { get; set; }

        [JsonProperty("compare_at_price")]
        public string CompareAtPrice { get; set; }

        [JsonProperty("fulfillment_service")]
        public string FulfillmentService { get; set; }

        [JsonProperty("inventory_management")]
        public string InventoryManagement { get; set; }

        [JsonProperty("option1")]
        public string Option1 { get; set; }

        [JsonProperty("option2")]
        public string Option2 { get; set; }

        [JsonProperty("option3")]
        public string Option3 { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("taxable")]
        public bool Taxable { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("grams")]
        public int Grams { get; set; }

        [JsonProperty("image_id")]
        public string ImageId { get; set; }

        [JsonProperty("inventory_quantity")]
        public int InventoryQuantity { get; set; }

        [JsonProperty("weight")]
        public float Weight { get; set; }

        [JsonProperty("weight_unit")]
        public string WeightUnit { get; set; }

        [JsonProperty("inventory_item_id")]
        public long InventoryItemId { get; set; }

        [JsonProperty("old_inventory_quantity")]
        public int OldInventoryQuantity { get; set; }

        [JsonProperty("minumum_stock")]
        public int MinimumStock { get; set; }

        [JsonProperty("allocated_stock")]
        public int AllocatedStock { get; set; }

        [JsonProperty("requires_shipping")]
        public bool RequiresShipping { get; set; }
    }
}