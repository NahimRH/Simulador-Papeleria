using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Clases
{
    public class Administrador : Usuario
    {
        //Constructor sin argumentos
        public Administrador()
        {

        }


        /**************************************** Métodos para la clase Administrador ****************************************/


        //Menú para el administrador
        public override void Menu(List<Producto> productos, List<Usuario> usuarios, List<Solicitud> solicitudes, List<Recibo> recibos)
        {
            //Instancia de la clase Producto
            Producto producto = new Producto();

            //Instancia de la clase Solicitud
            Solicitud solicitud = new Solicitud();

            //Instancia de la clase Solicitud
            List<Tarjeta> tarjetas = new List<Tarjeta>();

            //Instancia de la clase Solicitud
            List<Carrito> carritos = new List<Carrito>();

            //Variables para el método
            int opcion = 0, opcion1 = 0, opcion2 = 0, opcion3 = 0, opcion4 = 0, opcion5 = 0;

            do
            {
                try
                {
                    Console.WriteLine("\n =============== Administrador ===============\n");
                    Console.WriteLine(" Elegir una opción\n\n");
                    Console.Write(" 1. Ver tiendas\n" +
                                  " 2. Empleados\n" +
                                  " 3. Inventario (por tienda)\n" +
                                  " 4. Reportes\n" +
                                  " 5. Salir\n\n" +
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
                                    Console.WriteLine("\n =============== Ver tiendas ===============\n");
                                    Console.Write(" 1. Ver inventario (todos los productos)\n" +
                                                  " 2. Buscar en inventario\n" +
                                                  " 3. Regresar\n\n" +
                                                  " Opción: ");
                                    opcion1 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                    switch (opcion1)
                                    {
                                        case 1:
                                            Console.WriteLine("\n =============== Inventario total ===============\n");
                                            producto.VerInventario(productos, "Tienda", 0, 0, "");
                                            break;
                                        case 2:
                                            Console.WriteLine("\n =============== Búsqueda en el inventario total ===============\n");
                                            producto.VerInventario(productos, "Nombre", 1, 0, "");
                                            break;
                                        case 3:
                                            Console.WriteLine("\n Regresando...");
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
                            } while (opcion1 != 3);
                            break;
                        case 2:
                            do
                            {
                                try
                                {
                                    Console.WriteLine("\n =============== Empleados ===============\n");
                                    Console.Write(" 1. Ver empleados\n" +
                                                  " 2. Nuevo registro\n" +
                                                  " 3. Actualizar registro\n" +
                                                  " 4. Eliminar registro\n" +
                                                  " 5. Regresar\n\n" +
                                                  " Opción: ");
                                    opcion2 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                    switch (opcion2)
                                    {
                                        case 1:
                                            Console.WriteLine("\n =============== Lista de empleados ===============\n");
                                            VerUsuarios(usuarios, "Empleado", "ID", 0);
                                            break;
                                        case 2:
                                            Console.WriteLine("\n =============== Registrar nuevo empleado ===============\n");
                                            NuevoRegistro(usuarios, "Administrador", carritos, tarjetas);
                                            break;
                                        case 3:
                                            Console.WriteLine("\n =============== Editar perfil ===============\n");
                                            EditarPerfilEmpleados(usuarios);
                                            break;
                                        case 4:
                                            Console.WriteLine("\n =============== Eliminar empleado ===============\n");
                                            EliminarRegistro(usuarios);
                                            break;
                                        case 5:
                                            Console.WriteLine("\n Regresando...");
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
                            } while (opcion2 != 5);
                            break;
                        case 3:
                            do
                            {
                                try
                                {
                                    Console.WriteLine("\n =============== Inventario (por tienda) ===============\n");
                                    Console.Write(" 1. Ver inventario de productos (por tienda)\n" +
                                                  " 2. Dar alta de producto (agregar)\n" +
                                                  " 3. Ver solicitudes de nuevo material\n" +
                                                  " 4. Añadir stock (Aceptar solicitud de material)\n" +
                                                  " 5. Regresar\n\n" +
                                                  " Opcíon: ");
                                    opcion3 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                    switch (opcion3)
                                    {
                                        case 1:
                                            Console.WriteLine("\n =============== Inventario de productos (por tienda) ===============\n");
                                            producto.VerInventario(productos, "Tienda", 1, 0, "");
                                            break;
                                        case 2:
                                            Console.WriteLine("\n =============== Agregar un producto ===============\n");
                                            producto.AltaDeProducto(productos);
                                            break;
                                        case 3:
                                            Console.WriteLine("\n =============== Lista de solicitudes de nuevo material ===============\n");
                                            solicitud.VerSolicitudesMaterial(solicitudes);
                                            break;
                                        case 4:
                                            Console.WriteLine("\n =============== Añadir stock ===============\n");
                                            solicitud.AñadirStock(solicitudes, productos);
                                            break;
                                        case 5:
                                            Console.WriteLine("\n Regresando...");
                                            break;
                                        default:
                                            Console.WriteLine("\n -> Opción no válida, intente de nuevo");
                                            break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n -> Debe insertar una número");
                                }
                                Console.WriteLine("\n └> Presione ENTER para continuar");
                                Console.ReadLine();
                                Console.Clear();
                            } while (opcion3 != 5);
                            break;
                        case 4:
                            do
                            {
                                try
                                {
                                    Console.WriteLine("\n =============== Reportes ===============\n");
                                    Console.Write(" 1. Ver total de ventas por producto\n" +
                                                  " 2. Ver total de ventas por departamento\n" +
                                                  " 3. Ver compras\n" +
                                                  " 4. Regresar\n\n" +
                                                  " Opción: ");
                                    opcion4 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                    switch (opcion4)
                                    {
                                        case 1:
                                            Console.WriteLine("\n =============== Ver total de ventas por producto ===============\n");
                                            TotalDeVentas(recibos, "producto");
                                            break;
                                        case 2:
                                            Console.WriteLine("\n =============== Ver total de ventas por departamento ===============\n");
                                            TotalDeVentas(recibos, "departamento");
                                            break;
                                        case 3:
                                            do
                                            {
                                                try
                                                {
                                                    Console.WriteLine("\n =============== Ver compras ===============\n");
                                                    Console.Write(" 1. Ver todas las compras\n" +
                                                                  " 2. Buscar por producto\n" +
                                                                  " 3. Regresar\n\n" +
                                                                  " Opción: ");
                                                    opcion5 = Convert.ToInt32(Console.ReadLine());
                                                    Console.Clear();
                                                    switch (opcion5)
                                                    {
                                                        case 1:
                                                            Console.WriteLine("\n =============== Ver todas las compras ===============\n");
                                                            TotalCompras(solicitudes, productos, "total");
                                                            Console.WriteLine("\n └> Presione ENTER para continuar");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            break;
                                                        case 2:
                                                            Console.WriteLine("\n =============== Buscar por producto ===============\n");
                                                            TotalCompras(solicitudes, productos, "producto");
                                                            Console.WriteLine("\n └> Presione ENTER para continuar");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            break;
                                                        case 3:
                                                            Console.WriteLine("\n Regresando...");
                                                            break;
                                                        default:
                                                            Console.WriteLine("\n -> Opción no válida, intente de nuevo");
                                                            Console.WriteLine("\n └> Presione ENTER para continuar");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            break;
                                                    }
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\n -> Debe insertar una número");
                                                    Console.WriteLine("\n └> Presione ENTER para continuar");
                                                    Console.ReadLine();
                                                    Console.Clear();
                                                }
                                            } while (opcion5 != 3);
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
                                    Console.WriteLine("\n -> Debe insertar una número");
                                }
                                Console.WriteLine("\n └> Presione ENTER para continuar");
                                Console.ReadLine();
                                Console.Clear();
                            } while (opcion4 != 4);
                            break;
                        case 5:
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
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("\n Debe insertar un número, intenta de nuevo.\n ");
                    Console.WriteLine(" Presione ENTER para continuar.\n");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (opcion != 5);
        }


        /**************************************** Métodos para la clase Administrador ****************************************/


        /***** Método global que será utilizado en la mayoría de métodos *****/
        //Método que sirve para convertir la primera letra de una palabra en mayúscula
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;


        //Método para editar perfil de los empleados
        public void EditarPerfilEmpleados(List<Usuario> usuarios)
        {
            //Variables para el método
            int id;
            bool bandera = false, bandera1 = false;

            do
            {
                VerUsuarios(usuarios, "Empleado", "ID", 0);

                Console.Write("\n Ingrese el ID del empleado que desea modificar: ");
                id = Convert.ToInt32(Console.ReadLine());
                foreach (Usuario u in usuarios)
                {
                    if (u.GetId().Equals(id))
                    {
                        bandera = true;
                        u.EditarPerfil(u.GetTipoUsuario());
                        break;
                    }
                }
                if (!bandera)
                {
                    Console.WriteLine("\n El empleado " + id + " no se encuentra en la empresa");
                    do
                    {
                        try
                        {
                            Console.Write("\n ¿Desea buscar otro empleado?\n\n 1. Sí\n 2. No\n\n Opción: ");
                            int opcion1 = Convert.ToInt32(Console.ReadLine());
                            switch (opcion1)
                            {
                                case 1:
                                    bandera1 = true;
                                    bandera = false;
                                    break;
                                case 2:
                                    bandera1 = true;
                                    bandera = true;
                                    break;
                                default:
                                    Console.WriteLine("\n -> Opción no válida, intente de nuevo");
                                    break;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\n -> Debe insertar un número");
                        }
                    } while (!bandera1);
                }
            } while (!bandera);
        }

        //Ver total de ventas por producto
        public void TotalDeVentas(List<Recibo> recibos, string criterio)
        {
            string cadena;
            double ventaTotal = 0;
            int piezas = 0; ;


            Console.Write("\n Ingrese el " + criterio + ": ");
            cadena = ti.ToTitleCase(Console.ReadLine().ToLower());

            foreach (Recibo r in recibos)
            {
                foreach(Producto p in r.GetProductos())
                {
                    if (criterio.Equals("producto"))
                    {
                        if (p.GetNombre().Contains(cadena))
                        {
                            piezas += p.GetStock();
                            ventaTotal  += p.GetPrecio();
                        }
                    }
                    else
                    {
                        if (p.GetDepartamento().Contains(cadena))
                        {
                            piezas += p.GetStock();
                            ventaTotal += p.GetPrecio();
                        }
                    }
                }
            }
            Console.WriteLine("\n Unidades vendidas: " + piezas + " piezas" +
                              "\n Total de ventas del " + criterio + ": " + ventaTotal + " pesos");
        }

        //Ver total de compras
        public void TotalCompras(List<Solicitud> solicitudes, List<Producto> productos, string criterio)
        {
            //Variables para el método
            double total = 0;
            int piezas = 0;
            double precio = 0;
            string cadena;

            if (criterio.Equals("producto"))
            {
                Console.Write("\n Ingrese el " + criterio + ": ");
                cadena = ti.ToTitleCase(Console.ReadLine().ToLower());

                foreach (Producto p in productos)
                {
                    if (p.GetNombre().Contains(cadena))
                    {
                        precio = p.GetPrecio();
                        break;
                    }
                }

                foreach (Solicitud s in solicitudes)
                {
                    if (s.GetAceptada() == true && s.GetNombre().Contains(cadena))
                    {
                        piezas += s.GetCantidad();
                        total += precio * piezas;
                    }
                }
            }
            else
            {
                foreach (Solicitud s in solicitudes)
                {
                    if (s.GetAceptada() == true)
                    {
                        foreach(Producto p in productos)
                        {
                            if (p.GetNombre().Equals(s.GetNombre()))
                            {
                                precio = p.GetPrecio();
                                break;
                            }
                        }
                        piezas += s.GetCantidad();
                        total += (precio * s.GetCantidad());
                    }
                }
            }
            Console.WriteLine(" Piezas compradas: " + piezas + " Total: " + total + " pesos");
        }
    }
}
