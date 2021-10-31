using System;
using System.Collections.Generic;
using System.Linq;

namespace Clases
{
    public class Recibo
    {
        //Atributos
        public string nombreCliente;
        public string nombreProducto;
        public int numeroProductos;
        public int piezas;
        public double precioProducto;
        public string papeleria;
        public string fecha;
        public string hora;
        public double precioTotal;
        public List<Producto> productos = new List<Producto>();


        //Constructor sin argumentos
        public Recibo()
        {

        }

        //Constructor con argumentos
        public Recibo(string nombreCliente, string nombreProducto, int numeroProductos, int piezas, double precioProducto, string papeleria, string fecha, string hora, double precioTotal, List<Producto> productos)
        {
            this.nombreCliente = nombreCliente;
            this.nombreProducto = nombreProducto;
            this.numeroProductos = numeroProductos;
            this.piezas = piezas;
            this.precioProducto = precioProducto;
            this.papeleria = papeleria;
            this.fecha = fecha;
            this.hora = hora;
            this.precioTotal = precioTotal;
            this.productos = productos;
        }

        //Setters
        public void SetNombreCliente(string nombre) { this.nombreCliente = nombre; }
        public void SetNombreProducto(string nombreProducto) { this.nombreProducto = nombreProducto; }
        public void SetNumeroProductos(int numeroProductos) { this.numeroProductos = numeroProductos; }
        public void SetPiezas(int piezas) { this.piezas = piezas; }
        public void SetPrecioProducto(double precioProducto) { this.precioProducto = precioProducto; }
        public void SetPapeleria(string papeleria) { this.papeleria = papeleria; }
        public void SetFecha(string fecha) { this.fecha = fecha; }
        public void SetHora(string hora) { this.hora = hora; }
        public void SetPrecioTotal(double precio) { this.precioTotal = precio; }
        public void SetProductos(Producto producto) { productos.Add(producto); }

        //Getters
        public string GetNombreCliente() { return nombreCliente; }
        public string GetNombreProducto() { return nombreProducto; }
        public int GetNumeroProductos() { return numeroProductos; }
        public int GetPiezas() { return piezas; }
        public double GetPrecioProducto() { return precioProducto; }
        public string GetPapeleria() { return papeleria; }
        public string GetFecha() { return fecha; }
        public string GetHora() { return hora; }
        public double GetPrecioTotal() { return precioTotal; }
        public List<Producto> GetProductos() { return productos; }


        /**************************************** Métodos para la clase Recibo ****************************************/


        //Método que sirve para llenar un recibo con los datos que se leen de un txt
        public void LlenarRecibo(int opcion, string linea)
        {
            switch (opcion)
            {
                case 0:
                    SetPapeleria(linea);
                    break;
                case 1:
                    SetFecha(linea);
                    break;
                case 2:
                    SetHora(linea);
                    break;
                case 3:
                    SetNombreCliente(linea);
                    break;
                case 4:
                    SetNumeroProductos(Convert.ToInt32(linea));
                    break;
            }
        }
    }
}