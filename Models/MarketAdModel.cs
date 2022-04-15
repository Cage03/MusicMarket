namespace MusicMarket.Models;

public class MarketAdModel
{
    //Name, price, Status description
    //TODO add bidding function
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public string Status { get; set; } = null!;
    public string Description { get; set; } = null!;
}