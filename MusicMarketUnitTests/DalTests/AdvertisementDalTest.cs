using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketDAL;
using MusicMarketInterface.DTOs;

namespace MusicMarketUnitTests.DalTests;
//URGENT dal tests are currently used to test the creation of rows inside the database, change later.
[TestClass]
public class AdvertisementDalTest
{

    // [TestMethod]
    // public void AddAdvertisementTest()
    // {
    //     //Adds a row to advertisement-table in database
    //     //arrange
    //     var advertisementDal = new AdvertisementDal();
    //     //act
    //     var rowsAffected = advertisementDal.AddAdvertisement(new AdvertisementDto()
    //     {
    //         Name = "TestName",
    //         Description = "LoremIpsum",
    //         Price = 5.01,
    //         Status = "true"
    //     });
    //     //assert
    //     Assert.AreEqual(1,rowsAffected);
    // }

    [TestMethod]
    public void RemoveAdvertisementTest()
    {
        //Adds a row to Advertisement table, then remove that same row
        //arrange
        var advertisementDal = new AdvertisementDal();
        advertisementDal.AddAdvertisement(new AdvertisementDto()
        {
            Name = "TestData",
            Description = "LoremIpsum",
            Price = 5.01,
            Status = "true"
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