using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mochila
{
    public class Contacto
    {
        public Contacto()
        {
            Teléfonos = new List<Teléfono>();
            Emails = new List<Mail>();
            _nombre = "sin llenar";
            _apellido = "sin llenar";
            _dirección = "sin llenar";
            _localidad = "sin llenar";
            fecha_nacimiento = new DateTime(2000, 01, 01);
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        private string _dirección;

        public DateTime fecha_nacimiento {get; set;}

        public string Dirección
        {
            get { return _dirección; }
            set { _dirección = value; }
        }
        private string _localidad;

        public string Localidad
        {
            get { return _localidad; }
            set { _localidad = value; }
        }

        private List<Teléfono> _teléfonos;

        public List<Teléfono> Teléfonos
        {
            get { return _teléfonos; }
            set { _teléfonos = value; }
        }

        private List<Mail> _emails;

        public List<Mail> Emails
        {
            get { return _emails; }
            set { _emails = value; }
        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool guardar()
        {
            try
            {

                AdminData ad = new AdminData();
                ad.guardarContacto(this);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public void actualizar()
        {
            AdminData ad = new AdminData();
            ad.modificarContacto(this);
        }

        public static List<Contacto> cargarTodos()
        {
            AdminData ad = new AdminData();
            List<Contacto> misContactos = ad.recuperarTodosLosContactos();
            return misContactos;
        }

        public static Contacto cargarContacto(int idContacto)
        {
            AdminData ad = new AdminData();
            return ad.recuperarContacto (idContacto);
        }

        
        //public static int recuperarIdcontacto(string nombre, string apellido, string dirección, string localidad, string peluquería)
        //{
        //    AdminData ad = new AdminData();
        //    return ad.recuperar_ID_contacto(nombre, apellido, dirección, localidad, peluquería);
        //}

        //public static int recuperarIdcontacto(string nombre, string apellido)
        //{
        //    AdminData ad = new AdminData();
        //    return ad.recuperar_ID_contacto(nombre, apellido);
        //}

        public static int recuperarIdcontacto(string nombre)
        {
            AdminData ad = new AdminData();
            return ad.recuperar_IDcontacto(nombre);
        }

        public static string recuperarNombrecontacto(int id)
        {
            AdminData ad = new AdminData();
            return ad.recuperar_nombre_contacto(id);
        }

        public static List<string> recuperarTodosLosNombresDeContactos()
        {
            AdminData ad = new AdminData();
            return ad.recuperarTodosLosNombresDeContactos();
        }

        public static List<string> recuperarTodosLosID()
        {
            AdminData ad = new AdminData();
            return ad.recuperarTodosLosIDDeContactos();
        }

       

        public static void eliminar(int idcontacto)
        {
            AdminData ad = new AdminData();
            ad.eliminarContacto(idcontacto);
        }
    }

    public class Teléfono
    {
        public int idTeléfono { get; set; }
        public string Número { get; set; }
        public Teléfono() { }
        public Teléfono(string número) { Número = número; }
    }

    public class Mail
    {
        public int idMail { get; set; }
        public string Email { get; set; }
        public Mail() { }
        public Mail(string email) {Email = email; }
    }
}
