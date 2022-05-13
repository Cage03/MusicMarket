using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketLogic.Classes;

namespace MusicMarketUnitTests.ClassTests;

[TestClass]
public class AuctionTest
{
    [TestMethod]
    public void TestConstructAuction()
    {
        //arrange
        DateTime date = new DateTime(2022, 12, 25);
        var name = "table";
        var personId = 5;
        var currentPrice = 19;
        //act
        var auction = new Auction(date, name, personId, currentPrice);
        //assert
        Assert.IsTrue(auction.Name==name && auction.Date==date && auction.PersonId==personId);
        
    }
}