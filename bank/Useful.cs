using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using FontAwesome.Sharp;
using System.Windows.Forms;
using System.Drawing;

namespace bank
{
    public static class Useful
    {
        public static string getConnectionString(string connection = "Default")
        {
            string output = "";

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"C:\\C#\\Desktop\\bankApp\\bank\\bank\\")
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connection);
            return output;
        }
        public static void placeIconButtonInParent(IconButton button, Control parent,
             Size size, Point location, IconChar iconChar, string foreColor, string backColor,
             string text, Font font, ContentAlignment alignment)
        {
            button.Parent = parent;
            button.Size = size;
            button.Location = new Point((parent.Width - button.Width) / 2, location.Y);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.MouseDownBackColor = button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button.IconChar = iconChar;
            button.IconColor = button.ForeColor = ColorTranslator.FromHtml(foreColor);
            button.BackColor = ColorTranslator.FromHtml(backColor);
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.Text = text;
            button.Font = font;
            button.ImageAlign = button.TextAlign = alignment;
            button.FlatAppearance.BorderSize = 0;
        }
        public static void placePanelInParent(Panel panel, Control parent, Size size, 
            Point location, string backColor)
        {
            panel.Parent = parent;
            panel.Size = size;
            panel.Location = location;
            panel.BackColor = ColorTranslator.FromHtml(backColor);
        }
        public static void placeLabelInParent(Label label, Control parent, Size size, 
            Point location, string text, Font font, string foreColor)
        {
            label.Parent = parent;
            label.Size = size;
            label.Location = location;
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = font;
            label.BackColor = Color.Transparent;
            label.ForeColor = ColorTranslator.FromHtml(foreColor);
        }
    }
}
