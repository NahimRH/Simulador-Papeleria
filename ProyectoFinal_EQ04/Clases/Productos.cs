using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Clases
{
    public class Producto
    {
        //Atributos
        public string nombre;
        public string descripcion;
        public double precio;
        public int stock;
        public string codigoDeSerie;
        public string codigoDeInventario;
        public string papeleria;
        public string departamento;

        //Constructor sin argumentos
        public Producto()
        {

        }

        //Constructor con argumentos
        public Producto(string nombre, string descripcion, double precio, int stock, string codigoDeSerie, string codigoDeInventario, string papeleria, string departamento)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
            this.codigoDeSerie = codigoDeSerie;
            this.codigoDeInventario = codigoDeInventario;
            this.papeleria = papeleria;
            this.departamento = departamento;
        }

        //Setters
        public void SetNombre(string nombre) { this.nombre = nombre; }
        public void SetDescripcion(string descripcion) { this.descripcion = descripcion; }
        public void SetPrecio(double precio) { this.precio = precio; }
        public void SetStock(int stock) { this.stock = stock; }
        public void SetCodigoDeSerie(string codigoDeSerie) { this.codigoDeSerie = codigoDeSerie; }
        public void SetCodigoDeInventario(string codigoDeInventario) { this.codigoDeInventario = codigoDeInventario; }
        public void SetPapeleria(string papeleria) { this.papeleria = papeleria; }
        public void SetDepartamento(string departamento) { this.departamento = departamento; }

        //Getters
        public string GetNombre() { return nombre; }
        public string GetDescripcion() { return descripcion; }
        public double GetPrecio() { return precio; }
        public int GetStock() { return stock; }
        public string GetCodigoDeSerie() { return codigoDeSerie; }
        public string GetCodigoDeInventario() { return codigoDeInventario; }
        public string GetPapeleria() { return papeleria; }
        public string GetDepartamento() { return departamento; }


        /**************************************** Métodos para la clase Producto ****************************************/


        /***** Método global que será utilizado en la mayoría de métodos *****/
        //Método que sirve para convertir la primera letra de una palabra en mayúscula
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;


        //Método que sirve para llenar un producto con los datos que se leen de un txt
        public void LlenarProducto(int opcion, string linea)
        {
            switch (opcion)
            {
                case 0:
                    nombre = linea;
                    break;
                case 1:
                    descripcion = linea;
                    break;
                case 2:
                    precio = Convert.ToDouble(linea);
                    break;
                case 3:
                    stock = Convert.ToInt32(linea);
                    break;
                case 4:
                    codigoDeSerie = linea;
                    break;
                case 5:
                    codigoDeInventario = linea;
                    break;
                case 6:
                    papeleria = linea;
                    break;
                case 7:
                    departamento = linea;
                    break;
            }
        }

        //Método que sirve para imprimir productos
        public void ImprimirProducto()
        {
            Console.WriteLine(" ==========================================================\n" +
                              "\n " + GetNombre() +
                              "\n " + GetDescripcion() +
                              "\n " + GetPrecio() +
                              "\n " + GetStock() +
                              "\n " + GetCodigoDeSerie() +
                              "\n " + GetCodigoDeInventario() +
                              "\n " + GetPapeleria() +
                              "\n " + GetDepartamento() +
                              "\n\n ==========================================================");
        }

        //Método que sirve para validar que no se ingresen cadenas vacías
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
                else if (accion == 1)
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

        //Método que sirve para dar de alta un producto nuevo
        public void AltaDeProducto(List<Producto> productos)
        {
            //Instancia de la clase Producto
            Producto producto = new Producto();

            Console.Write(" Ingrese el nombre del producto: "); producto.SetNombre(IngresarCadena(0));

            Console.Write(" Ingrese la descripción: "); producto.SetDescripcion(IngresarCadena(0));

            Console.Write(" Ingrese el precio: "); producto.SetPrecio(Convert.ToDouble(IngresarCadena(1)));

            Console.Write(" Ingrese la cantidad: "); producto.SetStock(Convert.ToInt32(IngresarCadena(1)));

            Console.Write(" Ingrese el código de serie: "); producto.SetCodigoDeSerie(IngresarCadena(1));

            Console.Write(" Ingrese el código de inventario: "); producto.SetCodigoDeInventario(IngresarCadena(1));

            //Asignar tienda
            AsignarPapeleria(producto);

            //Asignar departamento
            AsignarDepartamento(producto);

            //Añadimos el producto a la lista de productos
            productos.Add(producto);
        }

        //Asignar papelería en donde se dará de alta el producto del método AltaDeProducto
        public void AsignarPapeleria(Producto producto)
        {
            //Variables para el método
            int opcion;
            bool encontrado = false;

            do
            {
                try
                {
                    Console.WriteLine("\n ¿En qué tienda desea de dar de alta al producto?\n");
                    Console.Write(" 1. Super Papelerías Insurgentes\n" +
                                  " 2. Super Papelerías Tlalpan\n" +
                                  " 3. Super Papelerías Coyoacán\n\n" +
                                  " Opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            producto.SetPapeleria("Super Papelerías Insurgentes");
                            encontrado = true;
                            break;
                        case 2:
                            producto.SetPapeleria("Super Papelerías Tlalpan");
                            encontrado = true;
                            break;
                        case 3:
                            producto.SetPapeleria("Super Papelerías Coyoacán");
                            encontrado = true;
                            break;
                        default:
                            Console.WriteLine("\n -> Opción no válida, por favor ingrese una de las opciones mostradas\n");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("\n -> Debe insertar un número");
                }
            } while (!encontrado);
        }

        //Asignar departamento en donde se dará de alta el producto del método AltaDeProducto
        public void AsignarDepartamento(Producto producto)
        {
            //Variables para el método
            int opcion;
            bool encontrado = false;

            do
            {
                try
                {
                    Console.WriteLine("\n ¿En qué departamento desea de dar de alta al producto?\n");
                    Console.Write(" 1. Artículos de Escritorio\n" +
                                  " 2. Cuadernos\n" +
                                  " 3. Corte\n" +
                                  " 4. Papel\n\n" +
                                  " Opción:  ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            producto.SetDepartamento("Artículos de Escritorio");
                            encontrado = true;
                            break;
                        case 2:
                            producto.SetDepartamento("Cuadernos");
                            encontrado = true;
                            break;
                        case 3:
                            producto.SetDepartamento("Corte");
                            encontrado = true;
                            break;
                        case 4:
                            producto.SetDepartamento("Papel");
                            encontrado = true;
                            break;
                        default:
                            Console.WriteLine("\n -> Opción no válida, por favor ingrese una de las opciones mostradas\n");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("\n -> Debe insertar un número");
                }
            } while (!encontrado);
        }

        /*Método que sirve para mostrar el inventario total, para mostrar los productos por nombre, departamento y tienda, 
          para buscar productos por nombre y departamento, y para mostrar el perfil de los clientes y empleados*/
        public void VerInventario(List<Producto> productos, string criterio, int accion, int identificador, string tienda)
        {
            //Instancia de la clase Usuario
            Usuario usuario = new Usuario();

            //Creamos una lista de tipo Usuario la cual contendra a los empleados ordenados
            List<Producto> productosSort = new List<Producto>();

            //Variables para el método
            string cadena;
            bool bandera = false;

            if (productos.Count() != 0)
            {
                if (criterio.Equals("Departamento"))
                {
                    //Ordenamos a los productos por departamento
                    productosSort = productos.OrderBy(p => p.departamento).ToList();
                }
                else if (criterio.Equals("Nombre"))
                {
                    //Ordenamos a los productos por nombre
                    productosSort = productos.OrderBy(p => p.nombre).ToList();
                }
                else if(criterio.Equals("Tienda"))
                {
                    //Ordenamos a los productos por tienda
                    productosSort = productos.OrderBy(p => p.papeleria).ToList();
                }
                else
                {
                    productosSort = productos;
                }

                if (accion.Equals(0)) // Despliega todo, ordenado o no
                {
                    if (identificador == 0)
                    {
                        foreach (Producto p in productosSort)
                        {
                            p.ImprimirProducto();
                        }
                    }
                    else
                    {
                        foreach (Producto p in productosSort)
                        {
                            if (p.GetPapeleria().Equals(tienda))
                            p.ImprimirProducto();
                        }
                    }
                }
                else // Despliega lo que se pide
                {
                    if (accion == 2)
                    {
                        cadena = " ";
                    }
                    else if (criterio != "Tienda") // Usuario ingresa Nombre o Depto.
                    {
                        Console.Write("\n Ingrese el " + criterio + ": ");
                        cadena = ti.ToTitleCase(Console.ReadLine().ToLower());
                    }
                    else // En este caso despliega un menú para que seleccione la tienda de donde quiere ver el inventario
                    {
                        cadena = usuario.AsignarTienda();
                    }

                    foreach (Producto p in productosSort)
                    {
                        //#########################################################
                        if (criterio.Equals("Nombre") && cadena != "")
                        {
                            if (identificador == 0) 
                            { 
                                if (p.GetNombre().Contains(cadena)) 
                                { 
                                    p.ImprimirProducto();
                                    bandera = true; 
                                } 
                            }
                            else if (identificador == 1) 
                            { 
                                if (p.GetNombre().Contains(cadena) && p.GetPapeleria() == tienda) 
                                { 
                                    p.ImprimirProducto();
                                    bandera = true; 
                                } 
                            }
                            else 
                            { 
                                if (p.GetStock() == 0) 
                                { 
                                    p.ImprimirProducto(); 
                                    bandera = true; 
                                }
                            }
                        }
                        //#########################################################
                        else if (criterio.Equals("Departamento") && cadena != "")
                        {
                            if (identificador == 0)
                            {
                                if (p.GetDepartamento().Contains(cadena))
                                {
                                    p.ImprimirProducto();
                                    bandera = true;
                                }
                            }
                            else
                            {
                                if (p.GetDepartamento().Contains(cadena) && p.GetPapeleria() == tienda)
                                {
                                    p.ImprimirProducto();
                                    bandera = true;
                                }
                            }
                        }
                        //#########################################################
                        else if (criterio.Equals("Tienda"))
                        {
                            if (p.GetPapeleria().Equals(cadena)) { p.ImprimirProducto(); bandera = true; }
                        }
                    }
                    if (!bandera) Console.WriteLine("\n El " + criterio + " (" + cadena + ") no existe.");
                }
            }
            else
            {
                Console.WriteLine("\n No hay productos");
            }
        }
    }
}
