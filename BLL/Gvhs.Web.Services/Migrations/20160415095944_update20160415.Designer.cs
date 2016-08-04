using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Gvhs.Web.Services;

namespace gvhs.web.services.Migrations
{
    [DbContext(typeof(WeixinDbContext))]
    [Migration("20160415095944_update20160415")]
    partial class update20160415
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gvhs.Web.DataContracts.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Mobile");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("UserId");

                    b.Property<DateTime>("WeixinAccessTokenTime");

                    b.Property<string>("WeixinOpenId")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("WeixinRefreshToken")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Gvhs.Web.DataContracts.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Adult");

                    b.Property<DateTime>("Arrival");

                    b.Property<string>("Code")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<DateTime>("Departure");

                    b.Property<int>("GuestId");

                    b.Property<bool>("PaymentFlag");

                    b.Property<decimal>("Rate");

                    b.Property<string>("Remark");

                    b.Property<string>("ReservationCode")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("RoomCode");

                    b.Property<int>("RoomTypeId");

                    b.Property<int>("Status");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Gvhs.Web.DataContracts.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Availables");

                    b.Property<string>("Code")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<decimal>("Rate");

                    b.Property<string>("Remark");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Gvhs.Web.DataContracts.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("UserCode")
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Gvhs.Web.DataContracts.Guest", b =>
                {
                    b.HasOne("Gvhs.Web.DataContracts.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Gvhs.Web.DataContracts.Reservation", b =>
                {
                    b.HasOne("Gvhs.Web.DataContracts.Guest")
                        .WithMany()
                        .HasForeignKey("GuestId");

                    b.HasOne("Gvhs.Web.DataContracts.RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId");
                });
        }
    }
}
