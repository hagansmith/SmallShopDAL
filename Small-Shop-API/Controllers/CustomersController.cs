using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Small_Shop_API.Models;
using Small_Shop_API.Services;

namespace Small_Shop_API.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/customers
        [Route, HttpPost]
        public HttpResponseMessage Post(object customers)
        {
            var parse = new Parser();
            var custs = parse.ParseCustomers(customers);
            var postCount = 0;

            foreach (Customer customer in custs)
            {
                var repo = new CustomersRepository();
                var result = repo.Post(customer);
                postCount += 1;
            }

            return custs.Count == postCount ? Request.CreateResponse(HttpStatusCode.Created) : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not save customer, try again later...");
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}