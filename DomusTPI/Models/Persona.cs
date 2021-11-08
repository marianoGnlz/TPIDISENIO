using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomusTPI.Models
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;
        private int cuil;
        private DateTime fechaDeNacimiento;
        private int telefono;
        private string email;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public int DNI
        {
            get { return dni; }
            set { dni = value; }
        }
        public int CUIL
        {
            get { return cuil; }
            set { cuil = value; }
        }
        public DateTime FechaDeNacimiento
        {
            get { return fechaDeNacimiento; }
            set { fechaDeNacimiento = value; }
        }
        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
