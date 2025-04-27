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

namespace trzy_gry
{
    public partial class Form3 : Form
    {
        List<List<Card>> arena = new List<List<Card>> { };
        List<Card> deck = new List<Card> { };
        Random rng = new Random();

        List<player> players = new List<player> { };
        //players??
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Form1 formularz)
        {
            InitializeComponent();
            generateTalia();
            this.Size = new Size(1500, 1000);
            
            Shuffle<Card>(deck);
            ShowWarArena();
            this.Click += board_Click;
            System.Diagnostics.Debug.WriteLine(" deck = " + deck.Count);

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
            public int money ;
            public Label nameplate;
            public bool folded ;
            public bool raised;

            public void set(int id, string name, int height, int width, Label template)
            {
                this.id = id;
                this.name = name;
                this.histurn = false;
                this.won = false;
                hand = new List<Card> { };
                playerHeight = height;
                playerWidth = width;
                money = 1000;
                nameplate = template;
                folded = false;
                raised = false;
            }
        }
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
        int turn = 0;

        int arenaLocWidth;
        int arenaLocHeight;
        void ShowWarArena()
        {

            for (int i = 0; i < 5; i++)
            {
                List < Card > temp = new List<Card> { };
                arena.Add(temp);
            }

            for (int i = 0; i < 5; i++)
            {
                arena[i].Add(deck[i]);
               
            }

            arenaLocWidth = this.Width / 2 - (int)(arena[0][0].Width * 2.5) - 50;
            arenaLocHeight = this.Height / 2 - arena[0][0].Height / 2;
            for (int i = 0; i < 5; i++)
            {
                arena[i][0].locationen(arenaLocWidth + 10 * i + arena[0][0].Width * i, arenaLocHeight);
                System.Diagnostics.Debug.WriteLine("arena [" + i + "] arena place = " + arena[i][0].liczba);
                arena[i][0].generateCard2();
                arena[i][0].Visible = true;
                System.Diagnostics.Debug.WriteLine("arena [" + i + "] arena place = " + arena[i][0].liczba);
                //this.Controls.Add(arena[i][0]);
            }

        }


        void startGame()
        {


            bool win = false;


            for (int i = 0; i < 4; i++)
            {
                player temp = new player();
                switch (i)
                {
                    case 0:
                        temp.set(i, "test" + i.ToString(), (int)(this.Width * (0.5) - arena[0][0].Height) +70, 20,player0);
                        break;
                    case 1:
                        temp.set(i, "test" + i.ToString(), 20, (int)(this.Height * (0.5) - arena[0][0].Height), player1);
                        break;
                    case 2:
                        temp.set(i, "test" + i.ToString(), (int)(this.Height * (0.5) - arena[0][0].Height) ,this.Width - arena[0][0].Width*2 - 20, player2);
                        break;
                    case 3:
                        temp.set(i, "test" + i.ToString(),  (int)(this.Height -20 - arena[0][0].Height) ,this.Width - arena[0][0].Width *2- 20, player3);
                        break;
                    default:
                        break;
                }
               
                players.Add(temp);
                //System.Diagnostics.Debug.WriteLine("player ["+i+"] height = " + players[i].playerHeight + "  width = " + players[i].playerWidth +"   "+ ((int)(this.Width / (0.6) * (i % 2))).ToString() );

                

            }
            for (int i = 5; i < 5+players.Count*2; i++)
            {
                deck[i + 10].assignID((i - 5) % 4);
                players[(i - 5) % 4].hand.Add(deck[i+10]);
            }
            System.Diagnostics.Debug.WriteLine(" deck = " + deck.Count);
            for (int i = 0; i < 4; i++)
            {
                spawnhand(players[i]);
                //System.Diagnostics.Debug.WriteLine("player [" + i + "] hand = "+ players[i].hand.Count);
            }



            //while (!win)
            //{
            //    
            //}

            newGameHandler();
        }

        private void card_Click(object sender, EventArgs e)
        {

            Card temp = (Card)sender;

            System.Diagnostics.Debug.WriteLine("player [" + temp.playerID + "] hand = " );

        }

        private void start_Click(object sender, EventArgs e)
        {
            start.Enabled = false;
            start.Visible = false;

            startGame();
        }


