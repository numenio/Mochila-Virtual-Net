using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Drawing;

namespace mochila
{
    //[Serializable()]
    class Usuario
    {
        bool swVerActividadesConJaws {get; set;} //para ver si se muestran las actividades en el calendario o en el árbol
        bool usarVoz { get; set; } //si está o no habilitada la voz
        string nombre { get; set; } //se les da 50 caracteres para que se escriba el nombre
        bool usuarioMujer { get; set; }
        bool mostrarTodasLasActividades { get; set; } //para ver si muestra act de años anteriores o futuros
        bool mostrarTodasLasTareas { get; set; }  //idem pero con tareas
        bool mostrarAñoEnEvaluaciones { get; set; }  //idem para evaluaciones
        bool imprimirDirecto { get; set; }  //para ver si se imprime sin mostrar el cuadro de diálogo de la impresora
        Font fuente { get; set; } //el nombre de la fuente, el tamaño
        System.Windows.Media.Brush fuenteColor { get; set; }  //el color de la fuente
        System.Windows.Media.Brush colorFondo { get; set; }  //el color de fondo de los rtf
        int velocidadVoz { get; set; }  //para regular la velocidad de la voz
        bool swLeerRenglones { get; set; } //para ver si leen los renglones
        bool swUsarCorrectorOrtográfico { get; set; }
        string nombreVoz { get; set; }
        bool swMúsicaDeFondo { get; set; } //para ver si suena la música de los form
        //bool swPermitirAbrirArchivos { get; set; }
        //Path rutaMúsicaFormPrincipal { get; set; }
        //Path rutaMúsicaFormCuaderno { get; set; }
        //Path rutaMúsicaFormActividad { get; set; }
        //Path rutaMúsicaFormTareas { get; set; }
        //Path rutaMúsicaFormLibros { get; set; }
        //Path rutaMúsicaFormAccesorios { get; set; }
        //Path rutaSonidosRecordatorios { get; set; }

        string rutaEnsamblado = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\";

        public bool guardarDatosUsuario()
        {
            try
            {
                //Serializar objContacto a XML
                string xmlContacto = this.SerializarToXml();
                File.WriteAllText(rutaEnsamblado + "\\usuario.xml", xmlContacto);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public bool cargarDatosUsuario()
        //{

        //    //Deserializar XML a objContacto
        //    Usuario contactoDeserializado = xmlContacto.DeserializarTo<Contacto>();
        //}


        //Serializar a XML (UTF-16) un objeto cualquiera
        string SerializarToXml()
        {
            try
            {
                StringWriter strWriter = new StringWriter();
                XmlSerializer serializer = new XmlSerializer(this.GetType());

                serializer.Serialize(strWriter, this);
                string resultXml = strWriter.ToString();
                strWriter.Close();

                return resultXml;
            }
            catch
            {
                return string.Empty;
            }
        }

        ////Deserializar un XML a un objeto T
        //T DeserializarTo<T>(this string xmlSerializado)
        //{
        //    try
        //    {
        //        XmlSerializer xmlSerz = new XmlSerializer(typeof(T));

        //        using (StringReader strReader = new StringReader(xmlSerializado))
        //        {
        //            object obj = xmlSerz.Deserialize(strReader);
        //            return (T)obj;
        //        }
        //    }
        //    catch { return default(T); }
        //}
    }
}