using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.WebApplication.DAL;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private IProduct _productEf;

        public ProductsController(IProduct productEf) 
        {
            _productEf = productEf;
        }

        // GET: ProductsController
        public ActionResult Index(string productName = "")
        {
            //if (TempData["Message"] != null)
            //{
            //    ViewBag.Message = TempData["Message"];
            //}

            //IEnumerable<Product> products;
            //if (productName != "")
            //{
            //    products = _productEf.GetByProductName(productName);
            //}
            //else
            //{
            //    products= _productEf.GetAll();
            //}

            var products = _productEf.GetAll();

            return View(products);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var product = _productEf.GetById(id);
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                var result = _productEf.Add(product);
                TempData["Message"] = $"Product {product.ProductName} added successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Product not added";
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
