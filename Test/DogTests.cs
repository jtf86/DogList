using Xunit;

namespace DogList.Objects
{
  public class DogListTests
  {

    [Fact]
    public void StupidTest()
    {
      Assert.Equal(1,1);
    }

    [Fact]
    public void Dog_HasName_True()
    {
      Dog newDog = new Dog("Kesa");
      Assert.Equal("Kesa", newDog.GetName());
    }

    [Fact]
    public void Dog_HasName_False()
    {
      Dog newDog = new Dog("Doug");
      Assert.NotEqual("Kesa", newDog.GetName());
    }

  }
}
