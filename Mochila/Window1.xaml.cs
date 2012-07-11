using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Windows.Markup;


namespace mochila
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string rutaEnsamblado = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\";
        string separadoresPalabra = " ,.;:?!-+\r\n";
        Texto adminTexto = new Texto();
        

        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hoja.abrirRTF("prueba.rtf");
        }

        string getPalabra(RichTextBox rtf) //listo
        {
            string cadenaInicio;
            string cadenaFin;
            TextPointer punteroPosActual = rtf.Selection.Start;
            
            cadenaInicio = punteroPosActual.GetTextInRun(LogicalDirection.Backward);
            cadenaFin = punteroPosActual.GetTextInRun(LogicalDirection.Forward);

            //TODO si es número, que lea todo y no la parte antes del .
            //TODO If swLeerRenglones = True Then renglónActual = cuadroRTF.GetLineFromChar(cuadroRTF.SelStart)
            if (cadenaFin.Length > 0) //si no está al final de la hoja
            {
                string fin = buscarPalabraHaciaAdelanteEnCadena(cadenaFin);
                string inicio = buscarPalabraHaciaAtrásEnCadena(cadenaInicio);
                
                return inicio + fin;
            }
            else
            {
                return "Estás al final de la hoja";
            }
        }

        string buscarPalabraHaciaAtrásEnCadena(string cadena) //listo
        {
            int cont;
            cont = 1;
            string cadenaDevol="";
            if (cadena != "") 
            {
                string aux = cadena.Substring(cadena.Length - cont, 1);
                cadenaDevol = aux + cadenaDevol;
                while (!separadoresPalabra.Contains(aux) && cadena.Length - cont != 0) //TODO que controle que no haya bajada de línea, ya puse en la cadena /n/r
                {
                    cont++;
                    aux = cadena.Substring(cadena.Length - cont, 1);
                    cadenaDevol = aux + cadenaDevol;
                }
            }
            else
            {
                return "";
            }
           
            return cadenaDevol;
        }

        string buscarPalabraHaciaAdelanteEnCadena(string cadena) //listo
        {
            if (cadena == "" || cadena.Length == 1) return cadena;

            int cont;
            cont = 0;
            
            string aux = cadena.Substring(cont, 1);
            while (!separadoresPalabra.Contains(aux) && cont < cadena.Length) //TODO que controle que no haya bajada de línea, ya puse en la cadena /n/r
            {
                aux = cadena.Substring(cont, 1);
                cont++;
            }

            if (cont > 0 && cont < cadena.Length) cont--;
            return cadena.Substring(0, cont);
        }

        string getRenglón(RichTextBox rtf) //listo
        {
            string renglón = "";
            TextPointer punteroInicioRenglón = rtf.Selection.Start.GetLineStartPosition(0);
            TextPointer punteroInicioRenglónSiguiente = rtf.Selection.Start.GetLineStartPosition(1);
            TextPointer punteroFinDocumento = rtf.Document.ContentEnd;

            if (punteroInicioRenglónSiguiente != null) //si no están en el último renglón
                renglón = new TextRange(punteroInicioRenglón, punteroInicioRenglónSiguiente).Text;
            else //si es el último renglón
                renglón = new TextRange(punteroInicioRenglón, punteroFinDocumento).Text;

            return renglón;
        }

        bool swPrincipioDeLaHoja(RichTextBox rtf) //listo
        {
            TextPointer punteroPosActual = rtf.Selection.Start;
            string cadena = punteroPosActual.GetTextInRun(LogicalDirection.Backward);

            if (cadena.Length > 0) //si no está al principio de la hoja
                return false;
            else
                return true;
        }
        
        bool swFinDeLaHoja(RichTextBox rtf) //listo
        {
            TextPointer punteroPosActual = rtf.Selection.Start;
            string cadena = punteroPosActual.GetTextInRun(LogicalDirection.Forward);

            if (cadena.Length > 0) //si no está al final de la hoja
                return false;
            else
                return true;
        }

        //TODO
        string traducirCadenaParaLeer (string cadenaOriginal)
        {
			string carácterCorregido="";
			 switch(cadenaOriginal)
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
            string cadena="";

            return cadena;
        }

        bool swEstáEnNegrita(TextSelection texto) //listo
        {
            if ((FontWeight)texto.GetPropertyValue(Run.FontWeightProperty) == FontWeights.Bold)
                return true;
            else
                return false;
        }

        bool swParteEnNegrita(string cadena)
        {
            return false;
        }

        bool swEstáEnCursiva(RichTextBox rtf) //listo
        {
            if ((FontStyle)rtf.Selection.GetPropertyValue(Run.FontStyleProperty) == FontStyles.Italic)
                return true;
            else
                return false;
        }

        bool swParteEnCursiva(string cadena)
        {
            return false;
        }

        //bool swEstáSubrayado(RichTextBox rtf)
        //{
        //    if (rtf.FontStyle == FontStyles.)
        //        return true;
        //    else
        //        return false;
        //}

        bool swParteSubrayado(string cadena)
        {
            return false;
        }
        
        bool abrirRTF(RichTextBox rtf, string ruta) //listo
        {
            TextRange range;
            FileStream fStream;
            string _fileName = rutaEnsamblado + ruta;

            if (File.Exists(_fileName))
            {
                range = new TextRange(rtf.Document.ContentStart, rtf.Document.ContentEnd);
                fStream = new FileStream(_fileName, FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.Rtf);
                fStream.Close();
                return true;
            }
            else
                return false; //si no existe el archivo, false
        }

        private void guardarRTF(string filename, RichTextBox richTextBox) //listo
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException();
            }


            // open the file for reading
            using (FileStream stream = File.OpenWrite(rutaEnsamblado + filename))
            {
                // create a TextRange around the entire document
                TextRange documentTextRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

                // sniff out what data format you've got
                string dataFormat = DataFormats.Text;
                string ext = System.IO.Path.GetExtension(filename);
                if (String.Compare(ext, ".xaml", true) == 0)
                {
                    dataFormat = DataFormats.Xaml;
                }
                else if (String.Compare(ext, ".rtf", true) == 0)
                {
                    dataFormat = DataFormats.Rtf;
                }
                documentTextRange.Save(stream, dataFormat);
            }
        }

        private void imprimirRTF(RichTextBox rtf, bool swMostrarCuadroDiálogo) //listo
        {
            if (swMostrarCuadroDiálogo)
            {
                // crear el cuadro de dialogo de impresion y mostrarlo
                PrintDialog pDialog = new PrintDialog();

                if ((pDialog.ShowDialog() == true))
                {
                    FlowDocument doc = rtf.Document;

                    // establecer las propiedades de impresion establecidas en el dialogo de impresion
                    doc.PagePadding = new Thickness(20, 40, 20, 40);
                    doc.PageHeight = pDialog.PrintableAreaHeight;
                    doc.PageWidth = pDialog.PrintableAreaWidth;
                    doc.ColumnGap = 0;
                    doc.ColumnWidth = pDialog.PrintableAreaWidth;

                    // crear un paginador para la impresion e imprimir el documento
                    IDocumentPaginatorSource dps = doc;
                    pDialog.PrintDocument(dps.DocumentPaginator, "impresion");
                }
            }
            else
            {
                imprimirRTF(rtf);
            }
        }

        private void imprimirRTF(RichTextBox rtf) //TODO que pueda elegir qué impresora usar para imprimir
        {
            // crear el cuadro de dialogo de impresion y mostrarlo
            PrintDialog pDialog = new PrintDialog();
            FlowDocument doc = rtf.Document;

            // establecer las propiedades de impresion establecidas en el dialogo de impresion
            doc.PagePadding = new Thickness(20, 40, 20, 40);
            doc.PageHeight = pDialog.PrintableAreaHeight;
            doc.PageWidth = pDialog.PrintableAreaWidth;
            doc.ColumnGap = 0;
            doc.ColumnWidth = pDialog.PrintableAreaWidth;

            // crear un paginador para la impresion e imprimir el documento
            IDocumentPaginatorSource dps = doc;
            pDialog.PrintDocument(dps.DocumentPaginator, "impresion");
        }

        bool swEsSímbolo(string cadena)
        {
            return false;
        }

        bool swEsSímbolo(char caracter)
        {
            return false;
        }

        bool swEsNúmero(string cadena)
        {
            return false;
        }

        bool swEsNúmero(char caracter)
        {
            return false;
        }

        bool swHojaVacía(RichTextBox rtf)
        {
            return false;
        }

        int getNúmeroLíneaActual(RichTextBox rtf)
        {
            return 0;
        }

        string getLetraSiguiente(RichTextBox rtf)
        {
            string cadena = "";

            return cadena;
        }

        string getLetraAnterior(RichTextBox rtf)
        {
            string cadena = "";

            return cadena;
        }

        bool swMedioDelRenglón(RichTextBox rtf)
        {
            return false;
        }

        private void label1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ////abrirRTF(richTextBox1, "doc2.rtf");
            ////guardarRTF("prueba.rtf", richTextBox1);
            //imprimirRTF(richTextBox1);
            ////label1.Content = getPalabra(richTextBox1);
            //label1.Content = "";
            //if (swPrincipioDeLaHoja(richTextBox1))
            //    label1.Content += ", comienzo de la hoja";
            //if (swFinDeLaHoja(richTextBox1))
            //    label1.Content += ", fin de la hoja";

            //TextSelection texto = richTextBox1.Selection;
            //Texto txt = new Texto();
            //txt.pasarANegrita(texto);
            Calculadora calc = new Calculadora();
            //calc.parsearCadena(texto.Text);
            //calc.result;
            label1.Content = calc.result;
            if (swEstáEnNegrita(hoja.rtf.Selection))
                label1.Content = "negrita";
            //Paragraph párrafo = richTextBox1.CaretPosition.Paragraph;
            //Inline textoInterno = párrafo.Inlines.FirstInline;

            //string cadena = new TextRange(textoInterno.ContentStart, textoInterno.ContentEnd).Text;

            //if (adminTexto.EstáEnCursiva(párrafo))
            //    label1.Content = "en negrita";
            //else
            //    label1.Content = textoInterno;//cadena;//"nones";
            SpellingError error = hoja.chequearOrtografíaEnPosActual();
            if (error != null)
            {
                foreach (string suggession in error.Suggestions)
                    //lstSuggessions.Items.Add(suggession);
                    label1.Content += suggession + " ";
            }

        }

        /*
        
        
 




         */
    }
}
