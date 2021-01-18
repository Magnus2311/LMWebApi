﻿// <auto-generated />
using System;
using LMWebApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LMWebApi.Database.Migrations
{
    [DbContext(typeof(LMDbContext))]
    [Migration("20210118113342_AddedUser")]
    partial class AddedUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LMWebApi.Database.Models.AminoAcids", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Alanine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Arginine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Cystine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Glutamine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Glycine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Histidine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Isoleucine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Leucine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Lysine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Methionine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Phenylalanine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductInfoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Proline")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Serine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Threonine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tryptophan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tyrosine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Valin")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductInfoId")
                        .IsUnique()
                        .HasFilter("[ProductInfoId] IS NOT NULL");

                    b.ToTable("AminoAcids");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Carbohydrates", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Fibres")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Fructose")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Galactose")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Glucose")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Lactose")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Maltose")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductInfoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Starchs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Sucrose")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Sugar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductInfoId")
                        .IsUnique()
                        .HasFilter("[ProductInfoId] IS NOT NULL");

                    b.ToTable("Carbohydrates");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Fats", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("FatsVal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Monounsaturated")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PolyunsaturatedFats")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductInfoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("SaturatedFats")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TransFats")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductInfoId")
                        .IsUnique()
                        .HasFilter("[ProductInfoId] IS NOT NULL");

                    b.ToTable("Fats");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Meal", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Minerals", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Calcium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Copper")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Fluoride")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Iron")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Magnesium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Manganese")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Phosphorus")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Potassium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductInfoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Selenium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Sodium")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Zinc")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductInfoId")
                        .IsUnique()
                        .HasFilter("[ProductInfoId] IS NOT NULL");

                    b.ToTable("Minerals");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Others", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Alcohol")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Caffeine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Cinder")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductInfoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Theobromine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Water")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductInfoId")
                        .IsUnique()
                        .HasFilter("[ProductInfoId] IS NOT NULL");

                    b.ToTable("Others");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Calories")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Carbohydrates")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Fats")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Proteins")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.ProductInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique()
                        .HasFilter("[ProductId] IS NOT NULL");

                    b.ToTable("ProductInfo");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.ProductMeal", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MealId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProductId", "MealId");

                    b.HasIndex("MealId");

                    b.ToTable("ProductMeal");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.ShopCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("ShopCategories");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.ShopItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AvailableQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ShopCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Usage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ShopCategoryId");

                    b.ToTable("ShopItems");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Sterols", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("BetaSitosterols")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Campesterols")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Cholesterol")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Phytosterols")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductInfoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Stigmasterols")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductInfoId")
                        .IsUnique()
                        .HasFilter("[ProductInfoId] IS NOT NULL");

                    b.ToTable("Sterols");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Vitamins", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Betaine")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductInfoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("VitaminA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VitaminB1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VitaminB12")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VitaminB2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VitaminB3")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VitaminB4")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VitaminB5")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VitaminB6")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VitaminB9")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VitaminC")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VitaminD")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VitaminE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VitaminK1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VitaminK2")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductInfoId")
                        .IsUnique()
                        .HasFilter("[ProductInfoId] IS NOT NULL");

                    b.ToTable("Vitamins");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.AminoAcids", b =>
                {
                    b.HasOne("LMWebApi.Database.Models.ProductInfo", "ProductInfo")
                        .WithOne("AminoAcids")
                        .HasForeignKey("LMWebApi.Database.Models.AminoAcids", "ProductInfoId");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Carbohydrates", b =>
                {
                    b.HasOne("LMWebApi.Database.Models.ProductInfo", "ProductInfo")
                        .WithOne("Carbohydrates")
                        .HasForeignKey("LMWebApi.Database.Models.Carbohydrates", "ProductInfoId");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Category", b =>
                {
                    b.HasOne("LMWebApi.Database.Models.Category", "Parent")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Fats", b =>
                {
                    b.HasOne("LMWebApi.Database.Models.ProductInfo", "ProductInfo")
                        .WithOne("Fats")
                        .HasForeignKey("LMWebApi.Database.Models.Fats", "ProductInfoId");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Minerals", b =>
                {
                    b.HasOne("LMWebApi.Database.Models.ProductInfo", "ProductInfo")
                        .WithOne("Minerals")
                        .HasForeignKey("LMWebApi.Database.Models.Minerals", "ProductInfoId");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Others", b =>
                {
                    b.HasOne("LMWebApi.Database.Models.ProductInfo", "ProductInfo")
                        .WithOne("Others")
                        .HasForeignKey("LMWebApi.Database.Models.Others", "ProductInfoId");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Product", b =>
                {
                    b.HasOne("LMWebApi.Database.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.ProductInfo", b =>
                {
                    b.HasOne("LMWebApi.Database.Models.Product", "Product")
                        .WithOne("ProductInfo")
                        .HasForeignKey("LMWebApi.Database.Models.ProductInfo", "ProductId");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.ProductMeal", b =>
                {
                    b.HasOne("LMWebApi.Database.Models.Meal", "Meal")
                        .WithMany("ProductMeals")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMWebApi.Database.Models.Product", "Product")
                        .WithMany("ProductMeals")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LMWebApi.Database.Models.ShopCategory", b =>
                {
                    b.HasOne("LMWebApi.Database.Models.ShopCategory", "Parent")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.ShopItem", b =>
                {
                    b.HasOne("LMWebApi.Database.Models.Brand", "Brand")
                        .WithMany("ShopItems")
                        .HasForeignKey("BrandId");

                    b.HasOne("LMWebApi.Database.Models.ShopCategory", "ShopCategory")
                        .WithMany("ShopItems")
                        .HasForeignKey("ShopCategoryId");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Sterols", b =>
                {
                    b.HasOne("LMWebApi.Database.Models.ProductInfo", "ProductInfo")
                        .WithOne("Sterols")
                        .HasForeignKey("LMWebApi.Database.Models.Sterols", "ProductInfoId");
                });

            modelBuilder.Entity("LMWebApi.Database.Models.Vitamins", b =>
                {
                    b.HasOne("LMWebApi.Database.Models.ProductInfo", "ProductInfo")
                        .WithOne("Vitamins")
                        .HasForeignKey("LMWebApi.Database.Models.Vitamins", "ProductInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
