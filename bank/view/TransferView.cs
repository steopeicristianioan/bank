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
    public class TransferView : View
    {
        private TextBox accNumberInput;
        private TextBox personInput;
        private TextBox moneyInput;
        private IconButton perform;
        private Timer timer;

        private AccountRepository accountRepository;
        private Account from;
        private Account to;

        private string number_Default = "Number of the account you are transfering to:";
        private string person_Default = "Name of the person you are transfering to:";
        private string money_Default = "Amount of money you are transfering ($):";
        private bool okAccNum = true;

        public TransferView(int id, Control parent, AccountRepository accountRepository) : base(id, parent)
        {
            this.accountRepository = accountRepository;
            from = accountRepository.getByCustomer(this.person_id);
            if(from != null)
            {
                timer = new Timer();
                timer.Tick += new EventHandler(this.timer_tick);
                timer.Start();
            }
            
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
            if(from != null)
            {
                loadNumberInput();
                loadPersonInput();
                loadMoneyInput();
                loadPerform();
            }
        }
        private void loadNumberInput()
        {
            accNumberInput = new TextBox();
            Useful.placeTextBoxInParent(accNumberInput, main, 500,
                new Point((main.Width - 500) / 2, 150), new Font("Segoe UI", 15, FontStyle.Regular),
                "#3C403D", BorderStyle.FixedSingle, "#DADED4");
            accNumberInput.Text = number_Default;

            accNumberInput.Click += new EventHandler(this.textBox_Click);
            accNumberInput.MouseLeave += new EventHandler(this.textBox_Leave);
            accNumberInput.TextChanged += new EventHandler(this.accNumber_TextChanged);
        }
        private void loadPersonInput()
        {
            personInput = new TextBox();
            Useful.placeTextBoxInParent(personInput, main, 500,
                new Point((main.Width - 500) / 2, 200), new Font("Segoe UI", 15, FontStyle.Regular),
                "#3C403D", BorderStyle.FixedSingle, "#DADED4");
            personInput.Text = person_Default;

            personInput.Click += new EventHandler(this.textBox_Click);
            personInput.MouseLeave += new EventHandler(this.textBox_Leave);
        }
        private void loadMoneyInput()
        {
            moneyInput = new TextBox();
            Useful.placeTextBoxInParent(moneyInput, main, 500,
                new Point((main.Width - 500) / 2, 250), new Font("Segoe UI", 15, FontStyle.Regular),
                "#3C403D", BorderStyle.FixedSingle, "#DADED4");
            moneyInput.Text = money_Default;

            moneyInput.Click += new EventHandler(this.textBox_Click);
            moneyInput.MouseLeave += new EventHandler(this.textBox_Leave);
        }
        private void textBox_Click(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Equals(accNumberInput) && box.Text == number_Default)
                box.Text = "";
            else if (box.Equals(personInput) && box.Text == person_Default)
                box.Text = "";
            else if (box.Text == money_Default)
                box.Text = "";
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Equals(accNumberInput) && box.Text == "")
                box.Text = number_Default;
            else if (box.Equals(personInput) && box.Text == "")
                box.Text = person_Default;
            else if (box.Text == "")
                box.Text = money_Default;
        }
        private void accNumber_TextChanged(object sender, EventArgs e)
        {
            to = accountRepository.getByNumber(accNumberInput.Text);
            //MessageBox.Show((to == null).ToString());
            if (accNumberInput.Text == from.Number)
                okAccNum = false;
            else okAccNum = true;
        }
        private void loadPerform()
        {
            perform = new IconButton();
            Useful.placeIconButtonInParent(perform, main, new Size(500, 300),
                new Point((main.Width - 500) / 2, 350), IconChar.ThumbsUp, "#A3BCB6",
                "#0000ffff", "Perform transaction", new Font("Segoe UI", 18, FontStyle.Regular),
                ContentAlignment.MiddleCenter);

            perform.Click += new EventHandler(this.perform_Click);
        }
        private void perform_Click(object sender, EventArgs e)
        {
            if (perform.ForeColor == ColorTranslator.FromHtml("#39603D"))
            {
                accountRepository.makeTransfer(from, to, moneyInput.Text);

                accNumberInput.Text = number_Default;
                personInput.Text = person_Default;
                moneyInput.Text = money_Default;

                MessageBox.Show("The transaction has been successfully done!");
            }
        }
        bool checkInputs()
        {
            if (to == null)
                return false;
            if (!okAccNum)
                return false;
            long number;
            double sum;
            if (accNumberInput.Text == number_Default || personInput.Text == person_Default || moneyInput.Text == money_Default)
                return false;
            if (!long.TryParse(accNumberInput.Text, out number))
                return false;
            if (long.TryParse(personInput.Text, out long aux) || personInput.Text.Length < 5)
                return false;
            if (!double.TryParse(moneyInput.Text, out sum) || sum > double.Parse(from.Balance))
                return false;
            return true;
        }
        private void timer_tick(object sener, EventArgs e)
        {
            bool ok = checkInputs();
            if (ok)
                perform.ForeColor = perform.IconColor = ColorTranslator.FromHtml("#39603D");
            else perform.ForeColor = perform.IconColor = ColorTranslator.FromHtml("#A3BCB6");
        }
    }
}
