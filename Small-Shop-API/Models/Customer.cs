﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Small_Shop_API.Models
{
    public partial class Customer
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("accepts_marketing")]
        public bool AcceptsMarketing { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("orders_count")]
        public long OrdersCount { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("total_spent")]
        public string TotalSpent { get; set; }

        [JsonProperty("last_order_id")]
        public string LastOrderId { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("verified_email")]
        public bool VerifiedEmail { get; set; }

        [JsonProperty("multipass_identifier")]
        public string MultipassIdentifier { get; set; }

        [JsonProperty("tax_exempt")]
        public bool TaxExempt { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("last_order_name")]
        public string LastOrderName { get; set; }

        [JsonProperty("default_address")]
        public Address DefaultAddress { get; set; }
    }
}
