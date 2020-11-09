/*
 * 		Written by Gastón Borysiuk
 * 
 * 	contact at: gaston.borysiuk@gmail.com
 * 
 * 
 * 	Versión 0.1
 */


using System;
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca
{

  public static class Hashes{

    public static string Md5Sum(string cadena)
    {
      string hash;
      using (MD5 hmd = MD5.Create()) {
        hash = GetMd5 (hmd, cadena);
      }

      return hash;
    }

    // ----------------- Funciones privadas
    private static string GetMd5(MD5 md5Hash, string cadena)
    {
      byte[] data = md5Hash.ComputeHash (Encoding.UTF8.GetBytes (cadena));

      StringBuilder strb = new StringBuilder ();

      for (int i=0; i < data.Length; i++) {
        strb.Append (data [i].ToString ("x2"));
      }

      return strb.ToString ();		
    }

  }
}
