using API01.DTO;
using API01.Filters;
using API01.Models;
using Microsoft.EntityFrameworkCore;

namespace API01.Services
{
    public class DepartmentRebo:IDepartment
    {
        private readonly CompanyContext Db;
        //private readonly IStudentReb studentRebo;

        public DepartmentRebo(CompanyContext _db ) // DI
        {
            Db = _db;
           // studentRebo = studentReb;   
        }
        public List<Department> GetAll()
        {
            var Department = Db.Department.Include(std =>std.students).ToList();

            return Department;
        }

        public Department GetById(int id)
        {
            var dept = Db.Department.Find(id);
            return dept;
        }

        public Department GetByName(string name)
        {
            var dept
                = Db.Department.FirstOrDefault(d => d.Name == name);
            return dept;
        }
        [LocationFilter("USA", "EG")]

        public void Add(Department dept)
        {
             StudentRebo studentRebo=new StudentRebo(new CompanyContext());
            // List<Student> students = new List<Student>();   
            //foreach (var std in dept.StudentNames)
            //{
            //    students.Add(studentRebo.GetByName(std));
            //}
            if (dept.students != null)
            {
                foreach (var std in dept.students)
                {
                    studentRebo.Add(std);
                }
            }

            Db.Department.Add(dept);
                //new Department
            //{
            //    Name = dept.Name,
            //    OpenDate = dept.OpenDate,
            //    Location = dept.Location,
            //    MgrName = dept.MgrName,
            //    students = students
            //}
            //) ;
            Db.SaveChanges();
            //return Ok(department);

        }
        [LocationFilter("USA", "EG")]

        public void Update(Department dept)
        {
            Department? dpt = Db.Department.Find(dept.Id);
            if (dpt != null)
            {
                dpt.Name = dept.Name;
                dpt.MgrName = dept.MgrName;
                dpt.Location = dept.Location;
                dpt.OpenDate = dept.OpenDate;

                Db.SaveChanges();
            }

        }
        public Department Delete(int id)
        {
            var dpt = Db.Department.Find(id);
            if (dpt != null)
            {
                Db.Department.Remove(dpt);
                Db.SaveChanges();
            }
            return dpt;
        }
    }
}
