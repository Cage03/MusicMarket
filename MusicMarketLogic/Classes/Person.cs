using MusicMarketInterface.DTOs;

namespace MusicMarketLogic.Classes;

public class Person
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    
    public string Password { get; private set; }
    public int Id { get; private set; }

    public Person(string username, string email)
    {
        Username = username;
        Email = email;
    }

    public Person(PersonDto personDto)
    {
        Username = personDto.Username;
        Email = personDto.Email;
        Id = personDto.Id;
        Password = personDto.Password;
    }

    public PersonDto ToDto()
    {
        PersonDto dto = new()
        {
            Username = Username,
            Email = Email,
            Password = Password,
            Id = Id
        };
        return dto;
    }
}