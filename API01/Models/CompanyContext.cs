using Microsoft.EntityFrameworkCore;

namespace API01.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions options) : base(options)
        {
        }

        public CompanyContext()
        {
        }
        public DbSet<Department> Department { get; set; }   
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EPURTM6\\SQL2022;Initial Catalog=APICompany;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;");
        }

    }
}
