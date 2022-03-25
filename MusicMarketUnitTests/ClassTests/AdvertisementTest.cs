using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketLogic.Classes;

namespace MusicMarketUnitTests.ClassTests;

[TestClass]
public class AdvertisementTest
{
    [TestMethod]
    public void TestConstructAdvertisement()
    {
        //arrange
        var personId = 2;
        DateTime date = new DateTime(2021, 12, 25);
        var name = "table";
        //act
        var advertisement = new Advertisement(personId,date,name);
        //assert
        Assert.IsTrue(advertisement.Name == name && advertisement.Date == date && advertisement.PersonId==personId);
    }
}