using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Small_Shop_API.Models;

namespace Small_Shop_API.Services
{
    public class Parser
    {
        public List<Product> ParseProducts(object products)
        {
            JObject parsedObject = JObject.Parse(products.ToString());
            //get line items into list
            IList<JToken> prods = parsedObject["products"].Children().ToList();
            //Serialize results into objects
            IList<Product> allTheProducts = new List<Product>();
            foreach (JToken prod in prods)
            {
                //ToObject helper method part of newtonsoft JToken
                Product product = prod.ToObject<Product>();
                allTheProducts.Add(product);
            }

            return allTheProducts.ToList();
        }

        public List<Order> ParseOrders(object orders)
        {


            JObject parsedObject = JObject.Parse(orders.ToString());
            //get line items into list
            IList<JToken> ords = parsedObject["orders"].Children().ToList();
            //Serialize results into objects
            IList<Order> allTheOrders = new List<Order>();
            foreach (JToken ord in ords)
            {
                //ToObject helper method part of newtonsoft JToken
                Order order = ord.ToObject<Order>();
                allTheOrders.Add(order);
            }

            return allTheOrders.ToList();
        }


        public List<Customer> ParseCustomers(object customers)
        {
            JObject parsedObject = JObject.Parse(customers.ToString());
            //get line items into list
            IList<JToken> custs = parsedObject["customers"].Children().ToList();
            //Serialize results into objects
            IList<Customer> allTheCustomers = new List<Customer>();
            foreach (JToken cust in custs)
            {
                //ToObject helper method part of newtonsoft JToken
                Customer order = cust.ToObject<Customer>();
                allTheCustomers.Add(order);
            }

            return allTheCustomers.ToList();
        }
    }
}