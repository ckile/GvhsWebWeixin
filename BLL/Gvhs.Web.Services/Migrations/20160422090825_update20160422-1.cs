using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace gvhs.web.services.Migrations
{
    public partial class update201604221 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_EGuest_User_UserId", table: "EGuest");
            migrationBuilder.DropForeignKey(name: "FK_EReservation_EGuest_GuestId", table: "EReservation");
            migrationBuilder.DropForeignKey(name: "FK_EReservation_ERoomType_RoomTypeId", table: "EReservation");
            migrationBuilder.AddColumn<string>(
                name: "LocalCode",
                table: "ERoomType",
                nullable: true);
            migrationBuilder.AddColumn<bool>(
                name: "Unavailable",
                table: "ERoomType",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddForeignKey(
                name: "FK_EGuest_User_UserId",
                table: "EGuest",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_EReservation_EGuest_GuestId",
                table: "EReservation",
                column: "GuestId",
                principalTable: "EGuest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_EReservation_ERoomType_RoomTypeId",
                table: "EReservation",
                column: "RoomTypeId",
                principalTable: "ERoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_EGuest_User_UserId", table: "EGuest");
            migrationBuilder.DropForeignKey(name: "FK_EReservation_EGuest_GuestId", table: "EReservation");
            migrationBuilder.DropForeignKey(name: "FK_EReservation_ERoomType_RoomTypeId", table: "EReservation");
            migrationBuilder.DropColumn(name: "LocalCode", table: "ERoomType");
            migrationBuilder.DropColumn(name: "Unavailable", table: "ERoomType");
            migrationBuilder.AddForeignKey(
                name: "FK_EGuest_User_UserId",
                table: "EGuest",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_EReservation_EGuest_GuestId",
                table: "EReservation",
                column: "GuestId",
                principalTable: "EGuest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_EReservation_ERoomType_RoomTypeId",
                table: "EReservation",
                column: "RoomTypeId",
                principalTable: "ERoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
