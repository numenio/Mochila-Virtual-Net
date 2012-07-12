using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;


namespace mochila
{
    class AdminData
    {
        //OleDbConnection cnn;
        private static string _rutaBD = @"Provider=Microsoft.Jet.OLEDB.4.0; User ID=Admin; Jet OLEDB:Database Password=pa$$word; Data Source=mochila.mdb";

        # region BD
        public string rutaBD
        {
            get
            {
                return _rutaBD;
            }
            set
            {
                _rutaBD = rutaBD;
            }
        }

        public bool nombrarBD(string nombreBD)
        {
            try
            {
                rutaBD = nombreBD;
                return true;
            }
            catch
            {
                return false;
            }
        }
        # endregion BD

        # region contactos
        public bool guardarContacto(Contacto miContacto)
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();

                //se guarda el contacto
                string comandoInsert = "'" + miContacto.Nombre + "', '" + miContacto.Apellido + "', '" + miContacto.Dirección + "', '" + miContacto.Localidad + "', " + miContacto.fecha_nacimiento;
                OleDbCommand cmd = new OleDbCommand("INSERT INTO Contactos (nombre, apellido, dirección, localidad, fechaNacimiento) VALUES (" + comandoInsert + ")", cnn);
                cmd.ExecuteNonQuery();

                //se recupera la id del contacto que se acaba de guardar
                int id = this.recuperar_ID_contacto(miContacto.Nombre, miContacto.Apellido);

                //se guardan los teléfonos de esa id
                guardarTeléfonos(miContacto.Teléfonos, id);

                //se guardan los mails de esa id
                guardarMails(miContacto.Emails, id);

                cnn.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool guardarTeléfonos(List<Teléfono> teléfonos, int id)  //listo
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();

                foreach (Teléfono tel in teléfonos)
                {
                    string comandoInsert = id + ", '" + tel.Número + "'";
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Teléfonos (idContacto, número) VALUES (" + comandoInsert + ")", cnn);
                    cmd.ExecuteNonQuery();
                }

                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
        }

        private bool guardarMails(List<Mail> mails, int id)  //listo
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();

