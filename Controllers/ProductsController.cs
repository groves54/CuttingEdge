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
        public ActionResult Add(Product product)
        {
            _dbContext.Product.Add(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}