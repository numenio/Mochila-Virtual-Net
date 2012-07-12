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
        //public string nombre { get; set; }
        public string pass { get; set; }
        public int nivel_seguridad { get; set; }
        public string mail { get; set; }
        public static Usuario usuarioActual { get; set; }

        //public usuario()
        //{
        //}

        public Usuario (string _nombre) //para cargar desde BD el pass y el nivel 
        {
            AdminData ad = new AdminData();
            nombre = _nombre;
            pass= ad.recuperarPassUsuario(nombre);
            nivel_seguridad = ad.recuperarNivelSeguridadUsuario(nombre);
            mail = ad.recuperarMailUsuario(nombre);
        }

        public Usuario(string _nombre, string _pass, int _nivel_seguridad, string _mail) //para guardar
        {
            nombre = _nombre;
            pass = _pass;
            nivel_seguridad = _nivel_seguridad;
            mail = _mail;
        }

        public static bool usuarioExiste(string nombre)
        {
            AdminData ad = new AdminData();
            return ad.comprobarUsuarioExiste(nombre);
        }

        public bool guardar()
        {
            if (string.IsNullOrEmpty(nombre)) return false;
            if (string.IsNullOrEmpty(pass)) return false;
            if (nivel_seguridad==null) return false;
            if (string.IsNullOrEmpty(mail)) return false;

            bool swDevolución;
            //if (nivel_seguridad == 0) //si es un administrador
            //{
                AdminData ad = new AdminData();
                if (!ad.comprobarUsuarioExiste(nombre)) //si no hay ya un usuario con ese nombre
                    swDevolución = ad.guardarUsuario(nombre, pass, nivel_seguridad, mail); //se lo guarda
                else
                    swDevolución = false;
            //}
            //else
            //{
            //    return false; //si no puede guardar porque es un laucha
            //}

            return swDevolución;
        }

        public static bool comprobarPass(string nombre, string pass)
        {
            AdminData ad = new AdminData();
            string passAlmacenado = ad.recuperarPassUsuario(nombre);
            if (passAlmacenado == pass)
                return true;
            else
                return false;
        }

        public static int recuperarNivelSeguridad(string nombre)
        {
            AdminData ad = new AdminData();
            return ad.recuperarNivelSeguridadUsuario(nombre);
        }

        public static string recuperarMail(string nombre)
        {
            AdminData ad = new AdminData();
            return ad.recuperarMailUsuario(nombre);
        }

        public static List<Usuario> cargarTodos()
        {
            AdminData ad = new AdminData();
            return ad.recuperarTodosLosUsuarios();
        }

        public bool eliminar()
        {
            if (!usuarioVálido()) return false;

            AdminData ad = new AdminData();
            return ad.eliminarUsuario(nombre); //se lo elimina
        }

        public bool cambiarPass(string passNuevo)
        {
            if (!usuarioVálido()) return false;
            //if (nivel_seguridad != 0) return false; //si no es administrador, no puede 

            AdminData ad = new AdminData();
            return ad.cambiarPassUsuario(nombre, passNuevo);
        }

        public bool cambiarMail(string mailNuevo)
        {
            if (!usuarioVálido()) return false;
            //if (nivel_seguridad != 0) return false; //si no es administrador, no puede 

            AdminData ad = new AdminData();
            return ad.cambiarMailUsuario(nombre, mailNuevo);
        }

        public bool cambiarNivel(int nivelNuevo)
        {
            if (!usuarioVálido()) return false;
            //if (nivel_seguridad != 0) return false; //si no es administrador, no puede 

            AdminData ad = new AdminData();
            return ad.cambiarNivelUsuario(nombre, nivelNuevo);
        }

        private bool usuarioVálido() //chequea que se hayan llenado todos los campos y que el usuario exista
        {
            AdminData ad = new AdminData();
            if (!ad.comprobarUsuarioExiste(nombre)) return false; //si el usuario no existe
            if (string.IsNullOrEmpty(nombre)) return false;
            if (string.IsNullOrEmpty(pass)) return false;
            if (string.IsNullOrEmpty(mail)) return false;
            if (nivel_seguridad == null) return false;
            return true;
        }
    }
}
