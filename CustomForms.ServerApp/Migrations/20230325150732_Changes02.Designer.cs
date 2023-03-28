﻿// <auto-generated />
using System;
using CustomForms.ServerApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomForms.ServerApp.Migrations
{
    [DbContext(typeof(CustomFormsContext))]
    [Migration("20230325150732_Changes02")]
    partial class Changes02
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomForms.Data.BlankForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("FormDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlankForms");
                });

            modelBuilder.Entity("CustomForms.Data.FormInputFieldDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlankFormId")
                        .HasColumnType("int");

                    b.Property<int>("FieldType")
                        .HasColumnType("int");

                    b.Property<int>("IntegerData")
                        .HasColumnType("int");

                    b.Property<string>("MaxLength")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MinLength")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Placeholder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StringData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlankFormId");

                    b.ToTable("FormInputFieldDefinitions");
                });

            modelBuilder.Entity("CustomForms.ServerApp.Data.Dispatch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BlankFormId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Dispatches");
                });

            modelBuilder.Entity("CustomForms.ServerApp.Data.FormInputFieldAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DispatchId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("FormInputFieldAnswers");
                });

            modelBuilder.Entity("CustomForms.Data.FormInputFieldDefinition", b =>
                {
                    b.HasOne("CustomForms.Data.BlankForm", null)
                        .WithMany("FormFields")
                        .HasForeignKey("BlankFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomForms.Data.BlankForm", b =>
                {
                    b.Navigation("FormFields");
                });
#pragma warning restore 612, 618
        }
    }
}
