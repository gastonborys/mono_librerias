/*
 * 		Written by Gastón Borysiuk
 * 
 * 	contact at: gaston.borysiuk@gmail.com
 * 
 * 
 * 	Versión 0.1
 */

using System;
using System.IO;
using System.Net;
using System.Text;

namespace Biblioteca
{
  public static class News
  {    

    public static string getRss(string url)
    {
      WebRequest peticion = WebRequest.Create(url);

      WebResponse respuesta = peticion.GetResponse();

      StreamReader sr = new StreamReader(respuesta.GetResponseStream());

      string pRespuesta = sr.ReadToEnd();
      
      return pRespuesta;
    }
  }
}

