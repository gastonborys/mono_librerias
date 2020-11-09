/*
 * 	Written By Gastón Borysiuk
 *
 * gaston.borysiuk@gmail.com
 *
 * Fecha: 22/04/2015
 * Hora: 01:17 p.m.
 * 
 * 
 */

using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Biblioteca
{	
  public class DbSqlite{

    // Creo variables privadas locales
    private string DBFile;
    private string DBPath;
    private string PS;
    // Constructor
    public SqliteDataAdapter Resultados;

    private SqliteConnection Conexion; // Objeto de conexión
    private bool estado = false; // Flag para el estado de la fucking conexión 
 
		
    // Constructor
    public DbSqlite(string DB, string path = "")
    {
      PS = Path.DirectorySeparatorChar.ToString();
      if (path == "")
        {
          DBPath = Directory.GetCurrentDirectory() + PS +  "db"; // Path de la db
        }
      else
        {
          DBPath = path;
        }
          
      DBFile = DB;            
    }

    // Establecer Conexión
    public bool Conectar()
    {
      try{
        Conexion = new SqliteConnection("Data Source = " + DBPath + "\\" + DBFile);
        Conexion.Open();
        estado = true;
        return true;
      }
      catch(SqliteException e)
        {
          Console.WriteLine("Error al abrir la base de datos. Detalle del error:\r\n" + e.ToString());
          estado = false;
          return false;
        }
    }
		
    // Cerrar Conexión
    public bool Desconectar()
    {
      try{
        Conexion.Close();
        estado = false;
        return true;
      }
      catch(SqliteException e)
        {
          Console.WriteLine("Error al cerrar la base de datos. Detalle del error:\r\n" + e.ToString());
          estado = false;
          return false;
        }
    }

    // Consultar
    public void Consultar(string strQuery)
    {
      if (!estado)
        Conectar();
			
      try{
        Resultados = new SqliteDataAdapter(strQuery,Conexion);
				
        if (estado)
          Desconectar();
				
      }
      catch(SqliteException e)
        {
          Console.WriteLine("Error al intentar consultar al servidor. Detalle del error:\r\n" + e.ToString());
          throw;
        }
			
    }
		
		
    // Ejecutar
    public int Ejecutar(string strQuery)
    {
      if (!estado)
        Conectar();
			
      try{
        SqliteCommand cmd = new SqliteCommand(strQuery, Conexion);
        int i = cmd.ExecuteNonQuery();
				
        if (estado)
          Desconectar();
				
        return i;
      }
      catch(SqliteException e)
        {
          Console.WriteLine("Error al ejecutar el comando\r\n" + e.ToString());
          return 0;
        }
    }
		
		
    // Consulta Sin dataset
    public SqliteDataReader ConsultarSDR(string strQuery)
    {
      if (!estado)
        Conectar();
		
      try{
        SqliteCommand cmd = new SqliteCommand(strQuery, Conexion);
				
        SqliteDataReader rdr = cmd.ExecuteReader();
        rdr.Read();				
        return rdr;
      }
      catch(SqliteException e)
        {
          Console.WriteLine("Error al ejecutar la consulta\r\n" + e.ToString());
          throw;
        }
    }
  }

	
  public class DbMySQL
  {
    /* Globales */
    private string ConnectionString;
    public MySqlConnection Socket;
    public MySqlDataAdapter Adaptador;	
    public MySqlCommand Comando;
    public MySqlDataReader Reader;
		
    private string server;
    private string database;
    private string username;
    private string password;
    private string pooling;
		
    /* Constructor */
    public DbMySQL (string _server, string _db, string _uname, string _pass)
    {
      /* Defino datos del servidor MySQL */
      server = _server;
      database = _db;
      username = _uname;
      password = _pass;
      pooling = "false";
			
      /* Creo la dsn */
      ConnectionString = "Server="+server+";Database="+database+";User Id="+username+";Password="+password+";Pooling="+pooling+";";
			
      /* Creo la conexión */
      Socket = new MySqlConnection(ConnectionString);
    }
		
    /* Función para consultar en la DB */
    public bool Query(string strQuery)
    {
      // Inicio la consulta
      try{
        Socket.Open();
								
        Adaptador = new MySqlDataAdapter(strQuery,Socket);
				
        Socket.Close();
        return true;
					
      }
      catch (Exception Error)
        {
          Console.WriteLine("Error al Consultar\r\n" + Error.ToString());
          return false;
        }
    }
		
    public bool Command(string strQuery)
    {
      // Inicio la consulta
      try{
        Socket.Open();
								
        Comando = new MySqlCommand(strQuery,Socket);
				
        Comando.ExecuteNonQuery();
				
        Socket.Close();
				
        return true;
					
      }
      catch (Exception Error)
        {
          Console.WriteLine("Error al ejecutar el comando\r\n" + Error.ToString());                            
          return false;
        }
    }
		
    public bool Update(string strQuery)
    {
      // Inicio la consulta
      try{
        Socket.Open();			
        Comando = new MySqlCommand(strQuery,Socket);
							
        Reader = Comando.ExecuteReader();
				
        while (Reader.Read()){}
					
        Socket.Close();
        return true;
					
      }
      catch (Exception Error)
        {
          Console.WriteLine("Error al Modificar\r\n" + Error.ToString());
          return false;
        }
    }	
    
  }
}
