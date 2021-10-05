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
    public class HomeView : View
    {
        private IconPictureBox pic;
        private PersonCard card;
        private PersonRepository personRepository;
        private Label welcome;

        public HomeView(int id, Control parent, PersonRepository personRepository) : 
            base(id, parent)
        {
            this.personRepository = personRepository;

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
            loadWelcome();
            loadPicBox();
            loadCard();
        }
        private void loadWelcome()
        {
            welcome = new Label();
            Useful.placeLabelInParent(welcome, main, new Size(500, 100),
                new Point((main.Width - 500) / 2, 50), "Thank you for using this app!",
                new Font("Segoe UI", 14, FontStyle.Bold), "#39603D");
        }
        private void loadPicBox()
        {
            pic = new IconPictureBox();
            Useful.placePicBoxInParent(pic, main, new Size(200, 200),
                new Point(main.Width - 300, (main.Height - 200) / 2), 
                IconChar.University, "#3C403D");
        }
        private void loadCard()
        {
            card = new PersonCard(personRepository.getById(person_id));
            Useful.placeControlInParent(card, main, new Size(500, 300),
                new Point(50, (main.Height - 300) / 2));
            card.Load();
        }
    }
}
