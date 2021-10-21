using bank.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.repository
{
    public class Fixed_DepositRepository : Repository<Fixed_Deposit>
    {
        public string Last_Number;
        public Fixed_DepositRepository()
        {
            read();
        }

        public override void read()
        {
            all = new List<Fixed_Deposit>();

            string sql = "select * from fixed_deposit";
            all = db.LoadData<Fixed_Deposit, dynamic>(sql, new { }, connection);
            last_id = all[all.Count - 1].ID;
            Last_Number = all[all.Count - 1].Number;
        }
        public override void print()
        {
            foreach(Fixed_Deposit deposit in all)
                Console.WriteLine(deposit);
        }

        public override void add(Fixed_Deposit obj)
        {
            string sql = "insert into fixed_deposit(customer_id, number, type, balance, " +
                "created_at, total, period, percent, interest_rate) values" +
                "(@c, @n, @t, @b, @cr, @to, @p, @pe, @i)";
            db.SaveData(sql, new
            {
                c = obj.Customer_ID,
                n = obj.Number,
                t = obj.Type,
                b = obj.Balance,
                cr = obj.Created_At,
                to = obj.Total,
                p = obj.Period,
                pe = obj.Percent,
                i = obj.Interest_Rate
            }, connection);
            read();
        }
        public override void delete(int id)
        {
            string sql = "delete from fixed_deposit where id = @i";
            db.SaveData(sql, new { i = id }, connection);
            read();
        }
        public Fixed_Deposit getByNumber(string number)
        {
            string sql = "select * from fixed_deposit where number = @n limit 1";
            List<Fixed_Deposit> deposits = db.LoadData<Fixed_Deposit, dynamic>(sql, new { n = number },
                connection);
            if (deposits.Count == 0)
                return null;
            return deposits[0];
        }

        private double generateInterest_Rate(double start, double finish)
        {
            Random random = new Random();
            return random.NextDouble() * (finish - start) + start;
        }
        public Fixed_DepositOffer generateOffer(double percent, string ammount)
        {
            double balance = double.Parse(ammount);
            double interest_rate = 0.0;
            if(percent >= 2 && percent <= 10)
            {
                if (balance < 100000)
                    interest_rate = generateInterest_Rate(0.05, 0.075);
                else if (balance < 500000)
                    interest_rate = generateInterest_Rate(0.25, 0.05);
                else interest_rate = generateInterest_Rate(0.01, 0.025);
            }
            else if(percent > 10 && percent <= 20)
            {
                if (balance < 100000)
                    interest_rate = generateInterest_Rate(0.055, 0.085);
                else if (balance < 500000)
                    interest_rate = generateInterest_Rate(0.03, 0.055);
                else interest_rate = generateInterest_Rate(0.02, 0.03);
            }
            else
            {
                if (balance < 100000)
                    interest_rate = generateInterest_Rate(0.07, 0.095);
                else if (balance < 500000)
                    interest_rate = generateInterest_Rate(0.045, 0.07);
                else interest_rate = generateInterest_Rate(0.02, 0.035);
            }

            return new Fixed_DepositOffer(percent, balance, interest_rate);
        }
        public Fixed_Deposit getByCustomer(int id)
        {
            string sql = "select * from fixed_deposit where customer_id = @i limit 1";
            List<Fixed_Deposit> deposits = db.LoadData<Fixed_Deposit, dynamic>(sql, new { i = id },
                connection);
            if (deposits.Count == 0)
                return null;
            return deposits[0];
        }
    }
}
