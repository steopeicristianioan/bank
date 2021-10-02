using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.model
{
    public class Role
    {
        private int id;
        private string name;
        private string description;

        //setters & getters
        #region
        public int ID { get => this.id; set => this.id = value; }
        public string Name { get => this.name; set => this.name = value; }
        public string Description { get => this.description; set => this.description = value; }
        #endregion

        public Role(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public override string ToString()
        {
            return id.ToString() + "|" + name;
        }
        public override bool Equals(object obj)
        {
            Role other = (Role)obj;
            return id == other.id;
        }
        public override int GetHashCode()
        {
            return id;
        }
    }
}
