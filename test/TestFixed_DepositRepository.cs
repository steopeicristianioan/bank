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
    public class TestFixed_DepositRepository
    {
        [TestMethod]
        public void testRead()
        {
            Fixed_DepositRepository repository = new Fixed_DepositRepository();
            Assert.AreEqual(2, repository.All.Count);
        }
        [TestMethod]
        public void testAddDelete()
        {
            Fixed_DepositRepository repository = new Fixed_DepositRepository();

            repository.add(new Fixed_Deposit(-1, 123, "n1", "t1", "b1", DateTime.Now,
                "t1", 1, 2, 3));
            repository.add(new Fixed_Deposit(-1, 104, "n2", "t2", "b2", DateTime.Now,
                "t2", 4, 5, 6)); 
            repository.add(new Fixed_Deposit(-1, 123, "n3", "t3", "b3", DateTime.Now,
                 "t3", 7, 8, 9));
            Assert.AreEqual(3, repository.getByNumber("n1").Interest_Rate);
            Assert.AreEqual("t2", repository.getByNumber("n2").Total);
            Assert.AreEqual(123, repository.getByNumber("n3").Customer_ID);

            repository.delete(repository.Last_ID);
            repository.delete(repository.Last_ID);
            repository.delete(repository.Last_ID);
            Assert.AreEqual(null, repository.getByNumber("n1"));
            Assert.AreEqual(null, repository.getByNumber("n2"));
            Assert.AreEqual(null, repository.getByNumber("n3"));
        }
    }
}
