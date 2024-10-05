namespace AnastasiaIlinaKT_31_21.Models
{
    public class AcademicGroup
    {
        public int GroupId { get; set; }
        
        public string Chars { get; set; }

        public int Number {  get; set; }

        public int Year { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Discipline> Disciplines { get; set; }
    }
}
