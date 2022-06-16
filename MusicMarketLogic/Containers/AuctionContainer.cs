using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;
using MusicMarketLogic.Classes;

namespace MusicMarketLogic.Containers;

public class AuctionContainer
{
    private List<Auction> _auctions;
    private IAuction Auction;

    public AuctionContainer(IAuction iAuction)
    {
        Auction = iAuction;
        _auctions = new List<Auction>();
    }

    public IReadOnlyCollection<Auction> GetAuctions()
    {
        return _auctions;
    }

    public void AddAuction(Auction auction)
    {
        if (_auctions.Contains(auction))
        {
            throw new ArgumentException("Cannot add duplicate auction");
        }

        if (string.IsNullOrWhiteSpace(auction.Name))
        {
            throw new ArgumentException("Not all information is given");
        }

        _auctions.Add(auction);
        Auction.AddAuction(auction.ToDto());
    }

    public void RemoveAuction(Auction auction)
    {
        GetAllAuctions();
        foreach (var _auction in _auctions)
        {
            if (_auction.Name == auction.Name)
            {
                _auctions.Remove(_auction);
                Auction.RemoveAuction(_auction.ToDto());
                return;
            }
        }

        throw new ArgumentException("Cannot remove non-container auction");
    }

    public List<Auction> GetAllAuctions()
    {
        var auctionDtos = Auction.GetAllAuctions();
        List<Auction> auctions = new();
        foreach (var auctionDto in auctionDtos)
        {
            auctions.Add(new Auction(auctionDto));
            _auctions.Add(new Auction(auctionDto));
        }

        return auctions;
    }

    public void UpdateCurrentPrice(Auction auction)
    {
        var allAuctions = GetAllAuctions();
        var isContained = false;
        foreach (var _auction in allAuctions)
        {
            if (_auction.PersonId == auction.PersonId)
            {
                isContained = true;
            }
        }

        if (!isContained)
        {
            throw new ArgumentException("Cannot update non-contained auction");
        }

        Auction.UpdateCurrentPrice(auction.ToDto());
    }
}