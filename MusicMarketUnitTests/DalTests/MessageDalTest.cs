using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketDAL;
using MusicMarketInterface.DTOs;
using MusicMarketLogic.Classes;

namespace MusicMarketUnitTests.DalTests;

[TestClass]
public class MessageDalTest
{
    [TestMethod]
    public void AddMessageTest()
    {
        //arrange
        var messageDal = new MessageDal();
        //act
        var rowsAffected = messageDal.AddMessage(new MessageDto()
        {
            Content = "TestContent",
            SenderId = 1
        });
        //assert
        Assert.AreEqual(1, rowsAffected);
    }

    [TestMethod]
    public void RemoveMessageTest()
    {
        //arrange
        var messageDal = new MessageDal();
        messageDal.AddMessage(new MessageDto()
        {
            Content = "Test",
            SenderId = 6
        });
        //act
        var rowsAffected = messageDal.RemoveMessage(new MessageDto()
        {
            Content = "Test"
        });
        //assert
        Assert.AreEqual(1, rowsAffected);
    }
}