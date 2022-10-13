using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp3_taller
{
    //inicio de la cadeteria
    internal class Cadeteria
    {
        //inicio 
        private string nombre, telefono;
        private List<Cadete> Cadetes=new List<Cadete>();
        //inicio de el constructor por sobrecarga
        public Cadeteria(string nombre, string telefono, List<Cadete> cadetes)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            Cadetes = cadetes;
        }
        //inicio de el constructor por defecto
        public Cadeteria()
        {
            this.nombre = "";
            this.telefono = "";
            Cadetes = new List<Cadete>();
        }
        //inicio de getters y setters
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        internal List<Cadete> Cadetes1 { get => Cadetes; set => Cadetes = value; }
        //inicio de cambiar de 
        //a) dar de alta pedidos
        //b) asignarlos a cadetes
        //c) cambiarlos de estado
        //d) cambiarlos de cadete
        //inicio de los metodos
        public void asignarCadetesPedido(int idCadete, Pedido pedidoAgregar)
        {
            //comienzo a asignar a el cadete el pedido
            //recorro toda la lista de cadetes
            int i=1;
            foreach (Cadete cadete in this.Cadetes1)
            {
                if (cadete.Id == idCadete)//le agrego a ese cadete dicho pedido
                {
                    cadete.agregarPedido(pedidoAgregar);
                }
                i++;
            }
            if (i==Cadetes1.Count)
            {
                Console.WriteLine("No se pudo agregar el pedido"+ Environment.NewLine+"No se encuentra el cadete en la lista");
            }
        }
        //agrego un cadete a la lista
        public void agregarCadete(Cadete cadeteAgregar)
        {
            //comienzo a agregar a un cadete a lista
            this.Cadetes1.Add(cadeteAgregar);//agrego al cadete a la lista
        }
        //cambiarlos de cadete
        public void cambiarCadete(int id1, int id2) // obtengo los id de los cadetes que quiero cambiar los pedidos
        {
            //selecciono los cadetes que tienen dicho id
            if (this.PerteneceCadete(id1) && this.PerteneceCadete(id2))
            {
                Cadete cadeteCambio1 = (Cadete)(from cadete in this.Cadetes where cadete.Id == id1 select cadete);

                Cadete cadeteCambio2 = (Cadete)(from cadete in this.Cadetes where cadete.Id == id2 select cadete);
                //inicio del cambio de lista
                var listaPedido2 = cadeteCambio2.ListaPedidos;
                var listaPedido1 = cadeteCambio1.ListaPedidos;
                cadeteCambio1.ListaPedidos.Clear(); //borro todos los datos de la lista 1
                cadeteCambio1.ListaPedidos = listaPedido2;
                cadeteCambio2.ListaPedidos.Clear();
                cadeteCambio2.ListaPedidos = listaPedido1;
            }
            else
            {
                Console.WriteLine("No se pudo realizar el cambio de pedidos entre los dos cadetes, uno de ellos no figura en nuestros datos");
            }
        }
        public bool PerteneceCadete(int id)
        {
            int i = 0;
            for (i= 0; i < this.Cadetes.Count; i++)
            {
                if (this.Cadetes1[i].Id==id)
                {
                    break;
                }
            }

            if (i==this.Cadetes1.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string mostrarDatos()
        {
            string datosCadetes = "";
            foreach (Cadete item in this.Cadetes1) //recorro la lista de los cadetes
            {
                datosCadetes += item.mostrarDatos()+"\n";
            }
            return this.Nombre + "," + this.Telefono+"\n"+datosCadetes;
        }
    }
}
