using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WeatherForecast.Migrations
{
    /// <inheritdoc />
    public partial class c12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_group_specialnost = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Специальность"),
                    c_group_groupname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Наименование группы"),
                    c_group_groupyear = table.Column<int>(type: "int4", maxLength: 100, nullable: false, comment: "Год формирования группы"),
                    c_group_doesexist = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Существует ли группа")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_(TableName)_GroupId", x => x.group_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
