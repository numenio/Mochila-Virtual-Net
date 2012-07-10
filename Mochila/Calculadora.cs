using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mochila
{
    class Calculadora
    {
        public double result { get; set; }

        public bool parsearCadena(string cadena)
        {
            //string separadores = "*+-/()[]{}%*^";
            //char[] separadoresEnChar = separadores.ToCharArray();
            //string números = "0123456789";
            //char[] númerosEnChar = números.ToCharArray();
            //char[] cadenaEnChar = cadena.ToCharArray();

            //string num = "", operación = "";
            //foreach (char carácter in cadenaEnChar)
            //{
            //    if (!números.Contains(carácter)) return false;
            //    if (!separadores.Contains(carácter)) return false;


            //}

            Parser parser = new Parser();
            if (parser.Evaluate(cadena))
            {
                result = parser.Result;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
