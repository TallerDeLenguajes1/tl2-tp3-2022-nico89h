using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace tp3_taller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //inicio de el tp3 de taller
            Cadete cadete = new Cadete();
            cadete.mostrarDatos();
            Console.WriteLine("Buen dia nicolas leal");
            Console.ReadKey();


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
            Cadete cadete1 = new Cadete(1, "masd", "asdd", "2241342", lista);
            cadete1.agregarPedido(pedido2);
            cadete1.agregarPedido(pedido3);
            cadete1.eliminarPedido(pedido3);
            Console.WriteLine("La jornada a cobrar es: " + cadete1.jornadaAcobrar());
            Cadete cadete2 = new Cadete(2, "masd", "asdd", "2241342", lista);

            List<Cadete> lista2 = new List<Cadete>();
            lista2.Add(cadete1);
            lista2.Add(cadete2);
            //Console.WriteLine("Los datos de una  cadena son: " + cadete1.mostrarDatos());
            //string datos = cadete1.mostrarDatos();
            //string[] josexd = datos.Split('*');
            //Console.WriteLine("Datos de los pedidos" + josexd[1]);
            //josexd[1] = josexd[1].Substring(0,josexd[1].Length - 1);
            //Console.WriteLine("Datos de los pedidos" + josexd[1]);
            //string[] pedidosxd = josexd[1].Split('|');
            //Console.WriteLine("Datos de los pedidos"+ pedidosxd[1]);
            //Console.ReadKey();


            Cadeteria empresa = new Cadeteria("nicolas", "222311", lista2);
            Console.WriteLine("Los datos de los cadetes son: " + empresa.mostrarDatos());
            Console.ReadKey();
            crearEscribirArchivos(empresa.mostrarDatos(),"archivo.csv");
            Cadeteria nosexdd = leerArchivo("archivo.csv");
            Console.WriteLine("Los datos de los cadetes son: " + nosexdd.mostrarDatos());
            Console.ReadKey();
            //inicio de la creacion de los archivos
            void crearEscribirArchivos(string datosEscribir, string nombre)
            {
                if (!File.Exists(nombre))
                {
                    File.Create(nombre);
                    Console.WriteLine("Se esta creando");
                    File.WriteAllText(nombre, datosEscribir);//escribo los datos del archivo
                }
                else
                {
                    File.WriteAllText(nombre, datosEscribir);
                    Console.WriteLine("Si existe");
                }

            }
            
            Cadeteria leerArchivo(string nombreArchivo)
            {
                File.OpenText(nombreArchivo);
                string []lineas = File.ReadAllLines(nombreArchivo);
                //Console.WriteLine("nose "+ lineasUno);
                //lineasUno= lineasUno.Substring(0,lineasUno.Length-1);
                //string []lineas = lineasUno.Split(' ');
                List<Cadete> listaDeCadetes = new List<Cadete>();
                for (int i = 1; i < lineas.Length; i++)
                {

                    listaDeCadetes.Add(datosCadete(lineas[i]));
                }
                //this.Nombre + "," + this.Telefono
                string[] datoUltimoCadeteria = lineas[0].Split(',');
                Cadeteria cadeteria = new Cadeteria(datoUltimoCadeteria[0],datoUltimoCadeteria[1],listaDeCadetes);
                return cadeteria;
            }
            
            
            
            Cadete datosCadete(string datosCadetes)
            {
                string []cadeteDato = datosCadetes.Split('*'); //separo el dato del cadete de su lista de pedidos
                //elimino el ultimo caracter de separacion de los pedidos
                cadeteDato[1] = cadeteDato[1].Substring(0,cadeteDato[1].Length - 1);
                List<Pedido> listaPedidos = new List<Pedido>();
                string[] datoPedido = cadeteDato[1].Split('|'); //separo los pedidos
                for (int i = 0; i < datoPedido.Length; i++)
                {
                    listaPedidos.Add(datosPedido(datoPedido[i]));
                }
                string[] datosCadeteUltimo= cadeteDato[0].Split(',');
                //Id.ToString() + "," + this.Nombre + "," + this.Direccion + "," + this.Telefono
                Cadete aux = new Cadete();
                aux.Id = (int)Int32.Parse(datosCadeteUltimo[0]);
                aux.Nombre = datosCadeteUltimo[1];
                aux.Direccion = datosCadeteUltimo[2];
                aux.Telefono = datosCadeteUltimo[3];
                aux.ListaPedidos = listaPedidos;
                //var aux = new Cadete( , datosCadeteUltimo[1], datosCadeteUltimo[2], datosCadeteUltimo[3], listaPedidos);
                return aux;
            }
            
            
            Pedido datosPedido(string datoPedidos)
            {
                //comienzo separando el dato de el pedido por ;
                string[] dato = datoPedidos.Split(';');
                Cliente cliente = datoCliente(dato[1]);
                string []datoUltimo = dato[0].Split(',');
                //this.Nro.ToString()+","+this.Observaciones+","+this.Estado.ToString()+Cliente
                
                var aux = new Pedido(Int32.Parse(datoUltimo[0]), datoUltimo[1], Boolean.Parse(datoUltimo[2]), cliente);
                return aux;
            }
            
            
            
            Cliente datoCliente(string dato)
            {
                string [] datoClienteUnico=dato.Split(','); //separo los datos por ,
                //Id.ToString() + "," + this.Nombre + "," + this.Direccion + "," + this.Telefono;
                //int id, string nombre, string direccion, string telefono, string datosReferenciaDireccion
                var aux = new Cliente(Int32.Parse(datoClienteUnico[0]), datoClienteUnico[1], datoClienteUnico[2], datoClienteUnico[3], datoClienteUnico[4]);
                return aux;
            }
        
        
        }


    }
}
