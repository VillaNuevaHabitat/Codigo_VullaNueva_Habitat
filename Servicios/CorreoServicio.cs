﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VillaNueva_Habitat.Models;
using MailKit.Security;
using MailKit.Net;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace VillaNueva_Habitat.Servicios
{
    public static class CorreoServicio
    {
        private static string _Host = "jared.carolina01@hotmail.com";
        private static int _Puerto = 587;

        private static string _NombreEnvia = "Gabino Jordaaan";
        private static string _Correo = "jared.carolina01@gmail.com";
        private static string _Clave = "ElidiaNicolasPatricio251072";



        public static bool Enviar(CorreoDTO correodto)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(_NombreEnvia, _Correo));
                email.To.Add(MailboxAddress.Parse("jared.carolina01@hotmail.com"));
                //email.To.Add(MailboxAddress.Parse(correodto.Para));
                email.Subject = correodto.Asunto;
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = correodto.Contenido
                };

                var smtp = new SmtpClient();
                //smtp.Connect(_Host, _Puerto, SecureSocketOptions.StartTls);

                smtp.Authenticate(_Correo, _Clave);
                smtp.Send(email);
                smtp.Disconnect(true);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}