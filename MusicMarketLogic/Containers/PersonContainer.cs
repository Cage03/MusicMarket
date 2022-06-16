using System.Security.Cryptography;
using MusicMarketInterface.Interfaces;
using MusicMarketLogic.Classes;
namespace MusicMarketLogic.Containers;

public class PersonContainer
{
    private List<Person> _persons;

    private IPerson Person;

    public PersonContainer(IPerson iPerson)
    {
        Person = iPerson;
        _persons = new List<Person>();
    }

    public IReadOnlyCollection<Person> GetPersons()
    {
        return _persons;
    }

    public void AddPerson(Person person)
    {
        Person.GetAllPersons();
        if (_persons.Contains(person))
        {
            throw new ArgumentException("Cannot add duplicate person");
        }

        if (string.IsNullOrWhiteSpace(person.Email) || string.IsNullOrWhiteSpace(person.Username) || string.IsNullOrWhiteSpace(person.Password))
        {
            throw new ArgumentException("Not all information is given");
        }
        _persons.Add(person);
        Person.AddPerson(person.ToDto());
    }

    public void RemovePerson(Person person)
    {
        Person.GetAllPersons();
        if (!_persons.Contains(person))
        {
            throw new ArgumentException("Cannot remove non-contained person");
        }
        _persons.Remove(person);
        Person.RemovePerson(person.ToDto());
    }

    public Person GetPersonByName(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("No username was provided");
        }

        return new Person(Person.GetPersonByName(username));
    }

    public List<Person> GetAllPersons()
    {
        var personDtos = Person.GetAllPersons();
        _persons.Clear();

        List<Person> persons = new();
        foreach (var personDto in personDtos)
        {
            persons.Add(new Person(personDto));
            _persons.Add(new Person(personDto));
        }

        return persons;
    }
}