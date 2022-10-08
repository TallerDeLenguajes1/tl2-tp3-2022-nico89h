using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace tp3_taller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //inicio de el tp3 de taller
            //Cadete cadete = new Cadete();
            //cadete.mostrar();
            //Console.ReadKey();


            Cliente jose = new Cliente(1, "mocas", "ladas", "344423423", "asafsa");
            Cliente pedro = new Cliente(2, "mocas", "ladas", "344423423", "asafsa");
            Cliente eduardo = new Cliente(3, "mocas", "ladas", "344423423", "asafsa");
            Cliente nico = new Cliente(4, "mocas", "ladas", "344423423", "asafsa");
            Pedido pedido = new Pedido(1, "nosad", true, jose);
            Pedido pedido2 = new Pedido(2, "nosad", false, nico);
            Pedido pedido3 = new Pedido(3, "nosad", false, jose);
            List<Pedido> lista = new List<Pedido>();
            lista.Add(pedido);
            //inicio de cadetes
            Cadete cadete1 = new Cadete(1, "masd", "asdd", "2241342",lista);
            cadete1.agregarPedido(pedido2);
            cadete1.agregarPedido(pedido3);
            cadete1.eliminarPedido(pedido3);
            Console.WriteLine("La jornada a cobrar es: "+ cadete1.jornadaAcobrar());
            Cadete cadete2= new Cadete(2, "masd", "asdd", "2241342", lista);

            List<Cadete> lista2 = new List<Cadete>();

            Cadeteria empresa = new Cadeteria("nicolas","222311",lista2);
            
            manejoArchivos(empresa);
            Console.ReadKey();
            //inicio de la creacion de los archivos
            void manejoArchivos(Cadeteria cadeteria)
            {
                string nombre = "archivo.csv";
                if (File.Exists(nombre))
                {
                    Console.WriteLine("Si existe");
                    File.WriteAllText(nombre, cadeteria.ToString());
                    var lineas=File.ReadAllLines(nombre);
                    Console.WriteLine("Lineas: "+ lineas);
                }
                else
                {
                    Console.WriteLine("No existe");
                }

            }
        }
        

    }
}
