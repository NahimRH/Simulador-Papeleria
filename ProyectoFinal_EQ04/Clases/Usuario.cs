using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Clases
{
    public class Usuario
    {
        //Atributos
        public string nombre;
        public string apellidos;
        public string direccion;
        public string correo;
        public double telefono;
        public string contraseña;
        public int id;
        public string tipoUsuario;
        public string papeleria;

        //Constructor sin argumentos
        public Usuario()
        {

        }

        //Constructor con argumentos
        public Usuario(string nombre, string apellidos, string direccion, string correo, double telefono, string contraseña, int id, string tipoUsuario, string papeleria)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.correo = correo;
            this.telefono = telefono;
            this.contraseña = contraseña;
            this.id = id;
            this.tipoUsuario = tipoUsuario;
            this.papeleria = papeleria;
        }

        //Setters
        public void SetNombre(string nombre) { this.nombre = nombre; }
        public void SetApellidos(string apellidos) { this.apellidos = apellidos; }
        public void SetDireccion(string direccion) { this.direccion = direccion; }
        public void SetCorreo(string correo) { this.correo = correo; }
        public void SetTelefono(double telefono) { this.telefono = telefono; }
        public void SetContraseña(string contraseña) { this.contraseña = contraseña; }
        public void SetId(int id) { this.id = id; }
        public void SetTipoUsuario(string tipoUsuario) { this.tipoUsuario = tipoUsuario; }
        public void SetPapeleria(string papeleria) { this.papeleria = papeleria; }

        //Getters
        public string GetNombre() { return nombre; }
        public string GetApellidos() { return apellidos; }
        public string GetDireccion() { return direccion; }
        public string GetCorreo() { return correo; }
        public double GetTelefono() { return telefono; }
        public string GetContraseña() { return contraseña; }
        public int GetId() { return id; }
        public string GetTipoUsuario() { return tipoUsuario; }
        public string GetPapeleria() { return papeleria; }


        /**************************************** Métodos para la clase Usuario ****************************************/


        /***** Método global que será utilizado en la mayoría de métodos *****/
        //Método que sirve para convertir la primera letra de una palabra en mayúscula
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;


        //Menú principal el cual será ocupado en las demás clases
        public virtual void Menu(List<Producto> productos, List<Usuario> usuarios, List<Solicitud> solicitudes, List<Recibo> recibos)
        {

        }

        /*************** Inicio: Método para registar nuevos empleados y clientes ***************/

        public string IngresarCadena(int accion)
        {
            //Variables para el método
            bool bandera = false;
            string cadena = "";
            do
            {
                if (accion == 0)
                {
                    cadena = ti.ToTitleCase(Console.ReadLine().ToLower());
                }
                else
                {
                    cadena = Console.ReadLine();
                }
                
                if (cadena != "")
                {
                    bandera = true;
                    return cadena;
                }
                else
                {
                    Console.WriteLine("\n Ingresa una cadena válida\n");
                }
            } while (!bandera);
            return cadena;
        }

        //Método que sirve para agregar nuevos empleados y clientes
        public void NuevoRegistro(List<Usuario> usuarios, string tipoUsuario, List<Carrito> carritos, List<Tarjeta> tarjetas)
        {
            //Instancia de la clase Usuario
            Usuario usuario = new Usuario();

            Console.Write(" Ingrese el nombre: "); usuario.SetNombre(IngresarCadena(0));

            Console.Write(" Ingrese los apellidos: "); usuario.SetApellidos(IngresarCadena(0));

            Console.Write(" Ingrese la dirección: "); usuario.SetDireccion(IngresarCadena(0));

            Console.Write(" Ingrese el correo: "); usuario.SetCorreo(IngresarCadena(1));

            Console.Write(" Ingrese la contraseña: "); usuario.SetContraseña(IngresarCadena(1));

            //Teléfono
            AsignarTelefono(usuario);

            //Tienda
            usuario.SetPapeleria(AsignarTienda());

            //Id para empleados y clientes, y área para los empleados
            if (tipoUsuario.Equals("Cliente"))
            {
                //Instancia de la clase Carrito
                Carrito carrito = new Carrito();

                //Instancia de la clase Tarjeta
                Tarjeta tarjeta = new Tarjeta();

                //Creación de una lista de recibos
                List<Recibo> recibos = new List<Recibo>();

                usuario.SetTipoUsuario(tipoUsuario);
                tarjeta = AsignarTarjeta(usuario);
                usuario.SetId(0);
                carrito.SetId(usuario.GetNombre() + " " + usuario.GetApellidos());
                usuarios.Add(usuario.UsuarioCliente(carrito, tarjeta, recibos));
                carritos.Add(carrito);
                tarjetas.Add(tarjeta);
            }
            else
            {
                AsignarID(usuarios, usuario);
                AsignarArea(usuario);
                if (usuario.GetTipoUsuario().Equals("Administrador"))
                {
                    usuarios.Add(usuario.UsuarioAdministrador());
                }
                else
                {
                    usuarios.Add(usuario.UsuarioVendedor());
                }
            }
        }

        //Método para asignar ID a los empleados
        public void AsignarID(List<Usuario> usuarios, Usuario usuario)
        {
            //Variables para el método
            int numEmpleados = 1;

            foreach (Usuario u in usuarios)
            {
                if (u.GetTipoUsuario() != "Cliente")
                {
                    numEmpleados++;
                }
            }
            usuario.SetId(numEmpleados);
        }

        //Método para asignar el número telefónico a los empleados y clientes
        public void AsignarTelefono(Usuario usuario)
        {
            //Variables para el método
            int digitos;
            double num;
            bool bandera = false;

            do
            {
                try
                {
                    Console.Write(" Ingrese el teléfono: ");
                    num = Convert.ToDouble(Console.ReadLine());
                    digitos = (int)Math.Floor(Math.Log10(num) + 1);
                    if (digitos == 10)
                    {
                        bandera = true;
                        usuario.SetTelefono(num);
                        Console.WriteLine(" - Teléfono asignado -\n");
                        break;
                    }
                    else if (!bandera)
                    {
                        Console.WriteLine("\n -> Debe ingresar un número telefónico de 10 dígitos\n");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n -> Debe ingresar un número telefónico\n");
                }
            } while (!bandera);
        }

        //Método para asignar el área de trabajo de los empleados
        public void AsignarArea(Usuario usuario)
        {
            //Variables para el método
            int opcion;
            bool bandera = false;

            do
            {
                try
                {
                    Console.Write(" ¿Qué área desea ocupar?\n\n" +
                                    " 1. Vendedor\n" +
                                    " 2. Administrador\n\n" +
                                    " Opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            usuario.SetTipoUsuario("Vendedor");
                            Console.WriteLine(" - Área asignada -\n");
                            bandera = true;
                            break;
                        case 2:
                            usuario.SetTipoUsuario("Administrador");
                            Console.WriteLine(" - Área asignada -\n");
                            bandera = true;
                            break;
                        default:
                            Console.WriteLine("\n -> Opción no válida, por favor ingrese una de las opciones mostradas\n");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n -> Debe insertar un número\n");
                }
            } while (!bandera);
        }

        //Método para asignar la papelería a los empleados y clientes
        public string AsignarTienda()
        {
            //Variables para el método
            int opcion;
            bool bandera = false;
            string cadena = " ";

            do
            {
                try
                {
                    Console.Write(" ¿Qué tienda le queda más cercana?\n\n" +
                                    " 1. Super Papelerías Insurgentes\n" +
                                    " 2. Super Papelerías Tlalpan\n" +
                                    " 3. Super Papelerías Coyoacán\n\n" +
                                    " Opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            cadena = "Super Papelerías Insurgentes";
                            Console.WriteLine(" - Tienda asignada -\n");
                            bandera = true;
                            break;
                        case 2:
                            cadena = "Super Papelerías Tlalpan";
                            Console.WriteLine(" - Tienda asignada -\n");
                            bandera = true;
                            break;
                        case 3:
                            cadena = "Super Papelerías Coyoacán";
                            Console.WriteLine(" - Tienda asignada -\n");
                            bandera = true;
                            break;
                        default:
                            Console.WriteLine("\n -> Opción no válida, por favor ingrese una de las opciones mostradas\n");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n -> Debe insertar un número\n");
                }
            } while (!bandera);
            return cadena;
        }

        //Método para asignar tarjeta para comprar a los clientes
        public Tarjeta AsignarTarjeta(Usuario usuario)
        {
            //Instancia de la clase Usuario
            Tarjeta tarjeta = new Tarjeta();

            Console.Write(" Ingrese el nombre del banco: "); tarjeta.SetNombreBanco(ti.ToTitleCase(Console.ReadLine().ToLower()));
            tarjeta.SetTipoTarjeta1(TipoTarjeta_1());
            tarjeta.SetTipoTarjeta2(TipoTarjeta_2());
            tarjeta.SetNumeroTarjeta(NumeroTarjeta());
            tarjeta.SetNombreTitular(usuario.GetNombre() + " " + usuario.GetApellidos());
            Console.Write(" Ingrese el código de verificación (CVC): "); tarjeta.SetCvc(Console.ReadLine());
            Console.WriteLine(" - Tarjeta asignada -\n");
            return tarjeta;
        }

        //Método para asignar el tipo de tarjeta (Crédito/Débito/Vales)
        public string TipoTarjeta_1()
        {
            //Variables para el método
            int opcion;
            bool bandera = false;
            string cadena = " ";

            do
            {
                try
                {
                    Console.Write("\n Seleccione el tipo de tarjeta\n" +
                                    " 1. Crédito\n" +
                                    " 2. Débito\n" +
                                    " 3. Vales\n\n" +
                                    " Opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            cadena = "Crédito";
                            Console.WriteLine(" - Tipo de tarjeta asignada -\n");
                            bandera = true;
                            break;
                        case 2:
                            cadena = "Débito";
                            Console.WriteLine(" - Tipo de tarjeta asignada -\n");
                            bandera = true;
                            break;
                        case 3:
                            cadena = "Vales";
                            Console.WriteLine(" - Tipo de tarjeta asignada -\n");
                            bandera = true;
                            break;
                        default:
                            Console.WriteLine("\n -> Opción no válida, por favor ingrese una de las opciones mostradas");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n -> Debe insertar un número");
                }
            } while (!bandera);
            return cadena;
        }

        //Método para asignar el tipo de tarjeta (Visa/MasterCard/American Express)
        public string TipoTarjeta_2()
        {
            //Variables para el método
            int opcion;
            bool bandera = false;
            string cadena = " ";

            do
            {
                try
                {
                    Console.Write(" Seleccione el tipo de tarjeta\n" +
                                    " 1. Visa\n" +
                                    " 2. MasterCard\n" +
                                    " 3. American Express\n\n" +
                                    " Opcion: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            cadena = "Visa";
                            Console.WriteLine(" - Tipo de tarjeta asignada -\n");
                            bandera = true;
                            break;
                        case 2:
                            cadena = "MasterCard";
                            Console.WriteLine(" - Tipo de tarjeta asignada -\n");
                            bandera = true;
                            break;
                        case 3:
                            cadena = "American Express";
                            Console.WriteLine(" - Tipo de tarjeta asignada -\n");
                            bandera = true;
                            break;
                        default:
                            Console.WriteLine("\n -> Opción no válida, por favor ingrese una de las opciones mostradas\n");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n -> Debe insertar un número\n");
                }
            } while (!bandera);
            return cadena;
        }

        //Método para asignar el número de tarjeta
        public string NumeroTarjeta()
        {
            //Variables para el método
            string cadena = " ";
            bool bandera = false;

            do
            {
                try
                {
                    Console.Write(" Ingrese el número de tarjeta: ");
                    cadena = Console.ReadLine();
                    if (cadena.Length.Equals(16))
                    {
                        bandera = true;
                        Console.WriteLine(" - Número de tarjeta asignado -\n");

                    }
                    if (!bandera)
                    {
                        Console.WriteLine("\n -> Debe ingresar un número de tarjeta de 16 dígitos\n");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n -> Debe ingresar un número de tarjeta\n");
                }
            } while (!bandera);
            return cadena;
        }



        /*************** Fin: Método para registar nuevos empleados y clientes ***************/


        //Método para eliminar empleados
        public void EliminarRegistro(List<Usuario> usuarios)
        {
            //Variables para el método
            int id;
            bool bandera = false, bandera1 = false;

            if (usuarios.Count() != 0)
            {
                VerUsuarios(usuarios, "Empleado", "ID", 0);
                do
                {
                    try
                    {
                        Console.Write(" Ingrese el ID del empleado que desea eliminar: ");
                        id = Convert.ToInt32(Console.ReadLine());

                        foreach (Usuario u in usuarios)
                        {
                            if (u.GetId().Equals(id))
                            {
                                bandera = true;
                                usuarios.Remove(u);
                                Console.WriteLine("\n El empleado ha sido eliminado");
                                break;
                            }
                        }
                        if (!bandera)
                        {
                            Console.WriteLine("\n El empleado no existe");
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
                    }
                    catch  (Exception e)
                    {
                        Console.WriteLine("\n -> Debe insertar un número\n");
                    }
                } while (!bandera);
            }
            else
            {
                Console.WriteLine("\n No hay empleados");
            }
        }


        //Método que sirve para modificar el perfil de los empleados y los clientes
        public void EditarPerfil(string tipoUsuario)
        {
            //Variables para el método
            int opc = 0;

            do
            {
                try
                {
                    Console.WriteLine("\n ¿Qué desea modificar?\n");
                    Console.WriteLine(" 1. Nombre\n 2. Apellido\n 3. Dirección\n 4. Correo\n 5. Celular\n 6. Contraseña\n 7. Salir\n");
                    Console.Write(" Opción: ");
                    opc = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (opc)
                    {
                        case 1:
                            Console.Write("\n Nombre: "); SetNombre(ti.ToTitleCase(Console.ReadLine().ToLower()));
                            Console.WriteLine("\n El " + tipoUsuario + " fue modificado correctamente, presiona ENTER para continuar");
                            break;
                        case 2:
                            Console.Write("\n Apellido: "); SetApellidos(ti.ToTitleCase(Console.ReadLine().ToLower()));
                            Console.WriteLine("\n El " + tipoUsuario + " fue modificado correctamente, presiona ENTER para continuar");
                            break;
                        case 3:
                            Console.Write("\n Dirección: "); SetDireccion(ti.ToTitleCase(Console.ReadLine().ToLower()));
                            Console.WriteLine("\n El " + tipoUsuario + " fue modificado correctamente, presiona ENTER para continuar");
                            break;
                        case 4:
                            Console.Write("\n Correo: "); SetCorreo(Console.ReadLine());
                            Console.WriteLine("\n El " + tipoUsuario + " fue modificado correctamente, presiona ENTER para continuar");
                            break;
                        case 5:
                            Console.Write("\n Teléfono: "); SetTelefono(Convert.ToDouble(Console.ReadLine()));
                            Console.WriteLine("\n El " + tipoUsuario + " fue modificado correctamente, presiona ENTER para continuar");
                            break;
                        case 6:
                            Console.Write("\n Contraseña: "); SetContraseña(Console.ReadLine());
                            Console.WriteLine("\n El " + tipoUsuario + " fue modificado correctamente, presiona ENTER para continuar");
                            break;
                        case 7:
                            Console.WriteLine("\n Saliendo...");
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
            } while (opc != 7);
        }


        //Método que sirve para mostrar clientes y empleados, para buscar clientes y empleados, y para mostrar el perfil de los clientes y empleados 
        public void VerUsuarios(List<Usuario> usuarios, string usuario, string criterio, int accion)
        {
            //Creamos una lista de tipo Usuario la cual contendra a los empleados ordenados por apellido
            List<Usuario> usuariosSort = new List<Usuario>();

            //Variables para el método
            string cadena;
            bool bandera = false, bandera1 = false;

            if (usuarios.Count() != 0)
            {
                if (criterio.Equals("Apellido"))
                {
                    //Ordenamos a los empleados por apellido
                    usuariosSort = usuarios.OrderBy(u => u.apellidos).ToList();
                }
                else if (criterio.Equals("Nombre"))
                {
                    //Ordenamos a los empleados por nombre
                    usuariosSort = usuarios.OrderBy(u => u.nombre).ToList();
                }
                else
                {
                    //Ordenamos a los empleados por ID
                    usuariosSort = usuarios.OrderBy(u => u.id).ToList();
                }

                if (accion.Equals(0))
                {
                    if (usuario.Equals("Cliente"))
                    {
                        foreach (Usuario u in usuariosSort)
                        {
                            if (u.GetTipoUsuario().Equals("Cliente"))
                            {
                                u.ImprimirUsuario();
                            }
                        }
                    }
                    else
                    {
                        foreach (Usuario u in usuariosSort)
                        {
                            if (u.GetTipoUsuario().Equals("Administrador") || u.GetTipoUsuario().Equals("Vendedor"))
                            {
                                u.ImprimirUsuario();
                            }
                        }
                    }
                }
                else if (accion.Equals(1))
                {
                    do
                    {
                        try
                        {
                            Console.Write("\n Ingrese " + criterio + ": "); cadena = ti.ToTitleCase(Console.ReadLine().ToLower());
                            foreach (Usuario u in usuariosSort)
                            {
                                if (u.GetTipoUsuario().Equals(usuario) && u.GetApellidos().Contains(cadena) && cadena != "")
                                {
                                    bandera = true;
                                    u.ImprimirUsuario();
                                }
                                else if (u.GetTipoUsuario().Equals(usuario) && u.GetNombre().Contains(cadena) && cadena != "")
                                {
                                    bandera = true;
                                    u.ImprimirUsuario();
                                }
                            }
                            if (!bandera)
                            {
                                Console.WriteLine("\n El " + criterio + " es incorrecto");
                                do
                                {
                                    try
                                    {
                                        Console.Write("\n ¿Desea buscar otro cliente?\n\n 1. Sí\n 2. No\n\n Opción: ");
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
                                    catch(Exception e)
                                    {
                                        Console.WriteLine("\n -> Debe insertar un número");
                                    }
                                } while (!bandera1);
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("\n Debe insertar una cadena válida");
                        }
                    }  while  (!bandera);
                }
                else
                {
                    Console.WriteLine(" Nombre: " + GetNombre() + "\n" +
                                      " Apellido: " + GetApellidos() + "\n" +
                                      " Direccion: " + GetDireccion() + "\n" +
                                      " Correo: " + GetCorreo() + "\n" +
                                      " Celular: " + GetTelefono() + "\n" +
                                      " Tipo: " + GetTipoUsuario() + "\n" +
                                      " Contraseña: " + GetContraseña());
                }
            }
            else
            {
                Console.WriteLine("\n No hay " + usuario + "s");
            }
        }


        //Método que sirve para convertir a un usuario convencional en un administrador
        public Administrador UsuarioAdministrador()
        {
            //Instancia de la clase Administrador
            Administrador administrador = new Administrador();

            administrador.SetNombre(GetNombre());
            administrador.SetApellidos(GetApellidos());
            administrador.SetDireccion(GetDireccion());
            administrador.SetCorreo(GetCorreo());
            administrador.SetTelefono(GetTelefono());
            administrador.SetContraseña(GetContraseña());
            administrador.SetId(GetId());
            administrador.SetTipoUsuario(GetTipoUsuario());
            administrador.SetPapeleria(GetPapeleria());

            return administrador;
        } 


        //Método que sirve para convertir a un usuario convencional en un vendedor
        public Vendedor UsuarioVendedor()
        {
            //Instancia de la clase Vendedor
            Vendedor vendedor = new Vendedor();

            vendedor.SetNombre(GetNombre());
            vendedor.SetApellidos(GetApellidos());
            vendedor.SetDireccion(GetDireccion());
            vendedor.SetCorreo(GetCorreo());
            vendedor.SetTelefono(GetTelefono());
            vendedor.SetContraseña(GetContraseña());
            vendedor.SetId(GetId());
            vendedor.SetTipoUsuario(GetTipoUsuario());
            vendedor.SetPapeleria(GetPapeleria());

            return vendedor;
        }


        //Método que sirve para convertir a un usuario convencional en un cliente
        public Cliente UsuarioCliente(Carrito carrito, Tarjeta tarjeta, List<Recibo> recibos)
        {
            //Instancia de la clase Cliente
            Cliente cliente = new Cliente();

            cliente.SetNombre(GetNombre());
            cliente.SetApellidos(GetApellidos());
            cliente.SetDireccion(GetDireccion());
            cliente.SetCorreo(GetCorreo());
            cliente.SetTelefono(GetTelefono());
            cliente.SetContraseña(GetContraseña());
            cliente.SetId(GetId());
            cliente.SetTipoUsuario(GetTipoUsuario());
            cliente.SetPapeleria(GetPapeleria());
            cliente.carrito = carrito;
            cliente.tarjeta = tarjeta;
            cliente.recibosCliente = recibos;

            return cliente;
        }


        //Método que sirve para llenar un usuario con los datos que se leen de un txt
        public void LlenarUsuario(int opcion, string linea)
        {
            switch (opcion)
            {
                case 0:
                    SetNombre(linea);
                    break;
                case 1:
                    SetApellidos(linea);
                    break;
                case 2:
                    SetDireccion(linea);
                    break;
                case 3:
                    SetCorreo(linea);
                    break;
                case 4:
                    SetTelefono(Convert.ToDouble(linea));
                    break;
                case 5:
                    SetContraseña(linea);
                    break;
                case 6:
                    SetId(Convert.ToInt32(linea));
                    break;
                case 7:
                    SetTipoUsuario(linea);
                    break;
                case 8:
                    SetPapeleria(linea);
                    break;
            }
        }


        //Método que sirve para imprimir usuarios (Empleados o clientes)
        public void ImprimirUsuario()
        {
            Console.WriteLine(" ==========================================================\n" +
                              "\n " + GetNombre() +
                              "\n " + GetApellidos() +
                              "\n " + GetDireccion() +
                              "\n " + GetCorreo() +
                              "\n " + GetTelefono() +
                              "\n " + GetContraseña() +
                              "\n " + GetId() +
                              "\n " + GetTipoUsuario() +
                              "\n " + GetPapeleria() +
                              "\n\n ==========================================================");
        }
    }
}
