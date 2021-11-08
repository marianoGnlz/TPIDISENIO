using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomusTPI.Migrations
{
    public partial class Prueba1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendario",
                columns: table => new
                {
                    IdCalendario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendario", x => x.IdCalendario);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    NroCuenta = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    CUIL = table.Column<int>(type: "int", nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    IdAgenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarioIdCalendario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.IdAgenda);
                    table.ForeignKey(
                        name: "FK_Agendas_Calendario_CalendarioIdCalendario",
                        column: x => x.CalendarioIdCalendario,
                        principalTable: "Calendario",
                        principalColumn: "IdCalendario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    IdHorarios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false),
                    CalendarioIdCalendario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.IdHorarios);
                    table.ForeignKey(
                        name: "FK_Horarios_Calendario_CalendarioIdCalendario",
                        column: x => x.CalendarioIdCalendario,
                        principalTable: "Calendario",
                        principalColumn: "IdCalendario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    IdCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: true),
                    AgendaIdAgenda = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.IdCita);
                    table.ForeignKey(
                        name: "FK_Cita_Agendas_AgendaIdAgenda",
                        column: x => x.AgendaIdAgenda,
                        principalTable: "Agendas",
                        principalColumn: "IdAgenda",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cita_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    NroCuenta = table.Column<int>(type: "int", nullable: false),
                    AgendaIdAgenda = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    CUIL = table.Column<int>(type: "int", nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Agendas_AgendaIdAgenda",
                        column: x => x.AgendaIdAgenda,
                        principalTable: "Agendas",
                        principalColumn: "IdAgenda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_CalendarioIdCalendario",
                table: "Agendas",
                column: "CalendarioIdCalendario");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_AgendaIdAgenda",
                table: "Cita",
                column: "AgendaIdAgenda");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_ClienteIdCliente",
                table: "Cita",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_AgendaIdAgenda",
                table: "Empleados",
                column: "AgendaIdAgenda");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_CalendarioIdCalendario",
                table: "Horarios",
                column: "CalendarioIdCalendario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Calendario");
        }
    }
}
