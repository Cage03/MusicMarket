using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Containers;

namespace MusicMarketUnitTests.ContainerTests;

[TestClass]
public class AuctionContainerTest
{
    [TestMethod]
    public void AddAuctionTest()
    {
        //arrange
        var container = new AuctionContainer();
        var auction = new Auction(DateTime.Now, "Table", 6);
        //act
        container.AddAuction(auction);
        //assert
        Assert.IsTrue(container.GetAuctions().Contains(auction));
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddAlreadyContainedAuctionTest()
    {
        //arrange
        var container = new AuctionContainer();
        var auction = new Auction(DateTime.Now, "Table", 6);
        container.AddAuction(auction);
        //act
        container.AddAuction(auction);
        //assert
        Assert.IsTrue(container.GetAuctions().Count==1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]

    public void AddEmptyValueAuctionTest()
    {
        //arrange
        var container = new AuctionContainer();
        var auction = new Auction(DateTime.Now, "", 6);
        //act
        container.AddAuction(auction);
        //assert
        Assert.IsTrue(container.GetAuctions().Count==0);
    }

    [TestMethod]
    public void RemoveAuctionTest()
    {
        //arrange
        var container = new AuctionContainer();
        var auction = new Auction(DateTime.Now, "Table", 5);
        container.AddAuction(auction);
        //act
        container.RemoveAuction(auction);
        //assert
       Assert.IsTrue(!container.GetAuctions().Contains(auction)); 
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RemoveNonContainedAuctionTest()
    {
        //arrange
        var container = new AuctionContainer();
        var auction = new Auction(DateTime.Now, "Table", 5);
        //act
        container.RemoveAuction(auction);
        //assert
        Assert.IsTrue(container.GetAuctions().Count==0);
    }
}