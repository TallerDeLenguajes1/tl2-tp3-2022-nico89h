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

        public Cliente()
        {
            this.datosReferenciaDireccion = "";
        }

        public Cliente(int id, string nombre, string direccion, string telefono, string datosReferenciaDireccion = "") : base(id, nombre, direccion, telefono)
        {
            this.datosReferenciaDireccion = datosReferenciaDireccion;
        }
    }
}
