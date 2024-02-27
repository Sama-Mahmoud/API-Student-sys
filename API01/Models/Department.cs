using API01.Validators;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API01.Models
{
    public class Department
    {
        public int Id { get; set; }
        [UniqueDeptName]
        public string Name { get; set; }
        public string Location { get; set; }
        [StringLength(20 , MinimumLength =5 , ErrorMessage ="mgr name must be between 5 and 20")]
        public string MgrName { get; set; }
        [DayInPast]
        public DateTime OpenDate { get; set; }
        [JsonIgnore]
        public ICollection<Student>? students { get; set; } = null;
    }
}
