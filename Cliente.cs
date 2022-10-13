using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp3_taller
{
    internal class Cliente:Personas
    {
        //inicio de la clase cliente
        private string datosReferenciaDireccion;
        //iniciod de constructores
        public Cliente()
        {
            this.datosReferenciaDireccion = "";
        }

        public Cliente(int id, string nombre, string direccion, string telefono, string datosReferenciaDireccion) : base(id, nombre, direccion, telefono)
        {
            this.datosReferenciaDireccion = datosReferenciaDireccion;
        }
        //inicio de getter y setter
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

        //inicio de metodos
        public override string mostrarDatos()
        {
            return base.mostrarDatos()+","+this.DatosReferenciaDireccion;
        }
    }
}
