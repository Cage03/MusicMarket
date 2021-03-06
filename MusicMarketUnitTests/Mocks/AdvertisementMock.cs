using System.Collections.Generic;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketUnitTests.Mocks;

public class AdvertisementMock : IAdvertisement
{
    public List<AdvertisementDto> AdvertisementDtos = new();

    public AdvertisementMock()
    {
        AdvertisementDtos.Add(new AdvertisementDto()
        {
            Description = "TestDescription1",
            Name = "TestName1",
            Price = 1,
            Status = "Active",
            PersonId = 0,
            Id = 0
        });
        AdvertisementDtos.Add(new AdvertisementDto()
        {
            Description = "TestDescription2",
            Name = "TestName2",
            Price = 2,
            Status = "Active",
            PersonId = 0,
            Id = 1
        });
        AdvertisementDtos.Add(new AdvertisementDto()
        {
            Description = "TestDescription3",
            Name = "TestName3",
            Price = 3,
            Status = "Active",
            PersonId = 0,
            Id = 2
        });
    }

    public List<AdvertisementDto> GetAllAds()
    {
        return AdvertisementDtos;
    }

    public int AddAdvertisement(AdvertisementDto advertisementDto)
    {
        AdvertisementDtos.Add(advertisementDto);
        return advertisementDto.Id;
    }

    public int RemoveAdvertisement(AdvertisementDto advertisementDto)
    {
        foreach (var dto in AdvertisementDtos)
        {
            if (dto.Name == advertisementDto.Name && dto.Description == advertisementDto.Description && //todo ask for help 
                dto.Status == advertisementDto.Status)
            {
                AdvertisementDtos.Remove(dto);
                break;
            }
        }
        return 1; //todo void?
    }
}