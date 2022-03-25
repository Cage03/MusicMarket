using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketLogic.Classes;

namespace MusicMarketUnitTests.ClassTests;

[TestClass]
public class MessageTest
{
    [TestMethod]
    public void TestConstructMessage()
    {
        //arrange
        var content = "I'd like to make an offer";
        DateTime date = new DateTime(2022, 12, 25);
        var personId = 4;
        //act
        var message = new Message(content, date, personId);
        //assert
        Assert.IsTrue(message.Content==content && message.Date==date && message.PersonId==personId);
    }
}