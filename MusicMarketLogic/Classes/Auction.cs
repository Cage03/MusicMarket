namespace MusicMarketLogic.Classes;

public class Auction
{
    public DateTime Date { get; private set; }
    public string Name { get; private set; }
    public int PersonId { get; private set; }


    public Auction(DateTime date, string name, int personId)
    {
        Date = date;
        Name = name;
        PersonId = personId;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}