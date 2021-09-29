using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bank.repository;

namespace test
{
    [TestClass]
    public class TestPersonRepository
    {
        [TestMethod]
        public void testGetAll()
        {
            PersonRepository repository = new PersonRepository();
            Assert.AreEqual(5, repository.All.Count);
        }
    }
}
