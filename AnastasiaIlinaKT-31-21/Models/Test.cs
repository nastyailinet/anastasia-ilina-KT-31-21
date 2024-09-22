namespace AnastasiaIlinaKT_31_21.Models
{
    public class Test
    {
        public int TestId { get; set; }

        public DateTime TestDate { get; set; }

        public int DisciplineId {  get; set; }

        public Discipline Discipline { get; set; }

        public bool Passed { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

    }
}
