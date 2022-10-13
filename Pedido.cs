using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp3_taller
{
    internal class Pedido
    {
        //inicio de la creacion de la clase pedidos
        private int nro;
        private string observaciones;
        private bool estado;
        private Cliente cliente;
        //inicio de constructor por copia
        public Pedido(Pedido copia)
        {
            this.nro = copia.Nro;
            this.observaciones = copia.Observaciones;
            this.estado = copia.Estado;
            this.cliente = copia.Cliente;
        }

        
        //inicio de constructor por defecto
        public Pedido()
        {
            this.nro = 0;
            this.observaciones = "";
            this.estado = false;
            this.cliente = new Cliente();
        }
        //inicio de el constructor sobrecargado
        public Pedido(int nro, string observaciones, bool estado, int id, string nombre, string direccion, string telefono, string datosReferenciaDireccion = "")
        {
            this.nro = nro;
            this.observaciones = observaciones;
            this.estado = estado;
            //inicio de constructor sobrecargado
            this.cliente=new Cliente(id,nombre, direccion,telefono, datosReferenciaDireccion);
        }
        public Pedido(int nro, string observaciones, bool estado, Cliente cliente)
        {
            this.nro = nro;
            this.observaciones = observaciones;
            this.estado = estado;
            this.Cliente = cliente;
        }
        //inicio de los getters y setters
        public int Nro { get => nro; set => nro = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public bool Estado { get => estado; set => estado = value; }
        internal Cliente Cliente { get => cliente; set => cliente = value; }

        //inicio de la creacion de los metodos
        public void cambiarEstado()
        {
            this.Estado = !this.Estado;
        }
        public string mostrarDatos()
        {
            return this.Nro.ToString()+","+this.Observaciones+","+this.Estado.ToString()+";"+this.Cliente.mostrarDatos();
        }
    }
}
