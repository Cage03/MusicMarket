using System.ComponentModel;
using Humanizer;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Helpers;

namespace MusicMarket.Models;

public class MarketViewModel
{
    public List<Advertisement> Advertisements = new();

    public List<Auction> Auctions = new();

    public List<Person> Persons = new();
    public string username { get; set; }
    // public List<MarketAdModel> AdModels = new();

    // public void GetAdModels()
    // {
    //     AdModels.Clear();
    //     var adverts = Toolbox.BuildAdContainer().GetAllAds();
    //     foreach (var advert in adverts)
    //     {
    //         AdModels.Add(new MarketAdModel()
    //         {
    //             Name = advert.Name,
    //             Description = advert.Description,
    //             Price = advert.Price,
    //             Status = advert.Status
    //         });
    //     }
    // }
}