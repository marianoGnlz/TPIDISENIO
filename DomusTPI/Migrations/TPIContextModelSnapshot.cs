﻿// <auto-generated />
using System;
using DomusTPITPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DomusTPI.Migrations
{
    [DbContext(typeof(TPIContext))]
    partial class TPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomusTPI.Models.Agenda", b =>
                {
                    b.Property<int>("IdAgenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CalendarioIdCalendario")
                        .HasColumnType("int");

                    b.HasKey("IdAgenda");

                    b.HasIndex("CalendarioIdCalendario");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("DomusTPI.Models.Calendario", b =>
                {
                    b.Property<int>("IdCalendario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("IdCalendario");

                    b.ToTable("Calendario");
                });

            modelBuilder.Entity("DomusTPI.Models.Cita", b =>
                {
                    b.Property<int>("IdCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgendaIdAgenda")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("time");

                    b.HasKey("IdCita");

                    b.HasIndex("AgendaIdAgenda");

                    b.HasIndex("ClienteIdCliente");

                    b.ToTable("Cita");
                });

            modelBuilder.Entity("DomusTPI.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CUIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CUIT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicilio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDeNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NroCuenta")
                        .HasColumnType("int");

                    b.Property<string>("RazonSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("DomusTPI.Models.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgendaIdAgenda")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CUIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDeNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NroCuenta")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("IdEmpleado");

                    b.HasIndex("AgendaIdAgenda");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("DomusTPI.Models.Horarios", b =>
                {
                    b.Property<int>("IdHorarios")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CalendarioIdCalendario")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Horario")
                        .HasColumnType("time");

                    b.HasKey("IdHorarios");

                    b.HasIndex("CalendarioIdCalendario");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("DomusTPI.Models.Agenda", b =>
                {
                    b.HasOne("DomusTPI.Models.Calendario", "Calendario")
                        .WithMany()
                        .HasForeignKey("CalendarioIdCalendario");

                    b.Navigation("Calendario");
                });

            modelBuilder.Entity("DomusTPI.Models.Cita", b =>
                {
                    b.HasOne("DomusTPI.Models.Agenda", null)
                        .WithMany("Citas")
                        .HasForeignKey("AgendaIdAgenda");

                    b.HasOne("DomusTPI.Models.Cliente", "Cliente")
                        .WithMany("Cita")
                        .HasForeignKey("ClienteIdCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("DomusTPI.Models.Empleado", b =>
                {
                    b.HasOne("DomusTPI.Models.Agenda", "Agenda")
                        .WithMany()
                        .HasForeignKey("AgendaIdAgenda");

                    b.Navigation("Agenda");
                });

            modelBuilder.Entity("DomusTPI.Models.Horarios", b =>
                {
                    b.HasOne("DomusTPI.Models.Calendario", null)
                        .WithMany("Horarios")
                        .HasForeignKey("CalendarioIdCalendario");
                });

            modelBuilder.Entity("DomusTPI.Models.Agenda", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("DomusTPI.Models.Calendario", b =>
                {
                    b.Navigation("Horarios");
                });

            modelBuilder.Entity("DomusTPI.Models.Cliente", b =>
                {
                    b.Navigation("Cita");
                });
#pragma warning restore 612, 618
        }
    }
}
