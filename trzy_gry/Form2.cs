using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trzy_gry
{
    public partial class Form2 : Form
    {
        Form1 yep;
        List<Card> deck = new List<Card> { };
        public Form2(Form1 yep)
        {
            InitializeComponent();
            this.AllowDrop = true;
            Card card = new Card(5, 'k');
            card.locationen(100, 100);
            card.Visible = true;
            card.Show();
            //card.Paint += card.image_Click;
          
            card.Click += label1_Click;

            Card card2 = new Card();
            card.locationen(300, 100);
            card.Visible = true;
            card.Show();

            this.Controls.Add(card);
            this.Controls.Add(card2);
            deck.Add(card);
            deck.Add(card2);
            this.yep = yep;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = deck[0].Tag.ToString()+"  "+ deck[0].drageed.ToString();
        }
    }
}
