using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WeatherForecast.Migrations
{
    /// <inheritdoc />
    public partial class xxcxc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specialnosts",
                columns: table => new
                {
                    specialnost_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор специальности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_group_specialnostname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Наименование специальности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName)_SpecialnostId", x => x.specialnost_id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_group_groupname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Наименование группы"),
                    c_group_groupyear = table.Column<int>(type: "int4", maxLength: 100, nullable: false, comment: "Год формирования группы"),
                    c_group_doesexist = table.Column<bool>(type: "bool", nullable: false, comment: "Существует ли группа"),
                    c_group_specialnostid = table.Column<int>(type: "int4", nullable: false, comment: "ИД специальности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName)_GroupId", x => x.group_id);
                    table.ForeignKey(
                        name: "fk_f_specialnost_id",
                        column: x => x.c_group_specialnostid,
                        principalTable: "Specialnosts",
                        principalColumn: "specialnost_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_Group_fk_f_specialnost_id",
                table: "Group",
                column: "c_group_specialnostid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Specialnosts");
        }
    }
}
