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
    public class TestRoleRepository
    {
        [TestMethod]
        public void testRead()
        {
            RoleRepository repository = new RoleRepository();
            Assert.AreEqual(5, repository.All.Count);
        }
        [TestMethod]
        public void testAddDelete()
        {
            RoleRepository repository = new RoleRepository();

            repository.add(new Role(-1, "n1", "d1"));
            repository.add(new Role(-1, "n2", "d2"));
            Assert.AreEqual("d1", repository.getByName("n1").Description);
            Assert.AreEqual("n2", repository.getByName("n2").Name);

            repository.delete(repository.Last_ID);
            repository.delete(repository.Last_ID);
            Assert.AreEqual(null, repository.getByName("n1"));
            Assert.AreEqual(null, repository.getByName("n2"));
        }
    }
}
