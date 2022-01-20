using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
  [TestFixture]
  public class NUnitCheetSheet
  {
    [Test]
    public void StandardTest()
    {
      Assert.AreEqual(1, 1);
    }

    [TestCase(1, "ala", 123)]
    public void TestCase(int index, string str, int count)
    {
      Assert.IsTrue(true);
      //Assert.Fail();
    }

    [Test, Sequential]
    public void Test(
      [Values(1, 2, 3)] int x,
      [Values("A", "B")] string s)
    {
      //Assert.Throws<InvalidOperationException>(() =>
      //{
      //  throw new InvalidOperationException();
      //});
    }

    [Test, Combinatorial]
    public void MyTest(
      [Values(1, 2, 3)] int x,
      [Values("A", "B")] string s)
    {
      Assert.DoesNotThrow(() => { int i = 10; });

      // Declaration
      var mock = new Mock<IFoo>();
      // Usage
      IFoo v = mock.Object;
      // function return value
      mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
      // Matching arguments
      mock.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns(true);
      // Property
      mock.Setup(foo => foo.Name).Returns("bar");
    }

    public interface IFoo
    {
      object Name { get; }

      bool DoSomething(string v);
    }
  }
}