using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace gvhs.web.services.Migrations
{
    public partial class update20160422 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_EGuest_User_UserId", table: "EGuest");
            migrationBuilder.DropForeignKey(name: "FK_EReservation_EGuest_GuestId", table: "EReservation");
            migrationBuilder.DropForeignKey(name: "FK_EReservation_ERoomType_RoomTypeId", table: "EReservation");
            migrationBuilder.CreateTable(
                name: "EHotel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    WWW = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EHotel", x => x.Id);
                });
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "ERoomType",
                nullable: true);
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
            migrationBuilder.DropColumn(name: "ImgUrl", table: "ERoomType");
            migrationBuilder.DropTable("EHotel");
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
