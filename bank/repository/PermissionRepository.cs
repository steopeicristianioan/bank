using bank.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.repository
{
    public class PermissionRepository : Repository<Permission>
    {
        public PermissionRepository()
        {
            read();
        }

        public override void read()
        {
            all = new List<Permission>();

            string sql = "select * from permission";
            all = db.LoadData<Permission, dynamic>(sql, new { }, connection);
            last_id = all[all.Count - 1].ID;
        }
        public override void print()
        {
            foreach (Permission permission in all)
                Console.WriteLine(permission);
        }

        public override void add(Permission obj)
        {
            string sql = "insert into permission (role_id, title, module, description) values " +
                "(@r, @t, @m, @d)";
            db.SaveData(sql, new
            {
                r = obj.Role_ID,
                t = obj.Title,
                m = obj.Module,
                d = obj.Description
            }, connection);
            read();
        }
        public override void delete(int id)
        {
            string sql = "delete from permission where id = @i";
            db.SaveData(sql, new { i = id }, connection);
            read();
        }
        public Permission getByTitle(string title)
        {
            string sql = "select * from permission where title = @t limit 1";
            List<Permission> permissions = db.LoadData<Permission, dynamic>(sql, new { t = title }
                , connection);
            if (permissions.Count == 0)
                return null;
            return permissions[0];
        }
    }
}
