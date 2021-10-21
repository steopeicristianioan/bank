using bank.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.repository
{
    public class AccountRepository : Repository<Account>
    {

        public AccountRepository()
        {
            read();
        }

        public override void read()
        {
            all = new List<Account>();

            string sql = "select * from account where type = @a ";
            all = db.LoadData<Account, dynamic>(sql, new { a = "current" }, connection);
            this.last_id = all[all.Count - 1].ID;
        }
        public override void print()
        {
            foreach(Account account in all)
                Console.WriteLine(account);
        }

        public override void add(Account obj)
        {
            string sql = "insert into account(customer_id, number, type, balance, created_at) values" +
                "(@c, @n, @t, @b, @cr)";
            db.SaveData(sql, new {
                c = obj.Customer_ID,
                n = obj.Number,
                t = obj.Type,
                b = obj.Balance,
                cr = obj.Created_At },
            connection);
            read();
        }
        public override void delete(int id)
        {
            string sql = "delete from account where id = @i";
            db.SaveData(sql, new { i = id }, connection);
            read();
        }
        public Account getByNumber(string number)
        {
            string sql = "select * from account where type = @v and number = @n limit 1";
            List<Account> accounts = db.LoadData<Account, dynamic>(sql, new { v = "current", n = number },
                connection);
            if (accounts.Count == 0)
                return null;
            return accounts[0];
        }

        public Account getByCustomer(int cusotmer_id)
        {
            string sql = "select * from account where type = @v and customer_id = @i limit 1";
            List<Account> accounts = db.LoadData<Account, dynamic>(sql, new { v = "current", i = cusotmer_id },
                connection);
            if (accounts.Count == 0)
                return null;
            return accounts[0];
        }
        public void makeTransfer(Account from, Account to, string sum)
        {
            double diff = double.Parse(sum);
            double fromSum = double.Parse(from.Balance);
            double toSum = double.Parse(to.Balance);

            fromSum -= diff;
            toSum += diff;

            from.Balance = fromSum.ToString();
            to.Balance = toSum.ToString();

            string sql1 = "update account set balance = @from where id = @ifrom;";
            string sql2 = "update account set balance = @to where id = @ito";

            db.SaveData(sql1, new { from = from.Balance, ifrom = from.ID }, connection);
            db.SaveData(sql2, new { to = to.Balance, ito = to.ID }, connection);

            read();
        }
    }
}
