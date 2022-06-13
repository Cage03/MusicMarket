using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Containers;
using MusicMarketUnitTests.Mocks;

namespace MusicMarketUnitTests.ContainerTests;

[TestClass]
public class AuctionContainerTest
{

    [TestMethod]

    public void ConstructorTest()
    {
        //arrange
        AuctionMock dal = new();
        //act
        var container = new AuctionContainer(dal);
        //assert
        Assert.IsNotNull(container, "container == null");
    }
    
    [TestMethod]
    public void AddAuctionTest()
    {
        //arrange
        var dal = new AuctionMock();
        var container = new AuctionContainer(dal);
        var auction = new Auction(DateTime.Now, "Table", 6,19);
        //act
        container.AddAuction(auction);
        //assert
        // Assert.IsTrue(dal.AuctionDtos.Contains(auction.ToDto()),"List does not contain Auction"); //Reminder, this does not work
        Assert.AreEqual(dal.AuctionDtos[^1].Name, auction.Name);
        Assert.AreEqual(dal.AuctionDtos[^1].Date, auction.Date);
        Assert.AreEqual(dal.AuctionDtos[^1].CurrentPrice, auction.CurrentPrice);
        Assert.AreEqual(dal.AuctionDtos[^1].PersonId, auction.PersonId);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddAlreadyContainedAuctionTest()
    {
        //arrange
        AuctionMock dal = new();
        var container = new AuctionContainer(dal);
        var auction = new Auction(DateTime.Now, "Table", 6,19);
        container.AddAuction(auction);
        //act
        container.AddAuction(auction);
        //assert
        Assert.IsFalse(dal.AuctionDtos.Contains(auction.ToDto()), "Scrub list does not contain auction");
        Assert.IsFalse(container.GetAuctions().Contains(auction), "Container list does not contain auction");
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    
    public void AddEmptyValueAuctionTest()
    {
        //arrange
        AuctionMock dal = new();
        var container = new AuctionContainer(dal);
        var auction = new Auction(DateTime.Now, "", 6,19);
        //act
        container.AddAuction(auction);
        //assert
        Assert.IsFalse(dal.AuctionDtos.Contains(auction.ToDto()));
        Assert.IsFalse(container.GetAuctions().Contains(auction));
    }

    [TestMethod]
    public void RemoveAuctionTest()
    {
        //arrange
        var dal = new AuctionMock();
        var container = new AuctionContainer(dal);
        var auction = new Auction(DateTime.Now, "Table", 5,19);
        container.AddAuction(auction);
        //act
        container.RemoveAuction(auction);
        //assert
       Assert.IsFalse(dal.AuctionDtos.Contains(auction.ToDto())); 
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RemoveNonContainedAuctionTest()
    {
        //arrange
        AuctionMock dal = new();
        var container = new AuctionContainer(dal);
        var auction = new Auction(DateTime.Now, "Table", 5,19);
        //act
        container.RemoveAuction(auction);
        //assert
        //nothing to assert
    }

    [TestMethod]
    public void GetAllTest()
    {
        //arrange
        AuctionMock dal = new();
        var container = new AuctionContainer(dal);
        //act
        var auctions = container.GetAllAuctions();
        //assert
        Assert.IsTrue(auctions.Count >= 3, "List does not contain all auctions");
    }

    [TestMethod]
    public void UpdateCurrentPriceTest()
    {
        //arrange
        AuctionMock dal = new();
        var container = new AuctionContainer(dal);
        var oldAuction = new Auction(DateTime.Now, "Table", 6,19);
        var newAuction = new Auction(DateTime.Now, "Table", 6, 23);
        container.AddAuction(oldAuction);
        //act
        container.UpdateCurrentPrice(newAuction);
        //assert
        Assert.IsTrue(dal.AuctionDtos[3].CurrentPrice == 23,"dal.AuctionDtos[3].CurrentPrice != 23");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void UpdateNonContainedAuction()
    {
        //arrange
        AuctionMock dal = new();
        var container = new AuctionContainer(dal);
        var oldAuction = new Auction(DateTime.Now, "Table", 6,19);
        var newAuction = new Auction(DateTime.Now, "Table", 6, 23);
        //act
        container.UpdateCurrentPrice(newAuction);
        //assert
        Assert.IsFalse(dal.AuctionDtos.Contains(newAuction.ToDto()));
    }
}