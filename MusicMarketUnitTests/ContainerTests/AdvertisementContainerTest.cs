using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Containers;
using MusicMarketUnitTests.Stubs;

namespace MusicMarketUnitTests.ContainerTests;

[TestClass]
public class AdvertisementContainerTest
{
    [TestMethod]
    public void ConstructorTest()
    {
        //arrange
        AdvertisementScrub dal = new();
        //act
        var container = new AdvertisementContainer(dal);
        //assert
        Assert.IsNotNull(container, "container = null");
    }

    [TestMethod]
    public void AddAdvertisementTest()
    {
        //arrange
        var dal = new AdvertisementScrub();
        var container = new AdvertisementContainer(dal);
        var advertisement = new Advertisement("TestName", "TestDescription", 19, "Active");
        //act
        container.AddAdvertisement(advertisement);
        //assert
        // Assert.IsTrue(dal.AdvertisementDtos.Contains(advertisement.ToDto()),
        //     "List of AdvertisementDtos does not contain advertisement"); //Reminder, < this for some reason doesn't work.
        Assert.AreEqual(dal.AdvertisementDtos[^1].Name, advertisement.Name);
        Assert.AreEqual(dal.AdvertisementDtos[^1].Description, advertisement.Description);
        Assert.AreEqual(dal.AdvertisementDtos[^1].Price, advertisement.Price);
        Assert.AreEqual(dal.AdvertisementDtos[^1].Status, advertisement.Status);
        Assert.IsTrue(container.GetAdvertisements().Contains(advertisement));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddAlreadyContainedAdTest()
    {
        //arrange
        AdvertisementScrub dal = new();
        var container = new AdvertisementContainer(dal);
        var advertisement = new Advertisement("testName", "testDescription", 5.02, "true");
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
        AdvertisementScrub dal = new();
        var container = new AdvertisementContainer(dal);
        var advertisement = new Advertisement("", "testDescription", 5.01, "true");
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
        var dal = new AdvertisementScrub();
        var container = new AdvertisementContainer(dal);
        var advertisement = new Advertisement("testName", "testDescription", 5, "true");
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
        AdvertisementScrub dal = new();
        var container = new AdvertisementContainer(dal);
        var advertisement = new Advertisement("testName", "testDescription", 5.01, "true");
        //act
        container.RemoveAdvertisement(advertisement);
        //assert
        //no assert needed
    }

    [TestMethod]

    public void GetAllTest()
    {
        //arrange
        var dal = new AdvertisementScrub();
        var container = new AdvertisementContainer(dal);
        //act
        var advertList = container.GetAllAds();
        //assert
        Assert.IsTrue(advertList.Count >= 3);
    }
}