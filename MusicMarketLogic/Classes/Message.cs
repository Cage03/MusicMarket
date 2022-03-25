namespace MusicMarketLogic.Classes;

public class Message
{
    public string Content { get; private set; }
    public DateTime Date { get; private set; }
    public int PersonId { get; private set; }

    public Message(string content, DateTime date, int personId)
    {
        Content = content;
        Date = date;
        PersonId = personId;
    }

    public void SetContent(string content)
    {
        Content = content;
    }
}