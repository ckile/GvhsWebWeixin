using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace gvhs.web.services.Migrations
{
    public partial class update201604151 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Guest_User_UserId", table: "Guest");
            migrationBuilder.DropForeignKey(name: "FK_Reservation_Guest_GuestId", table: "Reservation");
            migrationBuilder.DropForeignKey(name: "FK_Reservation_RoomType_RoomTypeId", table: "Reservation");
            migrationBuilder.AddColumn<string>(
                name: "WeixinHeadimgurl",
                table: "Guest",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "WeixinNickname",
                table: "Guest",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "WeixinSex",
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
            migrationBuilder.DropColumn(name: "WeixinHeadimgurl", table: "Guest");
            migrationBuilder.DropColumn(name: "WeixinNickname", table: "Guest");
            migrationBuilder.DropColumn(name: "WeixinSex", table: "Guest");
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
