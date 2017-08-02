using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3;
using WebApplication3.Controllers;
using WebApplication3.Models;

namespace WebApplication3.Test.Controllers
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void Get_All_Test()
        {
            ProductsController productsController = new ProductsController();

            var result = productsController.Get();

            Assert.AreEqual(0, result.Count());

        }

        [TestMethod]
        public void Get_single_Test()
        {
            Product p1 = new Product() {
                Id = "1",
                Brand = "Lv"
            };

            ProductsController.productLIst.Add(p1);

            ProductsController productsController = new ProductsController();

            var result = productsController.Get(1);

            Assert.AreEqual("Lv", result.Brand);

        }

        [TestMethod]
        public void Delete_Test()
        {
            Product p1 = new Product()
            {
                Id = "1",
                Brand = "Lv"
            };

            ProductsController.productLIst.Add(p1);

            ProductsController productsController = new ProductsController();

            var result = productsController.Delete(1);

            Assert.AreEqual("success", result);

        }
        [TestMethod]
        public void Post_Test()
        {
            Product p1 = new Product()
            {
                Id = "3",
                Brand = "Lv"
            };

            ProductsController productsController = new ProductsController();

            var result = productsController.Post(p1);

            Assert.AreEqual("success", result);

        }

        [TestMethod]
        public void Put_Test()
        {
            Product p1 = new Product()
            {
                Id = "1",
                Brand = "LV"
            };

            Product p2 = new Product()
            {
                Id = "1",
                Brand = "LV2"
            };

            ProductsController.productLIst.Add(p1);

            ProductsController productsController = new ProductsController();

            var result = productsController.Put(1, p2);
        }

    }
}
