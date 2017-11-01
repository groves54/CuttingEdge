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
    }
}