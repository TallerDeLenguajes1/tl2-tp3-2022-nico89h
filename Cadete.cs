using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp3_taller
{
    internal class Cadete:Personas
    {
        //inicio de la creacion de la clase cadete
        //inicio de la lista de los pedidos
        private List<Pedido> listaPedidos= new List<Pedido>();
        //inicio de el getter y setter
        internal List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }
        //inicio de el constructor por sobrecarga
        public Cadete(int id, string nombre, string direccion, string telefono, List<Pedido> listaPedidos) : base(id, nombre, direccion, telefono)
        {
            this.listaPedidos = listaPedidos;
        }
        //inicio de constructor por defecto
        public Cadete():base()
        {
            this.ListaPedidos = new List<Pedido>();
        }
        //inicio de los metodos
        public void agregarPedido(Pedido pedidoAgregar)
        {
            //inicio de el agregado del pedido
            listaPedidos.Add(pedidoAgregar);
            Console.WriteLine("Se agrego el pedido correctamente");
        }
        private float total=0;
        public float jornadaAcobrar()
        {
            //inicio del intengo de linq
            foreach (var item in this.ListaPedidos)
            {
                this.total += item.Estado ? this.total + 300 : 0;
            }
            return total;
        }
        public void eliminarPedido(Pedido pedidoEliminar)
        {
            if (this.ListaPedidos.Contains(pedidoEliminar))
            {
                //inicio de la eliminada del pedido
                listaPedidos.Remove(pedidoEliminar);//se elimina el pedido a eliminar
                Console.WriteLine("El pedido solicitado se elimino ");
            }
            else
            {
                Console.WriteLine("El pedido a eliminar no se encuentra en la lista de el cadete");
            }
        }
        //controlo si es que existe un pedido en el cadete
        public bool pertenece(int numero)
        {
            int i;
            for (i = 0; i < listaPedidos.Count; i++)
            {
                if (listaPedidos[i].Nro==numero)
                {
                    return true;
                }
            }
            if (i==listaPedidos.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        //inicio de cambiar el estado de un pedido del cadete
        public void cambiarEstado(int numero)
        {
            if (this.pertenece(numero))//controlo si existe el pedido en el cadete
            {
                for (int i = 0; i < this.ListaPedidos.Count; i++)
                {
                    if (listaPedidos[i].Nro==numero) //selecciono el igual
                    {
                        listaPedidos[i].Estado = !(listaPedidos[i].Estado);
                    }
                }
                Console.WriteLine("Se cambio el pedido correctamente");
                
            }
            else
            {
                Console.WriteLine("No existe el pedido en el cadete");
            }
        }

        public override string mostrarDatos()
        {
            string datosPedidos = "";
            foreach (Pedido pedido in this.ListaPedidos)
            {
                datosPedidos += pedido.mostrarDatos()+"|"; //aca en el ultimo dato quedara un problema para poder obtener el listado de los pedidos
            }
            int aux = datosPedidos.Length;
            return base.mostrarDatos()+"*"+datosPedidos;
        }
    }

}
