using System;
using System.Collections.Generic;
using MusicMarketInterface.DTOs;
using MusicMarketInterface.Interfaces;

namespace MusicMarketUnitTests.Mocks;

public class PersonMock : IPerson
{
    public List<PersonDto> Persons = new();

    public PersonMock()
    {
        Persons.Add(new PersonDto()
        {
            Email = "test1@test.com",
            Id = 1,
            Password = "Pass1",
            Username = "Name1"
        });
        Persons.Add(new PersonDto()
        {
            Email = "test2@test.com",
            Id = 2,
            Password = "Pass2",
            Username = "Name2"
        });
        Persons.Add(new PersonDto()
        {
            Email = "test2@test.com",
            Id = 2,
            Password = "Pass2",
            Username = "Name2"
        });
    }

    public int AddPerson(PersonDto personDto)
    {
        Persons.Add(personDto);
        return personDto.Id;
    }

    public int RemovePerson(PersonDto personDto)
    {
        Persons.Remove(personDto);
        return personDto.Id;
    }

    public PersonDto GetPersonByName(string username)
    {
        PersonDto returnPerson = new();
        foreach (var personDto in Persons)
        {
            if (personDto.Username == username)
            {
                returnPerson = personDto;
            }
        }

        return returnPerson;
    }

    public List<PersonDto> GetAllPersons()
    {
        List<PersonDto> returnList = new();
        foreach (var personDto in Persons)
        {
            returnList.Add(personDto);
        }

        return returnList;
    }
}