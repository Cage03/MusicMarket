using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Containers;
using MusicMarketUnitTests.Mocks;

namespace MusicMarketUnitTests.ContainerTests;

[TestClass]
public class MessageContainerTest
{
    [TestMethod]
    public void ConstructorTest()
    {
        //arrange
        MessageMock dal = new();
        //act
        var container = new MessageContainer(dal);
        //assert
        Assert.IsNotNull(container);
    }
    [TestMethod]
    public void AddMessageTest()
    {
        //arrange
        MessageMock dal = new();
        var container = new MessageContainer(dal);
        var message = new Message("I would like to make an offer.", 7, 6);
        //act
        container.AddMessage(message);
        //assert
        Assert.IsTrue(container.GetMessages().Contains(message));
        Assert.AreEqual(dal.MessageDtos[^1].Content, message.Content);
        Assert.AreEqual(dal.MessageDtos[^1].ReceiverId, message.ReceiverId);
        Assert.AreEqual(dal.MessageDtos[^1].SenderId, message.SenderId);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddAlreadyContainedMessage()
    {
        //arrange
        MessageMock dal = new();
        var container = new MessageContainer(dal);
        var message = new Message("I would like to make an offer.", 3, 6);
        container.AddMessage(message);
        //act
        container.AddMessage(message);
        //assert
        //no assert needed
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]

    public void AddEmptyValueMessageTest()
    {
        //arrange
        MessageMock dal = new();
        var container = new MessageContainer(dal);
        var message = new Message("", 6, 2);
        //act
        container.AddMessage(message);
        //assert
        Assert.IsFalse(container.GetMessages().Contains(message));
        Assert.IsFalse(dal.MessageDtos.Contains(message.toDto()));
    }
    
    [TestMethod]
    
    public void RemoveMessageTest()
    {
        //arrange
        MessageMock dal = new();
        var container = new MessageContainer(dal);
        var message = new Message("I would like to make an offer", 2, 5);
        container.AddMessage(message);
        //act
        container.RemoveMessage(message);
        //assert
        Assert.IsFalse(container.GetMessages().Contains(message));
        Assert.IsFalse(dal.MessageDtos.Contains(message.toDto()));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]

    public void RemoveNonContainedMessage()
    {
        //arrange
        MessageMock dal = new();
        var container = new MessageContainer(dal);
        var message = new Message("I would like to make an offer", 19, 7);
        //act
        container.RemoveMessage(message);
        //assert
        //no assert needed 
    }
    [TestMethod]
    public void GetConversationTest() //For some reason messages in messageList cannot be compared to the messages created here, hence the many asserts.
    {
        //arrange
        MessageMock dal = new();
        var container = new MessageContainer(dal);
        var message1 = new Message("I would like to make an offer", 19, 7);
        var message2 = new Message("How much are you willing to pay?", 19, 7);
        container.AddMessage(message1);
        container.AddMessage(message2);
        //act
        var messageList = container.GetConversation(message1.SenderId, message1.ReceiverId);
        //assert
        Assert.AreEqual(messageList[0].Content, message1.Content);
        Assert.AreEqual(messageList[0].ReceiverId, message1.ReceiverId);
        Assert.AreEqual(messageList[0].SenderId, message1.SenderId);
        Assert.AreEqual(messageList[1].Content, message2.Content);
        Assert.AreEqual(messageList[1].ReceiverId, message2.ReceiverId);
        Assert.AreEqual(messageList[1].SenderId, message2.SenderId);
        
        Assert.AreEqual(dal.MessageDtos[3].Content, message1.Content);
        Assert.AreEqual(dal.MessageDtos[3].SenderId, message1.SenderId);
        Assert.AreEqual(dal.MessageDtos[3].ReceiverId, message1.ReceiverId);
        Assert.AreEqual(dal.MessageDtos[4].Content, message2.Content);
        Assert.AreEqual(dal.MessageDtos[4].SenderId, message2.SenderId);
        Assert.AreEqual(dal.MessageDtos[4].ReceiverId, message2.ReceiverId);
    }
}