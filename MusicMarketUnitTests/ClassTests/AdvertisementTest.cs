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
        var name = "table";
        var description = "lorem ipsum";
        double price = 5.01;
        var status = "true";
        //act
        var advertisement = new Advertisement(name, description, price, status);
        //assert
        Assert.AreEqual(name, advertisement.Name);
        Assert.AreEqual(description, advertisement.Description);
        Assert.AreEqual(price, advertisement.Price);
        Assert.AreEqual(status, advertisement.Status);
    }
}