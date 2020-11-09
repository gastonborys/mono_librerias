using System;
using System.Text;
using System.Net;
using System.IO;

namespace Biblioteca
{

  public class B64{
  	
    public B64(){}
  	
    public string toBase64(string texto)
    {
      return Convert.ToBase64String(Encoding.UTF8.GetBytes(texto));
    }
  	
    public string fromBase64(string texto)
    {
      return Encoding.UTF8.GetString(Convert.FromBase64String(texto));
    }
  	
  }
  
  public class WebUtil
  {
    public WebUtil(){}
  	
    public string wget(string url)
    {
      string resultado = "N/D";
      try{
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse) request.GetResponse();
  			
        StreamReader reader = new StreamReader(response.GetResponseStream());
        resultado = reader.ReadToEnd();
        reader.Close();
      }
      catch(Exception ex)
        {
          resultado = ex.Message.ToString();
        }
  		
      return resultado;
    }
  }
}