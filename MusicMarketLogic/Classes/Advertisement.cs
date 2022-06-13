using System.Data.Common;
using MusicMarketInterface.DTOs;

namespace MusicMarketLogic.Classes;

public class Advertisement
{
    public string Name { get; set; } //TODO test private setter / init ?
    public string Description { get; set; }
    public double Price { get; set; }
    public string Status { get; set; }
    
    public int Id { get; set; }

    public Advertisement(string name, string description, double price, string status, int id)
    {
        Name = name;
        Description = description;
        Price = price;
        Status = status;
        Id = id;
    }

    public Advertisement(AdvertisementDto advertisementDto)
    {
        Name = advertisementDto.Name;
        Description = advertisementDto.Description;
        Price = advertisementDto.Price;
        Status = advertisementDto.Status;
        Id = advertisementDto.Id;
    }

    public Advertisement()
    {
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public AdvertisementDto ToDto()
    {
        AdvertisementDto dto = new()
        {
            Name = Name,
            Description = Description,
            Price = Price,
            Status = Status,
            Id = Id
        };

        return dto;
    }
}