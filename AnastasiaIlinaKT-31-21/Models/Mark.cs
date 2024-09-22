namespace AnastasiaIlinaKT_31_21.Models
{
    public class Mark
    {
        public int MarkId { get; set; }

        public int MarkValue { get; set; }

        public DateTime MarkDate { get; set; }

        public int DisciplineId { get; set; }

        public Discipline Discipline { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

    }
}
