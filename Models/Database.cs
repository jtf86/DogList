using System;
using System.Data;
using System.Data.SqlClient;

namespace DogList
{
  public class DB
  {
    public static SqlConnection Connection()
    {
      SqlConnection conn = new SqlConnection(DBConfiguration.ConnectionString);
      Console.WriteLine("YOU HAVE CONNECTED");
      return conn;
    }
  }

}