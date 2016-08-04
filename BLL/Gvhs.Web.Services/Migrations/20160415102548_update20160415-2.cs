using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace gvhs.web.services.Migrations
{
    public partial class update201604152 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Guest_User_UserId", table: "Guest");
            migrationBuilder.DropForeignKey(name: "FK_Reservation_Guest_GuestId", table: "Reservation");
            migrationBuilder.DropForeignKey(name: "FK_Reservation_RoomType_RoomTypeId", table: "Reservation");
            migrationBuilder.CreateTable(
                name: "WeixinConfig",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeixinConfig", x => x.Id);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_Guest_User_UserId",
                table: "Guest",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Guest_GuestId",
                table: "Reservation",
                column: "GuestId",
                principalTable: "Guest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_RoomType_RoomTypeId",
                table: "Reservation",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Guest_User_UserId", table: "Guest");
            migrationBuilder.DropForeignKey(name: "FK_Reservation_Guest_GuestId", table: "Reservation");
            migrationBuilder.DropForeignKey(name: "FK_Reservation_RoomType_RoomTypeId", table: "Reservation");
            migrationBuilder.DropTable("WeixinConfig");
            migrationBuilder.AddForeignKey(
                name: "FK_Guest_User_UserId",
                table: "Guest",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Guest_GuestId",
                table: "Reservation",
                column: "GuestId",
                principalTable: "Guest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_RoomType_RoomTypeId",
                table: "Reservation",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
