﻿// <auto-generated />
using CustomerApplication.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerApplication.Migrations.Product
{
    [DbContext(typeof(ProductContext))]
    [Migration("20191203171144_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("CustomerApplication.Models.Product.ProductDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Product");

                    b.HasKey("Id");

                    b.ToTable("ProductDTO");
                });
#pragma warning restore 612, 618
        }
    }
}
