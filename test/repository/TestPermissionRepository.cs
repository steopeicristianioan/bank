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
    public class TestPermissionRepository
    {
        [TestMethod]
        public void testRead()
        {
            PermissionRepository repository = new PermissionRepository();
            Assert.AreEqual(15, repository.All.Count);
        }
        [TestMethod]
        public void testAddDelete()
        {
            PermissionRepository repository = new PermissionRepository();

            repository.add(new Permission(-1, 1, "t1", "m1", "d1"));
            repository.add(new Permission(-1, 2, "t2", "m2", "d2"));
            repository.add(new Permission(-1, 3, "t3", "m3", "d3"));
            Assert.AreEqual(1, repository.getByTitle("t1").Role_ID);
            Assert.AreEqual("m2", repository.getByTitle("t2").Module);
            Assert.AreEqual("d3", repository.getByTitle("t3").Description);

            repository.delete(repository.Last_ID);
            repository.delete(repository.Last_ID);
            repository.delete(repository.Last_ID);
            Assert.AreEqual(null, repository.getByTitle("t1"));
            Assert.AreEqual(null, repository.getByTitle("t2"));
            Assert.AreEqual(null, repository.getByTitle("t3"));
        }
    }
}
