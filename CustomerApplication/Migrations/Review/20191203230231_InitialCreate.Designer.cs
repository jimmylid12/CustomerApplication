﻿// <auto-generated />
using CustomerApplication.Models.Review;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerApplication.Migrations.Review
{
    [DbContext(typeof(ReviewContext))]
    [Migration("20191203230231_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("CustomerApplication.Models.Review.ReviewDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Mark");

                    b.Property<string>("Review");

                    b.HasKey("Id");

                    b.ToTable("ReviewDTO");
                });
#pragma warning restore 612, 618
        }
    }
}
