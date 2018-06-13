using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shopify_DB_WriterAPI.Products;
using Small_Shop_API.Models;
using Small_Shop_API.Products;
using Small_Shop_API.Services;

namespace Small_Shop_API.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        // GET api/products/variants
        [Authorize]
        [Route("variants"), HttpGet]
        public HttpResponseMessage GetProducts()
        {
            var products = new ProductsRepository();
            var results = products.Get();
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        // GET api/products/
        [Authorize]
        [Route, HttpGet]
        public HttpResponseMessage Get()
        {
            var repo = new ProductsRepository();
            var results = repo.GetLowStock();
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        // GET api/products/1234567890123
        [Authorize]
        [Route("{id}"), HttpGet]
        public HttpResponseMessage Get(string id)
        {
            var repo = new ProductsRepository();
            var product = repo.GetProductById(id);

            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        // POST api/products
        [Route, HttpPost]
        public HttpResponseMessage Post(object products)
        {
            var parse = new ProductParser();
            var prods = parse.Parse(products);
            var postCount = 0;

            foreach (Product product in prods)
            {
                var repo = new ProductsRepository();
                var result = repo.Post(product);
                postCount += 1;
            }

            return prods.Count == postCount ? Request.CreateResponse(HttpStatusCode.Created) : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not save product, try again later...");
        }

        // PUT api/products/1234567890123
        [Authorize]
        [Route("{id}"), HttpPut]
        public HttpResponseMessage Put(Variant productVariant)
        {
            var repo = new ProductsRepository();
            var product = repo.Edit(productVariant);

            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        // PATCH api/products/update
        [Authorize]
        [Route("update"), HttpPut]
        public HttpResponseMessage Patch(Variant details)
        {
            var repo = new ProductsRepository();
            var update = repo.PatchCount(details);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // Delete api/products/id
        [Authorize]
        [Route("{id}"), HttpDelete]
        public HttpResponseMessage Delete(long id)
        {
            var repo = new ProductsRepository();
            var results = repo.Delete(id);

            return results == 1 ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "A product with that id already exists");
        }
    }
}
