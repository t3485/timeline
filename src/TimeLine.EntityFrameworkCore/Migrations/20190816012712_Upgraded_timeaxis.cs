using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeLine.Migrations
{
    public partial class Upgraded_timeaxis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeAxisAuthority_TimeAxis_TimeAxisId",
                table: "TimeAxisAuthority");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAxis_CreatorUserId",
                table: "TimeAxis",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeAxis_AbpUsers_CreatorUserId",
                table: "TimeAxis",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeAxisAuthority_TimeAxis_TimeAxisId",
                table: "TimeAxisAuthority",
                column: "TimeAxisId",
                principalTable: "TimeAxis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeAxis_AbpUsers_CreatorUserId",
                table: "TimeAxis");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeAxisAuthority_TimeAxis_TimeAxisId",
                table: "TimeAxisAuthority");

            migrationBuilder.DropIndex(
                name: "IX_TimeAxis_CreatorUserId",
                table: "TimeAxis");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeAxisAuthority_TimeAxis_TimeAxisId",
                table: "TimeAxisAuthority",
                column: "TimeAxisId",
                principalTable: "TimeAxis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
