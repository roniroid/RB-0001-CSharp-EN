using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roniroid.Basics.EF.Migrations
{
    /// <inheritdoc />
    public partial class addedpersontouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Person_PersonId",
                table: "User",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Person_PersonId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PersonId",
                table: "User");
        }
    }
}
