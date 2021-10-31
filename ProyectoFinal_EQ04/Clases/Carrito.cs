using System;
using System.Collections.Generic;

namespace Clases
{
    public class Carrito
    {
        //Atributos
        public List<Producto> productosEnCarrito = new List<Producto>();
        public string id;
        public int numeroProductos;
        public double contadorPrecio;
        public double puntos;

        //Constructor sin argumentos
        public Carrito()
        {
            contadorPrecio = 0;
            puntos = 0;
        }

        //Constructor con argumentos
        public Carrito(List<Producto> productosEnCarrito, string id, int numeroProductos, double contadorPrecio)
        {
            this.productosEnCarrito = productosEnCarrito;
            this.id = id;
            this.numeroProductos = numeroProductos;
            this.contadorPrecio = contadorPrecio;
        }

        // Setters
        public void SetId(string id)
        {
            this.id = id;
        }

        public void SetPuntos(double puntos) { this.puntos = puntos; }

        public void ActualizarPuntos(double puntos) { this.puntos += puntos; }

        public void SetNumeroProductos(int numeroProductos)
        {
            this.numeroProductos = numeroProductos;
        }

        public void SetContadorPrecio(double contadorPrecio)
        {
            this.contadorPrecio = contadorPrecio;
        }

        // Setters miscelaneos
        public void SetProductos(Producto producto)
        {
            productosEnCarrito.Add(producto);
        }

        public void ActualizarNumeroProductos()
        {
            this.numeroProductos++;
        }

        public void ActualizarContadorPrecio(double contadorPrecio)
        {
            this.contadorPrecio += contadorPrecio;
        }

        // Getters
        public string GetId()
        {
            return id;
        }

        public double GetPuntos() { return puntos; }

        public int GetNumeroProductos()
        {
            return numeroProductos;
        }

        public double GetContadorPrecio()
        {
            return contadorPrecio;
        }

        public List<Producto> GetProductos()
        { 
           return productosEnCarrito;
        }

        /**************************************** Métodos para la clase Carrito ****************************************/


