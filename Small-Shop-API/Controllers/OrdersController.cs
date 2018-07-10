using System.Net;
using System.Net.Http;
using System.Web.Http;
using Small_Shop_API.Models;
using Small_Shop_API.Services;

namespace Small_Shop_API.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        // GET api/orders
        [Authorize]
        [Route, HttpGet]
        public HttpResponseMessage GetOrderLineItems()
        {
            var orders = new OrdersRepository();
            var results = orders.Get();
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        // POST api/orders
        [Route, HttpPost]
        public HttpResponseMessage PostOrder(Order orders)
        {
            try
            {
                var parse = new Parser();
                var ords = parse.ParseOrders(orders);
                var postCount = 0;

                foreach (Order ord in ords)
                {
                    var repo = new OrdersRepository();
                    var result = repo.Post(ord);
                    postCount += 1;
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                var repo = new OrdersRepository();
                var result = repo.Post(orders);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}