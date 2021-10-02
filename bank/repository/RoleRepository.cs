using bank.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.repository
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository()
        {
            read();
        }

        public override void read()
        {
            all = new List<Role>();

            string sql = "select * from role";
            all = db.LoadData<Role, dynamic>(sql, new { }, connection);
            last_id = all[all.Count - 1].ID;
        }
        public override void print()
        {
            foreach(Role role in all)
                Console.WriteLine(role);
        }

        public override void add(Role obj)
        {
            string sql = "insert into role(name, description) values (@n, @d)";
            db.SaveData(sql, new { n = obj.Name, d = obj.Description }, connection);
            read();
        }
        public override void delete(int id)
        {
            string sql = "delete from role where id = @i";
            db.SaveData(sql, new { i = id }, connection);
            read();
        }
        public Role getByName(string name)
        {
            string sql = "select * from role where name = @n limit 1";
            List<Role> roles = db.LoadData<Role, dynamic>(sql, new { n = name }, connection);
            if (roles.Count == 0)
                return null;
            return roles[0];
        }
    }
}
