using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimaApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class deleteSerialFieldsFromEmpDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serial",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "EmployeeDocuments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "EmployeeDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SerialNumber",
                table: "EmployeeDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
