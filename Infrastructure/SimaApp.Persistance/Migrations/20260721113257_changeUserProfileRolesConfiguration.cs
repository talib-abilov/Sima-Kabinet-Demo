using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimaApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class changeUserProfileRolesConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfilesRoles_Roles_UserProfileId",
                table: "UserProfilesRoles");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfilesRoles_RoleId",
                table: "UserProfilesRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfilesRoles_Roles_RoleId",
                table: "UserProfilesRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfilesRoles_Roles_RoleId",
                table: "UserProfilesRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfilesRoles_RoleId",
                table: "UserProfilesRoles");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfilesRoles_Roles_UserProfileId",
                table: "UserProfilesRoles",
                column: "UserProfileId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
