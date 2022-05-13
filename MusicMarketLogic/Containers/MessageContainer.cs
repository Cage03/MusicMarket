using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;
using MusicMarketLogic.Classes;

namespace MusicMarketLogic.Containers;

public class MessageContainer
{
    private List<Message> _messages;

    private IMessage Message;

    public MessageContainer(IMessage iMessage)
    {
        Message = iMessage;
        _messages = new List<Message>();
    }

    public IReadOnlyCollection<Message> GetMessages()
    {
        return _messages;
    }

    public void AddMessage(Message message)
    {
        if (_messages.Contains(message))
        {
            throw new ArgumentException("Cannot add duplicate message");
        }

        if (string.IsNullOrWhiteSpace(message.Content))
        {
            throw new ArgumentException("Not all information is given");
        }
        _messages.Add(message);
        Message.AddMessage(message.toDto());
    }

    public void RemoveMessage(Message message)
    {
        if (!_messages.Contains(message))
        {
            throw new ArgumentException("Cannot remove non-contained message");
        }
        _messages.Remove(message);
        Message.RemoveMessage(message.toDto());
    }

    public List<Message> GetConversation(Message message)
    {
        var messageDtos = Message.GetConversation(message.toDto());
        List<Message> messages = new();
        foreach (var messageDto in messageDtos)
        {
            messages.Add(new Message(messageDto));
        }

        return messages;
    }
}