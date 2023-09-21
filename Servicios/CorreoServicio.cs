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

namespace VillaNueva_Habitat.Servicios
{
    public static class CorreoServicio
    {



        public static bool Enviar(CorreoDTO correodto)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.From = new MailAddress("jared.carolina01@hotmail.com", "snicoper");
                mail.To.Add(new MailAddress("gjordan@staffit.mx", "Salvador Nicolas"));
                mail.Subject = "Mensaje de prueba desde C# .NET";
                mail.Body = "<h1>Mensaje de prueba!!<h1>";

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = "jared.carolina01@hotmail.com";
                    NetworkCred.Password = "ElidiaNicolasPatricio251072";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Send(mail);
                }
            }
            catch (Exception)
            {
                return true;
            }

            return true;
        }
        public static bool Enviar1(CorreoDTO correodto)
        {


            try
            {



                MailMessage email = new MailMessage();
                email.From = new MailAddress("gjordan@staffit.mx", "Correo de confirmacion"); //correodto.Asunto));
                                                                                            // email.To.Add(MailboxAddress.Parse("mail.staff.mx "));
                email.To.Add(correodto.Para);
                email.Subject = correodto.Asunto;
                email.Body = correodto.Contenido;
                email.IsBodyHtml = true;
                // {
                //      Text = correodto.Contenido
                // };

                SmtpClient cliente = new SmtpClient("mail.staff.mx",465);
                cliente.Credentials = new NetworkCredential("mail.staff.mx", "!QJxQf5.R & 4J");
                cliente.EnableSsl = true;

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