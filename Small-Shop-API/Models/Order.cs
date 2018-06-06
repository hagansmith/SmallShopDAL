using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Small_Shop_API.Models
{
    public partial class Order
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("closed_at")]
        public DateTime ClosedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("gateway")]
        public string Gateway { get; set; }

        [JsonProperty("test")]
        public bool Test { get; set; }

        [JsonProperty("total_price")]
        public string TotalPrice { get; set; }

        [JsonProperty("subtotal_price")]
        public string SubtotalPrice { get; set; }

        [JsonProperty("total_weight")]
        public int TotalWeight { get; set; }

        [JsonProperty("total_tax")]
        public string TotalTax { get; set; }

        [JsonProperty("taxes_included")]
        public bool TaxesIncluded { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("financial_status")]
        public string FinancialStatus { get; set; }

        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }

        [JsonProperty("total_discounts")]
        public string TotalDiscounts { get; set; }

        [JsonProperty("total_line_items_price")]
        public string TotalLineItemsPrice { get; set; }

        [JsonProperty("cart_token")]
        public long CartToken { get; set; }

        [JsonProperty("buyer_accepts_marketing")]
        public bool BuyerAcceptsMarketing { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("referring_site")]
        public object ReferringSite { get; set; }

        [JsonProperty("landing_site")]
        public string LandingSite { get; set; }

        [JsonProperty("cancelled_at")]
        public DateTime CancelledAt { get; set; }

        [JsonProperty("cancel_reason")]
        public string CancelReason { get; set; }

        [JsonProperty("total_price_usd")]
        public string TotalPriceUsd { get; set; }

        [JsonProperty("checkout_token")]
        public string CheckoutToken { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("source_identifier")]
        public int SourceIdentifier { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        [JsonProperty("processed_at")]
        public DateTime ProcessedAt { get; set; }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("customer_locale")]
        public string CustomerLocale { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("browser_ip")]
        public string BrowserIp { get; set; }

        [JsonProperty("landing_site_ref")]
        public string LandingSiteRef { get; set; }

        [JsonProperty("order_number")]
        public long OrderNumber { get; set; }

        [JsonProperty("discount_codes")]
        public List<object> DiscountCodes { get; set; }

        [JsonProperty("note_attributes")]
        public List<object> NoteAttributes { get; set; }

        [JsonProperty("payment_gateway_names")]
        public List<string> PaymentGatewayNames { get; set; }

        [JsonProperty("processing_method")]
        public string ProcessingMethod { get; set; }

        [JsonProperty("checkout_id")]
        public string CheckoutId { get; set; }

        [JsonProperty("source_name")]
        public string SourceName { get; set; }

        [JsonProperty("fulfillment_status")]
        public string FulfillmentStatus { get; set; }

        [JsonProperty("tax_lines")]
        public List<string> TaxLines { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("contact_email")]
        public string ContactEmail { get; set; }

        [JsonProperty("order_status_url")]
        public string OrderStatusUrl { get; set; }

        [JsonProperty("line_items")]
        public virtual List<LineItem> LineItems { get; set; }

        [JsonProperty("shipping_lines")]
        public List<ShippingLine> ShippingLines { get; set; }

        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("fulfillments")]
        public List<string> Fulfillments { get; set; }

        [JsonProperty("refunds")]
        public List<string> Refunds { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }
    }
}
