using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeLine.Migrations
{
    public partial class create_timeline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeAxis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAxis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeAxisAuthority",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorizeType = table.Column<string>(nullable: true),
                    TimeAxisId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAxisAuthority", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeAxisAuthority_TimeAxis_TimeAxisId",
                        column: x => x.TimeAxisId,
                        principalTable: "TimeAxis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeAxisAuthority_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeAxisFilter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaxPage = table.Column<int>(nullable: true),
                    MinPage = table.Column<int>(nullable: true),
                    MaxDate = table.Column<DateTime>(nullable: true),
                    MinDate = table.Column<DateTime>(nullable: true),
                    TimeAxisId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAxisFilter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeAxisFilter_TimeAxis_TimeAxisId",
                        column: x => x.TimeAxisId,
                        principalTable: "TimeAxis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeAxisFilter_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeAxisItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: true),
                    MaxPage = table.Column<int>(nullable: false),
                    MinPage = table.Column<int>(nullable: false),
                    Descript = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ImgPath = table.Column<string>(nullable: true),
                    TimeAxisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAxisItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeAxisItem_TimeAxis_TimeAxisId",
                        column: x => x.TimeAxisId,
                        principalTable: "TimeAxis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeAxisItemAuthority",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorizeType = table.Column<string>(nullable: true),
                    TimeAxisItemId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeAxisItemAuthority", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeAxisItemAuthority_TimeAxisItem_TimeAxisItemId",
                        column: x => x.TimeAxisItemId,
                        principalTable: "TimeAxisItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeAxisItemAuthority_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeAxisAuthority_TimeAxisId",
                table: "TimeAxisAuthority",
                column: "TimeAxisId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAxisAuthority_UserId",
                table: "TimeAxisAuthority",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAxisFilter_TimeAxisId",
                table: "TimeAxisFilter",
                column: "TimeAxisId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAxisFilter_UserId",
                table: "TimeAxisFilter",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAxisItem_TimeAxisId",
                table: "TimeAxisItem",
                column: "TimeAxisId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAxisItemAuthority_TimeAxisItemId",
                table: "TimeAxisItemAuthority",
                column: "TimeAxisItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeAxisItemAuthority_UserId",
                table: "TimeAxisItemAuthority",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeAxisAuthority");

            migrationBuilder.DropTable(
                name: "TimeAxisFilter");

            migrationBuilder.DropTable(
                name: "TimeAxisItemAuthority");

            migrationBuilder.DropTable(
                name: "TimeAxisItem");

            migrationBuilder.DropTable(
                name: "TimeAxis");
        }
    }
}
