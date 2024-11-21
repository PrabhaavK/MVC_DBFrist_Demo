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
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var data = _context.Categories;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category newcategory)
        {
            if (ModelState.IsValid){

                _context.Categories.Add(newcategory);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.Categories.Find(id);
            return View(data);
        }

        
        [HttpPost]
        public IActionResult Delete(int id, Category category)
        {
            if (ModelState.IsValid){

                _context.Categories.Remove(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Edit(int id, Category category)
        {
            if (ModelState.IsValid){

                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Data = _context.Categories.Find(id);
            return View(Data);
        }
    }
}




