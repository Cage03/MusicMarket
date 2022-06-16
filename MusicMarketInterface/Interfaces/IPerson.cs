using MusicMarketInterface.DTOs;

namespace MusicMarketInterface.Interfaces;

public interface IPerson
{
    int AddPerson(PersonDto personDto);

    int RemovePerson(PersonDto personDto);

    PersonDto GetPersonByName(string username);

    List<PersonDto> GetAllPersons();
}