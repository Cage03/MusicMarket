namespace MusicMarketInterface.DTOs;

public class AuctionDto
{
    public DateTime Date { get; set; }
    public string Name { get; set; }
    
    public int PersonId { get; set; }
    
    public double CurrentPrice { get; set; }
}