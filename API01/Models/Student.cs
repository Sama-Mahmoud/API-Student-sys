using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API01.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }

        [ForeignKey("department")]
        public int departmentID { get; set; }
        [JsonIgnore]
        public Department? department { get; set; }
    }
}
