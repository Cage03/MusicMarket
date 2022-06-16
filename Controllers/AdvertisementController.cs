using Microsoft.AspNetCore.Mvc;
using MusicMarket.Models;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Helpers;
using MusicMarketLogic.Interfaces;

namespace MusicMarket.Controllers;

public class AdvertisementController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IAdvertisementContainer IAdvertisementContainer;

    public AdvertisementController(ILogger<HomeController> logger, IAdvertisementContainer iAdvertisementContainer)
    {
        _logger = logger;
        IAdvertisementContainer = iAdvertisementContainer;
    }

    [HttpGet]
    public IActionResult AddAdvertisement()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddAdvertisement(MarketAdModel marketAdModel)
    {
        var person = ContainerFactory.PersonContainer.GetPersonByName(Request.Cookies["UserData"]);
        ContainerFactory.AdvertisementContainer.AddAdvertisement(new Advertisement()
        {
            Description = marketAdModel.Description,
            Name = marketAdModel.Name,
            Price = marketAdModel.Price,
            Status = marketAdModel.Status,
            PersonId = person.Id
        });
        return RedirectToAction("Market", "Market");
    }

    [HttpGet]
    public IActionResult RemoveAdvertisement(int id)
    {
        if (Request.Cookies["UserData"] == null)
        {
            return RedirectToAction("Login", "Home");
        }

        ContainerFactory.AdvertisementContainer.RemoveAdvertisement(new Advertisement()
        {
            Id = id
        });
        return RedirectToAction("Market", "Market");
    }

    [HttpGet]
    public IActionResult AdvertModal(string name, double price, string description, int id, int receiverId,
        int senderId)
    {
        if (Request.Cookies["UserData"] == null)
        {
            return RedirectToAction("Login", "Home");
        }

        var marketAdModel = new MarketAdModel()
        {
            Id = id,
            Name = name,
            Price = price,
            Description = description,
            ReceiverId = receiverId,
            SenderId = senderId
        };
        return View(marketAdModel);
    }
}