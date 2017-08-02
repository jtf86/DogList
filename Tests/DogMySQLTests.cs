using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace DogList.Objects
{
    [TestClass]
    public class DogListTests : IDisposable
    {

        public void Dispose()
        {
            Dog.DeleteAll();
        }

        public DogListTests()
        {
            DBConfiguration.ConnectionString = "server=localhost:3306;database=doglist_test;uid=root;pwd=root";
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

        [TestMethod]
        public void ManyDogs_ManyFuns()
        {
            Dog newDog = new Dog("Doug");
            Dog newDog2 = new Dog("Pete");
            Dog newDog3 = new Dog("Sam");
            Dog newDog4 = new Dog("Kesa");
            Dog newDog5 = new Dog("Phil");
            newDog.Save();
            newDog2.Save();
            newDog3.Save();
            newDog4.Save();
            newDog5.Save();
            List<Dog> allDogs = Dog.GetAll();
            foreach (var dog in allDogs)
            {
                Console.WriteLine(dog.GetName());
            }
            Console.WriteLine(newDog.GetId());
            Dog foundDog = Dog.Find(newDog.GetId());

            Assert.AreEqual("Doug", foundDog.GetName());
        }



    }
}
