using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Cliente : Usuario
    {
        //Instancia de la clase Tarjeta
        public Tarjeta tarjeta = new Tarjeta();

        //Instancia de la clase Carrito
        public Carrito carrito = new Carrito();

        //Lista de la clase Recibo
        public List<Recibo> recibosCliente = new List<Recibo>();

        //Constructor sin argumentos
        public Cliente()
        {

        }

        //Setters
        public void SetRecibo(Recibo recibo) { recibosCliente.Add(recibo); }

        //Getters
        public List<Recibo> GetRecibo() { return recibosCliente; }


        /**************************************** Métodos para la clase Cliente ****************************************/


        public override void Menu(List<Producto> productos, List<Usuario> usuarios, List<Solicitud> solicitudes, List<Recibo> recibos)
        {
            //Variables para el método
            int opcion = 0, opcion1 = 0, opcion2 = 0, opcion3 = 0, opcion4 = 0, opcion5 = 0;

            do
            {
                try
                {
                    Console.WriteLine("\n =============== Cliente ===============\n");
                    Console.Write("\n Seleccionar una opcion.\n\n" +
                                  " 1. Ver Catálogo\n" +
                                  " 2. Mi Carrito\n" +
                                  " 3. Mis Compras\n" +
                                  " 4. Ver mis puntos\n" +
                                  " 5. Mi perfil\n" +
                                  " 6. Salir\n\n" +
                                  " Opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (opcion)
                    {
                        case 1:
                            do
                            {
                                try
                                {
                                    Console.WriteLine("\n =============== Ver Catálogo ===============\n");
                                    Console.Write(" 1. A-Z\n" +
                                                  " 2. Por departamento\n" +
                                                  " 3. Buscar producto\n" +
                                                  " 4. Salir\n\n" +
                                                  " Opción: ");
                                    opcion1 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();

                                    switch (opcion1)
                                    {
                                        case 1:
                                            Console.WriteLine("\n =============== Catálogo por nombre ===============\n");
                                            carrito.AñadirProductosCarrito(productos, GetPapeleria(), "Nombre", 0);
                                            break;
                                        case 2:
                                            Console.WriteLine("\n =============== Catálogo por departamento ===============\n");
                                            carrito.AñadirProductosCarrito(productos, GetPapeleria(), "Departamento", 0);
                                            break;
                                        case 3:
                                            do
                                            {
                                                try
                                                {
                                                    Console.WriteLine("\n =============== Búsqueda de productos ===============\n");
                                                    Console.Write(" 1. Buscar por nombre de producto\n" +
                                                                  " 2. Buscar por departamento\n" +
                                                                  " 3. Salir\n\n" +
                                                                  " Opción: ");
                                                    opcion2 = Convert.ToInt32(Console.ReadLine());
                                                    Console.Clear();
                                                    switch (opcion2)
                                                    {//opcion 2 del menu principal para buscar por nombre o departamento
                                                        case 1:
                                                            Console.WriteLine("\n =============== Producto por nombre ===============\n");
                                                            carrito.AñadirProductosCarrito(productos, GetPapeleria(), "Nombre", 1);
                                                            Console.WriteLine("\n └> Presione ENTER para continuar");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            break;
                                                        case 2:
                                                            Console.WriteLine("\n =============== Producto por departamento ===============\n");
                                                            carrito.AñadirProductosCarrito(productos, GetPapeleria(), "Departamento", 1);
                                                            Console.WriteLine("\n └> Presione ENTER para continuar");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            break;
                                                        case 3:
                                                            Console.WriteLine("\n Saliendo...");
                                                            break;
                                                        default:
                                                            Console.WriteLine("\n -> Opción no válida, intente de nuevo");
                                                            Console.WriteLine("\n └> Presione ENTER para continuar");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            break;
                                                    }
                                                }
                                                catch (Exception e) //manejamos las excepciones
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\n -> Debe insertar un número");
                                                    Console.WriteLine("\n └> Presione ENTER para continuar");
                                                    Console.ReadLine();
                                                    Console.Clear();
                                                }
                                            } while (opcion2 != 3);
                                            break;
                                        case 4:
                                            Console.WriteLine("\n Saliendo...");
                                            break;
                                        default:
                                            Console.WriteLine("\n -> Opción no válida, intente de nuevo");
                                            break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n -> Debe insertar un número");
                                }
                                Console.WriteLine("\n └> Presione ENTER para continuar");
                                Console.ReadLine();
                                Console.Clear();
                            } while (opcion1 != 4);
                            break;
                        case 2:
                            do
                            {
                                try
                                {
                                    Console.WriteLine("\n =============== Mi Carrito ===============\n");
                                    Console.Write(" 1. Ver carrito\n" +
                                                  " 2. Pagar\n" +
                                                  " 3. Salir\n\n" +
                                                  " Opción: ");
                                    opcion3 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                    switch (opcion3)
                                    {
                                        case 1:
                                            carrito.VisualizarCarrito();
                                            break;
                                        case 2:
                                            carrito.Pagar(recibos, GetPapeleria(), GetNombre() + " " + GetApellidos());
                                            break;
                                        case 3:
                                            Console.WriteLine("\n Saliendo...");
                                            break;
                                        default:
                                            Console.WriteLine("\n -> Opción no válida, intente de nuevo");
                                            break;
                                    }
                                }
                                catch(Exception e)
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n -> Debe insertar un número");
                                }
                                Console.WriteLine("\n └> Presione ENTER para continuar");
                                Console.ReadLine();
                                Console.Clear();
                            } while (opcion3 != 3);
                            break;
                        case 3:
                            do
                            {
                                try
                                {
                                    Console.WriteLine("\n =============== Mis Compras ===============\n");
                                    Console.Write(" 1. Ver todas mis compras\n" +
                                                  " 2. Buscar compra\n" +
                                                  " 3. Salir\n\n" +
                                                  " Opción: ");
                                    opcion4 = Convert.ToInt32(Console.ReadLine());
                                    switch (opcion4)
                                    {
                                        case 1:
                                            Compras(1);
                                            break;
                                        case 2:
                                            Compras(2);
                                            break;
                                        case 3:
                                            Console.WriteLine("\n Saliendo...");
                                            break;
                                        default:
                                            Console.WriteLine("\n -> Opción no válida, intente de nuevo");
                                            break;
                                    }
                                }
                                catch(Exception e)
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n -> Debe insertar un número");
                                }
                                Console.WriteLine("\n └> Presione ENTER para continuar");
                                Console.ReadLine();
                                Console.Clear();
                            } while (opcion4 != 3);
                            break;
                        case 4:
                            Console.WriteLine("\n =============== Ver Mis Puntos ===============\n");
                            Console.WriteLine(" " + carrito.GetPuntos());
                            Console.WriteLine("\n └> Presione ENTER para continuar");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 5:
                            do
                            {
                                try
                                {
                                    Console.WriteLine("\n =============== Perfil ===============\n");
                                    Console.Write(" 1. Ver perfil\n" +
                                                  " 2. Editar\n" +
                                                  " 3. Salir\n\n" +
                                                  " Opción: ");
                                    opcion5 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                    switch (opcion5)
                                    {
                                        case 1:
                                            Console.WriteLine("\n =============== Perfil de usuario ===============\n");
                                            VerUsuarios(usuarios, "Cliente", "Nombre", 2);
                                            break;
                                        case 2:
                                            EditarPerfil("Vendedor");
                                            break;
                                        case 3:
                                            Console.WriteLine("\n Saliendo...");
                                            break;
                                        default:
                                            Console.WriteLine("\n -> Opción no válida, intente de nuevo");
                                            break;
                                    }
                                }
                                catch (Exception e) //manejamos las excepciones
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n -> Debe insertar un número");
                                }
                                Console.WriteLine("\n └> Presione ENTER para continuar");
                                Console.ReadLine();
                                Console.Clear();
                            } while (opcion5 != 3); //repetimos el menu si la opcion es diferente de salir
                            break;
                        case 6:
                            Console.WriteLine("\n Usted ha salido de manera exitosa");
                            Console.WriteLine("\n └> Presione ENTER para continuar");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("\n -> Opción no válida, por favor ingrese una de las opciones mostradas");
                            Console.WriteLine("\n └> Presione ENTER para continuar");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("\n -> Debe insertar un número, intente de nuevo\n ");
                    Console.WriteLine(" Presione ENTER para continuar\n");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (opcion != 6);
        }

        //Método para ver las compras de cada cliente
        public void Compras(int opcion)
        {
            //Variables para el método
            string cadena;
            bool bandera = false;

            if (recibosCliente.Count != 0)
            {
                if (opcion == 1)
                {
                    foreach (Recibo r in recibosCliente)
                    {
                        Console.WriteLine(" Papeleria: " + r.GetPapeleria());
                        Console.WriteLine(" Fecha: " + r.GetFecha() + " Hora: " + r.GetHora());
                        Console.WriteLine(" Cliente: " + r.GetNombreCliente());
                        Console.WriteLine(" Número de productos: " + r.GetNumeroProductos());
                        foreach (Producto p in r.GetProductos())
                        {
                            Console.WriteLine(" Artículo: " + p.GetNombre() + " Piezas: " + p.GetStock() + " Precio: " + p.GetPrecio());
                        }
                        Console.WriteLine(" Total: " + r.GetPrecioTotal());
                        Console.WriteLine("\n ==================================================\n");
                    }
                }
                else
                {
                    foreach (Recibo r in recibosCliente)
                    {
                        Console.Write("\n Ingrese el nombre del producto: "); cadena = Console.ReadLine();
                        Console.Clear();

                        foreach (Producto p in r.GetProductos())
                        {
                            if (p.GetNombre().Contains(cadena))
                            {
                                bandera = true;
                                Console.WriteLine(" Papeleria: " + r.GetPapeleria());
                                Console.WriteLine(" Fecha: " + r.GetFecha() + " Hora: " + r.GetHora());
                                Console.WriteLine(" Cliente: " + r.GetNombreCliente());
                                Console.WriteLine(" Número de productos: " + r.GetNumeroProductos());
                                Console.WriteLine(" Artículo: " + p.GetNombre() + " Piezas: " + p.GetStock() + " Precio: " + p.GetPrecio());
                                Console.WriteLine(" Total: " + r.GetPrecioTotal());
                                Console.WriteLine("\n ==================================================\n");
                            }
                        }
                        if (!bandera)
                        {
                            Console.WriteLine("\n No se ha realizado la compra del producto: " + cadena);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\n No ha realizado ninguna compra\n");
            }
            Console.ReadLine();
        }
    }
}
