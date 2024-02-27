namespace API01.DTO
{
    public class DepartmentWithStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string MgrName { get; set; }
        public DateTime OpenDate { get; set; }

        public List<String>? StudentNames { get; set; } = null;
    }
}
