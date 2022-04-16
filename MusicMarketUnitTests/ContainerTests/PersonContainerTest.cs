using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicMarketLogic.Classes;
using MusicMarketLogic.Containers;

namespace MusicMarketUnitTests.ContainerTests;

[TestClass]
public class PersonContainerTest
{
    [TestMethod]
    public void AddPersonTest()
    {
        //arrange
        var container = new PersonContainer();
        var person = new Person("Stijn", "Stijn@gmail.com");
        //act
        container.AddPerson(person);
        //assert
        Assert.IsTrue(container.GetPersons().Contains(person));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]

    public void AddAlreadyContainedPerson()
    {
        //arrange
        var container = new PersonContainer();
        var person = new Person("Stijn","Stijn@gmail.com");
        container.AddPerson(person);
        //act
        container.AddPerson(person);
        //assert
        Assert.IsTrue(container.GetPersons().Count==1);
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]

    public void AddEmptyValuePersonTest()
    {
        //arrange
        var container = new PersonContainer();
        var person = new Person("", "");
        //act
        container.AddPerson(person);
        //assert
        Assert.IsTrue(container.GetPersons().Count==0);
    }
    [TestMethod]
    public void RemovePersonTest()
    {
        //arrange
        var container = new PersonContainer();
        var person = new Person("Stijn", "Stijn@gmail.com");
        container.AddPerson(person);
        //act
        container.RemovePerson(person);
        //assert
        Assert.IsTrue(!container.GetPersons().Contains(person));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]

    public void RemoveNonContainedMessage()
    {
        //arrange
        var container = new PersonContainer();
        var person = new Person("Stijn","Stijn@gmail.com");
        //act
        container.RemovePerson(person);
        //assert
        Assert.IsTrue(container.GetPersons().Count==0);
    }
}