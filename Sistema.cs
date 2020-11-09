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

namespace Biblioteca
{
  public static class Logs
  {
    // Debug
    public static void Debug(string msg)
    {
      string horario = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss");
      using (StreamWriter w = File.AppendText("proceso_logs.log"))
        {
          string msj = horario + " | " + msg;

          Log(msj, w);
          Console.WriteLine (msj);
        }			
    }


    // ----------------- Funciones privadas
    private static void Log(string msg, TextWriter tw)
    {
      tw.WriteLine (msg);
    }

  }

}

