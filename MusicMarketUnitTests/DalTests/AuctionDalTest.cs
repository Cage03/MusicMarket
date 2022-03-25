using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketDAL;
using MusicMarketInterface.DTOs;

namespace MusicMarketUnitTests.DalTests;

[TestClass]
public class AuctionDalTest
{
    [TestMethod]
    public void AddAuctionTest()
    {
        //arrange
        var auctionDal = new AuctionDal();
        //act
        var rowsAffected = auctionDal.AddAuction(new AuctionDto()
        {
            Date = DateTime.Now,
            Name = "Test"
        });
        //assert
        Assert.AreEqual(1, rowsAffected);
    }

    [TestMethod]
    public void RemoveAuctionTest()
    {
        //arrange
        var auctionDal = new AuctionDal();
        auctionDal.AddAuction(new AuctionDto()
        {
            Name = "TestName",
            Date = DateTime.Now
        });
        //act
        var rowsAffected = auctionDal.RemoveAuction(new AuctionDto()
        {
            Name = "TestName"
        });
        //assert
        Assert.AreEqual(1, rowsAffected);
    }
}