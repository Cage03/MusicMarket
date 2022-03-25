using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketDAL;
using MusicMarketInterface.DTOs;

namespace MusicMarketUnitTests.DalTests;

[TestClass]
public class PersonDalTest
{
    [TestMethod]

    public void AddPersonTest()
    {
        //arrange
        var personDal = new PersonDal();
        //act
        var rowsAffected = personDal.AddPerson(new PersonDto()
        {
        Username = "TestUser",
        Email = "Test@mail.com"
        });
        //assert
        Assert.AreEqual(1, rowsAffected);
    }

    [TestMethod]
    public void RemovePersonTest()
    {
        //arrange
        var personDal = new PersonDal();
       personDal.AddPerson(new PersonDto()
        {
            Username = "Test",
            Email = "Test@home.com"
        });
        //act
        var rowsAffected = personDal.RemovePerson(new PersonDto()
        {
            Username = "Test"
        });
        //assert
        Assert.AreEqual(1, rowsAffected);
    }
}