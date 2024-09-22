using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnastasiaIlinaKT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_discipline_name = table.Column<string>(type: "varchar", maxLength: 300, nullable: false, comment: "Название дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_group_characters = table.Column<string>(type: "varchar", maxLength: 3, nullable: false, comment: "Литеры группы"),
                    c_group_number = table.Column<int>(type: "int4", nullable: false, comment: "Номер группы"),
                    c_group_year = table.Column<int>(type: "int4", nullable: false, comment: "Год поступления")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicGroupDiscipline",
                columns: table => new
                {
                    DisciplinesDisciplineId = table.Column<int>(type: "integer", nullable: false),
                    GroupsGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicGroupDiscipline", x => new { x.DisciplinesDisciplineId, x.GroupsGroupId });
                    table.ForeignKey(
                        name: "FK_AcademicGroupDiscipline_cd_discipline_DisciplinesDiscipline~",
                        column: x => x.DisciplinesDisciplineId,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicGroupDiscipline_cd_group_GroupsGroupId",
                        column: x => x.GroupsGroupId,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_lastname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    c_student_fisrtname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя студента"),
                    c_student_middlename = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Отчество студента"),
                    GroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.GroupId,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_mark",
                columns: table => new
                {
                    mark_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи оценки")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_mark_value = table.Column<int>(type: "int4", nullable: false, comment: "Оценка"),
                    c_mark_date = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Дата оценки"),
                    DisciplineId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_mark_mark_id", x => x.mark_id);
                    table.ForeignKey(
                        name: "fk_f_discipline_id",
                        column: x => x.DisciplineId,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_student_id",
                        column: x => x.StudentId,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_test",
                columns: table => new
                {
                    test_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи зачета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_taste_date = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Дата зачета"),
                    DisciplineId = table.Column<int>(type: "integer", nullable: false),
                    c_passed = table.Column<bool>(type: "bool", nullable: false, comment: "Результат"),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_test_test_id", x => x.test_id);
                    table.ForeignKey(
                        name: "fk_f_discipline_id",
                        column: x => x.DisciplineId,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_student_id",
                        column: x => x.StudentId,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGroupDiscipline_GroupsGroupId",
                table: "AcademicGroupDiscipline",
                column: "GroupsGroupId");

            migrationBuilder.CreateIndex(
                name: "inx_cd_mark_fk_f_discipline_id",
                table: "cd_mark",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "inx_cd_mark_fk_f_student_id",
                table: "cd_mark",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "inx_cd_student_fk_f_group_id",
                table: "cd_student",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "inx_cd_test_fk_f_discipline_id",
                table: "cd_test",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "inx_cd_test_fk_f_student_id",
                table: "cd_test",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicGroupDiscipline");

            migrationBuilder.DropTable(
                name: "cd_mark");

            migrationBuilder.DropTable(
                name: "cd_test");

            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_group");
        }
    }
}
