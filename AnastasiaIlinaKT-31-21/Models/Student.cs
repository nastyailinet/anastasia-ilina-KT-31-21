namespace AnastasiaIlinaKT_31_21.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; } 
        
        public string MiddleName { get; set; }

        public int GroupId { get; set; }

        public AcademicGroup Group { get; set; }

        public ICollection<Mark> Marks { get; set; }

        public ICollection<Test> Tests { get; set; }

    }
}
