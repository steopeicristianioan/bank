using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.model
{
    public class Account
    {
        protected int id;
        protected int customer_id;
        protected string number;
        protected string type;
        protected string balance;
        protected DateTime created_at;

        //getters & setters
        #region
        public int ID { get => this.id; set => this.id = value; }
        public int Customer_ID { get => this.customer_id; set => this.customer_id = value; }
        public string Number { get => this.number; set => this.number = value; }
        public string Type { get => this.type; set => this.type = value; }
        public string Balance { get => this.balance; set => this.balance = value; }
        public DateTime Created_At { get => this.created_at; set => this.created_at = value; }
        #endregion

        public Account(int id, int customer_id, string number, string type
            , string balance, DateTime created_at)
        {
            this.id = id;
            this.customer_id = customer_id;
            this.number = number;
            this.type = type;
            this.balance = balance;
            this.created_at = created_at;
        }

        public override string ToString()
        {
            return id.ToString() + "|" + customer_id.ToString() + "|" + balance;
        }
        public override bool Equals(object obj)
        {
            Account account = (Account)obj;
            return id == account.id;
        }
        public override int GetHashCode()
        {
            return id;
        }
    }
}
