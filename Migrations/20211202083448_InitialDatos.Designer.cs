﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFExamen.Migrations
{
    [DbContext(typeof(InstitutoContext))]
    [Migration("20211202083448_InitialDatos")]
    partial class InitialDatos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Alumno", b =>
                {
                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("Efectivo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pelo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlumnoId");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("Matricula", b =>
                {
                    b.Property<int>("MatriculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<int>("ModuloId")
                        .HasColumnType("int");

                    b.HasKey("MatriculaId");

                    b.HasIndex("ModuloId");

                    b.HasIndex("AlumnoId", "ModuloId")
                        .IsUnique();

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("Modulo", b =>
                {
                    b.Property<int>("ModuloId")
                        .HasColumnType("int");

                    b.Property<int>("Creditos")
                        .HasColumnType("int");

                    b.Property<int>("Curso")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModuloId");

                    b.ToTable("Modulos");
                });

            modelBuilder.Entity("Matricula", b =>
                {
                    b.HasOne("Alumno", null)
                        .WithMany("Matriculacion")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modulo", null)
                        .WithMany("Matriculado")
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Alumno", b =>
                {
                    b.Navigation("Matriculacion");
                });

            modelBuilder.Entity("Modulo", b =>
                {
                    b.Navigation("Matriculado");
                });
#pragma warning restore 612, 618
        }
    }
}