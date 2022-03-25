namespace MusicMarketLogic.Classes;

public class Person
{
    public string Username { get; private set; }
    public string Email { get; private set; }

    public Person(string username, string email)
    {
        Username = username;
        Email = email;
    }

    public void SetUsername(string username)
    {
        Username = username;
    }

    public void SetEmail(string email)
    {
        Email = email;
    }
}