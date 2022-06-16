namespace MusicMarket.Models;

public class MarketAdModel
{
    //Name, price, Status description
    //TODO add bidding function
    public int Id { get; set; }
    
    public int ReceiverId { get; set; }
    
    public int SenderId { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    
    public double CurrentPrice { get; set; }
    public string Status { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public DateTime Date { get; set; }
}