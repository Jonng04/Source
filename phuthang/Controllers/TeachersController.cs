using Microsoft.AspNetCore.Mvc;
using StudentTeacherManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentTeacherManagement.Controllers
{
    public class TeachersController : Controller
    {
        private static List<Teacher> teachers = new List<Teacher>();

        public IActionResult Index()
        {
            return View(teachers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teachers.Add(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        public IActionResult Edit(string id)
        {
            var teacher = teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(string id, Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingTeacher = teachers.FirstOrDefault(t => t.TeacherId == id);
                if (existingTeacher != null)
                {
                    existingTeacher.Name = teacher.Name;
                    existingTeacher.Email = teacher.Email;
                    existingTeacher.Age = teacher.Age;
                }
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        public IActionResult Delete(string id)
        {
            var teacher = teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var teacher = teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher != null)
            {
                teachers.Remove(teacher);
            }
            return RedirectToAction("Index");
        }
    }
}