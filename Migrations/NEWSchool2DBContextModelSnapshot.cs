﻿// <auto-generated />
using Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Migrations
{
    [DbContext(typeof(NEWSchool2DBContext))]
    partial class NEWSchool2DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models.Class", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models.ClassCourse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FK_ClassID")
                        .HasColumnType("int");

                    b.Property<int>("FK_CourseID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FK_ClassID");

                    b.HasIndex("FK_CourseID");

                    b.ToTable("ClassCourses");
                });

            modelBuilder.Entity("Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FK_ClassID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("FK_ClassID");

                    b.ToTable("Studens");
                });

            modelBuilder.Entity("Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models.ClassCourse", b =>
                {
                    b.HasOne("Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models.Class", "Classes")
                        .WithMany("ClassCourses")
                        .HasForeignKey("FK_ClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models.Course", "Courses")
                        .WithMany("ClassCourses")
                        .HasForeignKey("FK_CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classes");

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models.Student", b =>
                {
                    b.HasOne("Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("FK_ClassID");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models.Class", b =>
                {
                    b.Navigation("ClassCourses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Lektion_3___Code_first_Databas_POST__GET__DELETE_etc.Models.Course", b =>
                {
                    b.Navigation("ClassCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
