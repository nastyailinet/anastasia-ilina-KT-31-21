using Microsoft.EntityFrameworkCore;
using AnastasiaIlinaKT_31_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AnastasiaIlinaKT_31_21.Database.Helpers;

namespace AnastasiaIlinaKT_31_21.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder
                .HasKey(p => p.DisciplineId)
                .HasName($"pk_{TableName}_discipline_id");

            builder
                .Property(p => p.DisciplineId)
                .ValueGeneratedOnAdd()
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор записи дисциплины");

            builder
                .Property(p => p.DisciplineName)
                .IsRequired()
                .HasColumnName("c_discipline_name")
                .HasColumnType(ColumnType.String).HasMaxLength(300)
                .HasComment("Название дисциплины");

            builder.ToTable(TableName)
                .HasMany(p => p.Groups)
                .WithMany(p => p.Disciplines);

        }
    }
}

