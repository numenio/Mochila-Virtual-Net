using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace mochila
{
    public class Texto
    {
        string traducirCadenaParaLeer(string cadenaOriginal)
        {
            string carácterCorregido = "";
            switch (cadenaOriginal)
            {
                case "(":
                    carácterCorregido = " abre paréntesis, ";
                    break;
                case ")":
                    carácterCorregido = " cierra paréntesis, ";
                    break;
                case "_":
                    carácterCorregido = " sobre ";// 'para fracciones
                    break;
                case "$":
                    carácterCorregido = " pesos, ";
                    break;
                case " 1 ":
                    carácterCorregido = " uno, ";
                    break;
                case "-":
                    carácterCorregido = " menos ";
                    break;
                case "*":
                    carácterCorregido = " multiplicado por ";
                    break;
                case "/":
                    carácterCorregido = " dividido ";
                    break;
                case "{":
                    carácterCorregido = " abre llave, ";
                    break;
                case "}":
                    carácterCorregido = " cierra llave, ";
                    break;
                case "m ":
                    carácterCorregido = " eme. ";
                    break;
                case "s ":
                    carácterCorregido = " ese. ";
                    break;
                case "b ":
                    carácterCorregido = " be larga. ";
                    break;
                case "v ":
                    carácterCorregido = " ve corta. ";
                    break;
                case "y ":
                    carácterCorregido = " ih griega. ";
                    break;
                case "b. ":
                    carácterCorregido = " be larga. ";
                    break;
                case "v. ":
                    carácterCorregido = " ve corta. ";
                    break;
                case "y. ":
                    carácterCorregido = " ih griega. ";
                    break;
                case "l ":
                    carácterCorregido = " ele. ";
                    break;
                case "h ":
                    carácterCorregido = " ache. ";
                    break;
                case "p ":
                    carácterCorregido = " pe. ";
                    break;
                case "n ":
                    carácterCorregido = " ene. ";
                    break;
                case "m. ":
                    carácterCorregido = " eme. ";
                    break;
                case "s. ":
                    carácterCorregido = " ese. ";
                    break;
                case "l. ":
                    carácterCorregido = " ele. ";
                    break;
                case "h. ":
                    carácterCorregido = " ache. ";
                    break;
                case "p. ":
                    carácterCorregido = " pe. ";
                    break;
                case "n. ":
                    carácterCorregido = " ene. ";
                    break;
                case "g. ":
                    carácterCorregido = " je. ";
                    break;
                case "u. ":
                    carácterCorregido = " uh. ";
                    break;
                case "d. ":
                    carácterCorregido = " de. ";
                    break;
                case "á. ":
                    carácterCorregido = " a con acento. ";
                    break;
                case "é. ":
                    carácterCorregido = " e con acento. ";
                    break;
                case "í. ":
                    carácterCorregido = " i con acento. ";
                    break;
                case "ó. ":
                    carácterCorregido = " o con acento. ";
                    break;
                case "ú. ":
                    carácterCorregido = " u con acento. ";
                    break;
                case "ü. ":
                    carácterCorregido = " u con diéresis. ";
                    break;
                case "à. ":
                    carácterCorregido = " a con acento grave. ";
                    break;
                case "è. ":
                    carácterCorregido = " e con acento grave. ";
                    break;
                case "ì. ":
                    carácterCorregido = " i con acento grave. ";
                    break;
                case "ò. ":
                    carácterCorregido = " o con acento grave. ";
                    break;
                case "ù. ":
                    carácterCorregido = " u con acento grave. ";
                    break;
                case "â. ":
                    carácterCorregido = " a con acento circunflejo. ";
                    break;
                case "ê. ":
                    carácterCorregido = " e con acento circunflejo. ";
                    break;
                case "î. ":
                    carácterCorregido = " i con acento circunflejo. ";
                    break;
                case "ô. ":
                    carácterCorregido = " o con acento circunflejo. ";
                    break;
                case "û. ":
                    carácterCorregido = " u con acento circunflejo. ";
                    break;
            }
            return carácterCorregido;
        }

        string traducirCarácterParaLeer(char carácter)
        {
            string cadena = "";

            return cadena;
        }

        bool EstáEnNegrita(TextSelection texto) //listo
        {
            if ((FontWeight)texto.GetPropertyValue(Run.FontWeightProperty) == FontWeights.Bold)
                return true;
            else
                return false;
        }

        bool ParteEnNegrita(string cadena)
        {
            return false;
        }

        public bool EstáEnCursiva(TextSelection texto) //listo
        {
            if ((FontStyle)texto.GetPropertyValue(Run.FontStyleProperty) == FontStyles.Italic)
                return true;
            else
                return false;
        }

        bool ParteEnCursiva(string cadena)
        {
            return false;
        }

        //bool swEstáSubrayado(TextSelection texto)
        //{
        //    if (texto.GetPropertyValue(Run.) == )
        //        return true;
        //    else
        //        return false;
        //}

        bool ParteSubrayado(string cadena)
        {
            return false;
        }

        public bool pasarANegrita(TextSelection texto) //listo
        {
            try
            {
                texto.ApplyPropertyValue(Run.FontWeightProperty, FontWeights.Bold);
                return true;
            } catch {
                return false;
            }
        }

        public bool pasarAItalica(TextSelection texto) //listo
        {
            try
            {
                texto.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Italic);
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool EsSímbolo(char carácter)
        {
            String símbolos = "!\"·#$%&/()=?¿^*¨Çªº|@~€¬'][{}¡;:_,.-<> ";
            if (símbolos.Contains(carácter))
                return true;
            else
                return false;
        }

        bool EsSímbolo(string cadena)
        {
            char[] letras = cadena.ToCharArray();
            foreach (char letra in letras)
            {
                if (!EsSímbolo(letra)) return false;
            }
            return true;
        }

        bool EsNúmero(string cadena) //listo
        {
            try
            {
                float.Parse(cadena);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool EsNúmero(char caracter) //listo
        {
            String números = "0123456789";
            if (números.Contains(caracter))
                return true;
            else
                return false;
        }

        bool EsLetra(char carácter) //listo
        {
            String letras = "abcdefghijklmnñopqrstuvwxyzáéíóúü";
            if (letras.Contains(carácter))
                return true;
            else
                return false;
        }
        /*
        public static String traducirTeclaParaLeer(Tecla t)
        {
            HashMap<Tecla, String> caracteres = new HashMap<Tecla, String>();
            caracteres.put(Tecla.A, "a");
            caracteres.put(Tecla.B, "be");
            caracteres.put(Tecla.C, "ce");
            caracteres.put(Tecla.D, "de");
            caracteres.put(Tecla.E, "e");
            caracteres.put(Tecla.F, "efe");
            caracteres.put(Tecla.G, "je");
            caracteres.put(Tecla.H, "ache");
            caracteres.put(Tecla.I, "i");
            caracteres.put(Tecla.J, "jota");
            caracteres.put(Tecla.K, "ka");
            caracteres.put(Tecla.L, "ele");
            caracteres.put(Tecla.M, "eme");
            caracteres.put(Tecla.N, "ene");
            caracteres.put(Tecla.Ñ, "eñe");
            caracteres.put(Tecla.O, "o");
            caracteres.put(Tecla.P, "pe");
            caracteres.put(Tecla.Q, "ku");
            caracteres.put(Tecla.R, "erre");
            caracteres.put(Tecla.S, "ese");
            caracteres.put(Tecla.T, "te");
            caracteres.put(Tecla.U, "u");
            caracteres.put(Tecla.V, "ve");
            caracteres.put(Tecla.W, "doble ve");
            caracteres.put(Tecla.X, "equis");
            caracteres.put(Tecla.Y, "i griega");
            caracteres.put(Tecla.Z, "zeta");
            caracteres.put(Tecla.NUM_0, "cero");
            caracteres.put(Tecla.NUM_1, "uno");
            caracteres.put(Tecla.NUM_2, "dos");
            caracteres.put(Tecla.NUM_3, "tres");
            caracteres.put(Tecla.NUM_4, "cuatro");
            caracteres.put(Tecla.NUM_5, "cinco");
            caracteres.put(Tecla.NUM_6, "seis");
            caracteres.put(Tecla.NUM_7, "siete");
            caracteres.put(Tecla.NUM_8, "ocho");
            caracteres.put(Tecla.NUM_9, "nueve");
            caracteres.put(Tecla.Á, "a con acento");
            caracteres.put(Tecla.É, "e con acento");
            caracteres.put(Tecla.Í, "i con acento");
            caracteres.put(Tecla.Ó, "o con acento");
            caracteres.put(Tecla.Ú, "u con acento");
            caracteres.put(Tecla.Ü, "u con diéresis");
            caracteres.put(Tecla.SYM_ABRE_ADMIRACIÓN, "abre admiración");
            caracteres.put(Tecla.SYM_ABRE_CORCHETES, "abre corchetes");
            caracteres.put(Tecla.SYM_ASTERISCO, "asterisco");
            caracteres.put(Tecla.SYM_CIERRA_ADMIRACIÓN, "cierra admiración");
            caracteres.put(Tecla.SYM_DIÉRESIS, "diéresis");
            caracteres.put(Tecla.SYM_ABRE_PREGUNTA, "abre pregunta");
            caracteres.put(Tecla.SYM_CIERRA_PREGUNTA, "cierra pregunta");
            caracteres.put(Tecla.SYM_ABRE_LLAVE, "abre llave");
            caracteres.put(Tecla.SYM_CIERRA_LLAVE, "cierra llave");
            caracteres.put(Tecla.SYM_BARRA_DIAGONAL, "barra diagonal");
            caracteres.put(Tecla.SYM_BARRA_DIAGONAL_INVERTIDA, "barra diagonal inversa");
            caracteres.put(Tecla.SYM_CIERRA_CORCHETES, "cierra corchetes");
            caracteres.put(Tecla.SYM_NUMERAL, "numeral");
            caracteres.put(Tecla.SYM_COMILLAS, "comillas");
            caracteres.put(Tecla.SYM_PESOS, "pesos");
            caracteres.put(Tecla.SYM_PORCIENTO, "porciento");
            caracteres.put(Tecla.SYM_PUNTO_ELEVADO, "punto elevado");
            caracteres.put(Tecla.SYM_PUNTO, "punto");
            caracteres.put(Tecla.SYM_CE_CERILLAS, "ce cerilla");
            caracteres.put(Tecla.SYM_OVOLADA, "o volada");
            caracteres.put(Tecla.SYM_AVOLADA, "a volada");
            caracteres.put(Tecla.SYM_COMA, "coma");
            caracteres.put(Tecla.SYM_PUNTO_Y_COMA, "punto y coma");
            caracteres.put(Tecla.SYM_GUION_BAJO, "guión bajo");
            caracteres.put(Tecla.SYM_GUION, "guión");
            caracteres.put(Tecla.SYM_MAYOR, "mayor");
            caracteres.put(Tecla.SYM_MENOR, "menor");
            caracteres.put(Tecla.SYM_ABRE_PARÉNTESIS, "abre paréntesis");
            caracteres.put(Tecla.SYM_CIERRA_PARÉNTESIS, "cierra paréntesis");
            caracteres.put(Tecla.SYM_BARRA_VERTICAL, "barra vertical");
            caracteres.put(Tecla.SYM_IGUAL, "igual");
            caracteres.put(Tecla.SYM_ARROBA, "arroba");
            caracteres.put(Tecla.SYM_POTENCIA, "potencia");
            caracteres.put(Tecla.SYM_AND, "andpersant");
            caracteres.put(Tecla.SYM_EURO, "euro");
            caracteres.put(Tecla.SYM_NEGACIÓN, "negación");
            caracteres.put(Tecla.SYM_APÓSTROFO, "apóstrofo");
            caracteres.put(Tecla.SYM_DOS_PUNTOS, "dos puntos");
            caracteres.put(Tecla.BORRAR, "borrar");
            caracteres.put(Tecla.ESPACIO, "espacio");
            caracteres.put(Tecla.FLECHA_IZQ, "flecha izquierda");
            caracteres.put(Tecla.FLECHA_DER, "flecha derecha");
            caracteres.put(Tecla.FLECHA_ARR, "flecha arriba");
            caracteres.put(Tecla.FLECHA_AB, "flecha abajo");
            caracteres.put(Tecla.OPCIONES, "abrir opciones");
            caracteres.put(Tecla.ENTER, "aceptar");
            caracteres.put(Tecla.ESCAPE, "cancelar");
            caracteres.put(Tecla.ENVIAR, "enviar");
            caracteres.put(Tecla.NINGUNA, "ninguna");

            String cadena = caracteres.get(t);
            if (cadena == null) cadena = "";
            return cadena;
        }
*/
    }
}


/*
 * 
 

	
	
	
	
	
	public static String traducirCadenaParaLeer (String cadena){
		String cadenaTraducida = "";
		for (char carácter : cadena.toCharArray()){
			if (swEsSímbolo(String.valueOf(carácter))) //si es símbolo, lo traducimos
				cadenaTraducida += " " + traducirTeclaParaLeer(traducirCarácterATecla(String.valueOf(carácter)));
			else
				cadenaTraducida += String.valueOf(carácter); //si no es símbolo, pasa directo
		}
		return cadenaTraducida;
	}
	
	public static Tecla traducirCarácterATecla(String carácter){
		HashMap<String, Tecla> teclas = new HashMap<String, Tecla>();
		teclas.put("a", Tecla.A);
		teclas.put("b", Tecla.B);
		teclas.put("c", Tecla.C);
		teclas.put("d", Tecla.D);
		teclas.put("e", Tecla.E);
		teclas.put("f",Tecla.F);
		teclas.put("g",Tecla.G);
		teclas.put("h",Tecla.H);
		teclas.put("i",Tecla.I);
		teclas.put("j",Tecla.J);
		teclas.put("k",Tecla.K);
		teclas.put("l",Tecla.L);
		teclas.put("m",Tecla.M);
		teclas.put("n",Tecla.N);
		teclas.put("ñ",Tecla.Ñ);
		teclas.put("o",Tecla.O);
		teclas.put("p",Tecla.P);
		teclas.put("q",Tecla.Q);
		teclas.put("r",Tecla.R);
		teclas.put("s",Tecla.S);
		teclas.put("t",Tecla.T);
		teclas.put("u",Tecla.U);
		teclas.put("v",Tecla.V);
		teclas.put("w",Tecla.W);
		teclas.put("x",Tecla.X);
		teclas.put("y",Tecla.Y);
		teclas.put("z",Tecla.Z);
		teclas.put("0",Tecla.NUM_0);
		teclas.put("1",Tecla.NUM_1);
		teclas.put("2",Tecla.NUM_2);
		teclas.put("3",Tecla.NUM_3);
		teclas.put("4",Tecla.NUM_4);
		teclas.put("5",Tecla.NUM_5);
		teclas.put("6",Tecla.NUM_6);
		teclas.put("7",Tecla.NUM_7);
		teclas.put("8",Tecla.NUM_8);
		teclas.put("9",Tecla.NUM_9);
		teclas.put("á",Tecla.Á);
		teclas.put("é",Tecla.É);
		teclas.put("í",Tecla.Í);
		teclas.put("ó",Tecla.Ó);
		teclas.put("ú",Tecla.Ú);
		teclas.put("ü",Tecla.Ü);	
		teclas.put("¡",Tecla.SYM_ABRE_ADMIRACIÓN);
		teclas.put("[",Tecla.SYM_ABRE_CORCHETES);
		teclas.put("*",Tecla.SYM_ASTERISCO);
		teclas.put("!",Tecla.SYM_CIERRA_ADMIRACIÓN);
		teclas.put("¨",Tecla.SYM_DIÉRESIS);
		teclas.put("¿",Tecla.SYM_ABRE_PREGUNTA);
		teclas.put("?",Tecla.SYM_CIERRA_PREGUNTA);
		teclas.put("{",Tecla.SYM_ABRE_LLAVE);
		teclas.put("}",Tecla.SYM_CIERRA_LLAVE);
		teclas.put("/",Tecla.SYM_BARRA_DIAGONAL);
		teclas.put("\\",Tecla.SYM_BARRA_DIAGONAL_INVERTIDA);
		teclas.put("]",Tecla.SYM_CIERRA_CORCHETES);
		teclas.put("#",Tecla.SYM_NUMERAL);
		teclas.put("\"",Tecla.SYM_COMILLAS);
		teclas.put("$",Tecla.SYM_PESOS);
		teclas.put("%",Tecla.SYM_PORCIENTO);
		teclas.put("·",Tecla.SYM_PUNTO_ELEVADO);
		teclas.put(".",Tecla.SYM_PUNTO);
		teclas.put("Ç",Tecla.SYM_CE_CERILLAS);
		teclas.put("º",Tecla.SYM_OVOLADA);
		teclas.put("ª",Tecla.SYM_AVOLADA);
		teclas.put(",",Tecla.SYM_COMA);
		teclas.put(";",Tecla.SYM_PUNTO_Y_COMA);
		teclas.put("_",Tecla.SYM_GUION_BAJO);
		teclas.put("-",Tecla.SYM_GUION);
		teclas.put(">",Tecla.SYM_MAYOR);
		teclas.put("<",Tecla.SYM_MENOR);
		teclas.put("(",Tecla.SYM_ABRE_PARÉNTESIS);
		teclas.put(")",Tecla.SYM_CIERRA_PARÉNTESIS);
		teclas.put("|",Tecla.SYM_BARRA_VERTICAL);
		teclas.put("=",Tecla.SYM_IGUAL);
		teclas.put("@",Tecla.SYM_ARROBA);
		teclas.put("^",Tecla.SYM_POTENCIA);
		teclas.put("&",Tecla.SYM_AND);
		teclas.put("€",Tecla.SYM_EURO);
		teclas.put("~",Tecla.SYM_NEGACIÓN);
		teclas.put("'",Tecla.SYM_APÓSTROFO);
		teclas.put(":",Tecla.SYM_DOS_PUNTOS);
		teclas.put(" ",Tecla.ESPACIO);
		
		return teclas.get(carácter);
	}
	
	
	
	public static String traducirTeclarParaEscribir (Tecla t){
		HashMap<Tecla, String> caracteres = new HashMap<Tecla, String>();
		caracteres.put(Tecla.A, "a");
		caracteres.put(Tecla.B, "b");
		caracteres.put(Tecla.C, "c");
		caracteres.put(Tecla.D, "d");
		caracteres.put(Tecla.E, "e");
		caracteres.put(Tecla.F, "f");
		caracteres.put(Tecla.G, "g");
		caracteres.put(Tecla.H, "h");
		caracteres.put(Tecla.I, "i");
		caracteres.put(Tecla.J, "j");
		caracteres.put(Tecla.K, "k");
		caracteres.put(Tecla.L, "l");
		caracteres.put(Tecla.M, "m");
		caracteres.put(Tecla.N, "n");
		caracteres.put(Tecla.Ñ, "ñ");
		caracteres.put(Tecla.O, "o");
		caracteres.put(Tecla.P, "p");
		caracteres.put(Tecla.Q, "q");
		caracteres.put(Tecla.R, "r");
		caracteres.put(Tecla.S, "s");
		caracteres.put(Tecla.T, "t");
		caracteres.put(Tecla.U, "u");
		caracteres.put(Tecla.V, "v");
		caracteres.put(Tecla.W, "w");
		caracteres.put(Tecla.X, "x");
		caracteres.put(Tecla.Y, "y");
		caracteres.put(Tecla.Z, "z");
		caracteres.put(Tecla.NUM_0, "0");
		caracteres.put(Tecla.NUM_1, "1");
		caracteres.put(Tecla.NUM_2, "2");
		caracteres.put(Tecla.NUM_3, "3");
		caracteres.put(Tecla.NUM_4, "4");
		caracteres.put(Tecla.NUM_5, "5");
		caracteres.put(Tecla.NUM_6, "6");
		caracteres.put(Tecla.NUM_7, "7");
		caracteres.put(Tecla.NUM_8, "8");
		caracteres.put(Tecla.NUM_9, "9");
		caracteres.put(Tecla.Á, "á");
		caracteres.put(Tecla.É, "é");
		caracteres.put(Tecla.Í, "í");
		caracteres.put(Tecla.Ó, "ó");
		caracteres.put(Tecla.Ú, "ú");
		caracteres.put(Tecla.Ü, "ü");
		caracteres.put(Tecla.SYM_CIERRA_ADMIRACIÓN, "!");
		caracteres.put(Tecla.SYM_CIERRA_PREGUNTA, "?");
		caracteres.put(Tecla.SYM_PUNTO, ".");
		caracteres.put(Tecla.SYM_COMA, ",");
		caracteres.put(Tecla.SYM_DOS_PUNTOS, ":");
		caracteres.put(Tecla.SYM_ABRE_ADMIRACIÓN, "¡");
		caracteres.put(Tecla.SYM_ABRE_CORCHETES, "[");
		caracteres.put(Tecla.SYM_ASTERISCO, "*");
		caracteres.put(Tecla.SYM_DIÉRESIS, "¨");
		caracteres.put(Tecla.SYM_ABRE_PREGUNTA, "¿");
		caracteres.put(Tecla.SYM_ABRE_LLAVE, "{");
		caracteres.put(Tecla.SYM_CIERRA_LLAVE, "}");
		caracteres.put(Tecla.SYM_BARRA_DIAGONAL, "/");
		caracteres.put(Tecla.SYM_BARRA_DIAGONAL_INVERTIDA, "\\");
		caracteres.put(Tecla.SYM_CIERRA_CORCHETES, "]");
		caracteres.put(Tecla.SYM_NUMERAL, "#");
		caracteres.put(Tecla.SYM_COMILLAS, "\"");
		caracteres.put(Tecla.SYM_PESOS, "$");
		caracteres.put(Tecla.SYM_PORCIENTO, "%");
		caracteres.put(Tecla.SYM_PUNTO_ELEVADO, "·");
		
		caracteres.put(Tecla.SYM_CE_CERILLAS, "Ç");
		caracteres.put(Tecla.SYM_OVOLADA, "º");
		caracteres.put(Tecla.SYM_AVOLADA, "ª");
		
		caracteres.put(Tecla.SYM_PUNTO_Y_COMA, ";");
		caracteres.put(Tecla.SYM_GUION_BAJO, "_");
		caracteres.put(Tecla.SYM_GUION, "-");
		caracteres.put(Tecla.SYM_MAYOR, ">");
		caracteres.put(Tecla.SYM_MENOR, "<");
		caracteres.put(Tecla.SYM_ABRE_PARÉNTESIS, "(");
		caracteres.put(Tecla.SYM_CIERRA_PARÉNTESIS, ")");
		caracteres.put(Tecla.SYM_BARRA_VERTICAL, "|");
		caracteres.put(Tecla.SYM_IGUAL, "=");
		caracteres.put(Tecla.SYM_ARROBA, "@");
		caracteres.put(Tecla.SYM_POTENCIA, "^");
		caracteres.put(Tecla.SYM_AND, "&");
		caracteres.put(Tecla.SYM_EURO, "€");
		caracteres.put(Tecla.SYM_NEGACIÓN, "~");
		caracteres.put(Tecla.SYM_APÓSTROFO, "'");
		caracteres.put(Tecla.BORRAR, "borrar");
		caracteres.put(Tecla.ESPACIO, "espacio");
		caracteres.put(Tecla.FLECHA_IZQ, "flecha izquierda");
		caracteres.put(Tecla.FLECHA_DER, "flecha derecha");
		caracteres.put(Tecla.FLECHA_ARR, "flecha arriba");
		caracteres.put(Tecla.FLECHA_AB, "flecha abajo");
		caracteres.put(Tecla.OPCIONES, "abrir opciones");
		caracteres.put(Tecla.ENTER, "aceptar");
		caracteres.put(Tecla.ESCAPE, "cancelar");
		caracteres.put(Tecla.ENVIAR, "enviar");
		caracteres.put(Tecla.NINGUNA, "ninguna");
		
		String cadena = caracteres.get(t);
		if (cadena == null) cadena = "";
		return cadena;
	} 
}

 * 
 * 
 * 
 * 
 * 
 * 
 * 
Public Function quéLetraSeApretó(númeroLetra As Integer) As String
    Dim auxString As String ', cadena As String

    Select Case UCase(Chr(númeroLetra))
        Case " "
            auxString = " espacio"
        Case "1"
            auxString = " uno"
        Case "´"
            auxString = " acento agudo"
        Case "¨"
            auxString = " diéresis"
        Case "`"
            auxString = " acento grave"
        Case "^"
            auxString = " acento circunflejo"
        Case "+"
            auxString = " más"
        Case "-"
            auxString = " menos"
        Case "_"
            auxString = " sobre "
        Case "*"
            auxString = " por"
        Case "/"
            auxString = " dividido"
        Case "="
            auxString = " igual"
        Case ","
            auxString = " coma"
        Case "."
            auxString = " punto"
        Case ";"
            auxString = " punto y coma"
        Case ":"
            auxString = " dos puntos"
        Case Chr(34) '"'"
            auxString = " comillas"
        Case "¡"
            auxString = " abre exclamación"
        Case "!"
            auxString = " cierra exclamación"
        Case "¿"
            auxString = " abre pregunta"
        Case "?"
            auxString = " cierra pregunta"
        Case "$"
            auxString = " signo pesos"
        Case "&"
            auxString = " anpersand"
        Case "\"
            auxString = " barra diagonal inversa"
        Case "º"
            auxString = " ordinal masculino"
        Case "ª"
            auxString = " ordinal femenino"
        Case "%"
            auxString = " porciento"
        Case "("
            auxString = " abre paréntesis"
        Case ")"
            auxString = " cierra paréntesis"
        Case "{"
            auxString = " abre llave"
        Case "}"
            auxString = " cierra llave"
        Case "Á"
            auxString = " a con acento"
        Case "É"
            auxString = " e con acento"
        Case "Í"
            auxString = " i con acento"
        Case "Ó"
            auxString = " o con acento"
        Case "Ú"
            auxString = " u con acento"
        Case "Ü"
            auxString = " u con diéresis"
        Case "B"
            auxString = " bé larga"
        Case "C"
            auxString = " cé"
        Case "D"
            auxString = " dé"
        Case "F"
            auxString = " éfe"
        Case "G"
            auxString = " gé"
        Case "H"
            auxString = " áche"
        Case "J"
            auxString = " jóta"
        Case "K"
            auxString = " ká"
        Case "L"
            auxString = " éle"
        Case "M"
            auxString = " éme"
        Case "N"
            auxString = " éne"
        Case "Ñ"
            auxString = " éñe"
        Case "P"
            auxString = " pé"
        Case "Q"
            auxString = " cú"
        Case "R"
            auxString = " érre"
        Case "S"
            auxString = " ése"
        Case "T"
            auxString = " té"
        Case "V"
            auxString = " vé corta"
        Case "W"
            auxString = " doble bé"
        Case "X"
            auxString = " équis"
        Case "Y"
            auxString = " i griega"
        Case "Z"
            auxString = " seta"
        Case "A"
            auxString = " ah"
        Case "E"
            auxString = " eh"
        Case "I"
            auxString = " ih"
        Case "O"
            auxString = " oh"
        Case "U"
            auxString = " uh"
        Case Else 'si es cualquier otro caracter
            auxString = Chr(númeroLetra)
    End Select
    
    'cadena = auxString
    If (númeroLetra >= 65 And númeroLetra <= 90) Then auxString = auxString + " mayúscula"
    
    If númeroLetra = 9 Then auxString = "avanzando hacia adelante un salto" 'si es un tab
    quéLetraSeApretó = auxString
End Function


Public Function traducirParaBorrar(letra As String) As String
    Dim auxString As String
    Select Case UCase(letra)
        Case " "
            auxString = " el espacio"
        Case "´"
            auxString = " el acento agudo "
        Case "¨"
            auxString = " la diéresis"
        Case "`"
            auxString = " el acento grave"
        Case "^"
            auxString = " el acento circunflejo"
        Case "&"
            auxString = " el ampersand"
        Case "+"
            auxString = " el más"
        Case "-"
            auxString = " el menos"
        Case "_"
            auxString = " el sobre"
        Case "*"
            auxString = " el por"
        Case "/"
            auxString = " el dividido"
        Case "="
            auxString = " el igual"
        Case ","
            auxString = " la coma"
        Case "."
            auxString = " el punto"
        Case ";"
            auxString = " el punto y coma"
        Case ":"
            auxString = " los dos puntos"
        Case Chr(34) '"'"
            auxString = " las comillas"
        Case "¡"
            auxString = " el abre exclamación"
        Case "!"
            auxString = " el cierra exclamación"
        Case "¿"
            auxString = " el abre pregunta"
        Case "?"
            auxString = " el cierra pregunta"
        Case "$"
            auxString = " el signo pesos"
        Case "%"
            auxString = " el porciento"
        Case "("
            auxString = " el abre paréntesis"
        Case ")"
            auxString = " el cierra paréntesis"
        Case "{"
            auxString = " el abre llave"
        Case "}"
            auxString = " el cierra llave"
        Case "Á"
            auxString = " la a con acento"
        Case "É"
            auxString = " la e con acento"
        Case "Í"
            auxString = " la i con acento"
        Case "Ó"
            auxString = " la o con acento"
        Case "Ú"
            auxString = " la u con acento"
        Case "B"
            auxString = " la bé larga"
        Case "C"
            auxString = " la cé"
        Case "D"
            auxString = " la dé"
        Case "F"
            auxString = " la éfe"
        Case "G"
            auxString = " la gé"
        Case "H"
            auxString = " la áche"
        Case "J"
            auxString = " la jóta"
        Case "K"
            auxString = " la ká"
        Case "L"
            auxString = " la éle"
        Case "M"
            auxString = " la éme"
        Case "N"
            auxString = " la éne"
        Case "Ñ"
            auxString = " la éñe"
        Case "P"
            auxString = " la pé"
        Case "Q"
            auxString = " la cú"
        Case "R"
            auxString = " la érre"
        Case "S"
            auxString = " la ése"
        Case "T"
            auxString = " la té"
        Case "V"
            auxString = " la vé corta"
        Case "W"
            auxString = " la doble bé"
        Case "X"
            auxString = " la équis"
        Case "Y"
            auxString = " la i griega"
        Case "Z"
            auxString = " la seta"
        Case "A"
            auxString = " la ah"
        Case "E"
            auxString = " la eh"
        Case "I"
            auxString = " la ih"
        Case "O"
            auxString = " la oh"
        Case "U"
            auxString = " la uh"
        Case "1"
            auxString = " el uno"
        Case "2"
            auxString = " el dos"
        Case "3"
            auxString = " el tres"
        Case "4"
            auxString = " el cuatro"
        Case "5"
            auxString = " el cinco"
        Case "6"
            auxString = " el seis"
        Case "7"
            auxString = " el siete"
        Case "8"
            auxString = " el ocho"
        Case "9"
            auxString = " el nueve"
        Case "0"
            auxString = " el cero"
        Case Else 'si es cualquier otro caracter
            auxString = " la " + letra
    End Select
    
    If (Asc(letra) >= 65 And Asc(letra) <= 90) Then auxString = auxString + " mayúscula"
    traducirParaBorrar = auxString
End Function



Public Function arreglarCadena(cadena As String) As String() 'para el corrector aspell
    Dim posición As Integer, cantidadDevolución As Integer, cadenaAux As String
    Dim temp() As String, contador As Integer, i As Integer ', tempAux(0 To 10) As String
    
    ReDim temp(0 To 0) 'para que no dé error si no hay palabras que coincidan
    posición = InStr(1, cadena, "*") 'se ve si la palabra fue correcta
    If posición = 0 Then
        posición = InStr(1, cadena, "&") 'se dejan sólo las palabras devueltas
        cadenaAux = Trim(Right(cadena, Len(cadena) - posición))
        
        posición = InStr(1, cadenaAux, " ") 'se busca el largo del array que devuelve aspell
        cadenaAux = Right(cadenaAux, Len(cadenaAux) - posición)
        posición = InStr(1, cadenaAux, " ")
        If IsNumeric(Left(cadenaAux, posición)) Then 'si hay alguna devolución para la palabra
            cantidadDevolución = Int(Left(cadenaAux, posición))
            ReDim Preserve temp(0 To cantidadDevolución - 1) 'se estira el array según la cantidad de palabras que devulve aspell
            
            If cantidadDevolución > 0 Then
                posición = InStr(1, cadenaAux, ":") 'se busca dejar sólo las palabras sugeridas
                cadenaAux = Trim(Right(cadenaAux, Len(cadenaAux) - posición))
            End If
            
            posición = InStr(1, cadenaAux, "ù") 'se quitan los caracteres ù
            Do While posición
                cadenaAux = Left(cadenaAux, posición - 1) + "é" + Right(cadenaAux, Len(cadenaAux) - posición)
                posición = InStr(1, cadenaAux, "ù")
            Loop
                    
            posición = InStr(1, cadenaAux, "ý") 'se quitan los caracteres ý
            Do While posición
                cadenaAux = Left(cadenaAux, posición - 1) + "í" + Right(cadenaAux, Len(cadenaAux) - posición)
                posición = InStr(1, cadenaAux, "ý")
            Loop
                   
           'Debug.Print cadenaAux
           
            posición = InStr(1, cadenaAux, "ø") 'se quitan los caracteres ý
            Do While posición
                cadenaAux = Left(cadenaAux, posición - 1) + "è" + Right(cadenaAux, Len(cadenaAux) - posición)
                posición = InStr(1, cadenaAux, "ø")
            Loop
            
            posición = InStr(1, cadenaAux, ",") 'se llena el array con las palabras devueltas
            contador = 0
            Do While posición
                If contador >= UBound(temp) Then Exit Do 'nos aseguramos que el contador no supere el límite del array así no da error
                temp(contador) = controlar_A_Acentuada(Trim(Left(cadenaAux, posición - 1)))
                cadenaAux = Right(cadenaAux, Len(cadenaAux) - posición)
                posición = InStr(1, cadenaAux, ",")
                contador = contador + 1
            Loop
            temp(contador) = controlar_A_Acentuada(Trim(Left(cadenaAux, Len(cadenaAux) - 4))) 'se carga la última palabra
        End If
    End If
    
'    If UBound(temp) > UBound(tempAux) Then
'        For i = 0 To UBound(tempAux)
'            tempAux(i) = temp(i)
'        Next
'        arreglarCadena = tempAux 'se devuelve el array
'    Else
        arreglarCadena = temp
'    End If
End Function




Public Function esSigno(cadena As String) As Boolean
    Dim i As Byte
    For i = 0 To 254
        If (i >= 65 And i <= 90) _
        Or (i >= 97 And i <= 122) _
        Or (i >= 192 And i <= 220) _
        Or (i >= 224 And i <= 252) Then
            If InStr(1, cadena, Chr(i)) Then 'con que haya una sola letra, se devuelve Falso
                esSigno = False
                Exit Function
            End If
        End If
    Next
    esSigno = True 'si no se devolvió falso, es que son sólo signos. Devuelve verdadero
End Function

Public Function separarEnLetras(palabra As String) As String
    Dim i As Integer, cadenaTemp As String
    
    For i = 1 To Len(palabra)
        cadenaTemp = cadenaTemp + Mid(palabra, i, 1) + ". "
    Next
    separarEnLetras = controlarDeletreo(cadenaTemp)
End Function

Public Function controlarDeletreo(cadena As String) As String
    Dim carácter(26) As String, posiciónCaracter As Long, cadenaFinal As String
    Dim i As Byte, swEntróAlFor As Boolean, swYaEmpezó As Boolean
    
    cadena = LCase(cadena)
    
    If cadena <> "" Then
        carácter(0) = "m. "
        carácter(1) = "s. "
        carácter(2) = "l. "
        carácter(3) = "h. "
        carácter(4) = "p. "
        carácter(5) = "n. "
        carácter(6) = "á. "
        carácter(7) = "é. "
        carácter(8) = "í. "
        carácter(9) = "ó. "
        carácter(10) = "ú. "
        carácter(11) = "à. "
        carácter(12) = "è. "
        carácter(13) = "ì. "
        carácter(14) = "ò. "
        carácter(15) = "ù. "
        carácter(16) = "â. "
        carácter(17) = "ê. "
        carácter(18) = "î. "
        carácter(19) = "ô. "
        carácter(20) = "û. "
        carácter(21) = "g. "
        carácter(22) = "u. "
        carácter(23) = "d. "
        carácter(24) = "b. "
        carácter(25) = "v. "
        carácter(26) = "y. "

        swEntróAlFor = False
        swYaEmpezó = False
        
        For i = 0 To UBound(carácter)
            If swYaEmpezó = False Then
                posiciónCaracter = InStr(1, cadena, carácter(i))
            Else
                posiciónCaracter = InStr(1, cadenaFinal, carácter(i))
            End If
            
            Do While posiciónCaracter <> 0
                If swEntróAlFor = False Then
                    cadenaFinal = corregirCadena(cadena, posiciónCaracter, carácter(i))
                Else
                    cadenaFinal = corregirCadena(cadenaFinal, posiciónCaracter, carácter(i))
                End If
                posiciónCaracter = InStr(1, cadenaFinal, carácter(i))
                swEntróAlFor = True
                swYaEmpezó = True
            Loop
        Next
        
        If cadenaFinal = "" Then cadenaFinal = cadena
        controlarDeletreo = cadenaFinal
    End If
End Function



Public Function controlar_A_Acentuada(devoluciónAspell As String) As String
    Dim Pos As Integer, palabraCambiada As String
    
    Pos = InStr(1, devoluciónAspell, "ñ") 'se quitan los caracteres ñ
    If Pos <> 0 Then 'si hay alguna ñ
        Do While Pos
            palabraCambiada = Left(devoluciónAspell, Pos - 1) + "á" + Right(devoluciónAspell, Len(devoluciónAspell) - Pos)
            Pos = InStr(Pos + 1, devoluciónAspell, "ñ")
                    
            'se ve si la palabra cambiada es correcta para dejar de cambiar ñ
            If corregirPalabra(palabraCambiada) Then Exit Do
        Loop
        
        'se ve si la palabra cambiada es correcta
        If corregirPalabra(palabraCambiada) Then 'si la palabra es correcta
            controlar_A_Acentuada = palabraCambiada
        Else
            controlar_A_Acentuada = devoluciónAspell
        End If
    Else 'si no hay ñ en la palabra, se la devuelve sin cambio
        controlar_A_Acentuada = devoluciónAspell
    End If
End Function
*/