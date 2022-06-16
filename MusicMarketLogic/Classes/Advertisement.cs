using System.Data.Common;
using MusicMarketInterface.DTOs;

namespace MusicMarketLogic.Classes;

public class Advertisement
{
    public string Name { get; set; } //TODO test private setter / init ?
    public string Description { get; set; }
    public double Price { get; set; }
    public string Status { get; set; }

    public int PersonId { get; set; }
    
    public int Id { get; set; }

    public Advertisement(string name, string description, double price, string status, int id, int personId)
    {
        Name = name;
        Description = description;
        Price = price;
        Status = status;
        Id = id;
        PersonId = personId;
    }

    public Advertisement()
    {
        
    }

    public Advertisement(AdvertisementDto advertisementDto)
    {
        Name = advertisementDto.Name;
        Description = advertisementDto.Description;
        Price = advertisementDto.Price;
        Status = advertisementDto.Status;
        Id = advertisementDto.Id;
        PersonId = advertisementDto.PersonId;
    }

    public AdvertisementDto ToDto()
    {
        AdvertisementDto dto = new()
        {
            Name = Name,
            Description = Description,
            Price = Price,
            Status = Status,
            PersonId = PersonId,
            Id = Id
        };

        return dto;
    }
}