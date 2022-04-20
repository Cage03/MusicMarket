using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MusicMarket.Models;
using MusicMarketInterface.DTOs;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Helpers;
using MusicMarketLogic.Interfaces;

namespace MusicMarket.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IAdvertisementContainer IAdvertisementContainer;

    public HomeController(ILogger<HomeController> logger, IAdvertisementContainer iAdvertisementContainer)
    {
        _logger = logger;
        IAdvertisementContainer = iAdvertisementContainer;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Market()
    {
        var marketViewModel = new MarketViewModel();
        marketViewModel.Advertisements = Toolbox.AdvertisementContainer.GetAllAds();
        return View(marketViewModel);
    }

    [HttpPost]
    public IActionResult Market(Advertisement advertisement)
    {
        Toolbox.AdvertisementContainer.AddAdvertisement(advertisement);
        return View();
    }
    public IActionResult AddAdvert(MarketAdModel model)
    {
        Toolbox.AdvertisementContainer.AddAdvertisement(new Advertisement(new AdvertisementDto())
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Status =model.Status
        });
        return RedirectToAction("AddAdvert", "Home");
    }
    
    public IActionResult Messages()
    {
        return View();
    }

    public IActionResult AddAdvertisement()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddAdvertisement(Advertisement advertisement)
    {
       Toolbox.AdvertisementContainer.AddAdvertisement(advertisement);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}