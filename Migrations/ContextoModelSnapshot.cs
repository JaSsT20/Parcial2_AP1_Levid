﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Parcial2_Levid.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Empacado", b =>
                {
                    b.Property<int>("EmpacadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("EmpacadoId");

                    b.ToTable("Empacados");
                });

            modelBuilder.Entity("EmpacadoDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmpacadoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmpacadoId");

                    b.ToTable("EmpacadoDetalle");
                });

            modelBuilder.Entity("Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Costo = 2000f,
                            Descripcion = "Mani",
                            Existencia = 200,
                            Precio = 2600f
                        },
                        new
                        {
                            ProductoId = 2,
                            Costo = 3000f,
                            Descripcion = "Pistachos",
                            Existencia = 400,
                            Precio = 3600f
                        },
                        new
                        {
                            ProductoId = 3,
                            Costo = 1500f,
                            Descripcion = "Pasas",
                            Existencia = 100,
                            Precio = 2000f
                        },
                        new
                        {
                            ProductoId = 4,
                            Costo = 4000f,
                            Descripcion = "Ciruela",
                            Existencia = 700,
                            Precio = 5600f
                        },
                        new
                        {
                            ProductoId = 5,
                            Costo = 4000f,
                            Descripcion = "Empaque en fundita",
                            Existencia = 700,
                            Precio = 5600f
                        });
                });

            modelBuilder.Entity("EmpacadoDetalle", b =>
                {
                    b.HasOne("Empacado", null)
                        .WithMany("EmpacadoDetalles")
                        .HasForeignKey("EmpacadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Empacado", b =>
                {
                    b.Navigation("EmpacadoDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
