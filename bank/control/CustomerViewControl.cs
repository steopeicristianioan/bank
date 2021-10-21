using bank.model;
using bank.repository;
using bank.view;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bank.control
{
    public class CustomerViewControl
    {
        private CustomerView view;
        private PersonRepository personRepository;
        private AccountRepository accountRepository;
        private Fixed_DepositRepository depositRepository;

        public CustomerView View { get => this.view; set => this.view = value; }

        public CustomerViewControl(CustomerView view)
        {
            this.view = view;
            this.personRepository = new PersonRepository();
            this.accountRepository = new AccountRepository();
            this.depositRepository = new Fixed_DepositRepository();

            openChild(new HomeView(view.ID, view.Main, personRepository), view.Main);
        }

        public void moveCurrentPanel(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            view.Current.Location = new Point(button.Location.X - 10, button.Location.Y);
            view.CurrentTitle.Text = button.Text;
        }
        public void openChild(Form child, Control parent)
        {
            parent.Controls.Clear();
            child.Parent = parent;
            child.Show();
        }
        public void openHomeView(object sender, EventArgs e)
        {
            openChild(new HomeView(view.ID, view.Main, personRepository), view.Main);
        }
        public void openMyAccountView(object sender, EventArgs e)
        {
            Account account = accountRepository.getByCustomer(view.ID);
            openChild(new MyAccountView(view.ID, view.Main, account), view.Main);
        }
        public void openTransferView(object sender, EventArgs e)
        {
            openChild(new TransferView(view.ID, view.Main, accountRepository), view.Main);
        }
        public void openMySavingView(object sender, EventArgs e)
        {
            openChild(new MySavingView(view.ID, view.Main, depositRepository.getByCustomer(view.ID))
                , view.Main);
        }
    }
}
