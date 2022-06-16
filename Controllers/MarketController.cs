using Microsoft.AspNetCore.Mvc;
using MusicMarket.Models;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Helpers;
using MusicMarketLogic.Interfaces;

namespace MusicMarket.Controllers;

public class MarketController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IAdvertisementContainer IAdvertisementContainer;

    public MarketController(ILogger<HomeController> logger, IAdvertisementContainer iAdvertisementContainer)
    {
        _logger = logger;
        IAdvertisementContainer = iAdvertisementContainer;
    }
    [HttpGet]
    public IActionResult Market()
    {
        if (Request.Cookies["UserData"] == null)
        {
            return RedirectToAction("Login", "Home");
        }
        var marketViewModel = new MarketViewModel();
        marketViewModel.Advertisements = ContainerFactory.AdvertisementContainer.GetAllAds();
        marketViewModel.Auctions = ContainerFactory.AuctionContainer.GetAllAuctions();
        marketViewModel.Persons = ContainerFactory.PersonContainer.GetAllPersons();
        if (Request.Cookies["UserData"] != null)
        {
            marketViewModel.username = Request.Cookies["UserData"];
        }

        //reverse lists so that the newest items are at the top of the page
        marketViewModel.Advertisements.Reverse();
        marketViewModel.Auctions.Reverse();
        return View(marketViewModel);
    }

    [HttpPost]
    public IActionResult Market(Advertisement advertisement)
    {
        ContainerFactory.AdvertisementContainer.AddAdvertisement(advertisement);
        return View();
    }
}