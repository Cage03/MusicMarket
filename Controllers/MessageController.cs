using Microsoft.AspNetCore.Mvc;
using MusicMarket.Models;
using MusicMarketInterface.DTOs;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Helpers;
using MusicMarketLogic.Interfaces;

namespace MusicMarket.Controllers;

public class MessageController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IAdvertisementContainer IAdvertisementContainer;

    public MessageController(ILogger<HomeController> logger, IAdvertisementContainer iAdvertisementContainer)
    {
        _logger = logger;
        IAdvertisementContainer = iAdvertisementContainer;
    }

    [HttpGet]
    public IActionResult Messages()
    {
        if (Request.Cookies["UserData"] == null)
        {
            return RedirectToAction("Login", "Home");
        }

        var messageViewModel = new MessageViewModel();
        var personId = 0;
        foreach (var person in ContainerFactory.PersonContainer.GetAllPersons())
        {
            if (person.Username == Request.Cookies["UserData"])
            {
                personId = person.Id;
            }
        }

        messageViewModel.Messages = ContainerFactory.MessageContainer.GetAllConversations(personId);
        messageViewModel.Persons = ContainerFactory.PersonContainer.GetAllPersons();
        return View(messageViewModel);
    }

    [HttpGet]
    public IActionResult Conversation(int senderId, int receiverId)
    {
        if (Request.Cookies["UserData"] == null)
        {
            return RedirectToAction("Login", "Home");
        }

        var messageViewModel = new MessageViewModel();
        if (senderId == receiverId)
        {
            return RedirectToAction("Market", "Market");
        }

        if (ContainerFactory.MessageContainer.GetConversation(senderId, receiverId).Any())
        {
            messageViewModel.Messages = ContainerFactory.MessageContainer.GetConversation(senderId, receiverId);
        }
        else
        {
            foreach (var person in ContainerFactory.PersonContainer.GetAllPersons())
            {
                if (person.Id == receiverId)
                {
                    messageViewModel.NewPerson = person;
                }
            }
        }

        messageViewModel.Persons = ContainerFactory.PersonContainer.GetAllPersons();
        if (Request.Cookies["UserData"] != null)
        {
            messageViewModel.CurrentUser = Request.Cookies["UserData"] ?? throw new InvalidOperationException();
        }

        return View(messageViewModel);
    }

    [HttpPost]
    public IActionResult Conversation(MessageViewModel messageViewModel, int senderId, int receiverId)
    {
        ContainerFactory.MessageContainer.AddMessage(new Message(new MessageDto()
        {
            ReceiverId = receiverId,
            SenderId = senderId,
            Content = messageViewModel.newMessage
        }));
        return RedirectToAction("Messages", "Message");
    }
}