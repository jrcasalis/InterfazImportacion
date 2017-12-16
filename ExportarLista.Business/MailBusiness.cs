using ExportarLista.Business.Interfaces;
using ExportarLista.Entities;
using ExportarLista.Entities.Configuracion;
using ExportarLista.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ExportarLista.Business
{
    public class MailBusiness : IMailBusiness
    {
        public bool EnviarMail(Mail mail)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            foreach (var destinatario in mail.destinatarios)
            {
                mmsg.To.Add(destinatario);
            }
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = mail.asunto;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("jrcasalis@gmail.com"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = mail.cuerpo;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = mail.cuerpoEsHtml; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress(mail.remitente);
            mmsg.ReplyToList.Add(new System.Net.Mail.MailAddress(mail.responderA));
            
            //Agrega los adjuntos
            foreach (var adjunto in mail.archivosAdjuntos)
            {
                mmsg.Attachments.Add(new System.Net.Mail.Attachment(adjunto));
            }
            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential(mail.usuario, mail.password);

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            
            if (mail.ssl)
            {
                cliente.Port = mail.puerto;
                cliente.EnableSsl = mail.ssl;
            }

            cliente.Host = mail.servidor;//"smtp.gmail.com"; //Para Gmail "smtp.gmail.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
                return false;
            }
        }
    }
}
