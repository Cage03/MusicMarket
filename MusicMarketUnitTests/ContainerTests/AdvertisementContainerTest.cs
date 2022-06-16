using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Containers;
using MusicMarketUnitTests.Mocks;
using Newtonsoft.Json.Linq;

namespace MusicMarketUnitTests.ContainerTests;

[TestClass]
public class AdvertisementContainerTest
{
    [TestMethod]
    public void ConstructorTest()
    {
        //arrange
        AdvertisementMock dal = new();
        //act
        var container = new AdvertisementContainer(dal);
        //assert
        Assert.IsNotNull(container, "container = null");
    }

    [TestMethod]
    public void AddAdvertisementTest()
    {
        //arrange
        var dal = new AdvertisementMock();
        var container = new AdvertisementContainer(dal);
        var advertisement = new Advertisement("TestName", "TestDescription", 19, "Active", 109, 0);
        //act
        container.AddAdvertisement(advertisement);
        
        //assert
        Assert.IsTrue(container.GetAdvertisements().Contains(advertisement));
        Assert.AreEqual(advertisement.Name, dal.AdvertisementDtos[^1].Name,"advertisement was not added correctly");
        Assert.AreEqual(advertisement.Description, dal.AdvertisementDtos[^1].Description,"advertisement was not added correctly");
        Assert.AreEqual(advertisement.Price, dal.AdvertisementDtos[^1].Price,"advertisement was not added correctly");
        Assert.AreEqual(advertisement.Status, dal.AdvertisementDtos[^1].Status,"advertisement was not added correctly");
        Assert.AreEqual(advertisement.Id, dal.AdvertisementDtos[^1].Id,"advertisement was not added correctly");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddAlreadyContainedAdTest()
    {
        //arrange
        AdvertisementMock dal = new();
        var container = new AdvertisementContainer(dal);
        var advertisement = new Advertisement("testName", "testDescription", 5.02, "true", 81, 0);
        container.AddAdvertisement(advertisement);
        //act
        container.AddAdvertisement(advertisement);
        //assert
        //no assert needed
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))] 
    public void AddEmptyValueAdvertTest()
    {
        //arrange
        AdvertisementMock dal = new();
        var container = new AdvertisementContainer(dal);
        var advertisement = new Advertisement("", "testDescription", 5.01, "true", 10, 0);
        //act
        container.AddAdvertisement(advertisement);
        //assert
        Assert.IsFalse(container.GetAdvertisements().Contains(advertisement));
        Assert.IsFalse(dal.AdvertisementDtos.Contains(advertisement.ToDto()));
    }

    [TestMethod]
    public void RemoveAdvertisementTest()
    {
        //arrange
        var dal = new AdvertisementMock();
        var container = new AdvertisementContainer(dal);
        var advertisement = new Advertisement("testName", "testDescription", 5, "true", 19, 0);
        container.AddAdvertisement(advertisement);
        //act
        container.RemoveAdvertisement(advertisement);
        //assert
        Assert.IsFalse(dal.AdvertisementDtos.Contains(advertisement.ToDto()));
        Assert.IsFalse(container.GetAdvertisements().Contains(advertisement));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RemoveNonContainedAdvertisementTest()
    {
        //arrange
        AdvertisementMock dal = new();
        var container = new AdvertisementContainer(dal);
        var advertisement = new Advertisement("testName", "testDescription", 5.01, "true", 99, 0);
        //act
        container.RemoveAdvertisement(advertisement);
        //assert
        //no assert needed
    }

    [TestMethod]

    public void GetAllTest()
    {
        //arrange
        var dal = new AdvertisementMock();
        var container = new AdvertisementContainer(dal);
        //act
        var advertList = container.GetAllAds();
        //assert
        Assert.IsTrue(advertList.Count >= 3);
    }
}