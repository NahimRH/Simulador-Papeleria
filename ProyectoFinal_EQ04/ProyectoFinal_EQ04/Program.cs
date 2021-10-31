using System;
using System.Collections.Generic;
using System.IO;
using Clases;

namespace ProyectoFinal_EQ04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creación de una lista de usuarios
            List<Usuario> usuarios = new List<Usuario>();

            //Creación de una lista de productos
            List<Producto> productos = new List<Producto>();

            //Creación de una lista de solicitudes
            List<Solicitud> solicitudes = new List<Solicitud>();

            //Creación de una lista de carritos
            List<Carrito> carritos = new List<Carrito>();

            //Creación de una lista de carritos
            List<Tarjeta> tarjetas = new List<Tarjeta>();

            //Creación de una lista de carritos
            List<Recibo> recibos = new List<Recibo>();

            //Instancia de la clase Cliente
            Cliente cliente = new Cliente();

            //Variables para el método
            int opcion = 0;
            string nombre, contraseña;
            bool bandera = false;

            //Método que imprime los datos del equipo encargado de la realización del proyecto
            EquipoDesarrollador();

            LlenarInventario(productos);
            LlenarCarrito(carritos);
            LlenarTarjeta(tarjetas);
            LlenarSolicitud(solicitudes);
            LlenarRecibo(recibos);
            LlenarUsuario(usuarios, carritos, tarjetas, recibos);

            do
            {
                try
                {
                    Console.WriteLine("\n =============== Super Papelerias ===============\n");
                    Console.Write(" Elegir una opción\n" +
                                  " 1. Iniciar sesión\n" +
                                  " 2. Registrarse (cliente)\n" +
                                  " 3. Salir\n\n" +
                                  " Opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("\n =============== Inicio de sesión ===============\n");
                            Console.Write(" Nombre: "); nombre = Console.ReadLine();
                            Console.Write(" Contraseña: "); contraseña = Console.ReadLine();
                            Console.Clear();

                            foreach (Usuario u in usuarios)
                            {
                                if (u.GetNombre().Equals(nombre) && u.GetContraseña().Equals(contraseña))
                                {
                                    bandera = true;
                                    u.Menu(productos, usuarios, solicitudes, recibos);
                                }
                            }
                            if (!bandera)
                            {
                                Console.WriteLine("\n El usuario o la contraseña son incorrectos");
                                Console.WriteLine("\n └> Presione ENTER para continuar");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            break;
                        case 2:
                            Console.WriteLine("\n=============== Registro ===============\n");
                            cliente.NuevoRegistro(usuarios, "Cliente", carritos, tarjetas);
                            Console.WriteLine("\n El cliente se agregó de manera correcta, presione ENTER para continuar");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            Console.WriteLine("\n Usted ha salido de manera exitosa, gracias por su preferencia, vuelva pronto");
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
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("\n -> Debe insertar un número, intente de nuevo");
                    Console.WriteLine("\n └> Presione ENTER para continuar\n");
                    Console.ReadLine();
                    Console.Clear();
                }
                Guardar(usuarios, productos, solicitudes, tarjetas, carritos, recibos);
            } while (opcion != 3);
        }


        /**************************************** Métodos para la clase Program ****************************************/


        //Método que sirve para mostrar el equipo encargado de realizar el proyecto
        static void EquipoDesarrollador()
        {
            Console.WriteLine("\n\t ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ Proyecto Final ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\n" +
                              "\t Programación Orientada a Objetos\n" +
                              "\t Grupo: 09\n" +
                              "\t Semestre: 2021-1\n" +
                              "\t Equipo: 4\n" +
                              "\t Nombre del equipo: ░░░░░ Code Company ░░░░░\n" +
                              "\t Integrantes: " +
                              "\t -> Ana Paula Flores Salinas\n" +
                              "\t\t\t -> Mario Mendoza González\n" +
                              "\t\t\t -> Nahim Rosas Hernández\n" +
                              "\t Nombre y que desarrolló del proyecto: Super Papelerías, sistema de gestión y control de una pequeña cadena de papelerías.");
            Console.WriteLine("\n └> Presione ENTER para ejecutar el programa.");
            Console.ReadLine();
            Console.Clear();
        }

        //Método que sirve para leer el txt que contiene los usuarios que estan registrados en la empresa (Empleados y clientes)
        static void LlenarUsuario(List<Usuario> usuarios, List<Carrito> carritos, List<Tarjeta> tarjetas, List<Recibo> recibos)
        {
            //Instancia de la clase Usuario
            Usuario usuario = new Usuario();

            //Instancia de la clase Carrito
            Carrito carrito = new Carrito();

            //Instancia de la clase Tarjeta
            Tarjeta tarjeta = new Tarjeta();

            //Variables para el método
            string linea;

            //Apertura de un archivo de texto, el cual contiene usuarios (Empleados y clientes)
            StreamReader archivoUsuarios = File.OpenText("Usuarios.txt");

            while (!archivoUsuarios.EndOfStream)
            {
                for (int i = 0; i < 9; i++)
                {
                    linea = archivoUsuarios.ReadLine();
                    usuario.LlenarUsuario(i, linea);
                }

                if (usuario.GetTipoUsuario().Equals("Administrador"))
                {
                    usuarios.Add(usuario.UsuarioAdministrador());
                }
                else
                {
                    if (usuario.GetTipoUsuario().Equals("Vendedor"))
                    {
                        usuarios.Add(usuario.UsuarioVendedor());
                    }
                    else
                    {
                        //Instancia de la clase Cliente
                        Cliente cliente = new Cliente();

                        //Variable que almacena el nombre y apellido concatenado de un cliente
                        string nombre = usuario.GetNombre() + " " + usuario.GetApellidos();

                        foreach (Carrito c in carritos)
                        {
                            if (c.GetId().Equals(nombre))
                            {
                                carrito = c;
                            }
                        }

                        foreach (Tarjeta t in tarjetas)
                        {
                            if (t.GetNombreTitular().Equals(nombre))
                            {
                                tarjeta = t;
                            }
                        }

                        foreach (Recibo r in recibos)
                        {
                            if (r.GetNombreCliente().Equals(nombre))
                            {
                                cliente.SetRecibo(r);
                            }
                        }
                        usuarios.Add(usuario.UsuarioCliente(carrito, tarjeta, cliente.GetRecibo()));
                    }
                }
                linea = archivoUsuarios.ReadLine();
            }
            archivoUsuarios.Close();
        }

        //Método que sirve para leer el txt que contiene el inventario general de productos
        static void LlenarInventario(List<Producto> productos)
        {
            //Variables para el método
            string linea;

            //Apertura de un archivo de texto, el cual contiene el inventario de productos
            StreamReader archivoInventario = File.OpenText("Inventario.txt");

            while (!archivoInventario.EndOfStream)
            {
                //Instancia de la clase Producto
                Producto producto = new Producto();

                for (int i = 0; i < 8; i++)
                {
                    linea = archivoInventario.ReadLine();
                    producto.LlenarProducto(i, linea);
                }
                productos.Add(producto);
                linea = archivoInventario.ReadLine();
            }
            archivoInventario.Close();
        }

        //Método que sirve para leer el txt que contiene las solicitudes de nuevo material
        static void LlenarSolicitud(List<Solicitud> solicitudes)
        {
            //Variables para el método
            string linea;

            //Apertura de un archivo de texto, el cual contiene las solicitudes de material
            StreamReader archivoSolicitudes = File.OpenText("Solicitudes.txt");

            while (!archivoSolicitudes.EndOfStream)
            {
                //Instancia de la clase Solicitud
                Solicitud solicitud = new Solicitud();

                for (int i = 0; i < 7; i++)
                {
                    linea = archivoSolicitudes.ReadLine();
                    solicitud.LlenarSolicitud(i, linea);
                }
                solicitudes.Add(solicitud);
                linea = archivoSolicitudes.ReadLine();
            }
            archivoSolicitudes.Close();
        }

        //Método que sirve para leer el txt que contiene las tarjetas asociadas a los clientes
        static void LlenarTarjeta(List<Tarjeta> tarjetas)
        {
            //Variables para el método
            string linea;

            //Apertura de un archivo de texto, el cual contiene las tarjetas de los clientes
            StreamReader archivoTarjetas = File.OpenText("Tarjetas.txt");

            while (!archivoTarjetas.EndOfStream)
            {
                //Instancia de la clase Tarjeta
                Tarjeta tarjeta = new Tarjeta();

                for (int i = 0; i < 6; i++)
                {
                    linea = archivoTarjetas.ReadLine();
                    tarjeta.LlenarTarjeta(i, linea);
                }
                tarjetas.Add(tarjeta);
                linea = archivoTarjetas.ReadLine();
            }
            archivoTarjetas.Close();
        }

        //Método que sirve para leer el txt que contiene los carritos asociados a los clientes
        static void LlenarCarrito(List<Carrito> carritos)
        {
            //Variables para el método
            string linea;

            //Apertura de un archivo de texto, el cual contiene los carritos de los clientes
            StreamReader archivoCarritos = File.OpenText("Carritos.txt");

            while (!archivoCarritos.EndOfStream)
            {
                //Instancia de la clase Carrito
                Carrito carrito = new Carrito();

                for (int i = 0; i < 4; i++)
                {
                    linea = archivoCarritos.ReadLine();
                    carrito.LlenarCarrito(i, linea);
                }
                if (carrito.GetNumeroProductos() != 0)
                {
                    for (int j = 0; j < carrito.GetNumeroProductos(); j++)
                    {
                        linea = archivoCarritos.ReadLine();
                        //Instancia de la clase Producto
                        Producto producto = new Producto();

                        for (int k = 0; k < 8; k++)
                        {
                            linea = archivoCarritos.ReadLine();
                            producto.LlenarProducto(k, linea);
                        }
                        carrito.SetProductos(producto);
                    }
                }
                carritos.Add(carrito);
                linea = archivoCarritos.ReadLine();
                linea = archivoCarritos.ReadLine();
            }
            archivoCarritos.Close();
        }

        //Método que sirve para leer el txt que contiene los recibos de compra asociados a los clientes
        static void LlenarRecibo(List<Recibo> recibos)
        {
            //Variables para el método
            string linea;

            //Apertura de un archivo de texto, el cual contiene los recibos de los clientes
            StreamReader archivoRecibos = File.OpenText("Recibos.txt");

            while (!archivoRecibos.EndOfStream)
            {
                //Instancia de la clase Recibo
                Recibo recibo = new Recibo();

                for (int i = 0; i < 5; i++)
                {
                    linea = archivoRecibos.ReadLine();
                    recibo.LlenarRecibo(i, linea);
                }
                if (recibo.GetNumeroProductos() != 0)
                {
                    for (int j = 0; j < recibo.GetNumeroProductos(); j++)
                    {
                        linea = archivoRecibos.ReadLine();

                        //Instancia de la clase Producto
                        Producto producto = new Producto();

                        for (int k = 0; k < 8; k++)
                        {
                            linea = archivoRecibos.ReadLine();
                            producto.LlenarProducto(k, linea);
                        }
                        recibo.SetProductos(producto);
                    }
                    linea = archivoRecibos.ReadLine();
                    recibo.SetPrecioTotal(Convert.ToDouble(linea = archivoRecibos.ReadLine()));
                }
                recibos.Add(recibo);
                linea = archivoRecibos.ReadLine();
                linea = archivoRecibos.ReadLine();
            }
            archivoRecibos.Close();
        }

        //Método que sirve para guardar todos los cambios realizados en la ejecución del programa
        static void Guardar(List<Usuario> usuarios, List<Producto> productos, List<Solicitud> solicitudes, List<Tarjeta> tarjetas, List<Carrito> carritos, List<Recibo> recibos)
        {
            //Apertura de los archivos Usuarios, Inventario, Solicitudes, Tarjetas y Carritos para escritura
            TextWriter archivoUsuarios = new StreamWriter("Usuarios.txt");
            TextWriter archivoInventario = new StreamWriter("Inventario.txt");
            TextWriter archivoSolicitudes = new StreamWriter("Solicitudes.txt");
            TextWriter archivoTarjetas = new StreamWriter("Tarjetas.txt");
            TextWriter archivoCarrito = new StreamWriter("Carritos.txt");
            TextWriter archivoRecibos = new StreamWriter("Recibos.txt");

            foreach (Usuario u in usuarios)
            {
                archivoUsuarios.WriteLine(u.GetNombre());
                archivoUsuarios.WriteLine(u.GetApellidos());
                archivoUsuarios.WriteLine(u.GetDireccion());
                archivoUsuarios.WriteLine(u.GetCorreo());
                archivoUsuarios.WriteLine(u.GetTelefono());
                archivoUsuarios.WriteLine(u.GetContraseña());
                archivoUsuarios.WriteLine(u.GetId());
                archivoUsuarios.WriteLine(u.GetTipoUsuario());
                archivoUsuarios.WriteLine(u.GetPapeleria());
                archivoUsuarios.WriteLine("");
            }
            archivoUsuarios.Close();

            foreach (Producto p in productos)
            {
                archivoInventario.WriteLine(p.GetNombre());
                archivoInventario.WriteLine(p.GetDescripcion());
                archivoInventario.WriteLine(p.GetPrecio());
                archivoInventario.WriteLine(p.GetStock());
                archivoInventario.WriteLine(p.GetCodigoDeSerie());
                archivoInventario.WriteLine(p.GetCodigoDeInventario());
                archivoInventario.WriteLine(p.GetPapeleria());
                archivoInventario.WriteLine(p.GetDepartamento());
                archivoInventario.WriteLine("");
            }
            archivoInventario.Close();

            foreach (Solicitud s in solicitudes)
            {
                archivoSolicitudes.WriteLine(s.GetAceptada());
                archivoSolicitudes.WriteLine(s.GetId());
                archivoSolicitudes.WriteLine(s.GetPapeleria());
                archivoSolicitudes.WriteLine(s.GetNombre());
                archivoSolicitudes.WriteLine(s.GetDepartamento());
                archivoSolicitudes.WriteLine(s.GetCantidad());
                archivoSolicitudes.WriteLine(s.GetMotivo());
                archivoSolicitudes.WriteLine("");
            }
            archivoSolicitudes.Close();

            foreach (Tarjeta t in tarjetas)
            {
                archivoTarjetas.WriteLine(t.GetNombreBanco());
                archivoTarjetas.WriteLine(t.GetTipoTarjeta1());
                archivoTarjetas.WriteLine(t.GetTipoTarjeta2());
                archivoTarjetas.WriteLine(t.GetNumeroTarjeta());
                archivoTarjetas.WriteLine(t.GetNombreTitular());
                archivoTarjetas.WriteLine(t.GetCvc());
                archivoTarjetas.WriteLine("");
            }
            archivoTarjetas.Close();

            foreach (Carrito c in carritos)
            {
                archivoCarrito.WriteLine(c.GetId());
                archivoCarrito.WriteLine(c.GetPuntos());
                archivoCarrito.WriteLine(c.GetNumeroProductos());
                archivoCarrito.WriteLine(c.GetContadorPrecio());
                if (c.GetNumeroProductos() != 0)
                {
                    archivoCarrito.WriteLine("");
                    foreach (Producto p in c.GetProductos())
                    {
                        archivoCarrito.WriteLine(p.GetNombre());
                        archivoCarrito.WriteLine(p.GetDescripcion());
                        archivoCarrito.WriteLine(p.GetPrecio());
                        archivoCarrito.WriteLine(p.GetStock());
                        archivoCarrito.WriteLine(p.GetCodigoDeSerie());
                        archivoCarrito.WriteLine(p.GetCodigoDeInventario());
                        archivoCarrito.WriteLine(p.GetPapeleria());
                        archivoCarrito.WriteLine(p.GetDepartamento());
                        archivoCarrito.WriteLine("");
                    }
                }
                else
                {
                    archivoCarrito.WriteLine("");
                }
                archivoCarrito.WriteLine("");
            }
            archivoCarrito.Close();

            foreach (Recibo r in recibos)
            {
                archivoRecibos.WriteLine(r.GetPapeleria());
                archivoRecibos.WriteLine(r.GetFecha());
                archivoRecibos.WriteLine(r.GetHora());
                archivoRecibos.WriteLine(r.GetNombreCliente());
                archivoRecibos.WriteLine(r.GetNumeroProductos());
                archivoRecibos.WriteLine("");
                foreach (Producto p in r.GetProductos())
                {
                    archivoRecibos.WriteLine(p.GetNombre());
                    archivoRecibos.WriteLine(p.GetDescripcion());
                    archivoRecibos.WriteLine(p.GetPrecio());
                    archivoRecibos.WriteLine(p.GetStock());
                    archivoRecibos.WriteLine(p.GetCodigoDeSerie());
                    archivoRecibos.WriteLine(p.GetCodigoDeInventario());
                    archivoRecibos.WriteLine(p.GetPapeleria());
                    archivoRecibos.WriteLine(p.GetDepartamento());
                    archivoRecibos.WriteLine("");
                }
                archivoRecibos.WriteLine(r.GetPrecioTotal());
                archivoRecibos.WriteLine("");
                archivoRecibos.WriteLine("");
            }
            archivoRecibos.Close();
        }
    }
}
