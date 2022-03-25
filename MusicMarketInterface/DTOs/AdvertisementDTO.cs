namespace MusicMarketInterface.DTOs;

public class AdvertisementDto
{
    public int PersonId { get; set; } //todo Test private setter?
    
    public DateTime Date { get; set; }
    
    public string Name { get; set; }
}