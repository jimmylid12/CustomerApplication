﻿// <auto-generated />
using CustomerApplication.Models.OrderHistory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerApplication.Migrations.OrderHistory
{
    [DbContext(typeof(OrderHistoryContext))]
    [Migration("20191203232802_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("CustomerApplication.Models.OrderHistory.OrderHistoryDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Price");

                    b.Property<string>("Product");

                    b.HasKey("Id");

                    b.ToTable("OrderHistoryDTO");
                });
#pragma warning restore 612, 618
        }
    }
}
