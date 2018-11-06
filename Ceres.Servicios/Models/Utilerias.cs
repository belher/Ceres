using System;
using System.Collections.Generic;
using System.Text;

namespace Ceres.Servicios.Models
{

    public enum xLado
    {
        Izquierda=0,
        Derecha=1,
    }

    public class Utilerias
    {

   

        public int Valor(string Cadena)
        {
            return Convert.ToInt32(Cadena);
        }

        public string InsertarCaracteres( string Cadena, int cantidad, char caracter , xLado lado)
        {
            string resultado = string.Empty;

          

            if (lado==xLado.Izquierda)
            {
                resultado = Cadena.PadLeft(cantidad, caracter);
            }
            else
            {
                resultado = Cadena.PadRight (cantidad, caracter);
            }
            return resultado;
        }

        public string InsertarCaracteres(int Numero, int cantidad, char caracter, xLado lado)
        {
            string resultado = string.Empty;

            string cadena = Convert.ToString(Numero);

            if (lado == xLado.Izquierda)
            {
                resultado = cadena.PadLeft(cantidad, caracter);
            }
            else
            {
                resultado = cadena.PadRight(cantidad, caracter);
            }
            return resultado;
        }

    }
}
