using Microsoft.EntityFrameworkCore;
using AnastasiaIlinaKT_31_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;
using AnastasiaIlinaKT_31_21.Database.Helpers;

namespace AnastasiaIlinaKT_31_21.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<AcademicGroup>
    {
        private const string TableName = "cd_group";

        public void Configure(EntityTypeBuilder<AcademicGroup> builder)
        {
            builder
                .HasKey(p => p.GroupId)
                .HasName($"pk_{TableName}_group_id");

            builder
                .Property(p => p.GroupId)
                .ValueGeneratedOnAdd()
                .HasColumnName("group_id")
                .HasComment("Идентификатор записи группы");

            builder
                .Property(p => p.Chars)
                .IsRequired()
                .HasColumnName("c_group_characters")
                .HasColumnType(ColumnType.String).HasMaxLength(3)
                .HasComment("Литеры группы");

            builder
                .Property(p => p.Number)
                .IsRequired()
                .HasColumnName("c_group_number")
                .HasColumnType(ColumnType.Int)
                .HasComment("Номер группы");

            builder
                .Property(p => p.Year)
                .IsRequired()
                .HasColumnName("c_group_year")
                .HasColumnType(ColumnType.Int)
                .HasComment("Год поступления");

            builder
                .Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("c_group_is_deleted")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Статус удаления");

            builder.ToTable(TableName)
                .HasMany(p => p.Disciplines)
                .WithMany(p => p.Groups); ;

        }
    }
}

