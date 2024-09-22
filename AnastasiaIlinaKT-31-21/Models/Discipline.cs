namespace AnastasiaIlinaKT_31_21.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }

        public string DisciplineName { get; set; }

        public ICollection<AcademicGroup> Groups { get; set; }

        public ICollection<Mark> Marks { get; set; }

        public ICollection<Test> Tests { get; set; }

    }
}
