using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Containers;

namespace MusicMarketUnitTests.ContainerTests;

[TestClass]
public class MessageContainerTest
{
    [TestMethod]
    public void AddMessageTest()
    {
        //arrange
        var container = new MessageContainer();
        var message = new Message("I would like to make an offer.", DateTime.Now, 6);
        //act
        container.AddMessage(message);
        //assert
        Assert.IsTrue(container.GetMessages().Contains(message));
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddAlreadyContainedMessage()
    {
        //arrange
        var container = new MessageContainer();
        var message = new Message("I would like to make an offer.", DateTime.Now, 6);
        container.AddMessage(message);
        //act
        container.AddMessage(message);
        //assert
        Assert.IsTrue(container.GetMessages().Count == 1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]

    public void AddEmptyValueMessageTest()
    {
        //arrange
        var container = new MessageContainer();
        var message = new Message("", DateTime.Now, 2);
        //act
        container.AddMessage(message);
        //assert
        Assert.IsTrue(container.GetMessages().Count==0);
    }
    
    [TestMethod]
    
    public void RemoveMessageTest()
    {
        //arrange
        var container = new MessageContainer();
        var message = new Message("I would like to make an offer", DateTime.Now, 5);
        container.AddMessage(message);
        //act
        container.RemoveMessage(message);
        //assert
        Assert.IsTrue(!container.GetMessages().Contains(message));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]

    public void RemoveNonContainedMessage()
    {
        //arrange
        var container = new MessageContainer();
        var message = new Message("I would like to make an offer", DateTime.Now, 7);
        //act
        container.RemoveMessage(message);
        //assert
        Assert.IsTrue(container.GetMessages().Count==0);
    }
}