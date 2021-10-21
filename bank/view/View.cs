using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bank.view
{
    public class View : Form
    {
        protected Panel header;
        protected Panel main;
        protected Panel aside;
        protected int person_id;
        public int ID { get => this.person_id; set => this.person_id = value; }

        public Panel Header { get => this.header; set => this.header = value; }
        public Panel Main { get => this.main; set => this.main = value; }
        public Panel Aside { get => this.aside; set => this.aside = value; }

        protected View(int id, Control parent)
        {
            this.person_id = id;

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
            this.Parent = parent;
            this.Size = parent.Size;
            this.BackColor = ColorTranslator.FromHtml("#DADED4");

            header = new Panel();
            main = new Panel();
            aside = new Panel();

            header.Parent = main.Parent = aside.Parent = this;
            header.BorderStyle = main.BorderStyle = aside.BorderStyle = BorderStyle.FixedSingle;
        }

        protected virtual void setHeader() { }
        protected virtual void setMain() { }
        protected virtual void setAside() { }

    }
}
