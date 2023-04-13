using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoadmapService.Migrations
{
    /// <inheritdoc />
    public partial class Contents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_ParentId",
                table: "Nodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Roadmaps_ParentId",
                table: "Nodes");

            migrationBuilder.DropIndex(
                name: "IX_Nodes_ParentId",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Nodes");

            migrationBuilder.AddColumn<Guid>(
                name: "RoadmapId",
                table: "Nodes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_RoadmapId",
                table: "Nodes",
                column: "RoadmapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Roadmaps_RoadmapId",
                table: "Nodes",
                column: "RoadmapId",
                principalTable: "Roadmaps",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Roadmaps_RoadmapId",
                table: "Nodes");

            migrationBuilder.DropIndex(
                name: "IX_Nodes_RoadmapId",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "RoadmapId",
                table: "Nodes");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Nodes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Roadmaps_ParentId",
                table: "Nodes",
                column: "ParentId",
                principalTable: "Roadmaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
