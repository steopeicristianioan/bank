using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.model
{
    public class Fixed_DepositOffer
    {
        private double percent;
        private double ammount;
        private double interest_rate;

        //setters & getters
        #region
        public double Percent { get => this.percent; set => this.percent = value; }
        public double Ammount { get => this.ammount; set => this.ammount = value; }
        public double Interest_Rate { get => this.interest_rate; set => this.interest_rate = value; }
        #endregion

        public Fixed_DepositOffer(double percent, double ammount, double interest_rate)
        {
            this.percent = percent;
            this.ammount = ammount;
            this.interest_rate = interest_rate;
        }
    }
}
