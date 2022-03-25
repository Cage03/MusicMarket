using MusicMarketLogic.Classes;
namespace MusicMarketLogic.Containers;

public class PersonContainer
{
    private List<Person> _persons;

    public PersonContainer()
    {
        _persons = new List<Person>();
    }

    public IReadOnlyCollection<Person> GetPersons()
    {
        return _persons;
    }

    public void AddPerson(Person person)
    {
        if (_persons.Contains(person))
        {
            throw new ArgumentException("Cannot add duplicate person");
        }

        if (string.IsNullOrWhiteSpace(person.Email) || string.IsNullOrWhiteSpace(person.Username))
        {
            throw new ArgumentException("Not all information is given");
        }
        _persons.Add(person);
    }

    public void RemovePerson(Person person)
    {
        if (!_persons.Contains(person))
        {
            throw new ArgumentException("Cannot remove non-contained person");
        }
        _persons.Remove(person);
    }
}