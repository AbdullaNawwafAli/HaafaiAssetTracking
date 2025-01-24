using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HaafaiAssetTrackingApp.Migrations
{
    /// <inheritdoc />
    public partial class SetUpDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NicNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscardedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    staffId = table.Column<int>(type: "int", nullable: true),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetNo);
                    table.ForeignKey(
                        name: "FK_Assets_Staffs_staffId",
                        column: x => x.staffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateTable(
                name: "staffAssetHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staffId = table.Column<int>(type: "int", nullable: false),
                    AssetNo = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffAssetHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_staffAssetHistories_Staffs_staffId",
                        column: x => x.staffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetNo", "AssetStatus", "AssetType", "AssignedDate", "DiscardedDate", "LastReturnedDate", "PurchasedDate", "staffId" },
                values: new object[] { 2, "Not Assigned", "CPU", null, null, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffId", "Department", "Name", "NicNo" },
                values: new object[,]
                {
                    { 1, "IT", "Jason David", "n333d3" },
                    { 2, "Support", "Larry Frank", "n4f4f4f" },
                    { 3, "HR", "Annie Taylor", "4fin4fn" }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetNo", "AssetStatus", "AssetType", "AssignedDate", "DiscardedDate", "LastReturnedDate", "PurchasedDate", "staffId" },
                values: new object[] { 1, "Assigned", "Monitor", new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "staffAssetHistories",
                columns: new[] { "Id", "AssetNo", "AssignedDate", "LastReturnedDate", "staffId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_staffId",
                table: "Assets",
                column: "staffId");

            migrationBuilder.CreateIndex(
                name: "IX_staffAssetHistories_staffId",
                table: "staffAssetHistories",
                column: "staffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "staffAssetHistories");

            migrationBuilder.DropTable(
                name: "Staffs");
        }
    }
}
