using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Categories;
            return View(objList);
        }

        //GET Create
        public IActionResult Create()
        {
            return View();
        }
        //POST Create
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //GET Edit
        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categories.Single(o => o.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST Edit
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //POST Edit
        
        public IActionResult Delete(int? id)
        {
            var obj = _db.Categories.Single(o => o.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
