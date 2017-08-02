using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductsController : ApiController
    {
        public static List<Product> productLIst = new List<Product>();
        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            return productLIst;
        }

        // GET: api/Product/5
        public Product Get(int id)
        {
            foreach (Product P in productLIst)
            {
                int productId = int.Parse(P.Id);
                if (productId == id)
                {
                    return P;
                }
            }

            return null;
        }

        // POST: api/Product
        public string Post(Product product)
        {
            foreach (Product p in productLIst)
            {
                int id = int.Parse(product.Id);
                int productId = int.Parse(p.Id);
                if (productId == id)
                {
                    return "already exist";
                }
            }
            productLIst.Add(product);
            return "success";

        }

        // PUT: api/Product/5
        public String Put(int id, Product product)
        {
            foreach (Product p in productLIst)
            {
                int productID = int.Parse(p.Id);
                if (productID == id)
                {
                    p.Brand = product.Brand;
                    p.Description = product.Description;
                    p.Model = product.Model;
                    return "success";
                }
            }

            return "no data to update";
        }

        // DELETE: api/Product/5
        public string Delete(int id)
        {
            foreach (Product p in productLIst)
            {
                int productId = int.Parse(p.Id);
                if (productId == id)
                {
                    productLIst.Remove(p);
                    return "success";
                }
            }

            return "no data to delete";

        }
    }
}
