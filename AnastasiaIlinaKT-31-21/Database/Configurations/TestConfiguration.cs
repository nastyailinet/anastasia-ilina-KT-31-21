using Microsoft.EntityFrameworkCore;
using AnastasiaIlinaKT_31_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AnastasiaIlinaKT_31_21.Database.Helpers;

namespace AnastasiaIlinaKT_31_21.Database.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        private const string TableName = "cd_test";

        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder
                .HasKey(p => p.TestId)
                .HasName($"pk_{TableName}_test_id");

            builder
                .Property(p => p.TestId)
                .ValueGeneratedOnAdd()
                .HasColumnName("test_id")
                .HasComment("Идентификатор записи зачета");

            builder
                .Property(p => p.TestDate)
                .IsRequired()
                .HasColumnName("c_taste_date")
                .HasColumnType(ColumnType.Date)
                .HasComment("Дата зачета");

            builder
                .Property(p => p.Passed)
                .IsRequired()
                .HasColumnName("c_passed")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Результат");

            builder.ToTable(TableName);

            //Connection with Discipline            

            builder
                .HasOne(p => p.Discipline)
                .WithMany(m => m.Tests)
                .HasForeignKey(p => p.DisciplineId)
                .HasConstraintName("fk_f_discipline_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(p => p.DisciplineId)
                .HasDatabaseName($"inx_{TableName}_fk_f_discipline_id");

            builder
                .Navigation(p => p.Discipline)
                .AutoInclude();

            //Connection with Student

            builder
                .HasOne(p => p.Student)
                .WithMany(m => m.Tests)
                .HasForeignKey(p => p.StudentId)
                .HasConstraintName("fk_f_student_id");

            builder
                .HasIndex(p => p.StudentId)
                .HasDatabaseName($"inx_{TableName}_fk_f_student_id");

            builder
                .Navigation(p => p.Student)
                .AutoInclude();
        }
    }
}
