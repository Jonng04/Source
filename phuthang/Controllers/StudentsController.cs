using Microsoft.AspNetCore.Mvc;
using StudentTeacherManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentTeacherManagement.Controllers
{
    public class StudentsController : Controller
    {
        private static List<Student> students = new List<Student>();

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(string id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(string id, Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingStudent = students.FirstOrDefault(s => s.StudentId == id);
                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Email = student.Email;
                    existingStudent.Age = student.Age;
                    existingStudent.ClassCode = student.ClassCode;
                }
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(string id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("Index");
        }
    }
}