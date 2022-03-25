using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketLogic.Classes;

namespace MusicMarketUnitTests.ClassTests;

[TestClass]
public class PersonTest
{
    [TestMethod]
    public void TestConstructPerson()
    {
        //arragne
        var username = "Stijn";
        var email="stijn@gmail.com";
        //act
        var person = new Person(username, email);
        //assert
        Assert.IsTrue(person.Email==email && person.Username==username);
    }
}