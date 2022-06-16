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

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(PersonModel personModel)
    {
        var thisPerson = new Person(new PersonDto()
        {
            Password = personModel.Password,
            Username = personModel.Username
        });
        var person = ContainerFactory.PersonContainer.GetPersonByName(thisPerson.Username);
        if (person.Password == thisPerson.Password &&
            person.Username == thisPerson.Username)
        {
            if (Request.Cookies["UserData"] != null)
            {
                Response.Cookies.Delete("UserData");
            }

            Response.Cookies.Append("UserData", thisPerson.Username);
            return RedirectToAction("Market", "Market");
        }

        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(PersonModel personModel)
    {
        ContainerFactory.PersonContainer.AddPerson(new Person(new PersonDto()
        {
            Email = personModel.Email,
            Password = personModel.Password,
            Username = personModel.Username
        }));

        return RedirectToAction("Login", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}