using MusicMarketLogic.Classes;

namespace MusicMarketLogic.Containers;

public class MessageContainer
{
    private List<Message> _messages;

    public MessageContainer()
    {
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
    }

    public void RemoveMessage(Message message)
    {
        if (!_messages.Contains(message))
        {
            throw new ArgumentException("Cannot remove non-contained message");
        }
        _messages.Remove(message);
    }
}