using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Gvhs.Web.Services;

namespace gvhs.web.services.Migrations
{
    [DbContext(typeof(WeixinDbContext))]
    partial class WeixinDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gvhs.Web.DataContracts.EGuest", b =>
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

                    b.Property<string>("WeixinHeadimgurl")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("WeixinNickname")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("WeixinOpenId")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("WeixinRefreshToken")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("WeixinSex")
                        .HasAnnotation("MaxLength", 1);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Gvhs.Web.DataContracts.EHotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("ImgUrl")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("Mobile");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Phone");

                    b.Property<string>("Remark");

                    b.Property<string>("WWW");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Gvhs.Web.DataContracts.EReservation", b =>
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

            modelBuilder.Entity("Gvhs.Web.DataContracts.ERoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Availables");

                    b.Property<string>("Code")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("ImgUrl");

                    b.Property<string>("LocalCode")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<decimal>("Rate");

                    b.Property<string>("Remark");

                    b.Property<bool>("Unavailable");

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

            modelBuilder.Entity("Gvhs.Web.DataContracts.WeixinConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Value");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Gvhs.Web.DataContracts.EGuest", b =>
                {
                    b.HasOne("Gvhs.Web.DataContracts.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Gvhs.Web.DataContracts.EReservation", b =>
                {
                    b.HasOne("Gvhs.Web.DataContracts.EGuest")
                        .WithMany()
                        .HasForeignKey("GuestId");

                    b.HasOne("Gvhs.Web.DataContracts.ERoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId");
                });
        }
    }
}
