using API01.DTO;
using API01.Models;
using API01.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //private readonly CompanyContext Db;

        IStudentReb studentRebo;

        public StudentController(IStudentReb studentReb)//DI
        {
            studentRebo = studentReb;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Students = studentRebo.GetAll();
            if (Students == null)
            {
                return NotFound();
            }
            List<StudentWithDepartment> studentWithDepartments = new List<StudentWithDepartment>();
            //List<string> Students = new List<string>();

            for (int i = 0; i < Students.Count; i++)
            {

                studentWithDepartments.Add(new StudentWithDepartment
                {

                    Name = Students[i].Name,
                    Adress = Students[i].Adress,
                    Age = Students[i].Age,
                    Id = Students[i].Id,
                    DepartmentName = Students[i].department.Name
                    //MgrName = depts[i].MgrName,
                    //Location = depts[i].Location,
                    //OpenDate = depts[i].OpenDate,
                    //StudentNames = Students
                });
            }
                return Ok(studentWithDepartments);
            }
            [HttpGet]
            [Route("{id:int}")]
            public IActionResult GetById(int id)
            {
                var stds = studentRebo.GetById(id);
                if (stds == null)
                {
                    return NotFound();
                }
                return Ok(new { msg = $"student with ID {id} Found , and here it is ", student = stds });
            }
            [HttpGet]
            [Route("{name:alpha}")]
            public IActionResult GetByName(string name)
            {
                var stds
                    = studentRebo.GetByName(name);
                if (stds == null)
                {
                    return NotFound();
                }
                return Ok(new { msg = $"student with Name {name} Found , and here it is ", Student = stds });
            }
            [HttpPost]

            public IActionResult Add(Student std)
            {
                if (ModelState.IsValid)
                {
                    studentRebo.Add(std);
                    //return Ok(department);
                    return Created($"http://localhost:5035/api/Student/{std.Id}", std);
                }
                return BadRequest();
            }
            [HttpPut]
            public IActionResult Update(Student Std)
            {
                if (ModelState.IsValid)
                {

                    studentRebo.Update(Std);
                    return NoContent();
                }
                return BadRequest();
            }
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {

                var Std = studentRebo.Delete(id);
                if (Std == null)
                {
                    return NotFound("Not found");
                }

                return Ok(Std);
            }
        }
    } 

