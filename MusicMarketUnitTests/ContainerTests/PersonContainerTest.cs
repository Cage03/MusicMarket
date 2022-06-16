using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketInterface.DTOs;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Containers;
using MusicMarketUnitTests.Mocks;

namespace MusicMarketUnitTests.ContainerTests;

[TestClass]
public class PersonContainerTest
{
    [TestMethod]
    public void ConstructorTest()
    {
        //arrange
        var dal = new PersonMock();
        //act
        var container = new PersonContainer(dal);
        //assert
        Assert.IsNotNull(container);
    }

    [TestMethod]
    public void AddPersonTest()
    {
        //arrange
        var dal = new PersonMock();
        var container = new PersonContainer(dal);
        var person = new Person(new PersonDto()
        {
            Email = "Test@TestThis.com",
            Id = 7,
            Password = "Pass7",
            Username = "Name7"
        });
        //act
        container.AddPerson(person);
        //assert
        Assert.IsTrue(container.GetPersons().Contains(person));
        Assert.AreEqual(person.Email, dal.Persons[^1].Email);
        Assert.AreEqual(person.Id, dal.Persons[^1].Id);
        Assert.AreEqual(person.Password, dal.Persons[^1].Password);
        Assert.AreEqual(person.Username, dal.Persons[^1].Username);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddExistingPersonTest()
    {
        //arrange
        var dal = new PersonMock();
        var container = new PersonContainer(dal);
        var person = new Person(new PersonDto()
        {
            Email = "Test@TestThis.com",
            Id = 7,
            Password = "Pass7",
            Username = "Name7"
        });
        //act
        container.AddPerson(person);
        container.AddPerson(person);
        //assert
        //no assert needed
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddNullValuePerson()
    {
        //arrange
        var dal = new PersonMock();
        var container = new PersonContainer(dal);
        var person1 = new Person(new PersonDto()
        {
            Email = "",
            Id = 7,
            Password = "Pass7",
            Username = "Name7"
        });
        var person2 = new Person(new PersonDto()
        {
            Email = "Test@Test.com",
            Id = 7,
            Password = null,
            Username = "Name7"
        });
        var person3 = new Person(new PersonDto()
        {
            Email = "Test@Test.com",
            Id = 7,
            Password = "Pass19",
            Username = ""
        });

        //act
        container.AddPerson(person1);
        container.AddPerson(person2);
        container.AddPerson(person3);
        //assert
        Assert.IsFalse(container.GetPersons().Contains(person1), "container contains person1");
        Assert.IsFalse(container.GetPersons().Contains(person2), "container contains person2");
        Assert.IsFalse(container.GetPersons().Contains(person3), "container contains person3");
    }

    [TestMethod]
    public void RemovePersonTest()
    {
        //arrange
        var dal = new PersonMock();
        var container = new PersonContainer(dal);
        var person = new Person(new PersonDto()
        {
            Email = "This@test.com",
            Id = 7,
            Password = "Pass7",
            Username = "Name7"
        });
        container.AddPerson(person);
        //act
        container.RemovePerson(person);
        //assert
        Assert.IsFalse(container.GetPersons().Contains(person), "container contains person");
        Assert.IsFalse(dal.Persons.Contains(person.ToDto()));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void RemoveNonContainedPerson()
    {
        //arrange
        var dal = new PersonMock();
        var container = new PersonContainer(dal);
        var person = new Person(new PersonDto()
        {
            Email = "This@test.com",
            Id = 7,
            Password = "Pass7",
            Username = "Name7"
        });
        //act
        container.RemovePerson(person);
        //assert
        Assert.Fail("Program did not stop");
    }

    [TestMethod]
    public void GetPersonByUsernameTest()
    {
        //arrange
        var dal = new PersonMock();
        var container = new PersonContainer(dal);
        var person = new Person(new PersonDto()
        {
            Email = "This@test.com",
            Id = 7,
            Password = "Pass7",
            Username = "Name7"
        });
        container.AddPerson(person);
        //act
        var thisPerson = container.GetPersonByName(person.Username);
        //assert
        Assert.AreEqual(person.Email, thisPerson.Email, "Email does not match");
        Assert.AreEqual(person.Username, thisPerson.Username, "Username does not match");
        Assert.AreEqual(person.Password, thisPerson.Password, "Password does not match");
        Assert.AreEqual(person.Id, thisPerson.Id, "Id does not match");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetPersonWithNullValue()
    {
        //arrange
        var dal = new PersonMock();
        var container = new PersonContainer(dal);
        var person = new Person(new PersonDto()
        {
            Email = "This@test.com",
            Id = 7,
            Password = "Pass7",
            Username = "Person1"
        });
        container.AddPerson(person);
        //act
        var thisPerson1 = container.GetPersonByName(null);
        //assert
        Assert.Fail("Program did not stop");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetPersonWithEmptyValue()
    {
        //arrange
        var dal = new PersonMock();
        var container = new PersonContainer(dal);
        var person = new Person(new PersonDto()
        {
            Email = "This@test.com",
            Id = 7,
            Password = "Pass7",
            Username = "Person1"
        });
        container.AddPerson(person);
        //act
        var thisPerson1 = container.GetPersonByName("");
        //assert
        Assert.Fail("Program did not stop");
    }

    [TestMethod]
    public void GetAllPersonsTest()
    {
        //arrange
        var dal = new PersonMock();
        var container = new PersonContainer(dal);
        var person1 = new Person(new PersonDto()
        {
            Email = "This@test.com",
            Id = 7,
            Password = "Pass7",
            Username = "Test1"
        });
        var person2 = new Person(new PersonDto()
        {
            Email = "This@test.com",
            Id = 7,
            Password = "Pass7",
            Username = "Test2"
        });
        container.AddPerson(person1);
        container.AddPerson(person2);
        //act
        List<Person> people = container.GetAllPersons();
        //assert
        Assert.IsTrue(people.Count == 5);
    }
}