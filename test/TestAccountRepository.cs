using bank.model;
using bank.repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    [TestClass]
    public class TestAccountRepository
    {
        [TestMethod]
        public void testRead()
        {
            AccountRepository repository = new AccountRepository();
            Assert.AreEqual(1, repository.All.Count);
        }
        [TestMethod]
        public void testAddDelete()
        {
            AccountRepository repository = new AccountRepository();

            repository.add(new Account(-1, 104, "n1", "current", "b1", DateTime.Now));
            repository.add(new Account(-1, 123, "n2", "current", "b2", DateTime.Now));

            Assert.AreEqual(104, repository.getByNumber("n1").Customer_ID);
            Assert.AreEqual("b2", repository.getByNumber("n2").Balance);

            repository.delete(repository.Last_ID);
            repository.delete(repository.Last_ID);

            Assert.AreEqual(null, repository.getByNumber("n1"));
            Assert.AreEqual(null, repository.getByNumber("n2"));
        }
    }
}
