﻿// <auto-generated />
using APIurlshortener.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIurlshortener.Migrations
{
    [DbContext(typeof(URLShortenerContext))]
    [Migration("20231209050812_OctavaMigracion")]
    partial class OctavaMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("APIurlshortener.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ecommerce"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Landing"
                        },
                        new
                        {
                            Id = 3,
                            Name = "SocialMedia"
                        });
                });

            modelBuilder.Entity("APIurlshortener.Entities.Urls", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ID_category")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ID_user")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UrlLarge")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlShort")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("counter")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ID_category");

                    b.HasIndex("ID_user");

                    b.ToTable("Url");
                });

            modelBuilder.Entity("APIurlshortener.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("APIurlshortener.Entities.Urls", b =>
                {
                    b.HasOne("APIurlshortener.Entities.Category", "Category")
                        .WithMany("url")
                        .HasForeignKey("ID_category")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIurlshortener.Entities.User", "User")
                        .WithMany("Url")
                        .HasForeignKey("ID_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("APIurlshortener.Entities.Category", b =>
                {
                    b.Navigation("url");
                });

            modelBuilder.Entity("APIurlshortener.Entities.User", b =>
                {
                    b.Navigation("Url");
                });
#pragma warning restore 612, 618
        }
    }
}
