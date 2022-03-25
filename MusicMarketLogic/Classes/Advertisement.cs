namespace MusicMarketLogic.Classes;

public class Advertisement
{
    public int PersonId { get; private set; } //here for testing purposes in the future
    
    public DateTime Date { get; private set; }
    
    public string Name { get; private set; }
    
    public Advertisement(int personId, DateTime date, string name)
    {
        PersonId = personId;
        Date = date;
        Name = name;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}