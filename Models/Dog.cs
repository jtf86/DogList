using System.Collections.Generic;
using System;
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

    public Dog(string newName, int id=0)
    {
        this._name = newName;
        this._id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

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

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("Delete FROM dogs WHERE id = @DogId;", conn);
      SqlParameter thisDogId = new SqlParameter();
      thisDogId.ParameterName = "@DogId";
      thisDogId.Value = this._id;

      cmd.Parameters.Add(thisDogId);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    public void Update(string newName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE dogs SET name = @NewName OUTPUT INSERTED.name WHERE id = @DogId;", conn);

      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewName";
      newNameParameter.Value = newName;
      cmd.Parameters.Add(newNameParameter);


      SqlParameter DogIdParameter = new SqlParameter();
      DogIdParameter.ParameterName = "@DogId";
      DogIdParameter.Value = this.GetId();
      cmd.Parameters.Add(DogIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._name = rdr.GetString(0);
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

      cmd.Parameters.Add(searchId);
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
