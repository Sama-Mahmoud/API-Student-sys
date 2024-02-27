using API01.Models;
using Microsoft.AspNetCore.Mvc;

namespace API01.Services
{
    public interface IStudentReb
    {
        public List<Student> GetAll();


        public Student GetById(int id);

        public Student GetByName(string name);


        public void Add(Student std);

        public void Update(Student Std);

        public Student Delete(int id);
        
    }
}
