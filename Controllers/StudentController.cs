using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLiteWeb.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SQLiteWeb.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext _context;
        public StudentController(SchoolContext context)
        {
            _context = context;
        }
        // index
        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        // create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // edit
        public IActionResult Edit(int? id)
        {
            Student student = _context.Students.SingleOrDefault(x => x.Id == id);
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            _context.Update(student);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // delete
        public IActionResult Delete(int? id)
        {
            Student student = _context.Students.SingleOrDefault(x => x.Id == id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Student student)
        {
            _context.Remove(student);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
