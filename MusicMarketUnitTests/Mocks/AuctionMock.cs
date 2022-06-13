using System;
using System.Collections.Generic;
using MusicMarketDAL;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketUnitTests.Mocks;

public class AuctionMock : IAuction
{

    public List<AuctionDto> AuctionDtos = new();
    
    public AuctionMock()
    {
        AuctionDtos.Add(new AuctionDto()
        {
            CurrentPrice = 1,
            Date = new DateTime(2022,5,1),
            Name = "TestName1",
            PersonId = 1
        });
        AuctionDtos.Add(new AuctionDto()
        {
            CurrentPrice = 2,
            Date = new DateTime(2022,5,2),
            Name = "TestName2",
            PersonId = 2
        });
        AuctionDtos.Add(new AuctionDto()
        {
            CurrentPrice = 3,
            Date = new DateTime(2022,5,3),
            Name = "TestName3",
            PersonId = 3
        });
    }

    public int AddAuction(AuctionDto auctionDto)
    {
        AuctionDtos.Add(auctionDto);
        return 1; //todo all int returns to void?
    }

    public int RemoveAuction(AuctionDto auctionDto)
    {
        AuctionDtos.Remove(auctionDto);
        return 1;
    }

    public List<AuctionDto> GetAllAuctions()
    {
        return AuctionDtos;
    }

    public int UpdateCurrentPrice(AuctionDto auctionDto)
    {
        GetAllAuctions();
        foreach (var dto in AuctionDtos)
        {
            if (dto.PersonId == auctionDto.PersonId)
            {
                AuctionDtos.Remove(dto);
                AuctionDtos.Add(auctionDto);
                return 1;
            }
        }

        return 0;
    }
}