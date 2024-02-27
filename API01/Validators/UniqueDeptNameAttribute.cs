using API01.Models;
using API01.Services;
using System.ComponentModel.DataAnnotations;

namespace API01.Validators
{
    public class UniqueDeptNameAttribute :ValidationAttribute
    {
        //IDepartment departmentrebo;
        
        DepartmentRebo departmentrebo = new DepartmentRebo(new CompanyContext());
        //public UniqueDeptNameAttribute(IDepartment departmentrebo2)
        //{
        //    departmentrebo = departmentrebo2;
        //}

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }
            List<Department> departments = departmentrebo.GetAll();
            foreach (Department department in departments)
            {
                if (department.Name == (value as string))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
