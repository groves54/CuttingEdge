using CuttingEdge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuttingEdge.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext;
        public ProductsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Products
        public ActionResult Index()
        {
            var products = _dbContext.Product.ToList();
            return View(products);
        }
        public ActionResult New()
        {
            return View();
        }
        [Authorize]public ActionResult Add(Product product)
        {
            _dbContext.Product.Add(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var product = _dbContext.Product.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            var productInDb = _dbContext.Product.SingleOrDefault(p => p.Id == product.Id);

            if (productInDb == null)
                return HttpNotFound();

            productInDb.Title = product.Title;
            productInDb.Description = product.Description;
            productInDb.price = product.price;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var product = _dbContext.Product.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }
        [HttpPost]
        public ActionResult DoDelete(int id)
        {
            var product = _dbContext.Product.SingleOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();
            _dbContext.Product.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}