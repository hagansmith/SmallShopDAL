﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Small_Shop_API.Dto;
using Small_Shop_API.Models;
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
            var parse = new Parser();
            var prods = parse.ParseProducts(products);
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
        public HttpResponseMessage Patch(ProductCountDto details)
        {
            var repo = new ProductsRepository();
            var update = repo.PatchCount(details);
            return update
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unable to process request");
        }

        // Update api/products/id/deactivate
        [Authorize]
        [Route("{id}/deactivate"), HttpPut]
        public HttpResponseMessage Deactivate(long id)
        {
            var repo = new ProductsRepository();
            var results = repo.Deactivate(id);

            return results ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unable to update");
        }

        // Update api/products/id/activate
        [Authorize]
        [Route("{id}/activate"), HttpPut]
        public HttpResponseMessage Activate(long id)
        {
            var repo = new ProductsRepository();
            var results = repo.Activate(id);

            return results ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unable to update");
        }
    }
}
