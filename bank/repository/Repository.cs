using DataAccessLibrary.NETFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.repository
{
    public abstract class Repository<T>
    {
        protected MySqlDataAccess db = new MySqlDataAccess();
        public MySqlDataAccess DB { get => this.db; set => this.db = value; }
        protected string connection = Useful.getConnectionString();
        public string Connection { get => this.connection; }
        protected List<T> all;
        public List<T> All { get => this.all; set => this.all = value; }
        protected int last_id;
        public int Last_ID { get => this.last_id; set => this.last_id = value; }

        public abstract void read();
        public abstract void print();
        public abstract void add(T obj);
        public abstract void delete(int id);
    }
}
