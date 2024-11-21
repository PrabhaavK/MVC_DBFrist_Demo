using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_DBFirst_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC_DBFirst_Demo.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        
        public ProductController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var data = _context.Products;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product newproduct)
        {
            if (ModelState.IsValid){

                _context.Products.Add(newproduct);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.Products.Find(id);
            return View(data);
        }

        
        [HttpPost]
        public IActionResult Delete(int id, Product product)
        {
            if (ModelState.IsValid){

                _context.Products.Remove(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            //var data = _context.Products.Find(id);
            return View();
        }

        
        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            if (ModelState.IsValid){

                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Data = _context.Products.Find(id);
            return View(Data);
        }
        
    }
}
