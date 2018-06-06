using System.Net;
using System.Net.Http;
using System.Web.Http;
using Small_Shop_API.Products;
using Small_Shop_API.Models;
using Small_Shop_API.Services;

namespace Small_Shop_API.Controllers
{
    [RoutePrefix("api/lineItems")]
    public class OrdersController : ApiController
    {
        // GET api/LineItems
        [Route, HttpGet]
        public HttpResponseMessage GetOrderLineItems()
        {
            var items = new OrdersRepository();
            var results = items.Get();
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        // POST api/LineItems
        [Route, HttpPost]
        public HttpResponseMessage PostOrderLineItems(Order order)
        {
            var repo = new OrdersRepository();
            var result =  repo.Post(order);

            return result == 1 ? Request.CreateResponse(HttpStatusCode.Created) : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not process your order, try again later...");
        }
    }
}
