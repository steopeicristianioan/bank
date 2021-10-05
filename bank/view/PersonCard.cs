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
    public class PersonCard : Panel
    {
        private Label info;
        private IconPictureBox pic;
        private Person person;
        
        public Person Person { get => this.person; set => this.person = value; }
        
        public PersonCard(Person person)
        {
            this.person = person;
            //this.BorderStyle = BorderStyle.Fixed3D;
            //this.BackColor = ColorTranslator.FromHtml("#A3BCB6");
        }

        public void Load()
        {
            loadPic();
            loadLabel();
        }
        private void loadPic()
        {
            pic = new IconPictureBox();
            Useful.placePicBoxInParent(pic, this, new Size(100, 100),
                new Point(10, (this.Height - 100) / 2), IconChar.UserCircle, "#3C403D");
        }
        private void loadLabel()
        {
            info = new Label();
            Useful.placeLabelInParent(info, this, new Size(300, 180), new Point(120, (this.Height - 180) / 2),
                "Name:\n" + person.Name + "\nAccount created:\n" + person.Created_At.ToString("f"),
                new Font("Segoe UI", 12, FontStyle.Regular), "#3C403D");
        }
    }
}
