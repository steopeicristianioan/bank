using bank.model;
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
    public class MyAccountView : View
    {
        private Account account;
        public Account Account { get => this.account; set => this.account = value; }

        private Label info;
        private IconButton balance;
        private IconButton created;
        private IconButton number;

        public MyAccountView(int id, Control parent, Account account) : base(id, parent)
        {
            this.account = account;

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
            if(account != null)
            {
                loadNumber();
                loadBalance();
                loadCreated();
                number.IconColor = balance.IconColor = created.IconColor = ColorTranslator.FromHtml("#39603D");
            }
        }
        private void loadNumber()
        {
            number = new IconButton();
            Useful.placeIconButtonInParent(number, main, new Size(400, 100), new Point(-1, 150),
                IconChar.Hashtag, "#3C403D", "", "Account number: " + account.Number,
                new Font("Segoe UI", 11, FontStyle.Regular), ContentAlignment.MiddleCenter);
        }
        private void loadBalance()
        {
            balance = new IconButton();
            Useful.placeIconButtonInParent(balance, main, new Size(400, 100), new Point(-1, 300),
                IconChar.MoneyCheckAlt, "#3C403D", "", "Current balance: " + account.Balance + " $",
                new Font("Segoe UI", 11, FontStyle.Regular), ContentAlignment.MiddleCenter);
            balance.Location = new Point(number.Location.X - 210, 275);
        }
        private void loadCreated()
        {
            created = new IconButton();
            Useful.placeIconButtonInParent(created, main, new Size(400, 100), new Point(-1, 300),
                IconChar.CalendarAlt, "#3C403D", "", "Created:\n" + account.Created_At.ToString("f"),
                new Font("Segoe UI", 11, FontStyle.Regular), ContentAlignment.MiddleCenter);
            created.Location = new Point(number.Location.X + 200, 275);
        }
    }
}
