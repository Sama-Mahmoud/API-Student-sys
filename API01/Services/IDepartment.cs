using API01.DTO;
using API01.Models;

namespace API01.Services
{
    public interface IDepartment
    {
        public List<Department> GetAll();


        public Department GetById(int id);

        public Department GetByName(string name);


        public void Add(Department dept);

        public void Update(Department deot);

        public Department Delete(int id);

    }
}
