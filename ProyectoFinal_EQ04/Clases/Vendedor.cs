using System;
using System.Collections.Generic;

namespace Clases
{
    public class Vendedor : Usuario
    {
        //Constructor sin argumentos
        public Vendedor()
        {

        }


        /**************************************** Métodos para la clase Vendedor ****************************************/


        //Menú sobreescrito de la clase usuario haciendo uso de polimorfismo. 
        public override void Menu(List<Producto> productos, List<Usuario> usuarios, List<Solicitud> solicitudes, List<Recibo> recibos)
        {
            //Instancia de la clase Producto
            Producto producto = new Producto();

            //Instancia de la clase Solicitud
            Solicitud solicitud = new Solicitud();

            //Variables para el método
            int opcion = 0, opcion1 = 0, opcion2 = 0, opcion3 = 0, opcion4 = 0;
            
            do
            {
                try
                {//menu principal
                    Console.WriteLine("\n =============== Vendedor ===============\n");
                    Console.WriteLine(" Elegir una opción\n\n");
                    Console.Write(" 1. Ver catálogo\n" +
                                  " 2. Buscar producto\n" +
                                  " 3. Solicitud de material\n" +
                                  " 4. Buscar clientes\n" +
                                  " 5. Perfil\n" +
                                  " 6. Salir\n\n" +
                                  " Opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    Console.Clear(); //Limpiamos la pantalla
                    switch (opcion)
                    {
                        case 1:
                            do
                            {
                                try //usamos un bloque try catch para manejas las excepciones
                                {
                                    Console.WriteLine("\n =============== Catálogo ===============\n");
                                    Console.Write(" 1. Catálogo en orden alfabético (por nombre)\n" +
                                                  " 2. Catálogo por departamento\n" +
                                                  " 3. Regresar\n\n" +
                                                  " Opción: ");
                                    opcion1 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                    switch (opcion1)
                                    {//vemos las opciones ver por catalogo y departamento con sus respectivos metodos para mostrar
                                        case 1:
                                            Console.WriteLine("\n =============== Catálogo por nombre ===============\n");
                                            producto.VerInventario(productos, "Nombre", 0, 0, "");
                                            break;
                                        case 2:
                                            Console.WriteLine("\n =============== Catálogo por departamento ===============\n");
                                            producto.VerInventario(productos, "Departamento", 0, 0, "");
                                            break;
                                        case 3:
                                            Console.WriteLine("\n Regresando...");
                                            break;
                                        default:
                                            Console.WriteLine("\n -> Opción no válida, intente de nuevo");
                                            break;
                                    }
                                }catch  (Exception e) //en caso de que se genere una excepcion se mostrará el bloque catch
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n -> Debe insertar un número");
                                }
                                Console.WriteLine("\n └> Presione ENTER para continuar");
                                Console.ReadLine();
                                Console.Clear();
                            }  while  (opcion1 != 3); //usamos un ciclo do while para poder repetir el menú si la opcion es diferente de la opcion salir
                            break;
                        case 2:
                            do 
                            {
                                try
                                {
                                    Console.WriteLine("\n =============== Búsqueda de productos ===============\n");
                                    Console.Write(" 1. Buscar por nombre de producto\n" +
                                                  " 2. Buscar por departamento\n" +
                                                  " 3. Regresar\n\n" +
                                                  " Opción: ");
                                    opcion2 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                    switch (opcion2)
                                    {//opcion 2 del menu principal para buscar por nombre o departamento
                                        case 1:
                                            Console.WriteLine("\n =============== Producto por nombre ===============\n");
                                            producto.VerInventario(productos, "Nombre", 1, 0, "");
                                            break;
                                        case 2:
                                            Console.WriteLine("\n =============== Producto por departamento ===============\n");
                                            producto.VerInventario(productos, "Departamento", 1, 0, "");
                                            break;
                                        case 3:
                                            Console.WriteLine("\n Regresando...");
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
                            } while (opcion2 != 3);
                            break;
                        case 3: //opcion 3 del menu principal para ver las solucitudes de material
                            solicitud.SolicitudDeMaterial(solicitudes, productos, GetPapeleria());
                            break;
                        case 4://opcion 4 para buscar usuarios por nombre por apellido o mostrar todos los usuarios
                            do
                            {
                                try
                                {
                                    Console.WriteLine("\n =============== Búsqueda de clientes ===============\n");
                                    Console.Write(" 1. Buscar por apellido de cliente\n" +
                                                  " 2. Buscar por nombre de cliente\n" +
                                                  " 3. Mostrar todos los clientes\n" +
                                                  " 4. Regresar\n\n" +
                                                  " Opción: ");
                                    opcion3 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                    switch (opcion3)
                                    {
                                        case 1:
                                            Console.WriteLine("\n =============== Clientes por apellido ===============\n");
                                            VerUsuarios(usuarios, "Cliente", "Apellido", 1);
                                            break;
                                        case 2:
                                            Console.WriteLine("\n =============== Clientes por nombre ===============\n");
                                            VerUsuarios(usuarios, "Cliente", "Nombre", 1);
                                            break;
                                        case 3:
                                            Console.WriteLine("\n =============== Clientes ===============\n");
                                            VerUsuarios(usuarios, "Cliente", "Nombre", 0);
                                            break;
                                        case 4:
                                            Console.WriteLine("\n Regresando...");
                                            break;
                                        default:
                                            Console.WriteLine("\n -> Opción no válida, intente de nuevo");
                                            break;
                                    }
                                }
                                catch(Exception e) //manejamos las escepciones que se puedan presentar
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n -> Debe insertar un número");
                                }
                                Console.WriteLine("\n └> Presione ENTER para continuar");
                                Console.ReadLine();
                                Console.Clear();
                            } while  (opcion3 != 4); //repetimos el menu si la opcion es diferente de la opcion salir
                            break;
                        case 5: //opcion para ver o editar perfil
                            do
                            {
                                try
                                {
                                    Console.WriteLine("\n =============== Perfil ===============\n");
                                    Console.Write(" 1. Ver mi perfil\n" +
                                                  " 2. Editar mi perfil\n" +
                                                  " 3. Regresar\n\n" +
                                                  " Opción: ");
                                    opcion4 = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                    switch (opcion4)
                                    {
                                        case 1:
                                            Console.WriteLine("\n =============== Perfil: " + GetNombre() + " " + GetApellidos() + " ===============\n");
                                            VerUsuarios(usuarios, "Empleado", "Nombre", 2);
                                            break;
                                        case 2:
                                            Console.WriteLine("\n =============== Editar mi perfil: " + GetNombre() + " " + GetApellidos() + " ===============\n");
                                            EditarPerfil("Vendedor");
                                            break;
                                        case 3:
                                            Console.WriteLine("\n Regresando...");
                                            break;
                                        default:
                                            Console.WriteLine("\n -> Opción no válida, intente de nuevo");
                                            break;
                                    }
                                }
                                catch(Exception e) //manejamos las excepciones
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n -> Debe insertar un número");
                                }
                                Console.WriteLine("\n └> Presione ENTER para continuar");
                                Console.ReadLine();
                                Console.Clear();
                            } while (opcion4 != 3); //repetimos el menu si la opcion es diferente de salir
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
                catch (Exception e) //manejamos la excepcion
                {
                    Console.Clear();
                    Console.WriteLine("\n -> Debe insertar un número, intente de nuevo\n ");
                    Console.WriteLine(" Presione ENTER para continuar\n");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (opcion != 6); //repetimos el menu si la opcion es diferente de salir
        }
    }
}
