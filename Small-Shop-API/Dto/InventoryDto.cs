using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Newtonsoft.Json;
using Small_Shop_API.Models;

namespace Small_Shop_API.Dto
{
    public class InventoryDto
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("variantId")] public long VariantId { get; set; }
        [JsonProperty("sku")] public string Sku { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("image")] public string Image { get; set; }
        [JsonProperty("inventory_quantity")] public int Inventory_Quantity { get; set; }
        [JsonProperty("reorderDate")] public DateTime ReorderDate { get; set; }
        [JsonProperty("orderedInventoryQty")] public int OrderedInventoryQty { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
    }
}