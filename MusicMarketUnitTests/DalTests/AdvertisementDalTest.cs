using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketDAL;
using MusicMarketInterface.DTOs;

namespace MusicMarketUnitTests.DalTests;

[TestClass]
public class AdvertisementDalTest
{

    [TestMethod]
    public void AddAdvertisementTest()
    {
        //Adds a row to advertisement-table in database
        //arrange
        var advertisementDal = new AdvertisementDal();
        //act
        var rowsAffected = advertisementDal.AddAdvertisement(new AdvertisementDto()
        {
            Date = DateTime.Now,
            Name = "TestName",
        });
        //assert
        Assert.AreEqual(1,rowsAffected);
    }

    [TestMethod]
    public void RemoveAdvertisementTest()
    {
        //Adds a row to Advertisement table, then remove that same row
        //arrange
        var advertisementDal = new AdvertisementDal();
        advertisementDal.AddAdvertisement(new AdvertisementDto()
        {
            Date = DateTime.Now,
            Name = "TestData"
        });
        //act
        var rowsAffected = advertisementDal.RemoveAdvertisement(new AdvertisementDto()
        {
            Name = "TestData"
        });
        //assert
        Assert.AreEqual(1, rowsAffected);
    }
}