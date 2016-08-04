using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace gvhs.web.services.Migrations
{
    public partial class update20160415 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Guest_User_UserId", table: "Guest");
            migrationBuilder.DropForeignKey(name: "FK_Reservation_Guest_GuestId", table: "Reservation");
            migrationBuilder.DropForeignKey(name: "FK_Reservation_RoomType_RoomTypeId", table: "Reservation");
            migrationBuilder.DropColumn(name: "WeixinId", table: "Guest");
            migrationBuilder.AddColumn<DateTime>(
                name: "WeixinAccessTokenTime",
                table: "Guest",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<string>(
                name: "WeixinOpenId",
                table: "Guest",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "WeixinRefreshToken",
                table: "Guest",
                nullable: true);
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
            migrationBuilder.DropColumn(name: "WeixinAccessTokenTime", table: "Guest");
            migrationBuilder.DropColumn(name: "WeixinOpenId", table: "Guest");
            migrationBuilder.DropColumn(name: "WeixinRefreshToken", table: "Guest");
            migrationBuilder.AddColumn<string>(
                name: "WeixinId",
                table: "Guest",
                nullable: true);
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
