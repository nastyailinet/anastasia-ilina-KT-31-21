using Microsoft.EntityFrameworkCore;
using AnastasiaIlinaKT_31_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AnastasiaIlinaKT_31_21.Database.Helpers;

namespace AnastasiaIlinaKT_31_21.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            builder
                .Property(p => p.StudentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("student_id")
                .HasComment("Идентификатор записи студента");

            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_fisrtname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя студента");

            builder
                .Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия студента");

            builder
                .Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("c_student_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество студента");

            builder.ToTable(TableName);

            //Connection with Groups

            builder
                .HasOne(p => p.Group)
                .WithMany(m => m.Students)
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(p => p.GroupId)
                .HasDatabaseName($"inx_{TableName}_fk_f_group_id");

            builder
                .Navigation(p => p.Group)
                .AutoInclude();


        }
    }
}
