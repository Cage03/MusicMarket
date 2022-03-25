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
        var advertisement = new Advertisement(4, DateTime.Now, "Table");
        //act
        container.AddAdvertisement(advertisement);
        //assert
        Assert.IsTrue(container.GetAdvertisements().Contains(advertisement));
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddAlreadyContainedAdTest()
    {
        //arrange
        var container = new AdvertisementContainer();
        var advertisement = new Advertisement(4, DateTime.Now, "Table");
        container.AddAdvertisement(advertisement);
        //act
        container.AddAdvertisement(advertisement);
        //assert
        Assert.IsTrue(container.GetAdvertisements().Count==1);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddEmptyValueAdvertTest()
    {
        //arrange
        var container = new AdvertisementContainer();
        var advertisement = new Advertisement(4, DateTime.Now, "");
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
        var advertisement = new Advertisement(4, DateTime.Now, "Table");
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
        var advertisement = new Advertisement(4, DateTime.Now, "Table");
        //act
        container.RemoveAdvertisement(advertisement);
        //assert
        Assert.IsTrue(container.GetAdvertisements().Count==0);
    }
}