using bank.model;
using bank.repository;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bank.view
{
    public class MySavingView : View
    {
        private Fixed_Deposit deposit;
        private Fixed_DepositRepository repository;

        private IconButton balance;
        private IconButton created;
        private IconButton number;
        private IconButton period;
        private IconButton percent;
        private IconButton interest_rate;
        private IconButton initial_deposit;

        private OfferView offer;

        public MySavingView(int id, Control parent, Fixed_Deposit deposit) : base(id, parent)
        {
            this.deposit = deposit;

            setHeader();
            setAside();
            setMain();

            loadMain();
        }

        protected override void setHeader()
        {
            header.Size = new Size(0, 0);
        }
        protected override void setAside()
        {
            aside.Size = new Size(0, 0);
        }
        protected override void setMain()
        {
            main.Size = this.Size;
        }

        private void loadMain()
        {
            if(deposit != null)
            {
                loadNumber();
                loadBalance();
                loadCreated();
                loadInterestRate();
                loadPercent();
                loadPeriod();
                loadTotal();
            }
            else
            {
                offer = new OfferView(this.ID, this.main);
                offer.Show();
                MessageBox.Show("NU STIU CUM SA FAC CA SA MEARGA CODU DE JOS NUMAI DUPA " +
                    "CE SE INCHIDE FORMA OFFER PENTRU CA NU MERGE CU SHOWDIALOG() CA NU E " +
                    "TOP LEVEL!!!!!!!!!!!!!!!");
                repository = new Fixed_DepositRepository();
                deposit = repository.getByCustomer(this.ID);
                if (deposit != null)
                {
                    main.Controls.Clear();
                    loadNumber();
                    loadBalance();
                    loadCreated();
                    loadInterestRate();
                    loadPercent();
                    loadPeriod();
                    loadTotal();
                }
            }
        }
        private void loadNumber()
        {
            number = new IconButton();
            Useful.placeIconButtonInParent(number, main, new Size(400, 125), new Point(-1, 75),
                IconChar.Hashtag, "#3C403D", "", "Deposit number: " + deposit.Number,
                new Font("Segoe UI", 11, FontStyle.Regular), ContentAlignment.MiddleCenter);

            //number.FlatAppearance.BorderSize = 1;
            //number.FlatAppearance.BorderColor = Color.Black;
        }
        private void loadBalance()
        {
            balance = new IconButton();
            Useful.placeIconButtonInParent(balance, main, new Size(400, 75), new Point(-1, 160),
                IconChar.MoneyCheckAlt, "#3C403D", "", "Current balance: " + deposit.Balance + " $",
                new Font("Segoe UI", 11, FontStyle.Regular), ContentAlignment.MiddleCenter);
            balance.Location = new Point(number.Location.X - 210,  210);
        }
        private void loadCreated()
        {
            created = new IconButton();
            Useful.placeIconButtonInParent(created, main, new Size(400, 75), new Point(-1, 160),
                IconChar.CalendarAlt, "#3C403D", "", "Created:\n" + deposit.Created_At.ToString("f"),
                new Font("Segoe UI", 11, FontStyle.Regular), ContentAlignment.MiddleCenter);
            created.Location = new Point(number.Location.X + 200, 210);
        }
        private void loadInterestRate()
        {
            interest_rate = new IconButton();
            Useful.placeIconButtonInParent(interest_rate, main, new Size(400, 75), new Point(-1, 295),
                IconChar.Percentage, "#3C403D", "", "Interest rate:\n" + deposit.Interest_Rate.ToString() + "%",
                new Font("Segoe UI", 11, FontStyle.Regular), ContentAlignment.MiddleCenter);
            //interest_rate.Location = new Point(number.Location.X - 190, 340);
        }
        private void loadPercent()
        {
            percent = new IconButton();
            Useful.placeIconButtonInParent(percent, main, new Size(400, 75), new Point(-1, 340),
                IconChar.DollarSign, "#3C403D", "", "You deposit " + deposit.Percent.ToString() + "%\nfrom your income monthly",
                new Font("Segoe UI", 11, FontStyle.Regular), ContentAlignment.MiddleCenter);
            percent.Location = new Point(number.Location.X - 190, 380);
        }
        private void loadPeriod()
        {
            period = new IconButton();
            DateTime future = deposit.Created_At.AddMonths(deposit.Period);
            TimeSpan midTime = future.Subtract(DateTime.Now);
            int temp = (int)midTime.Days;
            string output = temp.ToString();
            Useful.placeIconButtonInParent(period, main, new Size(400, 75), new Point(-1, 340),
                IconChar.Stopwatch, "#3C403D", "", "You gain access to your money in:\n" + output + " days",
                new Font("Segoe UI", 11, FontStyle.Regular), ContentAlignment.MiddleCenter);
            period.Location = new Point(number.Location.X + 200, 380);
        }
        private void loadTotal()
        {
            initial_deposit = new IconButton();
            Useful.placeIconButtonInParent(initial_deposit, main, new Size(400, 75), new Point(-1, 465),
                IconChar.FileInvoiceDollar, "#3C403D", "", "Initial deposit:\n" + deposit.Total + "$",
                new Font("Segoe UI", 11, FontStyle.Regular), ContentAlignment.MiddleCenter);
        }
    }
}
