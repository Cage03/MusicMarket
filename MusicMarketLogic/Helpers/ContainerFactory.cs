using MusicMarketInterface.Interfaces;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Containers;
using MusicMarketLogic.Interfaces;
using MusicMarketDAL;
namespace MusicMarketLogic.Helpers;

public static class ContainerFactory //currently not used, later used as a factory of sorts
{
    // public static IAdvertisement IAdvertisement;
    public static AdvertisementContainer AdvertisementContainer = new(new AdvertisementDal());
    public static AuctionContainer AuctionContainer = new(new AuctionDal());
    public static MessageContainer MessageContainer = new(new MessageDal());
    public static PersonContainer PersonContainer = new();
}