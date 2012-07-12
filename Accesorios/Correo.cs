using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;


namespace mochila
{
    class Correo
    {
        //Correo.enviar("guillermo.toscani@gmail.com", "hola", "hola");
        //TODO hacer que corra en un thread diferente para evitar lag
        public static void enviar(string to, string asunto, string cuerpo)
        {
            enviar(to, "mochilavirtualnet@gmail.com", asunto, cuerpo, "smtp.googlemail.com", 587, "mochilavirtualnet@gmail.com", "1234mochila5678"); 
        }
        
        public static void enviar(string to, string from, string asunto, string cuerpo, string servidor, int puerto, string usuario, string clave)
        {

            MailMessage msg = new MailMessage();

            msg.To.Add(new MailAddress(to));
            msg.From = new MailAddress(from);
            msg.Subject = asunto;
            msg.Body = cuerpo;

            SmtpClient clienteSmtp = new SmtpClient(servidor, puerto);

            clienteSmtp.Credentials = new NetworkCredential(usuario, clave);
            clienteSmtp.EnableSsl = true;

            try
            {
                clienteSmtp.Send(msg);
            }

            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                msg.Dispose();
            }
        }
    }
}
