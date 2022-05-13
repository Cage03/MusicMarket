using MusicMarketInterface.DTOs;

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

    public Message(MessageDto messageDto)
    {
        Content = messageDto.Content;
        SenderId = messageDto.SenderId;
        ReceiverId = messageDto.ReceiverId;
    }

    public void SetContent(string content)
    {
        Content = content;
    }

    public MessageDto toDto()
    {
        MessageDto dto = new()
        {
            Content = Content,
            ReceiverId = ReceiverId,
            SenderId = SenderId
        };
        return dto;
    }
}