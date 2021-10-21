using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bank.view;
using FontAwesome.Sharp;

namespace bank
{
    public partial class MainForm : Form
    {
        private Form child;
        public Form Child { get => this.child; set => this.child = value; }

        private IconButton fake = new IconButton();

        public MainForm()
        {
            this.MaximumSize = this.MinimumSize = this.Size = new Size(1250, 750);
            this.CenterToScreen();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            openChild(new CustomerView(172, this));
        }

        private void openChild(Form child)
        {
            if (this.child != null) this.child.Close();
            this.child = child;
            this.child.Show();
        }
    }
}
