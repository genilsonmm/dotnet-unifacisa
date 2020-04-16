﻿// <auto-generated />
using EFAppContact.WEB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFAppContact.WEB.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200416194057_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EFAppContact.WEB.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("contacts");
                });
#pragma warning restore 612, 618
        }
    }
}