        //Método para agregar productos al carrito de cada cliente
        public void AñadirProductosCarrito(List<Producto> productos, string tienda, string criterio, int accion)
        {
            //Instancia de la clase Producto
            Producto producto = new Producto();

            //Variables para el método
            string nombre;
            int cantidad, opcion;
            bool bandera = false, bandera1 = false;

            producto.VerInventario(productos, criterio, accion, 1, tienda);

            do
            {
                try
                {
                    Console.Write("\n ¿Desea agregar un producto al carrito?\n" +
                                  " 1. Sí\n" +
                                  " 2. No\n\n" +
                                  " Opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("\n Ingresar nombre del producto a añadir al carrito: ");
                            nombre = Console.ReadLine();
                            foreach (Producto p in productos)
                            {
                                if (p.GetNombre().Equals(nombre) && p.GetPapeleria().Equals(tienda))
                                {
                                    p.ImprimirProducto();
                                    Console.Write("\n Ingresar cantidad deseada: ");
                                    cantidad = Convert.ToInt32(Console.ReadLine());
                                    if (cantidad <= p.GetStock())
                                    {
                                        producto.SetNombre(p.GetNombre());
                                        producto.SetDescripcion(p.GetDescripcion());
                                        producto.SetPrecio(p.GetPrecio());
                                        producto.SetCodigoDeSerie(p.GetCodigoDeSerie());
                                        producto.SetCodigoDeInventario(p.GetCodigoDeInventario());
                                        producto.SetPapeleria(p.GetPapeleria());
                                        producto.SetDepartamento(p.GetDepartamento());
                                        producto.SetStock(cantidad);
                                        ActualizarContadorPrecio(producto.GetPrecio() * cantidad);
                                        p.SetStock(p.GetStock() - cantidad);
                                        productosEnCarrito.Add(producto);
                                        ActualizarNumeroProductos();
                                        bandera = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n No hay piezas suficientes en el inventario\n");
                                        Console.Write(" ¿Quiere ingresar otro producto?\n 1. Sí\n 2. No\n ");
                                        opcion = Convert.ToInt32(Console.ReadLine());
                                        if (opcion == 1)
                                        {
                                            bandera1 = true;
                                        }
                                        else
                                        {
                                            bandera = true;
                                            bandera1 = false;
                                        }
                                    }
                                    break;
                                }
                            }
                            if (!bandera && !bandera1) { Console.WriteLine("\n El producto no se encuentra en la tienda seleccionada o no existe"); }
                            break;
                        case 2:
                            bandera = true;
                            bandera1 = true;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n -> Debe insertar un número");
                }
            } while (!bandera && bandera1);
        }


        //Método que sirve para pagar el carrito de cada cliente
        public void Pagar(List<Recibo> recibos, string papeleria, string nombre)
        {
            if (GetNumeroProductos() != 0)
            {
                ImprimirRecibo(recibos, papeleria, nombre);
                ActualizarPuntos(GetContadorPrecio() * 0.05);
                Console.WriteLine("\n Pago realizado");
                SetContadorPrecio(0);
                productosEnCarrito.Clear();
                SetNumeroProductos(0);
                
            }
            else
            {
                Console.WriteLine("\n El carrito esta vacío\n");
            }
        }

        //Método que imprime el ticket virtual
        public void ImprimirRecibo(List<Recibo> recibos, string papeleria, string nombre)
        {
            //Instancia de la clase Recibo
            Recibo recibo = new Recibo();

            //Instancia que sirve para obtener la hora actual del sistema
            DateTime horaActual = DateTime.Now;

            Console.WriteLine("\n ========== Ticket ==========\n");

            Console.WriteLine(" ->" + papeleria + "<-"); recibo.SetPapeleria(papeleria);

            Console.WriteLine("\n Día: {0}     Hora: {1}", horaActual.ToString("dd/MMMM/yyyy"), horaActual.ToString("HH:mm:ss") + "\n");
            recibo.SetFecha(horaActual.ToString("dd/MMMM/yyyy"));
            recibo.SetHora(horaActual.ToString("HH:mm:ss"));

            Console.WriteLine("\n Cliente: {0}", nombre + "\n"); recibo.SetNombreCliente(nombre);

            foreach (Producto p in productosEnCarrito)
            {

                Console.WriteLine("\n Artículo: {0}  Piezas: {1}  Precio: {2}", p.GetNombre(), p.GetStock(), p.GetPrecio());
                recibo.SetProductos(p);
            }
            recibo.SetNumeroProductos(productosEnCarrito.Count);

            Console.WriteLine("\n Total a pagar: " + GetContadorPrecio() + "\n"); recibo.SetPrecioTotal(GetContadorPrecio());

            Console.WriteLine("\n Gracias por su preferencia, vuelva pronto");

            recibos.Add(recibo);
        }

        public void VisualizarCarrito()
        {
            Console.WriteLine("\n =============== Carrito ===============\n");
            Console.WriteLine("\n Productos:\n");
            foreach (Producto p in productosEnCarrito)
            {
                Console.WriteLine("\n " + p.GetNombre() + "\n " + p.GetStock() + " piezas       Costo: " + p.GetPrecio());
            }
            Console.WriteLine("\n Total: " + GetContadorPrecio());
            Console.ReadLine();
        }

        public void LlenarCarrito(int opcion, string linea)
        {
            switch (opcion)
            {
                case 0:
                    SetId(linea);
                    break;
                case 1:
                    SetPuntos(Convert.ToDouble(linea));
                    break;
                case 2:
                    SetNumeroProductos(Convert.ToInt32(linea));
                    break;
                case 3:
                    SetContadorPrecio(Convert.ToDouble(linea));
                    break;
            }
        }
    }
}

