using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;
using MailKit.Security;
using MailKit.Net;
using MailKit;
//using MailKit.Net.Smtp;
//using MimeKit;
//using MimeKit.Text;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;
using VillaNueva_Habitat.Datos;

namespace VillaNueva_Habitat.Servicios
{
    public static class CorreoServicio
    {



        
        public static bool Enviar(CorreoDTO correodto)
        {
            string from = "hola@eservicioscloud.net";
            string displayname = "Develofer";
            try
            {



                MailMessage email = new MailMessage();


                email.From = new MailAddress(from,displayname); //correodto.Asunto));
                                                                                       // email.To.Add(MailboxAddress.Parse("mail.staff.mx "));
                email.To.Add(correodto.Para);

                email.Subject = correodto.Asunto;
                email.Body = correodto.Contenido;
                email.IsBodyHtml = true;
                // {
                //      Text = correodto.Contenido
                // };

                SmtpClient cliente = new SmtpClient("mail.eservicioscloud.net", 8889);
                cliente.Credentials = new NetworkCredential(from, "Villanueva2023$");
                cliente.EnableSsl = false;

                cliente.Send(email);

               // smtp.Connect(_Host, 465, SecureSocketOptions.StartTls);

               // smtp.Authenticate(_Correo, _Clave);
              //  smtp.Send(email);
              //  smtp.Disconnect(true);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}