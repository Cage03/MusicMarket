using MusicMarketLogic.Classes;

namespace MusicMarketLogic.Containers;

public class AuctionContainer
{
    private List<Auction> _auctions;

    public AuctionContainer()
    {
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
    }

    public void RemoveAuction(Auction auction)
    {
        if (!_auctions.Contains(auction))
        {
            throw new ArgumentException("Cannot remove non-contained auction");
        }
        _auctions.Remove(auction);
    } 
}