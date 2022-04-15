using MusicMarketInterface.Interfaces;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Containers;
using MusicMarketLogic.Interfaces;

namespace MusicMarketLogic.Helpers;

public static class Toolbox //currently not used, later used as a factory of sorts
{
    // public static IAdvertisement IAdvertisement;
    public static AdvertisementContainer AdvertisementContainer = new();
    public static AuctionContainer AuctionContainer = new();
    public static MessageContainer MessageContainer = new();
    public static PersonContainer PersonContainer = new();
    
    // public static IAdvertisementContainer BuildAdContainer()
    // {
    //     return new AdvertisementContainer(IAdvertisement);
    // }
}