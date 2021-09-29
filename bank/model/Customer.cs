using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.model
{
    public class Customer : Person
    {
        public Customer(int id, int role_id, string name, string email, 
            DateTime created_at, string address) : base(id, role_id, name, email, created_at, address) { }

        public override string ToString()
        {
            return "Customer - " + base.ToString();
        }
    }
}
