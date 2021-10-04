using bank.control;
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
    public class CustomerView : View
    {
        private CustomerViewControl control;
        public CustomerViewControl Control { get => this.control; set => this.control = value; }

        //aside controls
        private Panel current;
        private IconButton myCurrentAccount;
        private IconButton myFixedDeposit;
        private IconButton makeTransfer;
        private IconButton home;

        //header controls
        private Label currentTitle;
        

        //setters & getters
        #region
        public Panel Current { get => this.current; set => this.current = value; }
        public Label CurrentTitle { get => this.currentTitle; set => this.currentTitle = value; }
        #endregion

        public CustomerView(int id, Control parent) : base(id, parent)
        {
            control = new CustomerViewControl(this);

            setHeader();
            setAside();
            setMain();

            loadAside();
            loadHeader();
        }

        protected override void setHeader()
        {
            header.Size = new Size(this.Width, 100);
        }
        protected override void setMain()
        {
            main.Size = new Size(this.Width - 300, this.Height - 100);
            main.Location = new Point(300, 100);
        }
        protected override void setAside()
        {
            aside.Size = new Size(300, this.Height - 100);
            aside.Location = new Point(0, 100);
        }

        private void loadAside()
        {
            loadHome();
            loadMyCurrent();
            loadMakeTransfer();
            loadMyFixedDeposit();

            loadCurrent();
        }
        private void loadCurrent()
        {
            current = new Panel();
            Useful.placePanelInParent(current, aside, new Size(10, 80),
                new Point(home.Location.X - 10, home.Location.Y), "#39603D");
        }
        private void loadHome()
        {
            home = new IconButton();
            Useful.placeIconButtonInParent(home, aside, new Size(250, 80),
                new Point(50, 150), IconChar.Coins, "#3C403D", "#0000ffff",
                "Home", new Font("Segoe UI", 10, FontStyle.Regular),
                ContentAlignment.MiddleCenter);
            home.Click += new EventHandler(control.moveCurrentPanel);
        }
        private void loadMyCurrent()
        {
            myCurrentAccount = new IconButton();
            Useful.placeIconButtonInParent(myCurrentAccount, aside, new Size(250, 80), 
                new Point(50, 240), IconChar.MoneyBillAlt,"#3C403D", "#0000ffff", 
                "My account", new Font("Segoe UI", 10, FontStyle.Regular),
                ContentAlignment.MiddleCenter);
            myCurrentAccount.Click += new EventHandler(control.moveCurrentPanel);
        }
        private void loadMakeTransfer()
        {
            makeTransfer = new IconButton();
            Useful.placeIconButtonInParent(makeTransfer, aside, new Size(250, 80),
                new Point(50, 330), IconChar.ExchangeAlt, "#3C403D", "#0000ffff",
                "Make Transfer", new Font("Segoe UI", 10, FontStyle.Regular),
                ContentAlignment.MiddleCenter);
            makeTransfer.Click += new EventHandler(control.moveCurrentPanel);
        }
        private void loadMyFixedDeposit()
        {
            myFixedDeposit = new IconButton();
            Useful.placeIconButtonInParent(myFixedDeposit, aside, new Size(250, 80),
                new Point(50, 420), IconChar.PiggyBank, "#3C403D", "#0000ffff",
                "My savings", new Font("Segoe UI", 10, FontStyle.Regular),
                ContentAlignment.MiddleCenter);
            myFixedDeposit.Click += new EventHandler(control.moveCurrentPanel);
        }
        

        private void loadHeader()
        {
            loadCurrentTitle();
        }
        private void loadCurrentTitle()
        {
            currentTitle = new Label();
            Useful.placeLabelInParent(currentTitle, header, new Size(200, 75),
                new Point((header.Width -200) / 2, (header.Height - 75) / 2), "Home", 
                new Font("Segoe UI", 13, FontStyle.Bold), "#39603D");
        }
    }
}
