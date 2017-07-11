using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.SqlServer;

namespace DogList.Objects
{
  public class Dog
  {
    private string _name;
    private int _id;
    // public static List<Dog> instances = new List<Dog> {};

    public Dog(string newName, int id=0)
    {
        this._name = newName;
        this._id = id;
        // instances.Add(this);
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    // public static List<Dog> GetAllOLD()
    // {
    //   return instances;
    // }

    public static List<Dog> GetAll()
    {
      List<Dog> allDogs = new List<Dog>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM dogs;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int dogId = rdr.GetInt32(0);
        string dogName = rdr.GetString(1);
        Dog newDog = new Dog(dogName, dogId);
        allDogs.Add(newDog);
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allDogs;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO dogs (name) OUTPUT INSERTED.id VALUES (@DogName);", conn);
      SqlParameter name = new SqlParameter();
      name.ParameterName = "@DogName";
      name.Value = this._name;

      cmd.Parameters.Add(name);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static Dog Find(int dogId)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM dogs WHERE id = @DogId;", conn);
      SqlParameter searchId = new SqlParameter();
      searchId.ParameterName = "@DogId";
      searchId.Value = dogId;
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundDogId = 0;
      string foundDogName = null;

      while(rdr.Read())
      {
        foundDogId = rdr.GetInt32(0);
        foundDogName = rdr.GetString(1);
      }

      Dog foundDog = new Dog(foundDogName, foundDogId);
      if (conn != null)
      {
        conn.Close();
      }
      return foundDog;
    }


  }
}
