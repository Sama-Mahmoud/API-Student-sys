using API01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API01.Services
{
    public class StudentRebo : IStudentReb
    {
        private readonly CompanyContext Db;

        public StudentRebo(CompanyContext _db) // DI
        {
            Db = _db;

        }
        public List<Student> GetAll()
        {
            var Students = Db.Students.Include(dept => dept.department).ToList();
           
            return Students;
        }
        
        public Student GetById(int id)
        {
            var stds = Db.Students.Find(id);
            return stds;
        }
    
        public Student GetByName(string name)
        {
            var stds
                = Db.Students.FirstOrDefault(d => d.Name == name);
            return stds;
        }

        public void Add(Student std)
        {
           
                Db.Students.Add(std);
                Db.SaveChanges();
                //return Ok(department);
          
        }
      
        public void Update(Student Std)
        {
            Student? std = Db.Students.Find(Std.Id);
            if (std != null)
            {
                std.Name = Std.Name;
                std.Age = Std.Age;
                std.Adress = Std.Adress;
                std.Image = Std.Image;
                
                Db.SaveChanges();
            }
                
        }
        public Student Delete(int id)
        {
            var std = Db.Students.Find(id);
            if (std != null)
            {
                Db.Students.Remove(std);
                Db.SaveChanges();
            }
            return std;
        }
    }
}
