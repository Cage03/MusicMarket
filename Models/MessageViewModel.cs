using MusicMarketInterface.DTOs;
using MusicMarketLogic.Classes;

namespace MusicMarket.Models;

public class MessageViewModel
{
    public List<Message> Messages = new();

    public List<Person> Persons = new();

    public Person NewPerson { get; set; }
    
    public string newMessage { get; set; }
    
    public string CurrentUser { get; set; }
}