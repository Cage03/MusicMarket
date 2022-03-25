using MusicMarketInterface.DTOs;

namespace MusicMarketInterface.Interfaces;

public interface IAuction
{
    int AddAuction(AuctionDto auctionDto);

    int RemoveAuction(AuctionDto auctionDto);
}