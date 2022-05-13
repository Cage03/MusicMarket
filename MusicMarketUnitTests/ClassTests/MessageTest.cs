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
        var receiverId = 6;
        var senderId = 4;
        //act
        var message = new Message(content, senderId, receiverId);
        //assert
        Assert.IsTrue(message.Content==content && message.ReceiverId==receiverId && message.SenderId==senderId);
    }
}