        void spawnhand(player current)
        {
            if (current.id == 3)
            {
                for (int i = 0; i < current.hand.Count; i++)
                {
                    current.hand[i].generateCard();
                    current.hand[i].locationen( current.playerWidth + (arena[0][0].Width + 10) * i, current.playerHeight);
                    current.hand[i].Visible = true;
                }
                current.nameplate.Text = "players " + current.id + " money: " + current.money;  
                
                


            }
            else
            {



                for (int i = 0; i < current.hand.Count; i++)
                {

                    current.hand[i].locationen(current.playerWidth + (arena[0][0].Width+10)*i, current.playerHeight);
                    current.hand[i].Visible = true;
                }
                current.nameplate.Text = "players " + current.id + " money: " + current.money;


            }

        }
         
        bool checkIfRaiseOrFold()
        {

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].folded) continue;

                if (players[i].raised)
                {

                }
            }
            return true;
        }
        bool playercanclick = true;

        void revalArena()
        {
            switch (turn)
            {
                case 0:
                    for (int i = 0; i < 3; i++)
                    {
                        arena[i][0].generateCard();
                    }
                    break;
                case 1:
                    arena[3][0].generateCard();
                    break;
                case 2:
                    arena[4][0].generateCard();
                    break;
                case 3:
                default:
                    break;
            }
            
            
        }

        int potValue = 0;
        void newGameHandler() //starting new bet
        {
            currentRaise = 0;
            turn = 0;
            pot.Text = "pot is holding " + potValue;
            playersFolded = 0;
            nextturn();
        }

        void randomChoiceOfPlayers(int start, int stop)
        {
            for (int i = start; i < stop; i++)
            {

                switch (rng.Next() % 3)
                {
                    case 0:
                        
                        foldfun(players[i]);
                        break;
                    case 1:
                        //if (players[i].raised)
                        // callfun(players[i]);
                        checkfun(players[i]);
                        break;
                    case 2:
                        foldfun(players[i]);
                        //risefun(players[i]);
                        break;
                    case 3:
                        checkfun(players[i]);
                        break;
                    default:
                        break;
                }


            }
        }
        void decideWinner()
        {
            pot.Text = "decide winner";
        }
        int playersFolded = 0;
        void nextturn()
        {
                
            if (turn == 3) decideWinner();
            if(playersFolded > 3 ) decideWinner();

            if (turn == 0)
            {
                risefun(players[0]);
                randomChoiceOfPlayers(1,3);
            }
            else
            {
                randomChoiceOfPlayers(0, 3);
            }

          
        }
        int currentRaise = 0;

        void dotest(player current)
        {
            for (int i = 0; i < players.Count-1; i++)
            {
                if (players[i].id != current.id)
                {
                    switch (rng.Next() % 2)
                    {
                        case 0:

                            foldfun(players[i]);
                            break;
                        case 1:
                            //if (players[i].raised)
                            // callfun(players[i]);
                            callfun(players[i]);
                            break;
                       
                        default:
                            break;
                    }
                }
            }

            messege.Text = " do you fold rise or call";
        }

        void foldfun(player current)
        {
            current.nameplate.Text = "player"+ current.id+ " money: "+ current.money + " Folded";
            current.folded = true;
            playersFolded++;
        }
        void callfun(player current)
        {
            if (currentRaise == 0) return;
            potValue += currentRaise;
            pot.Text = "pot: " + potValue;
            current.money = current.money - currentRaise;
            current.nameplate.Text = "player" + current.id + " money: " + current.money + " Called";
        }
        void risefun(player current)
        {
            currentRaise += rng.Next() % 100;
            potValue += currentRaise;
            pot.Text = "pot: " + potValue;
            current.money = current.money - currentRaise;
            current.nameplate.Text = "player" + current.id + " money: " + current.money + " Rised for "+ currentRaise;

            dotest( current);
        
        }
        void checkfun(player current)
        {
            if(currentRaise== 0)current.nameplate.Text = "player" + current.id + " money: " + current.money + " Checked " ;
           

        }

        bool playerturndone = false;
        private void fold_Click(object sender, EventArgs e)
        {
            messege.Text = "";
            if (playercanclick)  foldfun(players[players.Count-1]);
            playercanclick = false;

        }

        private void call_Click(object sender, EventArgs e)
        {
            messege.Text = "";
            if (playercanclick) callfun(players[players.Count - 1]);

            playercanclick = false;

        }

        private void rise_Click(object sender, EventArgs e)
        {
            messege.Text = "";
            if (playercanclick) risefun(players[players.Count - 1]);
                 playercanclick = false;
        }

        private void check_Click(object sender, EventArgs e)
        {
            messege.Text = "";
            if (playercanclick) checkfun(players[players.Count - 1]);
            playercanclick = false;
        }
        private void board_Click(object sender, EventArgs e)
        {
            if (!playercanclick)
            {
                
                revalArena();

                currentRaise = 0;
                turn++;
                playercanclick = true;
                nextturn();

            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
