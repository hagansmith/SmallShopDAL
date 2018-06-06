using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Small_Shop_API.Models
{
    public partial class Image
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("alt")]
        public string Alt { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("variant_ids")]
        public List<object> VariantIds { get; set; }
    }
}