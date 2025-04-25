using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace trzy_gry
{
    public partial class Form2 : Form
    {
        Form1 yep;
        List<Card> deck = new List<Card> { };
        List<Card> arena = new List<Card> { };
        player one;
        player two;
        public Form2(Form1 yep)
        {
            InitializeComponent();
            this.AllowDrop = true;

            this.yep = yep;
            generateTalia();
            Shuffle<Card>(deck);
            
            
        }
        /// <summary>
        /// trzeba zrobic nastepna ture przemyslec jak dziala arena bo trzeba dodawac w konkrene miejsce lul i musi sie aktualizowac reka gracza wiec musi działac jak areana albo podobnie mam dosc xd
        /// </summary>


        void startGame()
        {
            one = new player(); // nie wiem czemu akurat tak ale no cuz :p
            one.set(0, "test1");
            two = new player();
            two.set(1, "test2");

            for (int i = 0; i < deck.Count; i++)
            {


                if (i < 26)
                {
                    one.hand.Add(deck[i]);
                }
                else
                {
                    two.hand.Add(deck[i]);
                }
            }
            System.Diagnostics.Debug.WriteLine("count hand = " + two.hand.Count.ToString() + "count deck = " + deck.Count.ToString());

            bool win = false;
            spawnhand(one);
            spawnhand(two);
            

            //while (!win)
            //{
            //    
            //}


        }

        void nextTurn()
        {
            if (arena[arena.Count-1].liczba > arena[arena.Count-2].liczba)
            {
                
            }
        }

        void ShowWarArena()
        {

            arena = new List<Card> { };
            arena.Add(new Card());
            arena.Add(new Card());

            arena[0].locationen(this.Width / 2, this.Height / 2);



            arena[1].locationen(this.Width / 2 + arena[0].Width + 10, this.Height / 2);
            this.Controls.Add(arena[0]);
            this.Controls.Add(arena[1]);


        }
        void spawnhand(player current)
        {
            if (current.id == 1)
            {

                current.hand[0].generateCardReverse();
                current.hand[0].locationen(20, 20);
                current.hand[0].Visible = true;
            }
            else
            {


                current.hand[0].generateCardReverse();
                current.hand[0].locationen(this.Width - 20, this.Height - 20);
                current.hand[0].Visible = true;
            }
        }
        struct player
        {
            public int id;
            public string name;
            public bool histurn;
            public bool won;
            public List<Card> hand;
            public void set(int id, string name)
            {
                this.id = id;
                this.name = name;
                this.histurn = false;
                this.won = false;
                hand = new List<Card> { };
            }
        }
        void generateTalia()
        {
            for (int i = 2; i < 15; i++)
            {


                deck.Add(new Card(i, 'k'));
                deck.Add(new Card(i, 's'));
                deck.Add(new Card(i, 't'));
                deck.Add(new Card(i, 'p'));


            }
            foreach (Card item in deck)
            {

                this.Controls.Add(item);
                item.Visible = false;

            }

        }


        Random rng = new Random();
        void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public event System.EventHandler arenachange;

        //#2
        public void OnArenaChanged()
        {
            if (arena[0].liczba != 0 && arena[1].liczba != 0)
            {
                nextTurn();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = deck[0].Tag.ToString() + "  " + deck[0].drageed.ToString();
        }

        private void start_Click(object sender, EventArgs e)
        {
            start.Enabled = false;
            start.Visible = false;
            ShowWarArena();
            startGame();
        }
    }
}
