using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace VillaNueva_Habitat.Servicios
{
    
    public static class UtilidadServicio
    {
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        //public static string ConvertirSHA256(string texto)
        //{
        //    string hash = string.Empty;

        //    using (SHA256 sha256 = SHA256.Create())
        //    {
        //        byte[] hashvalue = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));

        //        foreach (byte b in hashvalue)
        //            hash += $"{b: X2}";

        //    }
        //    return hash;
        //}

        public static string GenerarToken()
        {
            string token = Guid.NewGuid().ToString("N");
            return token;
        }
    }
}