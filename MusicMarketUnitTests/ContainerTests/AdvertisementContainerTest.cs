using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Containers;

namespace MusicMarketUnitTests.ContainerTests;

[TestClass]
public class AdvertisementContainerTest
{
    [TestMethod]
    public void AddAdvertisementTest() 
    {
        //arrange
        var container = new AdvertisementContainer();
        var advertisement = new Advertisement("testName", "testDescription", 5.01,"true");
        //act
        container.AddAdvertisement(advertisement);
        //assert
        Assert.IsTrue(container.GetAdvertisements().Contains(advertisement));
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))] //TODO test breaks because of testing :)
    public void AddAlreadyContainedAdTest()
    {
        //arrange
        var container = new AdvertisementContainer();
        var advertisement = new Advertisement("testName", "testDescription", 5.02,"true");
        container.AddAdvertisement(advertisement);
        //act
        container.AddAdvertisement(advertisement);
        //assert
        Assert.IsTrue(container.GetAdvertisements().Count==1);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))] //TODO test breaks because of testing :)
    public void AddEmptyValueAdvertTest()
    {
        //arrange
        var container = new AdvertisementContainer();
        var advertisement = new Advertisement("", "testDescription", 5.01,"true");
        //act
        container.AddAdvertisement(advertisement);
        //assert
        Assert.IsTrue(container.GetAdvertisements().Count==0);
    }
    [TestMethod]
    public void RemoveAdvertisementTest()
    {
        //arrange
        var container = new AdvertisementContainer();
        var advertisement = new Advertisement("testName", "testDescription", 5.01,"true");
        container.AddAdvertisement(advertisement);
        //act
        container.RemoveAdvertisement(advertisement);
        //assert
        Assert.IsTrue(!container.GetAdvertisements().Contains(advertisement));
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RemoveNonContainedAdvertisementTest()
    {
        //arrange
        var container = new AdvertisementContainer();
        var advertisement = new Advertisement("testName", "testDescription", 5.01,"true");
        //act
        container.RemoveAdvertisement(advertisement);
        //assert
        Assert.IsTrue(container.GetAdvertisements().Count==0);
    }
}