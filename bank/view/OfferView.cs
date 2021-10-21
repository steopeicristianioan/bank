using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FontAwesome.Sharp;
using bank.repository;
using bank.model;

namespace bank.view
{
    public class OfferView : View
    {
        private Fixed_DepositRepository fixed_DepositRepository = new Fixed_DepositRepository();
        public Fixed_DepositRepository F_Repo { get => this.fixed_DepositRepository; set => this.fixed_DepositRepository = value; }

        private TextBox amount;
        private TextBox percent;
        private TextBox period;
        private IconButton generate;
        private IconButton ok;
        private Label contract;
        private Timer timer;

        string percent_default = "% of your monthly income will be deposited";
        string amount_default = "Base amount of money that you will deposit";
        string period_default = "Number of months that you will be depositing for";

        string a = "";
        string peri = "";
        string perc = "";
        string inter_ = "";

        public OfferView(int id, Control parent) : base(id, parent)
        {
            setHeader();
            setAside();
            setMain();

            loadMain();
            timer = new Timer();
            timer.Tick += timer_tick;
            timer.Start();
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
            loadAmount();
            loadPercent();
            loadPeriod();
            loadGenerate();
        }
        private void loadAmount()
        {
            amount = new TextBox();
            Useful.placeTextBoxInParent(amount, main, 500,
                new Point((main.Width - 500) / 2, 200), new Font("Segoe UI", 15, FontStyle.Regular),
                "#3C403D", BorderStyle.FixedSingle, "#DADED4");
            amount.Text = amount_default;

            amount.Click += new EventHandler(textbox_click);
            amount.Leave += new EventHandler(textbox_leave);
        }
        private void loadPercent()
        {
            percent = new TextBox();
            Useful.placeTextBoxInParent(percent, main, 500, 
                new Point((main.Width - 500) / 2, 250), new Font("Segoe UI", 15, FontStyle.Regular),
                "#3C403D", BorderStyle.FixedSingle, "#DADED4");
            percent.Text = percent_default;

            percent.Click += new EventHandler(textbox_click);
            percent.Leave += new EventHandler(textbox_leave);
        }
        private void loadPeriod()
        {
            period = new TextBox();
            Useful.placeTextBoxInParent(period, main, 500,
                new Point((main.Width - 500) / 2, 300), new Font("Segoe UI", 15, FontStyle.Regular),
                "#3C403D", BorderStyle.FixedSingle, "#DADED4");
            period.Text = period_default;

            period.Click += new EventHandler(textbox_click);
            period.Leave += new EventHandler(textbox_leave);
        }
        private void loadGenerate()
        {
            generate = new IconButton();
            Useful.placeIconButtonInParent(generate, main, new Size(400, 100),
                new Point((main.Width - 400) / 2, 450), IconChar.FileSignature, "#A3BCB6", "#0000ffff",
                "Generate offer", new Font("Segoe UI", 18, FontStyle.Regular),
                ContentAlignment.MiddleCenter);

            generate.Click += new EventHandler(generate_click);
        }
        private bool checkInputs()
        {
            if (period.Text == period_default || amount.Text == amount_default || percent.Text == percent_default)
                return false;
            if (!double.TryParse(percent.Text, out double per) || !int.TryParse(period.Text, out int peri) || !double.TryParse(amount.Text, out double amm))
                return false;
            return true;
        }
        private void timer_tick(object sender, EventArgs e)
        {
            bool ok = checkInputs();
            if (ok)
                generate.ForeColor = generate.IconColor = ColorTranslator.FromHtml("#39603D");
            else generate.ForeColor = generate.IconColor = ColorTranslator.FromHtml("#A3BCB6");
        }
        private void textbox_click(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Equals(amount) && box.Text == amount_default)
                box.Text = "";
            else if (box.Equals(percent) && box.Text == percent_default)
                box.Text = "";
            else if (box.Text == period_default)
                box.Text = "";
        }
        private void textbox_leave(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Equals(amount) && box.Text == "")
                box.Text = amount_default;
            else if (box.Equals(percent) && box.Text == "")
                box.Text = percent_default;
            else if (box.Text == "")
                box.Text = period_default;
        }

        private void generate_click(object sender, EventArgs e)
        {
            if (generate.ForeColor.Equals(ColorTranslator.FromHtml("#39603D")))
            {
                timer.Stop();
                Fixed_DepositOffer offer = fixed_DepositRepository.generateOffer(double.Parse(percent.Text), amount.Text);
                loadContract(offer.Interest_Rate);
            }
        }
        private void loadOK()
        {
            ok = new IconButton();
            Useful.placeIconButtonInParent(ok, main, new Size(210, 100),
                new Point((main.Width - 300) / 2, 450),
                IconChar.Check, "#39603D", "#0000ffff", "CONFIRM",
                new Font("Segoe UI", 15, FontStyle.Regular), ContentAlignment.MiddleLeft);
            ok.Click += new EventHandler(ok_click);
        }
        private void loadContract(double interest_rate)
        {
            a = amount.Text;
            perc = percent.Text;
            peri = period.Text;
            inter_ = interest_rate.ToString();

            main.Controls.Clear();

            contract = new Label();
            Useful.placeLabelInParent(contract, main, new Size(500, 400),
                new Point((main.Width - 500) / 2, (main.Height - 500) / 2), "",
                new Font("Segoe UI", 12, FontStyle.Regular), "#39603D");

            contract.Text = "We are offering you the following offer: \n" +
                "For depositing a base ammount of " + a + " $ for " + peri + " months, " +
                "and depositing " + perc + " % of your income monthly; we can provide your " +
                "fixed deposit with an interest rate of " + inter_ + " %. If " +
                "you are willing to accept this non-negociable offer, please click the CONFIRM button " +
                "below and start your fixed deposit now.";

            loadOK();
        }
        private void ok_click(object sender, EventArgs e)
        {
            double perce = double.Parse(perc);
            int perio = int.Parse(peri);
            double i = double.Parse(inter_);

            Fixed_Deposit deposit = new Fixed_Deposit(-1, this.ID, 
                (int.Parse(fixed_DepositRepository.Last_Number) + 1).ToString(), "fixed", a, 
                DateTime.Now, a, perio, perce, i);

            fixed_DepositRepository.add(deposit);
            this.Visible = false;
        }
    }
}
