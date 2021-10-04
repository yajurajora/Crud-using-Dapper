using CrudInDapper.Abstraction;
using CrudInDapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrudInDapper.Controllers
{
    public class StudentController : Controller
    {
        private readonly IDapper _dapper;
        public StudentController(IDapper dapper)
        {
            _dapper = dapper;
        }
        // GET: StudentController
        public async Task<IActionResult> Index()
        {                    
            return View(await _dapper.GetAllStudent());
        }
        

        // GET: StudentController/Details/5
        public async Task<ActionResult<Student>> Details(int id)
        {
            var student = await _dapper.GetStudentById(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Student>> Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dapper.InsertStudent(student);
                    return RedirectToAction("Index");
                }

                return View(student);
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public async Task<ActionResult<Student>> Edit(int id)
        {
            var student = await _dapper.GetStudentById(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Student>> Edit(int id,Student student)
        {
            try
            {
                // TODO: Add update logic here                
                await _dapper.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        // GET: StudentController/Delete/5
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var student = await _dapper.GetStudentById(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Student>>Delete(Student student,int id)
        {
            try
            {
                // TODO: Add delete logic here
                await _dapper.DeleteStudent(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