                foreach (Mail mail in mails)
                {
                    string comandoInsert =  id + ", '" + mail.Email + "'";
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Mails (idContacto, mail) VALUES (" + comandoInsert + ")", cnn);
                    cmd.ExecuteNonQuery();
                }

                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return false;
            }
        }

        private int recuperar_ID_contacto(string nombre, string apellido, string dirección, string localidad) //listo
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(_rutaBD);
                cnn.Open();

                string cadenaSelect = "Select id from Contactos where nombre = '" + nombre + "' and apellido = '" + apellido + "' and dirección = '" + dirección + "' and localidad = '" + localidad +"'";
                OleDbCommand cmd = new OleDbCommand(cadenaSelect, cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                miLector.Read();
                int id = miLector.GetInt32(0);

                miLector.Close();
                cnn.Close();
                return id;
            }
            catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    return 0;
                }
        }

        private int recuperar_ID_contacto(string nombre, string apellido)  //listo
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(_rutaBD);
                cnn.Open();

                string cadenaSelect = "Select id from Contactos where nombre = '" + nombre + "' and apellido = '" + apellido + "'";
                OleDbCommand cmd = new OleDbCommand(cadenaSelect, cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                miLector.Read();
                int id = miLector.GetInt32(0);

                miLector.Close();
                cnn.Close();
                return id;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return 0;
            }
        }

        private int recuperar_ID_contacto(string nombre)  //listo
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(_rutaBD);
                cnn.Open();

                string cadenaSelect = "Select id from Contactos where nombre = '" + nombre + "'";
                OleDbCommand cmd = new OleDbCommand(cadenaSelect, cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                miLector.Read();
                int id = miLector.GetInt32(0);

                miLector.Close();
                cnn.Close();
                return id;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return 0;
            }
        }

        public int recuperar_IDcontacto(string nombrecontacto)  //listo
        {
            string nombre = "", apellido = "";
            char[] caracteres = { ' ', ',', '.', ':', '\t' };
            //nombre = ;
            string[] cadena = nombrecontacto.Split(caracteres);
            nombre = cadena[0];
            if (cadena.Length > 1) apellido = cadena[1];
            if (string.IsNullOrEmpty(apellido))
            {
                return this.recuperar_ID_contacto(nombre);
            }
            else
            {
                return this.recuperar_ID_contacto(nombre, apellido);
            }
        }

        public string recuperar_nombre_contacto(int id)  //listo
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection(_rutaBD);
                cnn.Open();

                string cadenaSelect = "Select nombre, apellido from Contactos where id = " + id;
                OleDbCommand cmd = new OleDbCommand(cadenaSelect, cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                miLector.Read();
                string nombre = miLector.GetString(0) + " " + miLector.GetString(1);

                miLector.Close();
                cnn.Close();
                return nombre;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return "";
            }
        }

        private List<Teléfono> recuperarTeléfonos(int idContacto)  //listo
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);
            List<Teléfono> teléfonos = new List<Teléfono>();

            try
            {
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand("Select id, número from Teléfonos where idContacto = " + idContacto, cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                while (miLector.Read())
                {
                    Teléfono tel = new Teléfono();
                    tel.idTeléfono = miLector.GetInt32(0);
                    tel.Número = miLector.GetString(1);
                    teléfonos.Add(tel);
                }

                miLector.Close();
                cnn.Close();

                return teléfonos;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                cnn.Close();
                return teléfonos;
            }
        }

        private List<Mail> recuperarMails(int idContacto)  //listo
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);
            List<Mail> mails = new List<Mail>();

            try
            {
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand("Select id, mail from Mails where idContacto = " + idContacto, cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                while (miLector.Read())
                {
                    Mail miMail = new Mail();
                    miMail.idMail = miLector.GetInt32(0);
                    miMail.Email = miLector.GetString(1);
                    mails.Add(miMail);
                }

                miLector.Close();
                cnn.Close();

                return mails;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                cnn.Close();
                return mails;
            }
        }

        public bool eliminarContacto(int idContacto)  //listo
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);
            try
            {
                cnn.Open();
                //borramos el contacto de la tabla contacto
                string cadenaSQL = "Delete from Contactos where Id = " + idContacto;
                OleDbCommand cmd = new OleDbCommand(cadenaSQL, cnn);
                cmd.ExecuteNonQuery();
                //borramos los teléfonos
                cadenaSQL = "Delete from Teléfonos where idContacto = " + idContacto;
                cmd.CommandText = cadenaSQL;
                cmd.ExecuteNonQuery();
                //borramos los mails
                cadenaSQL = "Delete from Mails where idContacto = " + idContacto;
                cmd.CommandText = cadenaSQL;
                cmd.ExecuteNonQuery();
                cnn.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modificarContacto(Contacto contacto_a_modificar) //listo
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);
            try
            {
                cnn.Open();
                string cadenaSQL = "UPDATE Contactos SET nombre = '" + contacto_a_modificar.Nombre + "', apellido = '" + contacto_a_modificar.Apellido + "', dirección = '" + contacto_a_modificar.Dirección + "', localidad = '" + contacto_a_modificar.Localidad + "', fechaNacimiento = #" + contacto_a_modificar.fecha_nacimiento + "# where id = " + contacto_a_modificar.Id;
                OleDbCommand cmd = new OleDbCommand(cadenaSQL, cnn);
                cmd.ExecuteNonQuery();

                //se borran los teléfonos y mails del contacto por si hubieron modificaciones
                cadenaSQL = "DELETE from Teléfonos where idcontacto = " + contacto_a_modificar.Id;
                cmd = new OleDbCommand(cadenaSQL, cnn);
                cmd.ExecuteNonQuery();

                cadenaSQL = "DELETE from Mails where idcontacto = " + contacto_a_modificar.Id;
                cmd = new OleDbCommand(cadenaSQL, cnn);
                cmd.ExecuteNonQuery();

                //se agregan los nuevos teléfonos y mails
                guardarTeléfonos(contacto_a_modificar.Teléfonos, contacto_a_modificar.Id);
                guardarMails(contacto_a_modificar.Emails, contacto_a_modificar.Id);

                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
        }

        public List<Contacto> recuperarTodosLosContactos() //listo
        {
            List<Contacto> misContactos = new List<Contacto>();
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand("Select id, nombre, apellido, dirección, localidad, fechaNacimiento from Contactos", cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                //el comando y el lector para los teléfonos y los mails
                OleDbCommand cmd2 = new OleDbCommand();
                cmd2.Connection = cnn;

                while (miLector.Read())
                {
                    Contacto miContacto = new Contacto();
                    miContacto.Id = miLector.GetInt32(0);
                    miContacto.Nombre = miLector.GetString(1);
                    miContacto.Apellido = miLector.GetString(2);
                    miContacto.Dirección = miLector.GetString(3);
                    miContacto.Localidad = miLector.GetString(4);
                    miContacto.fecha_nacimiento = miLector.GetDateTime(5);
                    miContacto.Teléfonos = recuperarTeléfonos(miContacto.Id);
                    miContacto.Emails = recuperarMails(miContacto.Id);

                    misContactos.Add(miContacto);
                }

                miLector.Close();
                cnn.Close();

                return misContactos;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return misContactos;
            }
        }

        public Contacto recuperarContacto(int idContacto) //listo
        {
            Contacto micontacto = new Contacto();
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand("Select id, nombre, apellido, dirección, localidad from Contactos where id = " + idContacto, cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                miLector.Read();
                
                micontacto.Id = miLector.GetInt32(0);
                micontacto.Nombre = miLector.GetString(1);
                micontacto.Apellido = miLector.GetString(2);
                micontacto.Dirección = miLector.GetString(3);
                micontacto.Localidad = miLector.GetString(4);
                micontacto.Teléfonos = recuperarTeléfonos(micontacto.Id);
                micontacto.Emails = recuperarMails(micontacto.Id);
                
                miLector.Close();
                cnn.Close();

                return micontacto;
            }
            catch
            {
                return micontacto;
            }
        }

        public List<string> recuperarTodosLosNombresDeContactos() //listo
        {
            List<string> misContactos = new List<string>();
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand("Select nombre, apellido from Contactos", cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                while (miLector.Read())
                {

                    string cadena = miLector.GetString(0);
                    cadena += " " + miLector.GetString(1);
                    misContactos.Add(cadena);
                }

                miLector.Close();
                cnn.Close();

                return misContactos;
            }
            catch
            {
                return misContactos;
            }
        }

        public List<string> recuperarTodosLosIDDeContactos() //listo
        {
            List<string> misIDContactos = new List<string>();
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();

                OleDbCommand cmd = new OleDbCommand("Select id from Contactos", cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                while (miLector.Read())
                {
                    misIDContactos.Add(miLector.GetInt32(0).ToString());
                }

                miLector.Close();
                cnn.Close();

                return misIDContactos;
            }
            catch
            {
                return misIDContactos;
            }
        }
        # endregion contactos

        # region recordatorios

        public bool guardarRecordatorio(Recordatorio miRecordatorio)
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();

                //se guarda el contacto
                string comandoInsert = "#" + miRecordatorio.fecha + "#, '" + miRecordatorio.texto;
                OleDbCommand cmd = new OleDbCommand("INSERT INTO Recordatorios (fecha, texto) VALUES (" + comandoInsert + ")", cnn);
                cmd.ExecuteNonQuery();

                cnn.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Recordatorio recuperarRecordatorio(DateTime date, string texto)  //listo
        {
            Recordatorio miRecordatorio = new Recordatorio();
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();
                
                OleDbCommand cmd = new OleDbCommand("Select id from Recordatorios where fecha = #" + date + "# and texto = '" + texto + "'" , cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                miLector.Read();
                miRecordatorio.id = miLector.GetInt32(0);
                miRecordatorio.fecha = date;
                miRecordatorio.texto = texto;

                miLector.Close();
                cnn.Close();

                return miRecordatorio;
            }
            catch (Exception ex)
            {
                Debug.Print (ex.Message);
                cnn.Close();
                return miRecordatorio;
            }
        }

        public bool separarDateEnFechaHora(DateTime date, out string fecha, out string hora)  //listo
        {
            try
            {
                fecha = date.ToShortDateString();
                hora = date.ToShortTimeString();
                return true;
            }
            catch
            {
                fecha = "";
                hora = "";
                return false;
            }
        }

        //requiere que la fecha esté separada con / y la hora con :
        public DateTime juntarFechaHoraEnTime(string fecha, string hora)  //listo
        {
            try
            {
                int[] datosFecha = (fecha.Split(new char[] { '/' }).Select(a => int.Parse(a))).ToArray();
                int año = datosFecha[0];
                int mes = datosFecha[1];
                int día = datosFecha[2];

                int[] datosHora = (hora.Split(new char[] { ':' }).Select(a => int.Parse(a))).ToArray();
                int hor = datosHora[0];
                int min = datosHora[1];
                int sec = datosHora[2];
                return new DateTime(año, mes, día, hor, min, sec);
            }
            catch
            {
                return new DateTime();
            }
        }

        //si el Recordatorio buscado existe ya en la base de datos
        public bool chequearRecordatorio(Recordatorio RecordatorioABuscar) //listo
        {
            Recordatorio miRecordatorio = recuperarRecordatorio(RecordatorioABuscar.fecha, RecordatorioABuscar.texto);
            
            if (miRecordatorio.texto != null)
            {
                return true;
            } 
            else 
            {
                return false;
            }
        }

        public bool eliminarRecordatorio(Recordatorio Recordatorio_a_eliminar)  //listo
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);
            try
            {
                cnn.Open();
                string cadenaSQL = "Delete from Recordatorios where Id=" + Recordatorio_a_eliminar.id;
                OleDbCommand cmd = new OleDbCommand(cadenaSQL, cnn);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
            finally
            {
                cnn.Close();
            }
            
        }

        public bool modificarRecordatorio(Recordatorio Recordatorio_a_modificar)  //listo
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);
            try
            {
                cnn.Open();
                string cadenaSQL = "update Recordatorios set fecha = #" + Recordatorio_a_modificar.fecha + "#, texto = '" + Recordatorio_a_modificar.texto + "' where id = " + Recordatorio_a_modificar.id;
                OleDbCommand cmd = new OleDbCommand(cadenaSQL, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
        }

        public string recuperarTextoRecordatorio(int idRecordatorio) //listo
        {
            string textoRecordatorio = "";
            OleDbConnection cnn = new OleDbConnection(_rutaBD); 

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("Select texto from Recordatorios where id = " + idRecordatorio, cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                miLector.Read();
                textoRecordatorio = miLector.GetString(0);
                
                miLector.Close();
                cnn.Close();

                return textoRecordatorio;
            }
            catch
            {
                return textoRecordatorio;
            }
        }

        public List<Recordatorio> recuperarTodosLosRecordatorios() //listo
        {
            List<Recordatorio> misRecordatorios = new List<Recordatorio>();
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("Select id, fecha, texto from Recordatorios", cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                while (miLector.Read())
                {
                    Recordatorio miRecordatorio = new Recordatorio();
                    miRecordatorio.id = miLector.GetInt32(0);
                    //string fecha = miLector.GetString(1);
                    //string hora = miLector.GetString(2);
                    miRecordatorio.fecha = miLector.GetDateTime(1); //juntarFechaHoraEnTime(fecha, hora);
                    miRecordatorio.texto = miLector.GetString(2);
                    misRecordatorios.Add(miRecordatorio);
                }
                miLector.Close();
                cnn.Close();

                return misRecordatorios;
            }
            catch
            {
                return misRecordatorios;
            }
        }

        public List<Recordatorio> recuperarTodosLosRecordatoriosSegúnFecha(DateTime fecha) //listo
        {
            List<Recordatorio> misRecordatorios = new List<Recordatorio>();
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("Select id, fecha, hora, texto from Recordatorios where fecha >= " + fecha, cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                while (miLector.Read())
                {
                    Recordatorio miRecordatorio = new Recordatorio();
                    miRecordatorio.id = miLector.GetInt32(0);
                    miRecordatorio.fecha = miLector.GetDateTime(1);
                    miRecordatorio.texto = miLector.GetString(2);
                    misRecordatorios.Add(miRecordatorio);
                }
                miLector.Close();
                cnn.Close();

                return misRecordatorios;
            }
            catch
            {
                return misRecordatorios;
            }
        }

        //public List<string> recuperarTodosLos_ID_Recordatorios()
        //{
        //    List<string> misRecordatorios = new List<string>();
        //    OleDbConnection cnn = new OleDbConnection(_rutaBD);

        //    try
        //    {
        //        cnn.Open();
        //        OleDbCommand cmd = new OleDbCommand("Select id from Recordatorios", cnn);
        //        OleDbDataReader miLector = cmd.ExecuteReader();

        //        while (miLector.Read())
        //        {
        //            misRecordatorios.Add(miLector.GetInt32(0).ToString());
        //        }
        //        miLector.Close();
        //        cnn.Close();

        //        return misRecordatorios;
        //    }
        //    catch
        //    {
        //        return misRecordatorios;
        //    }
        //}

        //public int recuperarIDRecordatorioPorTexto(string nombreRecordatorio)
        //{
        //    string marca = "", producto = "", capacidad = "";
        //    char[] caracterEspacio = { ',' };
        //    string cadenaInicial, cadenaFinal;
        //    //se chequea si el Recordatorio tiene capacidad
        //    if (nombreRecordatorio.IndexOf(" x ") != -1)
        //    {
        //        cadenaInicial = nombreRecordatorio.Substring(0, nombreRecordatorio.IndexOf(" x "));
        //        cadenaFinal = nombreRecordatorio.Replace(cadenaInicial, "");
        //    }
        //    else
        //    {
        //        cadenaInicial = nombreRecordatorio;
        //        cadenaFinal = "0";
        //    }

        //    capacidad = cadenaFinal.Replace(",", ".");
        //    capacidad = capacidad.Replace("x ", "");
        //    capacidad = capacidad.Trim();
        //    //capacidad = capacidad.Replace(",", ".");
        //    string[] cadena2 = cadenaInicial.Split(caracterEspacio);
        //    marca = cadena2[0].Trim();
        //    producto = cadena2[1].Trim();

        //    if (!string.IsNullOrEmpty(capacidad))
        //        return this.recuperarIDRecordatorio(marca, producto, capacidad);

        //    return 0;
        //}

        //private int recuperarIDRecordatorio(string marca, string producto, string capacidad)
        //{
        //    int miID = 0;
        //    OleDbConnection cnn = new OleDbConnection(_rutaBD);

        //    try
        //    {
        //        cnn.Open();
        //        OleDbCommand cmd = new OleDbCommand("Select id from Recordatorios where marca = '" + marca + "' and producto = '" + producto + "' and capacidad = " + capacidad, cnn);
        //        OleDbDataReader miLector = cmd.ExecuteReader();

        //        miLector.Read();
        //        miID = miLector.GetInt32(0);

        //        miLector.Close();
        //        cnn.Close();

        //        return miID;
        //    }
        //    catch
        //    {
        //        return miID;
        //    }
        //}
        # endregion recordatorios

        # region usuario
        public bool guardarUsuario(string nombre, string pass, int nivelSeguridad, string mail)
        {

            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();

                string comandoInsert = "'" + nombre + "', '" + pass + "', " + nivelSeguridad + ", '" + mail + "'";

                OleDbCommand cmd = new OleDbCommand("INSERT INTO Usuarios (Nombre, Pass, Nivel_Seguridad, Email) VALUES (" + comandoInsert + ")", cnn);

                cmd.ExecuteNonQuery();

                cnn.Close();

                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }

        }

        public bool comprobarUsuarioExiste(string nombre)
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("Select id from Usuarios where nombre = '" + nombre + "'", cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                bool swUsuarioExiste;
                if (miLector.Read())
                    swUsuarioExiste = true;
                else
                    swUsuarioExiste = false;
                
                miLector.Close();
                cnn.Close();

                return swUsuarioExiste;
            }
            catch
            {
                cnn.Close();
                return false;
            }
        }

        public string recuperarPassUsuario(string nombre)
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("Select pass from Usuarios where nombre = '" + nombre + "'", cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                miLector.Read();

                string passUsuario = miLector.GetString(0);

                miLector.Close();
                cnn.Close();

                return passUsuario;
            }
            catch (Exception ex)
            {
                cnn.Close();
                return ex.Message;
            }
        }

        public int recuperarNivelSeguridadUsuario(string nombre)
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("Select nivel_seguridad from Usuarios where nombre = '" + nombre + "'", cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                miLector.Read();

                int nivel = miLector.GetInt32(0);

                miLector.Close();
                cnn.Close();

                return nivel;
            }
            catch
            {
                cnn.Close();
                return 1000; //cuanto más alto es el número, menos privilegios. Cero es el admin
            }
        }

        public List<Usuario> recuperarTodosLosUsuarios()
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("Select nombre, pass, nivel_seguridad, email from Usuarios", cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                while (miLector.Read())
                {
                    string nombre = miLector.GetString(0);
                    string pass = miLector.GetString(1);
                    int nivel = miLector.GetInt32(2);
                    string email = miLector.GetString(3);
                    Usuario miUsuario = new Usuario(nombre, pass, nivel, email);
                    usuarios.Add(miUsuario);
                }
                miLector.Close();
                cnn.Close();

                return usuarios;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                cnn.Close();
                return usuarios;
            }
        }

        public bool eliminarUsuario (string nombre)
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("Delete from Usuarios where nombre = '" + nombre + "'", cnn);
                cmd.ExecuteNonQuery();

                cnn.Close();

                return true;
            }
            catch
            {
                cnn.Close();
                return false; 
            }
        }

        public bool cambiarPassUsuario(string nombre, string pass)
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("Update Usuarios SET pass = '" + pass + "' where nombre = '" + nombre + "'", cnn);
                cmd.ExecuteNonQuery();

                cnn.Close();

                return true;
            }
            catch
            {
                cnn.Close();
                return false;
            }
        }

        public bool cambiarNivelUsuario(string nombre, int nivelNuevo)
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("Update Usuarios SET nivel_seguridad = " + nivelNuevo + " where nombre = '" + nombre + "'", cnn);
                cmd.ExecuteNonQuery();

                cnn.Close();

                return true;
            }
            catch
            {
                cnn.Close();
                return false;
            }
        }

        public string recuperarMailUsuario(string nombre)
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("Select email from Usuarios where nombre = '" + nombre + "'", cnn);
                OleDbDataReader miLector = cmd.ExecuteReader();

                miLector.Read();

                string mailUsuario = miLector.GetString(0);

                miLector.Close();
                cnn.Close();

                return mailUsuario;
            }
            catch (Exception ex)
            {
                cnn.Close();
                return ex.Message;
            }
        }

        public bool cambiarMailUsuario(string nombre, string nuevoMail)
        {
            OleDbConnection cnn = new OleDbConnection(_rutaBD);

            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand("Update Usuarios SET email = '" + nuevoMail + "' where nombre = '" + nombre + "'", cnn);
                cmd.ExecuteNonQuery();

                cnn.Close();

                return true;
            }
            catch
            {
                cnn.Close();
                return false;
            }
        }
        # endregion usuario
        
        //corregir
        //public bool respaldarBD(string rutaDondeRespaldar)
        //{
            //FileInfo[] MisFiles;
            //DirectoryInfo[] MisDir;
            //int ContadorDir = 0;
            //MisFiles = new DirectoryInfo(Origen).GetFiles();
            //MisDir = new DirectoryInfo(Origen).GetDirectories();
            //ContadorDir = MisDir.GetLength(0);
            //foreach (FileInfo Archivo in MisFiles)
            //{
            //try
            //{
            //Archivo.CopyTo(Destino + "\\" + Archivo.Name);
            //}
            //catch (Exception e)
            //{
            //MiFiFo.Enqueue("FAILURE: " + Destino + "\\" + Archivo.Name + "\r" + e.Message + "\r");
            //}
            //}
            //for (int i = 0; i &lt; ContadorDir; i++)
            //{
            //CrearDirectorio(Destino + "\\" + MisDir[i].Name);
            //MoverArchivos1(Destino + "\\" + MisDir[i].Name, MisDir[i].FullName);
            //}

        //}

    }
}
