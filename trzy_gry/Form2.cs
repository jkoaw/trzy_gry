using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace trzy_gry
{
    public partial class Form2 : Form
    {
        Form1 yep;
        List<Card> deck = new List<Card> { };
        List<List<Card>> arena = new List<List<Card>> { };
        player one;
        player two;
        public Form2(Form1 yep)
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.Size = new Size(1200, 800);
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
            one.set(0, "test1", 20, 20);

            two = new player();
            two.set(1, "test2", this.Height - arena[0][0].Height - 40, this.Width - arena[0][0].Width - 40);

            for (int i = 0; i < deck.Count; i++)
            {


                if (i < 26)
                {
                    deck[i].assignID(one.id);
                    one.hand.Add(deck[i]);
                }
                else
                {
                    deck[i].assignID(two.id);
                    two.hand.Add(deck[i]);
                }
            }
            //System.Diagnostics.Debug.WriteLine("count hand = " + two.hand.Count.ToString() + "count deck = " + deck.Count.ToString());

            bool win = false;
            spawnhand(one);
            spawnhand(two);

            //while (!win)
            //{
            //    
            //}


        }
        int turn = 0;

        int arenaLocWidth;
        int arenaLocHeight;
        void ShowWarArena()
        {

            arena.Add(new List<Card> { });
            arena.Add(new List<Card> { });
            arena[0].Add(new Card());
            arena[1].Add(new Card());

            arenaLocWidth = this.Width / 2 - arena[0][0].Width;
            arenaLocHeight = this.Height / 2 - arena[0][0].Height;
            arena[0][0].locationen(this.Width / 2 - arena[0][0].Width, this.Height / 2 - arena[0][0].Height);



            arena[1][0].locationen(this.Width / 2 + 10, this.Height / 2 - arena[0][0].Height);
            this.Controls.Add(arena[0][0]);
            this.Controls.Add(arena[1][0]);
            arena[0][0].playerID = one.id;
            arena[1][0].playerID = two.id;


        }
        int playerOneHeight;
        int playerTwoHeight;
        int playerOneWidth;
        int playerTwoWidth;
        void spawnhand(player current)
        {
            if (current.id == 0)
            {


                current.hand[0].locationen(20, 20);
                current.hand[0].Visible = true;
                current.hand[0].Refresh();
                playerone.Text = current.hand.Count.ToString();

            }
            else
            {



                playertwo.Text = current.hand.Count.ToString();
                current.hand[0].locationen(this.Width - arena[0][0].Width - 40, this.Height - arena[0][0].Height - 40);
                current.hand[0].Visible = true;
                current.hand[0].Refresh();

            }

        }
        struct player
        {
            public int id;
            public string name;
            public bool histurn;
            public bool won;
            public List<Card> hand;
            public int playerHeight;
            public int playerWidth;

            public void set(int id, string name, int height, int width)
            {
                this.id = id;
                this.name = name;
                this.histurn = false;
                this.won = false;
                hand = new List<Card> { };
                playerHeight = height;
                playerWidth = width;
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
            int j = 0;
            foreach (Card item in deck)
            {
                item.generateCardReverse();
                item.cardID = j;
                item.Click += card_Click;
                this.Controls.Add(item);
                item.Visible = false;
                j++;
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

        void updateDeck(int playerid) //updates hand of the player
        {

            if (playerid == one.id)
            {
                one.hand.Remove(arena[playerid][arena[playerid].Count]); //powinno usunąc karte z decku playera 
                                                                         // one.hand[0].generateCard();
            }

        }
        //#2
        public void OnArenaChanged(int playerid)
        {

            //updateDeck(playerid);

            if (arena[0][arena[0].Count - 1].liczba != 0 && arena[1][arena[1].Count - 1].liczba != 0 && arena[1].Count == arena[0].Count) //spr czy tyle sam kart na stosach oaraz czy nie puste
            {
                //  nextTurn();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Turn: " + turn.ToString();
        }


        void arenarefresh()
        {
            arena[0][arena[0].Count - 1].Visible = true;
            arena[1][arena[0].Count - 1].Visible = true;
            arena[0][arena[0].Count - 1].Refresh();
            arena[1][arena[0].Count - 1].Refresh();

        }




        void moveeWar(player current)
        {
            for (int i = 1; i < arena[0].Count; i++)
            {
                current.hand.Add(arena[0][i]);

            }
            for (int i = arena[0].Count - 1; i >= 1; i--) // moze powinno byc to w funkci :0
            {
                arena[0][i].generateCardReverse();
                arena[0][i].Visible = false;
                arena[0][i].locationen(current.playerWidth, current.playerHeight);
                arena[0].Remove(arena[0][i]);

            }
            for (int i = 1; i < arena[1].Count; i++)
            {
                current.hand.Add(arena[1][i]);

            }
            for (int i = arena[1].Count - 1; i >= 1; i--)
            {
                arena[1][i].generateCardReverse();
                arena[1][i].Visible = false;
                arena[1][i].locationen(current.playerWidth, current.playerHeight);
                arena[1].Remove(arena[1][i]);

            }
        }

        void mowee(player current)
        {
            //System.Diagnostics.Debug.WriteLine("arena[0] befoore add  = " + arena[0][arena[0].Count - 1].liczba + " arena[1] befoore add = " + arena[1][arena[1].Count - 1].liczba);
            current.hand.Add(arena[0][arena[0].Count - 1]);
            arena[0][arena[0].Count - 1].generateCardReverse();
            arena[0][arena[0].Count - 1].locationen(current.playerWidth, current.playerHeight);
            arena[0][arena[0].Count - 1].Visible = false;
            arena[0].Remove(arena[0][arena[0].Count - 1]);

            current.hand.Add(arena[1][arena[0].Count - 1]);
            arena[1][arena[1].Count - 1].locationen(current.playerWidth, current.playerHeight);
            arena[1][arena[1].Count - 1].generateCardReverse();
            arena[1][arena[1].Count - 1].Visible = false;
            arena[1].Remove(arena[1][arena[1].Count - 1]);
        }

        private void endturn_Click(object sender, EventArgs e)
        {
            if (win) return;
            if (arena[0].Count == 1 || arena[0].Count != arena[1].Count) return;
            nextTurn();
        }
        int pl = 0;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Space)
            {
                // Simulate a button click on button1
                endturn.PerformClick();
                // Prevent the Enter key from being added to the TextBox
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.N )
            {
                // Simulate a button click on button1
                EventArgs d = new EventArgs();
                if (pl == 0)
                {
                    card_Click(one.hand[0],d);
                    pl = 1;

                }
                else
                {
                    card_Click(two.hand[0], d);
                    pl = 0;
                }
                
                // Prevent the Enter key from being added to the TextBox
                e.Handled = true;
            }

        }
        bool win = false;


        void nextTurn()
        {
            if (win) return;

            if (one.hand.Count == 0)
            {
                winner.Text = " TWO has won the battle";
                winner.Size = new Size(200, 200);
                winner.Font = new  Font("Arial", 40);
                two.won = true;
                win = true;
            }
            if (two.hand.Count == 0)
            {
                winner.Text = " ONE has won the battle";
                winner.Size = new Size(200, 200);
                winner.Font = new Font("Arial", 40);
                one.won = true;
                win = true;
            }
            
            turn++;

            if(war && warturn%2 == 0)
            {
                waitforclick = true;
                return;
            } 
            if (arena[0][arena[0].Count - 1].liczba == arena[1][arena[1].Count - 1].liczba)
            {
                winner.Text = "WAR";
                war = true;
                warturn++;
                waitforclick = true;
                return;
            }


            if (arena[0][arena[0].Count - 1].liczba > arena[1][arena[1].Count - 1].liczba)
            {
                winner.Text = "one win";
                if (war)
                { //dodac obracanie kart
                    moveeWar(one);
                }
                else //zwykla tura bez wojny 
                {
                    mowee(one);
                }
                playerone.Text = one.hand.Count.ToString();
                war = false;
                warturn = 0;
                
            }
            else
            {
                winner.Text = "two win";
                if (war)
                { //dodac obracanie kart

                    moveeWar(two);
                }
                else //zwykla tura bez wojny 
                {
                    mowee(two);
                }
                playertwo.Text = two.hand.Count.ToString();
                arena[0][0].Visible = true;
                arena[1][0].Visible = true;
                war = false;
                warturn = 0;
                
            }
            waitforclick = true;


        }
        int licznika = 0;
        int licznikb = 0;
        bool war = false;
        int warturn = 0;

        void moveToArena(player current, Card temp)
        {
            arena[current.id].Add(temp);
            if (warturn % 2 == 0)
            {
                arena[current.id][arena[current.id].Count - 1].generateCard();
            }

            if (current.id == 0)
            {
                arena[current.id][arena[current.id].Count - 1].locationen(arenaLocWidth, arenaLocHeight);
            }
            else
            {
                arena[current.id][arena[current.id].Count - 1].locationen(arenaLocWidth + arena[1][0].Width + 10, arenaLocHeight);
            }


            arena[current.id][arena[current.id].Count - 2].Visible = false;
            current.hand[0].Visible = true;
            current.hand[0].locationen(current.playerWidth, current.playerHeight);
        }
        bool waitforclick = true;
        private void card_Click(object sender, EventArgs e)
        {
            if (win) return;
            Card temp = (Card)sender;
            if (!waitforclick) return;
        
            if (temp.playerID == 0)
            {
                if (arena[0].Count > arena[1].Count)
                {
                    return;
                }
            }
            else
            {
                if (arena[0].Count < arena[1].Count)
                {
                    return;
                }
            }
            
            //System.Diagnostics.Debug.WriteLine("player one cord  = " + one.playerHeight+" "+one.playerWidth+"  " + " two cord =  = " + two.playerHeight + " " + two.playerWidth);

            ///działac więcej z deckiem robic i przesuwać tylko karty z decku bawić się z visible
            System.Diagnostics.Debug.WriteLine("testClik");

            //   System.Diagnostics.Debug.WriteLine("arena[0] befoore add  = " + arena[0][arena[0].Count - 1].liczba + " arena[1] befoore add = " + arena[1][arena[1].Count - 1].liczba);
           

            System.Diagnostics.Debug.WriteLine("war = " + war + "warturn = " + warturn);

            if (one.hand.Remove(temp))
            {
                playerone.Text = one.hand.Count.ToString();
                moveToArena(one, temp);
            }
            else
            {
                two.hand.Remove(temp);
                playertwo.Text = two.hand.Count.ToString();
                
                moveToArena(two, temp);
            }
            //System.Diagnostics.Debug.WriteLine("arena[0] after add  = " + arena[0][arena[0].Count - 1].liczba + " arena[1] after add = " + arena[1][arena[1].Count - 1].liczba);
            //System.Diagnostics.Debug.WriteLine("after one del hand = " + one.hand[0].liczba + "after two del hand = " + two.hand[0].liczba);

            if (arena[0].Count != 1 && arena[0].Count == arena[1].Count)
            {
                waitforclick = false;
                if (war)
                {

                    warturn++;
                }
            }



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
