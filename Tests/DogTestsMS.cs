using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DogList.Objects
{
  [TestClass]
  public class DogListTests
  {
    public DogListTests()
    {
      DBConfiguration.ConnectionString = "Server=localhost;Database=doglist_test;User Id=sa;Password=Epic0dus";
    }

    [TestMethod]
    public void Dog_HasName_True()
    {
      Dog newDog = new Dog("Kesa");
      Assert.AreEqual("Kesa", newDog.GetName());
    }

    [TestMethod]
    public void Dog_HasName_False()
    {
      Dog newDog = new Dog("Doug");
      Assert.AreNotEqual("Kesa", newDog.GetName());
    }

    [TestMethod]
    public void Dog_SavesToDatabaseGetsAssignedId_True()
    {
      Dog newDog = new Dog("Doug");
      newDog.Save();

      Console.WriteLine(newDog.GetId());
      Dog foundDog = Dog.Find(newDog.GetId());

      Assert.AreEqual("Doug", foundDog.GetName());
    }


  }
}
