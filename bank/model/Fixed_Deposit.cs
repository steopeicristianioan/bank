using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.model
{
    public class Fixed_Deposit : Account
    {
        private int period;
        private double percent;
        private double interest_rate;
        private string total;

        //getters & setters
        #region
        public int Period { get => this.period; set => this.period = value; }
        public double Percent { get => this.percent; set => this.percent = value; }
        public double Interest_Rate { get => this.interest_rate; set => this.interest_rate = value; }
        public string Total { get => this.total; set => this.total = value; }
        #endregion}


        public Fixed_Deposit(int id, int customer_id, string number, string type, string balance, 
            DateTime created_at, string total, int period, double percent, double interest_rate) : 
            base(id, customer_id, number, type, balance, created_at)
        {
            this.total = total;
            this.period = period;
            this.percent = percent;
            this.interest_rate = interest_rate;
        }
    }
}
