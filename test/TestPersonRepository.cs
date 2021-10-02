using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bank.repository;
using bank.model;

namespace test
{
    [TestClass]
    public class TestPersonRepository
    {
        [TestMethod]
        public void testRead()
        {
            PersonRepository repository = new PersonRepository();
            Assert.AreEqual(5, repository.All.Count);
        }
        [TestMethod]
        public void testAddRemove()
        {
            PersonRepository repository = new PersonRepository();

            repository.add(new Person(repository.Last_ID + 1, 1, "name", "email", DateTime.Now, "adress"));
            repository.add(new Person(repository.Last_ID + 1, 2, "name1", "email1", DateTime.Now, "adress1"));
            repository.add(new Person(repository.Last_ID + 1, 3, "name2", "email2", DateTime.Now, "adress2"));
            Assert.AreEqual(2, repository.getByName("name1").Role_ID);
            Assert.AreEqual("email", repository.getByName("name").Email);
            Assert.AreEqual("adress2", repository.getByName("name2").Address);

            repository.delete(repository.Last_ID);
            repository.delete(repository.Last_ID);
            repository.delete(repository.Last_ID);
            Assert.AreEqual(null, repository.getByName("name"));
            Assert.AreEqual(null, repository.getByName("name1"));
            Assert.AreEqual(null, repository.getByName("name2"));
        }
    }
}
