using System.ComponentModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
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
        marketViewModel.Advertisements = ContainerFactory.AdvertisementContainer.GetAllAds();
        marketViewModel.Auctions = ContainerFactory.AuctionContainer.GetAllAuctions();
        
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
    
    [HttpPost]
    public IActionResult PostToModal(string name, double price, string description)
    {
        return RedirectToAction("AdvertModal", new MarketAdModel()
        {
            Name = name,
            Price = price,
            Description = description
        });
    }
    
    [HttpPost]
    public IActionResult AddAdvert(MarketAdModel model)
    {
        ContainerFactory.AdvertisementContainer.AddAdvertisement(new Advertisement()
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Status =model.Status
        });
        return RedirectToAction("Market", "Home");
    }
    
    public IActionResult Messages()
    {
        var messageViewModel = new MessageViewModel();

        messageViewModel.Messages = ContainerFactory.MessageContainer.GetAllConversations();
        return View(messageViewModel);
    }

    public IActionResult Conversation(int senderId, int receiverId)
    {
        var messageViewModel = new MessageViewModel();

        messageViewModel.Messages = ContainerFactory.MessageContainer.GetConversation(senderId, receiverId);
        return View();
    }

    public IActionResult AddAdvertisement()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddAdvertisement(MarketAdModel marketAdModel)
    {
       ContainerFactory.AdvertisementContainer.AddAdvertisement(new Advertisement()
       {
           Description = marketAdModel.Description,
           Name = marketAdModel.Name,
           Price = marketAdModel.Price,
           Status = marketAdModel.Status
       });
        return RedirectToAction("Market", "Home");
    }

    [HttpGet]
    public IActionResult RemoveAdvertisement(int id)
    {
        ContainerFactory.AdvertisementContainer.RemoveAdvertisement(new Advertisement()
        {
            Id = id
        });
        return RedirectToAction("Market", "Home");
    }
    [HttpGet]
    public IActionResult AdvertModal(string name, double price, string description, int id)
    {
        var marketAdModel = new MarketAdModel()
        {
            Id = id,
            Name = name,
            Price = price,
            Description = description
        };
        return View(marketAdModel);
    }

    [HttpGet]
    public IActionResult AuctionModal(string name, double currentPrice, string description, int id)
    {
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

        return RedirectToAction("Market", "Home");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}