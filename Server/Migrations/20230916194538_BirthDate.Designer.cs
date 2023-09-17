﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using STGeneticsTest.Server;

#nullable disable

namespace STGeneticsTest.Server.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230916194538_BirthDate")]
    partial class BirthDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("STGeneticsTest.Shared.Entities.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnimalId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BreedId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ProductoImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SexId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("AnimalId");

                    b.HasIndex("BreedId");

                    b.HasIndex("SexId");

                    b.HasIndex("StatusId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("STGeneticsTest.Shared.Entities.Breed", b =>
                {
                    b.Property<int>("BreedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BreedId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BreedId");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("STGeneticsTest.Shared.Entities.Sex", b =>
                {
                    b.Property<int>("SexId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SexId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SexId");

                    b.ToTable("Sex");
                });

            modelBuilder.Entity("STGeneticsTest.Shared.Entities.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("STGeneticsTest.Shared.Entities.Animal", b =>
                {
                    b.HasOne("STGeneticsTest.Shared.Entities.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("STGeneticsTest.Shared.Entities.Sex", "Sex")
                        .WithMany()
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("STGeneticsTest.Shared.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Breed");

                    b.Navigation("Sex");

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
