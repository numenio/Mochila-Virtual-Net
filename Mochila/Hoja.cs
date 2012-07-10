using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;
using System.IO;
using System.Windows;

namespace mochila
{
    class Hoja : RichTextBox
    {
        string rutaEnsamblado = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\";
        string separadoresPalabra = " ,.;:?!-+\r\n";

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
            string cadenaDevol = "";
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

        string getTextoRenglónActual(RichTextBox rtf) //listo
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

        Paragraph getPárrafoActual(RichTextBox rtf) //listo
        {
            return rtf.CaretPosition.Paragraph;
        }

        string getTextoPárrafoActual(RichTextBox rtf) //listo
        {
            Paragraph párrafo = getPárrafoActual(rtf);
            return new TextRange(párrafo.ElementStart, párrafo.ElementEnd).Text;
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

        bool swHojaVacía(RichTextBox rtf) //listo
        {
            if (new TextRange(rtf.Document.ContentStart, rtf.Document.ContentEnd).Text != "")
                return true;
            else
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

    }
}



/*
Public Function corregirPalabra(palabra As String) As Boolean 'true palabra encontrada, false no encontrada
    'Dim palabra As String
    Dim num As Integer
    Dim palabraArchivo As String
    Dim archivo As Integer
        
    If palabra = "" Then 'si el parámetro es vacío, se considera q está correcto
        corregirPalabra = True
    Else
        If swAspellInstalado = False Then
            archivo = FreeFile
            
            If palabra = "" Or palabra = "," Or palabra = "." Or palabra = ":" Or palabra = "?" Then
                corregirPalabra = True
                Exit Function
            End If
            
            Open App.path + "\datos\palabras.txt" For Input As #archivo 'se abre la lista de palabras
            Do Until EOF(archivo) 'chequeamos si la palabra está en la lista
                Line Input #archivo, palabraArchivo
                    If palabraArchivo = palabra Then 'si encuentra una palabra igual
                        Close #archivo
                        corregirPalabra = True
                        Exit Function
                    End If
                    
        '            If Asc(LCase(Left(palabraArchivo, 1))) > Asc(LCase(Left(palabra, 1))) Then 'si ya pasó la primera letra de la palabra
        '                Close #archivo
        '                corregirPalabra = False
        '                Exit Function
        '            End If
            Loop
            corregirPalabra = False
            Close #archivo
        Else
            Call objPipe.Write_(palabra & vbCrLf)
            Call Sleep(200)
            If InStr(1, objPipe.Read, "*") Then 'si está el asterisco en lo que devuelve aspell es que la palabra es correcta
                corregirPalabra = True
            Else
                corregirPalabra = False
            End If
        End If
    End If
End Function


Public Sub controlarCaracteresEspeciales(teclaPulsada As Integer, caja As TextBox)
    If teclaPulsada = 34 Or teclaPulsada = Asc("|") Or teclaPulsada = Asc("\") Or teclaPulsada = Asc("/") _
    Or teclaPulsada = Asc("?") Or teclaPulsada = Asc("*") Or teclaPulsada = Asc(">") Or teclaPulsada = Asc("<") _
    Or teclaPulsada = Asc(":") Or teclaPulsada = Asc(",") Or teclaPulsada = Asc(";") Or teclaPulsada = Asc(".") _
    Or teclaPulsada = Asc("-") Or teclaPulsada = Asc("_") Then
        caja.Text = Left(caja.Text, Len(caja.Text) - 1)
        frmMsgBox.cadenaAMostrar = "No se pueden escribir los siguientes signos en el nombre: . , ; - \ : / < > ? * | " + Chr(34) + "."
        frmMsgBox.swSíNoóAceptar = False 'se elige que sea cuadro aceptar
        frmMsgBox.Show 1
        SendKeys "^{end}"
    End If
End Sub


*/