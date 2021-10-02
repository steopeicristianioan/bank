using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.model
{
    public class Permission
    {
        private int id;
        private int role_id;
        private string title;
        private string module;
        private string description;

        //setters & getters;
        #region
        public int ID { get => this.id; set => this.id = value; }
        public int Role_ID { get => this.role_id; set => this.role_id = value; }
        public string Title { get => this.title; set => this.title = value; }
        public string Module { get => this.module; set => this.module = value; }
        public string Description { get => this.description; set => this.description = value; }
        #endregion

        public Permission(int id, int role_id, string title, string module, string description)
        {
            this.id = id;
            this.role_id = role_id;
            this.title = title;
            this.module = module;
            this.description = description;
        }

        public override string ToString()
        {
            return id.ToString() + "|" + title;
        }
        public override bool Equals(object obj)
        {
            Permission other = (Permission)obj;
            return id == other.id;
        }
        public override int GetHashCode()
        {
            return id;
        }
    }
}
