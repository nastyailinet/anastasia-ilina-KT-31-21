using Microsoft.EntityFrameworkCore;
using AnastasiaIlinaKT_31_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AnastasiaIlinaKT_31_21.Database.Helpers;

namespace AnastasiaIlinaKT_31_21.Database.Configurations
{
    public class MarkConfiguration : IEntityTypeConfiguration<Mark>
    {
        private const string TableName = "cd_mark";

        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder
                .HasKey(p => p.MarkId)
                .HasName($"pk_{TableName}_mark_id");

            builder
                .Property(p => p.MarkId)
                .ValueGeneratedOnAdd()
                .HasColumnName("mark_id")
                .HasComment("Идентификатор записи оценки");

            builder
                .Property(p => p.MarkValue)
                .IsRequired()
                .HasColumnName("c_mark_value")
                .HasColumnType(ColumnType.Int)
                .HasComment("Оценка");

            builder
                .Property(p => p.MarkDate)
                .IsRequired()
                .HasColumnName("c_mark_date")
                .HasColumnType(ColumnType.Date)
                .HasComment("Дата оценки");

            builder.ToTable(TableName);

            //Connection with Discipline            

            builder
                .HasOne(p => p.Discipline)
                .WithMany(m => m.Marks)
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
                .WithMany(m => m.Marks)
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
