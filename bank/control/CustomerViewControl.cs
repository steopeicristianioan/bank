using bank.view;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.control
{
    public class CustomerViewControl
    {
        private CustomerView view;
        public CustomerView View { get => this.view; set => this.view = value; }

        public CustomerViewControl(CustomerView view)
        {
            this.view = view;
        }

        public void moveCurrentPanel(object sender, EventArgs e)
        {
            IconButton button = (IconButton)sender;
            view.Current.Location = new Point(button.Location.X - 10, button.Location.Y);
            view.CurrentTitle.Text = button.Text;
        }
    }
}
