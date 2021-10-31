using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Clases
{
    public class Solicitud
    {
        //Atributos
        public int id;
        public string nombre;
        public string papeleria;
        public string departamento;
        public int cantidad;
        public string motivo;
        public bool aceptada = false;

        //Constructor sin argumentos
        public Solicitud()
        {

        }

        //Constructor con argumentos
        public Solicitud(int id, string nombre, string papeleria, string departamento, int cantidad, string motivo)
        {
            this.id = id;
            this.nombre = nombre;
            this.papeleria = papeleria;
            this.departamento = departamento;
            this.cantidad = cantidad;
            this.motivo = motivo;
        }

        //Setters
        public void SetAceptada(bool aceptada) { this.aceptada = aceptada; }
        public void SetId(int id) { this.id = id; }
        public void SetNombre(string nombre) { this.nombre = nombre; }
        public void SetPapeleria(string papeleria) { this.papeleria = papeleria; }
        public void SetDepartamento(string departamento) { this.departamento = departamento; }
        public void SetCantidad(int cantidad) { this.cantidad = cantidad; }
        public void SetMotivo(string motivo) { this.motivo = motivo; }
        

        //Getters
        public bool GetAceptada() { return aceptada;  }
        public int GetId() { return id; }
        public string GetNombre() { return nombre; }
        public string GetPapeleria() { return papeleria; }
        public string GetDepartamento() { return departamento; }
        public int GetCantidad() { return cantidad; }
        public string GetMotivo() { return motivo; }


        /**************************************** Métodos para la clase Solicitud ****************************************/


        /***** Método global que será utilizado en la mayoría de métodos *****/
        //Método que sirve para convertir la primera letra de una palabra en mayúscula
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;


        //Método que sirve para llenar una solicitud con los datos que se leen de un txt
        public void LlenarSolicitud(int opcion, string linea)
        {
            switch (opcion)
            {
                case 0:
                    SetAceptada(Convert.ToBoolean(linea));
                    break;
                case 1:
                    SetId(Convert.ToInt32(linea));
                    break;

                case 2:
                    SetNombre(linea);
                    break;

                case 3:
                    SetPapeleria(linea);
                    break;

                case 4:
                    SetDepartamento(linea);
                    break;

                case 5:
                    SetCantidad(Convert.ToInt32(linea));
                    break;

                case 6:
                    SetMotivo(linea);
                    break;
            }
        }

        //Método que sirve para imprimir solicitudes
        public void ImprimirSolicitud()
        {
            Console.WriteLine(" ==========================================================\n" + 
                              "\n " + GetId() +
                              "\n " + GetNombre() +
                              "\n " + GetPapeleria() +
                              "\n " + GetDepartamento() +
                              "\n " + GetCantidad() +
                              "\n " + GetMotivo() +
                              "\n\n ==========================================================");
        }

        //Método que sirve para crear una solicitud
        public void SolicitudDeMaterial(List<Solicitud> solicitudes, List<Producto> productos, string tienda)
        {
            //Instancia de la clase Producto
            Producto producto = new Producto();

            //Instancia de la clase Solicitud
            Solicitud solicitud = new Solicitud();

            //Variables para el método
            int opcion = 0;
            bool bandera = false;
            string cadena;

            do
            {
                try
                {
                    Console.WriteLine("\n =============== Solicitud de material ===============\n");
                    Console.Write(" 1. Agregar stock de productos sin existencias\n" +
                                  " 2. Buscar producto\n" +
                                  " 3. Regresar\n\n" +
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
                                    Console.WriteLine("\n Productos sin Stock:\n");
                                    producto.VerInventario(productos, "Nombre", 2, 2, tienda);
                                    Console.Write(" Ingrese el código de inventario: "); cadena = Console.ReadLine();
                                    foreach (Producto p in productos)
                                    {
                                        if (p.GetCodigoDeInventario().Equals(cadena))
                                        {
                                            solicitud.SetNombre(p.GetNombre());
                                            solicitud.SetPapeleria(p.GetPapeleria());
                                            solicitud.SetDepartamento(p.GetDepartamento());
                                            Console.Write(" Cantidad a solicitar: "); solicitud.SetCantidad(Convert.ToInt32(Console.ReadLine()));
                                            Console.Write(" Motivo: "); solicitud.SetMotivo(ti.ToTitleCase(Console.ReadLine().ToLower()));
                                            bandera = true;
                                            break;
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n -> Debe insertar un número");
                                }
                            } while (!bandera);
                            break;
                        case 2:
                            do
                            {
                                try
                                {
                                    Console.WriteLine("\n Solicitud de producto por nombre\n");
                                    producto.VerInventario(productos, "Nombre", 1, 1, tienda);
                                    Console.Write(" Ingrese el código de inventario: "); cadena = Console.ReadLine();
                                    foreach(Producto p in productos)
                                    {
                                        if (p.GetCodigoDeInventario().Equals(cadena))
                                        {
                                            solicitud.SetNombre(p.GetNombre());
                                            solicitud.SetPapeleria(p.GetPapeleria());
                                            solicitud.SetDepartamento(p.GetDepartamento());
                                            Console.Write(" Cantidad a solicitar: "); solicitud.SetCantidad(Convert.ToInt32(Console.ReadLine()));
                                            Console.Write(" Motivo: "); solicitud.SetMotivo(ti.ToTitleCase(Console.ReadLine().ToLower()));
                                            bandera = true;
                                            break;
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n -> Debe insertar un número");
                                }
                            }  while  (!bandera);
                            break;
                        case 3:
                            Console.WriteLine("\n Regresando...");
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
            } while (opcion != 3);
            solicitudes.Add(solicitud);
        }

        //Método que muestra las solicitudes de material
        public void VerSolicitudesMaterial(List<Solicitud> solicitudes)
        {
            //Variables para el método
            bool bandera = false;

            if (solicitudes.Count() != 0)
            {
                foreach (Solicitud s in solicitudes)
                {
                    if (!s.GetAceptada())
                    {
                        s.ImprimirSolicitud();
                        bandera = true;
                    }
                }
            }
            else if(!bandera)
            {
                Console.WriteLine("\n No hay solicitudes");
            }
        }

        //Método que sirve para aceptar las solicitudes de material
        public void AñadirStock(List<Solicitud> solicitudes, List<Producto> productos)
        {
            //Variables para el método
            bool bandera = false;

            if(solicitudes.Count() != 0)
            {
                foreach (Solicitud s in solicitudes)
                {
                    if (!s.GetAceptada())
                    {
                        Console.WriteLine("\n Producto: " + s.GetNombre() + " de " + s.GetPapeleria() + " requiere " + s.GetCantidad() + " piezas");
                        foreach (Producto p in productos)
                        {
                            if (p.GetNombre().Equals(s.GetNombre()) && p.GetPapeleria().Equals(s.GetPapeleria()))
                            {
                                bandera = true;
                                p.SetStock(p.GetStock() + s.GetCantidad());
                                s.SetAceptada(true);
                            }
                        }
                    }
                }
                if (!bandera)
                {
                    Console.WriteLine("\n Las solicitudes ya fueron aceptadas");
                }
            }
            else
            {
                Console.WriteLine("\n No hay solicitudes");
            }
        }
    }
}
