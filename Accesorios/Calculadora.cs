using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mochila
{
    class Calculadora
    {
        //Calculadora calc = new Calculadora();
        //calc.parsearCadena(texto.Text);
        //double result = calc.result;

        public double result { get; set; }

        public bool parsearCadena(string cadena)
        {
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
