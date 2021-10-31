using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Tarjeta
    {
        //Atributos
        public string nombreBanco;
        public string tipoTarjeta1;
        public string tipoTarjeta2;
        public string numeroTarjeta;
        public string nombreTitular;
        public string cvc;

        //Constructor sin argumentos
        public Tarjeta()
        {

        }

        //Constructor con argumentos
        public Tarjeta(string nombreBanco, string tipoTarjeta1, string tipoTarjeta2, string numeroTarjeta, string nombreTitular, string cvc)
        {
            this.nombreBanco = nombreBanco;
            this.tipoTarjeta1 = tipoTarjeta1;
            this.tipoTarjeta2 = tipoTarjeta2;
            this.numeroTarjeta = numeroTarjeta;
            this.nombreTitular = nombreTitular;
            this.cvc = cvc;
        }

        // Setters
        public void SetNombreBanco(string nombreBanco) { this.nombreBanco = nombreBanco; }
        public void SetTipoTarjeta1(string tipoTarjeta1) { this.tipoTarjeta1 = tipoTarjeta1; }
        public void SetTipoTarjeta2(string tipoTarjeta2) { this.tipoTarjeta2 = tipoTarjeta2; }
        public void SetNumeroTarjeta(string numeroTarjeta) { this.numeroTarjeta = numeroTarjeta; }
        public void SetNombreTitular(string nombreTitular) { this.nombreTitular = nombreTitular; }
        public void SetCvc(string cvc) { this.cvc = cvc; }

        // Getters
        public string GetNombreBanco() { return nombreBanco; }
        public string GetTipoTarjeta1() { return tipoTarjeta1; }
        public string GetTipoTarjeta2() { return tipoTarjeta2; }
        public string GetNumeroTarjeta() { return numeroTarjeta; }
        public string GetNombreTitular() { return nombreTitular; }
        public string GetCvc() { return cvc; }


        /**************************************** Métodos para la clase Tarjeta ****************************************/

        //Método que sirve para llenar una tarjeta con los datos que se leen de un txt
        public void LlenarTarjeta(int opcion, string linea)
        {
            switch (opcion)
            {
                case 0:
                    SetNombreBanco(linea);
                    break;
                case 1:
                    SetTipoTarjeta1(linea);
                    break;
                case 2:
                    SetTipoTarjeta2(linea);
                    break;
                case 3:
                    SetNumeroTarjeta(linea);
                    break;
                case 4:
                    SetNombreTitular(linea);
                    break;
                case 5:
                    SetCvc(linea);
                    break;
            }
        }
    }
}
