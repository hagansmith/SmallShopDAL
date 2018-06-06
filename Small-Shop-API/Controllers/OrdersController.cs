using System.Net;
using System.Net.Http;
using System.Web.Http;
using Small_Shop_API.Products;
using Small_Shop_API.Models;
using Small_Shop_API.Services;

namespace Small_Shop_API.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        // GET api/orders
        [Route, HttpGet]
        public HttpResponseMessage GetOrderLineItems()
        {
            var orders = new OrdersRepository();
            var results = orders.Get();
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        // POST api/order
        [Route, HttpPost]
        public HttpResponseMessage PostOrderLineItems(Order order)
        {
            var repo = new OrdersRepository();
            var result =  repo.Post(order);
            return result == 1 ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not save order");
        }
    }
}
