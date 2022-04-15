namespace MusicMarketLogic.Classes;

public class Message
{
    public string Content { get; private set; }
    public int SenderId { get; private set; }
    
    public int ReceiverId { get; private set; }
    
    
    
    public Message(string content, int senderId, int receiverId)
    {
        Content = content;
        SenderId = senderId;
        ReceiverId = receiverId;
    }

    public void SetContent(string content)
    {
        Content = content;
    }
}