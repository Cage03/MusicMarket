using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Containers;

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
        Assert.IsTrue(advertisement.Name==name && advertisement.Description==description && Math.Abs(advertisement.Price - price) < 0 && advertisement.Status==status);
    }
}