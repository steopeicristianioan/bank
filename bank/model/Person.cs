using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.model
{
    public class Person
    {
        protected int id;
        protected int role_id;
        protected string name;
        protected string email;
        protected DateTime created_at;
        protected string address;

        //setters & getters
        #region
        public int ID { get => this.id; set => this.id = value; }
        public int Role_ID { get => this.role_id; set => this.role_id = value; }
        public string Name { get => this.name; set => this.name = value; }
        public string Email { get => this.email; set => this.email = value; }
        public DateTime Created_At { get => this.created_at; set => this.created_at = value; }
        public string Adress { get => this.address; set => this.address = value; }
        #endregion

        public Person(int id, int role_id, string name, string email, 
            DateTime created_at, string address)
        {
            this.id = id;
            this.role_id = role_id;
            this.name = name;
            this.email = email;
            this.created_at = created_at;
            this.address = address;
        }

        public override string ToString()
        {
            return this.id.ToString() + "," + this.name;
        }
        public override bool Equals(object obj)
        {
            Person other = (Person)obj;
            return other.id == this.id;
        }
        public override int GetHashCode()
        {
            return id;
        }
    }
}
