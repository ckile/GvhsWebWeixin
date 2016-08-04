using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace gvhs.web.services.Migrations
{
    public partial class update20160421 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Reservation");
            migrationBuilder.DropTable("Guest");
            migrationBuilder.DropTable("RoomType");
            migrationBuilder.CreateTable(
                name: "EGuest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    WeixinAccessTokenTime = table.Column<DateTime>(nullable: false),
                    WeixinHeadimgurl = table.Column<string>(nullable: true),
                    WeixinNickname = table.Column<string>(nullable: true),
                    WeixinOpenId = table.Column<string>(nullable: true),
                    WeixinRefreshToken = table.Column<string>(nullable: true),
                    WeixinSex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EGuest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EGuest_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ERoomType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Availables = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(nullable: false),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERoomType", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "EReservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adult = table.Column<int>(nullable: false),
                    Arrival = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Departure = table.Column<DateTime>(nullable: false),
                    GuestId = table.Column<int>(nullable: false),
                    PaymentFlag = table.Column<bool>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    ReservationCode = table.Column<string>(nullable: true),
                    RoomCode = table.Column<string>(nullable: true),
                    RoomTypeId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EReservation_EGuest_GuestId",
                        column: x => x.GuestId,
                        principalTable: "EGuest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EReservation_ERoomType_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "ERoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("EReservation");
            migrationBuilder.DropTable("EGuest");
            migrationBuilder.DropTable("ERoomType");
            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    WeixinAccessTokenTime = table.Column<DateTime>(nullable: false),
                    WeixinHeadimgurl = table.Column<string>(nullable: true),
                    WeixinNickname = table.Column<string>(nullable: true),
                    WeixinOpenId = table.Column<string>(nullable: true),
                    WeixinRefreshToken = table.Column<string>(nullable: true),
                    WeixinSex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guest_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Availables = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(nullable: false),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adult = table.Column<int>(nullable: false),
                    Arrival = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Departure = table.Column<DateTime>(nullable: false),
                    GuestId = table.Column<int>(nullable: false),
                    PaymentFlag = table.Column<bool>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    ReservationCode = table.Column<string>(nullable: true),
                    RoomCode = table.Column<string>(nullable: true),
                    RoomTypeId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Guest_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_RoomType_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }
    }
}
