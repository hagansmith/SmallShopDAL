using System.Net;
using System.Net.Http;
using System.Web.Http;
using Small_Shop_API.Services;

namespace Small_Shop_API.Controllers
{
    [RoutePrefix("api/onOrder")]
    public class OnOrderController : ApiController
    {
        // GET api/onOrder
        [Authorize]
        [Route, HttpGet]
        public HttpResponseMessage Get()
        {
            var repo = new ProductsRepository();
            var results = repo.GetProductsOnReorder();
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        // POST api/onOrder/1234567890123/500
        [Authorize]
        [Route("{sku}/{count}"), HttpPost]
        public HttpResponseMessage OnOrderUpdater(string sku, int count)
        {
            var repo = new ProductsRepository();
            var results = repo.CreateReorder(sku, count);
            return results == 1 ? Request.CreateResponse(HttpStatusCode.Created) : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unable to process request");
        }

        // PATCH api/onOrder/1234567890123/250
        [Authorize]
        [Route("{id}/{count}"), HttpPut]
        public HttpResponseMessage RecieveInventory(int id, int count)
        {
            var repo = new ProductsRepository();
            var results = repo.Receive(id, count);
            return results == 1 ? Request.CreateResponse(HttpStatusCode.Created) : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unable to process request");
        }
    }
}
