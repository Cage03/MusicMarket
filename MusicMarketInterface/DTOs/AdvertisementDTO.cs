namespace MusicMarketInterface.DTOs;

public class AdvertisementDto
{
    public string Name { get; set; } //TODO test private setter
    public string Description { get; set; }
    public double Price { get; set; }
    public string Status { get; set; }
    
    public int Id { get; set; }
    public int PersonId { get; set; }
}