/*
 * 		Written by Gastón Borysiuk
 * 
 * 	contact at: gaston.borysiuk@gmail.com
 * 
 *  Esto lo chorie de algun lado
 * 
 * 	Versión 0.1
 */

using System;
using System.Net;
using System.Net.Sockets;

namespace Biblioteca
{
  public static class Red
  {
    // ReverseLookup
    public static string reverseDnsLookup(string IpAddressString)
    {			
      try 
        {
          IPAddress hostIPAddress = IPAddress.Parse(IpAddressString);
          IPHostEntry hostInfo = Dns.GetHostEntry(hostIPAddress);
          IPAddress[] address = hostInfo.AddressList;
          String[] alias = hostInfo.Aliases;

          Logs.Debug("[RDNS] HostName : " + hostInfo.HostName);
          Logs.Debug("\nAliases :");
          for(int index=0; index < alias.Length; index++) {
            Logs.Debug(alias[index]);
          } 
          Logs.Debug("\nIP address list : ");

          for(int index=0; index < address.Length; index++) {
            Logs.Debug(address[index].ToString());
          }

          return hostInfo.HostName;
        }
      catch(SocketException e) 
        {
          Logs.Debug("[RDNS] SocketException!!!");
          Logs.Debug("[RDNS] Source : " + e.Source);
          Logs.Debug("[RDNS] Message : " + e.Message);
        }
      catch(FormatException e)
        {
          Logs.Debug("[RDNS] FormatException!!!");
          Logs.Debug("[RDNS] Source : " + e.Source);
          Logs.Debug("[RDNS] Message : " + e.Message);
        }
      catch(ArgumentNullException e)
        {
          Logs.Debug("[RDNS] ArgumentNullException!!!");
          Logs.Debug("[RDNS] Source : " + e.Source);
          Logs.Debug("[RDNS] Message : " + e.Message);
        }
      catch(Exception e)
        {
          Logs.Debug("[RDNS] Exception caught!!!");
          Logs.Debug("[RDNS] Source : " + e.Source);
          Logs.Debug("[RDNS] Message : " + e.Message);
        }

      return "N/D";
    }
  }
}

