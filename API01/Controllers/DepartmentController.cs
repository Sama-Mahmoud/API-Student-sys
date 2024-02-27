using API01.DTO;
using API01.Filters;
using API01.Models;
using API01.Services;
using API01.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartment departmentRebo;
        public DepartmentController(IDepartment db)
        {
            departmentRebo = db;
        }
        [HttpGet]
        public IActionResult GetAll() {
            var depts = departmentRebo.GetAll();
            if(depts == null)
            {
                return NotFound();
            }
            List<DepartmentWithStudent> departmentWithStudent =new List<DepartmentWithStudent>();

            for(int i =0;i<depts.Count;i++)
            {
                List<string> Students = new List<string>();
                foreach (var stds in depts[i].students)
                {
                    Students.Add(stds.Name);
                }
                departmentWithStudent.Add(new DepartmentWithStudent
                {
                    Id = depts[i].Id,
                    Name = depts[i].Name,
                    MgrName = depts[i].MgrName,
                    Location = depts[i].Location,
                    OpenDate = depts[i].OpenDate,
                    StudentNames = Students
                });
                //departmentWithStudent[i].Name = ;
                //departmentWithStudent[i].MgrName = depts[i].MgrName;
                //departmentWithStudent[i].Location = depts[i].Location;
                //departmentWithStudent[i].OpenDate = depts[i].OpenDate;

                

            }
            return Ok(departmentWithStudent);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id) {
            var dept = departmentRebo.GetById(id);
            if(dept == null)
            {
                return NotFound();
            }
            DepartmentWithStudent departmentWithStudent = new DepartmentWithStudent();
            departmentWithStudent.Id = dept.Id;

            departmentWithStudent.Name = dept.Name;
            departmentWithStudent.MgrName = dept.MgrName;
            departmentWithStudent.Location = dept.Location;
            departmentWithStudent.OpenDate = dept.OpenDate;

            foreach (var stds in dept.students)
            {
                departmentWithStudent.StudentNames.Add(stds.Name);
            }

            return Ok(new {msg = $"dept with ID {id} Found , and here it is " , Dept = departmentWithStudent });
        }
        [HttpGet]
        [Route("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            var dept = departmentRebo.GetByName(name);
            if (dept == null)
            {
                return NotFound();
            }
            DepartmentWithStudent departmentWithStudent = new DepartmentWithStudent();
            departmentWithStudent.Id = dept.Id;
            departmentWithStudent.Name = dept.Name;
            departmentWithStudent.MgrName = dept.MgrName;
            departmentWithStudent.Location = dept.Location;
            departmentWithStudent.OpenDate = dept.OpenDate;

            foreach (var stds in dept.students)
            {
                departmentWithStudent.StudentNames.Add(stds.Name);
            }
            return Ok(new { msg = $"dept with Name {name} Found , and here it is ", Dept = departmentWithStudent });
        }
        [HttpPost]
        [LocationFilter("USA", "EG")]
        public IActionResult Add(Department department) {
            if(ModelState.IsValid)
            {
                departmentRebo.Add(department);
                //return Ok(department);
                DepartmentWithStudent departmentWithStudent = new DepartmentWithStudent();
                departmentWithStudent.Id = department.Id;
                departmentWithStudent.Name = department.Name;
                departmentWithStudent.MgrName = department.MgrName;
                departmentWithStudent.Location = department.Location;
                departmentWithStudent.OpenDate = department.OpenDate;
                //departmentWithStudent.StudentNames.Add("null");

                if (department.students != null)
                {
                    foreach (var stds in department.students)
                    {
                        departmentWithStudent.StudentNames.Add(stds.Name);
                    }
                }
                return Created($"http://localhost:5035/api/Department/{department.Id}", departmentWithStudent);
            }
            return BadRequest();
        }
        [HttpPut]
        [LocationFilter("USA", "EG")]
        public IActionResult Update(Department department) {
            if (ModelState.IsValid)
            {
                departmentRebo.Update(department);
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) { 
            var dept = departmentRebo.GetById(id);
            if (dept == null)
            {
                return NotFound();
            }
            departmentRebo.Delete(id);
            DepartmentWithStudent departmentWithStudent = new DepartmentWithStudent();
            departmentWithStudent.Id = dept.Id;
            departmentWithStudent.Name = dept.Name;
            departmentWithStudent.MgrName = dept.MgrName;
            departmentWithStudent.Location = dept.Location;
            departmentWithStudent.OpenDate = dept.OpenDate;

            foreach (var stds in dept.students)
            {
                departmentWithStudent.StudentNames.Add(stds.Name);
            }

            return Ok(departmentWithStudent);
        }
    }
}
