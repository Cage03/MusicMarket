using MusicMarketInterface.DTOs;

namespace MusicMarketLogic.Classes;

public class Auction
{
    public DateTime Date { get; private set; }
    public string Name { get; private set; }
    public int PersonId { get; private set; }
    
    public double CurrentPrice { get; private set; }


    public Auction(DateTime date, string name, int personId, double currentPrice)
    {
        Date = date;
        Name = name;
        PersonId = personId;
        CurrentPrice = currentPrice;
    }

    public Auction(AuctionDto auctionDto)
    {
        Date = auctionDto.Date;
        Name = auctionDto.Name;
        PersonId = auctionDto.PersonId;
        CurrentPrice = auctionDto.CurrentPrice;
    }

    public Auction()
    {
        
    }
    

    public AuctionDto ToDto()
    {
        AuctionDto auctionDto = new();

        auctionDto.Date = Date;
        auctionDto.Name = Name;
        auctionDto.CurrentPrice = CurrentPrice;
        auctionDto.PersonId = PersonId;

        return auctionDto;
    }
}