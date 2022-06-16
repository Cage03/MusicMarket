using Microsoft.AspNetCore.Mvc;
using MusicMarket.Models;
using MusicMarketInterface.DTOs;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Helpers;
using MusicMarketLogic.Interfaces;

namespace MusicMarket.Controllers;

public class AuctionController:Controller
{
    private readonly ILogger<HomeController> _logger;
    private IAdvertisementContainer IAdvertisementContainer;

    public AuctionController(ILogger<HomeController> logger, IAdvertisementContainer iAdvertisementContainer)
    {
        _logger = logger;
        IAdvertisementContainer = iAdvertisementContainer;
    }

    [HttpGet]
    public IActionResult AuctionModal(string name, double currentPrice, string description, int id)
    {
        if (Request.Cookies["UserData"] == null)
        {
            return RedirectToAction("Login", "Home");
        }
        var marketAdModel = new MarketAdModel()
        {
            Id = id,
            Name = name,
            CurrentPrice = currentPrice,
            Description = description
        };
        return View(marketAdModel);
    }

    [HttpPost]
    public IActionResult AuctionModal(MarketAdModel marketAdModel)
    {
        foreach (var auction in ContainerFactory.AuctionContainer.GetAllAuctions())
        {
            if (auction.PersonId == marketAdModel.Id)
            {
                if (auction.CurrentPrice > marketAdModel.CurrentPrice)
                {
                    return View();
                }
            }
        }

        ContainerFactory.AuctionContainer.UpdateCurrentPrice(new Auction(new AuctionDto()
        {
            CurrentPrice = marketAdModel.CurrentPrice,
            PersonId = marketAdModel.Id,
            Date = marketAdModel.Date,
            Name = marketAdModel.Name
        }));

        return RedirectToAction("Market", "Market");
    }

    [HttpGet]
    public IActionResult AddAuction()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddAuction(MarketAdModel marketAdModel)
    {
        var person = ContainerFactory.PersonContainer.GetPersonByName(Request.Cookies["UserData"]);
        foreach (var auction in ContainerFactory.AuctionContainer.GetAllAuctions())
        {
            if (auction.PersonId == person.Id)
            {
                throw new ArgumentException("Users can only have one auction active at a time");
            }
        }
        ContainerFactory.AuctionContainer.AddAuction(new Auction(new AuctionDto()
        {
            CurrentPrice = marketAdModel.CurrentPrice,
            Name = marketAdModel.Name,
            PersonId = person.Id
        }));

        return RedirectToAction("Market", "Market");
    }

    [HttpGet]
    public IActionResult RemoveAuction(string name)
    {
        if (Request.Cookies["UserData"] == null)
        {
            return RedirectToAction("Login", "Home");
        }
        ContainerFactory.AuctionContainer.RemoveAuction(new Auction(new AuctionDto()
        {
            Name = name
        }));
        return RedirectToAction("Market", "Market");
    }
}