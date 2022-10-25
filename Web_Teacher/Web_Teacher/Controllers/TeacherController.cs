using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Teacher_Data;
using Teacher_Service;
using Web_Teacher.Models;

namespace Web_Teacher.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacher_Service teacher_Service;

        public TeacherController(ITeacher_Service teacher_Service)
        {
            this.teacher_Service = teacher_Service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = teacher_Service.GetAllTeachers();
            return View(model);
        }

        [HttpGet]
        public IActionResult Addteacher()
        {
            TeacherViewModel model = new TeacherViewModel();
            return View("Addteacher", model);
        }

        [HttpPost]
        public IActionResult Addteacher(TeacherViewModel model)
        {
            Teacher teach = new Teacher
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
            };

            teacher_Service.Insert(teach);
            if (teach.Id > 0)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditTeacher(int? Id)
        {
            //StudentViewModel model = new StudentViewModel();
            //if(Id.HasValue && Id.Value >0)
            //{
            Teacher std = teacher_Service.GetTeacher(Id);
            //    model.Name = std.Name;
            //    model.Classroom = std.Classroom;
            //    model.DateOfBirth = std.DateOfBirth;
            //}
            return View("EditTeacher", std);
        }

        [HttpPost]
        public IActionResult EditTeacher(TeacherViewModel model)
        {
            Teacher std = teacher_Service.GetTeacher(model.Id);
            std.FirstName = model.FirstName;
            std.LastName = model.LastName;
            std.DateOfBirth = model.DateOfBirth;
            teacher_Service.Update(std);
            if (std.Id > 0)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteTeacher(int? Id)
        {
            Teacher student = teacher_Service.GetTeacher(Id);
            return View("DeleteTeacher", student);
        }

        [HttpPost]
        public IActionResult DeleteTeacher(int? Id, TeacherViewModel model)
        {
            Teacher std = teacher_Service.GetTeacher(Id);
            teacher_Service.Delete(std);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> StudentList()
        {
            TeacherViewModel model = new TeacherViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7200/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("StudentLists");  //api/Student/
                if (response.IsSuccessStatusCode)
                {
                    var details = response.Content.ReadAsAsync<IEnumerable<StudentViewModel>>().Result;

                    return View(details);
                    //return Ok(details);
                }
                else
                {
                    return View();
                }
            }
            
        }

        public IActionResult GetTeacherForTesting(int? Id)
        {
            var teacher = teacher_Service.GetTeacher(Id);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(teacher);
        }

        public IActionResult DeleteTeacherWithAReturn(Teacher teacher)
        {
            teacher_Service.Delete(teacher);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok("Delete successfully");
        }
    }
}
