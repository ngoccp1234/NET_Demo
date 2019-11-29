using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test7.Models;

namespace test7.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProduct(int Id, string Name, int Quantity)
        {

            bool checkProduct = false;
          
            var products = Session["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }

          
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id != null)
                {
                    checkProduct = true;
                    products[i].Quantity += Quantity;
                    break;
                }

            }

            if (!checkProduct)
            {
                Product product = new Product()
                {
                    Id = Id,
                    Name = Name,
                    Quantity = Quantity
                };
                  products.Add(product);
            }
          
          
            Session["products"] = products;
            return Redirect("/Products/Get");
        }

        public ActionResult Get()
        {
            var products = Session["products"] as List<Product>;
           
            ViewBag.Products = products;
            return View("Get");
        }
    }
}