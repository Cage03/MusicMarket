using MusicMarketInterface.Interfaces;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Containers;
using MusicMarketLogic.Interfaces;
using MusicMarketDAL;
namespace MusicMarketLogic.Helpers;

public static class Toolbox //currently not used, later used as a factory of sorts
{
    // public static IAdvertisement IAdvertisement;
    public static AdvertisementContainer AdvertisementContainer = new AdvertisementContainer(new AdvertisementDal());
    public static AuctionContainer AuctionContainer = new();
    public static MessageContainer MessageContainer = new();
    public static PersonContainer PersonContainer = new();
}