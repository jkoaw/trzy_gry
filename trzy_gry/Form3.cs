using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            this.Click += board_new_rozdanie_Click;
            this.Click += board_wait_Click;
            //System.Diagnostics.Debug.WriteLine(" deck = " + deck.Count);

        }

        class player
        {
            public int id;
            public string name;
            public bool histurn;
            public bool won;
            public List<Card> hand;
            public int playerHeight;
            public int playerWidth;
            public int money;
            public Label nameplate;
            public bool folded;
            public bool raised;

            public HandRank handrank;
            public int handranknumber;


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

            public void setMoney(int moneychange){
                money = moneychange;
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
                item.playerID = 999;
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
                //System.Diagnostics.Debug.WriteLine("arena [" + i + "] arena place = " + arena[i][0].liczba);
                arena[i][0].generateCard2();
                arena[i][0].Visible = true;
               // System.Diagnostics.Debug.WriteLine("arena [" + i + "] arena place = " + arena[i][0].liczba);
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
            //System.Diagnostics.Debug.WriteLine(" deck = " + deck.Count);
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
                    current.hand[i].playerID = current.id;
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
                    current.hand[i].playerID = current.id;
                    current.hand[i].generateCardReverse();
                    current.hand[i].locationen(current.playerWidth + (arena[0][0].Width+10)*i, current.playerHeight);
                    current.hand[i].Visible = true;
                }
                current.nameplate.Text = "players " + current.id + " money: " + current.money;


            }

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
            for (int i = 0; i < players.Count; i++)
            {
                players[i].folded = false;
            }
            currentRaise = 0;
            turn = 0;
            potValue = 0;
            factualnextturnclick = false;
            pot.Text = "pot is holding " + potValue;
            playersFolded = 0;
            playercanclick = true;
            waitTillNextTurn = false;
            nextturn();
        }

        void randomChoiceOfPlayers(int start, int stop)
        {
            for (int i = start; i < stop; i++)
            {
                if (players[i].folded)
                {
                    continue;
                }
                switch (rng.Next() % 6)
                {
                    case 0:
                        
                        foldfun(players[i]);
                        break;
                    case 1:
                        //if (players[i].raised)
                        // callfun(players[i]);
                        if(currentRaise > 0) callfun(players[i]);
                        checkfun(players[i]);
                        break;
                    case 2:
                        if (currentRaise > 0) callfun(players[i]);
                        if(turn != 3 )risefun(players[i]);
                        else checkfun(players[i]);
                        break;
                    case 3:
                        if (currentRaise > 0) callfun(players[i]);
                        checkfun(players[i]);
                        break;
                    case 4:
                        if (currentRaise > 0) callfun(players[i]);
                        checkfun(players[i]);
                        break;
                    case 5:
                        if (currentRaise > 0) callfun(players[i]);
                        checkfun(players[i]);
                        break;
                    default:
                        break;
                }


            }
        }


        public enum HandRank
        {
           HighCard, OnePair, TwoPair, ThreeOfAKind,
            Straight, Flush, FullHouse, FourOfAKind,
            StraightFlush, RoyalFlush
        }

        

        void evalute(List<Card> temp,player current)
        {
            
            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < temp.Count; j++)
                {

                    if (temp[i].liczba > temp[j].liczba)
                    {
                        Card var2 = temp[i];
                        temp[i] = temp[j];
                        temp[j] = var2;
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine(" player[" + current.id + "] ------------------------------------------------------------");
         
            System.Diagnostics.Debug.WriteLine("player["+current.id+"] hand + arena " + temp[0].liczba +" "+ temp[1].liczba + " " + temp[2].liczba + " " + temp[3].liczba + " " + temp[4].liczba + " " + temp[5].liczba + " " + temp[6].liczba);


            bool haveplayerscard = false;
            //Royal Flush------------------------------------------------------------
            int licznik = 0;
            for (int i = 0; i < temp.Count-1; i++)
            {
                if (14 == temp[0].liczba)
                {
                    if (temp[i].liczba == temp[i + 1].liczba + 1 && temp[i].znaczek == temp[i + 1].znaczek)
                    {
                        licznik++;
                        if (temp[i].playerID == current.id || temp[i + 1].playerID == current.id) haveplayerscard = true;
                        if (licznik == 4) break;
                    }
                }
                else break;
             
            }
            System.Diagnostics.Debug.WriteLine("Royal Flush  licznik =  " + licznik);
            if (licznik >= 4 && haveplayerscard) { current.handrank = HandRank.RoyalFlush; return; }
            licznik = 0;
            haveplayerscard = false;
            //Straight Flush------------------------------------------------------------
            for (int i = 0; i < temp.Count - 1; i++)
            {              
                if (temp[i].liczba == temp[i + 1].liczba + 1 && temp[i].znaczek == temp[i + 1].znaczek)
                {
                    licznik++;
                    if (temp[i].playerID == current.id || temp[i+1].playerID == current.id) haveplayerscard = true;
                }
            

            }
            System.Diagnostics.Debug.WriteLine("Straight Flush  licznik =  " + licznik);
            
            if (licznik >= 4 && haveplayerscard) { current.handrank = HandRank.StraightFlush; current.handranknumber = temp[0].liczba; return; }
            haveplayerscard = false;
            licznik = 0;
            //Four of a Kind------------------------------------------------------------
            for (int i = 0; i < temp.Count - 1; i++)
            {
                if (temp[i].liczba == temp[i + 1].liczba)
                {
                    licznik++;
                    if (temp[i].playerID == current.id || temp[i + 1].playerID == current.id) haveplayerscard = true;
                    if (licznik == 3) break;
                }
                else licznik = 0;
                
            }
            System.Diagnostics.Debug.WriteLine("Four of a Kind  licznik =  " + licznik);
            if (licznik == 3 && haveplayerscard) { current.handrank = HandRank.FourOfAKind; current.handranknumber = temp[0].liczba; return; }
            licznik = 0;
            int licznik2 = 0;
            int wynik = 0;
            haveplayerscard = false;
            //Full House------------------------------------------------------------
            int var = 0;
            for (int i = 0; i < temp.Count - 1; i++)
            {
                if (temp[i].liczba == temp[i + 1].liczba && licznik2==0) //jezeli drugapara lub 3 jeszcze nie policzona
                {
                    var = i;
                    licznik++;
                    wynik += temp[i].liczba;
                    if (temp[i].playerID == current.id || temp[i + 1].playerID == current.id) haveplayerscard = true;
                }
                if (temp[i].liczba == temp[i + 1].liczba && temp[var].liczba != temp[i].liczba)
                {
                    licznik2++;
                    wynik += temp[i].liczba;
                    if (temp[i].playerID == current.id || temp[i + 1].playerID == current.id) haveplayerscard = true;
                }
               
            }
            System.Diagnostics.Debug.WriteLine("Full House licznik =  " + licznik+ " licznik 2 = "+ licznik2);
            if ((licznik == 2 || licznik >= 1) && (licznik2 == 3 || licznik2 >= 1) && haveplayerscard) { current.handrank = HandRank.FullHouse; current.handranknumber = wynik; return; } //mabe player extension maybe 1 lub  2 ten wynik uhh
            licznik = 0;
            var = 0;
            licznik2 = 0;
            wynik = 0;
            haveplayerscard = false;
            //Flush------------------------------------------------------------
            for (int i = 0; i < temp.Count - 1; i++)
            {
                if (temp[i].znaczek == temp[i + 1].znaczek ) 
                {
                    licznik++;
                    wynik += temp[i].liczba;
                    if (temp[i].playerID == current.id || temp[i + 1].playerID == current.id) haveplayerscard = true;
                }
               
            }
            System.Diagnostics.Debug.WriteLine("Flush licznik =  " + licznik);
            if ((licznik >= 4 ) && haveplayerscard) { current.handrank = HandRank.Flush; current.handranknumber = wynik; return; } 
            licznik = 0;
            licznik2 = 0;
            wynik = 0;
            haveplayerscard = false;
            //Straight------------------------------------------------------------
            for (int i = 0; i < temp.Count - 1; i++)
            {
                if (temp[i].liczba == temp[i + 1].liczba +1) 
                {
                    licznik++;
                    wynik += temp[i].liczba;
                    if (temp[i].playerID == current.id || temp[i + 1].playerID == current.id) haveplayerscard = true;
                    if (licznik == 4) break;
                  
                }
                else
                {
                    licznik = 0;
                    wynik = 0;
                    if (temp[i].playerID == current.id || temp[i + 1].playerID == current.id) haveplayerscard = true;
                }

            }
            System.Diagnostics.Debug.WriteLine("Straight licznik =  " + licznik);
            if ((licznik >= 4) && haveplayerscard) { current.handrank = HandRank.Straight; current.handranknumber = wynik; return; } 
            licznik = 0;
            licznik2 = 0;
            wynik = 0;
            haveplayerscard = false;
            // Three of a Kind------------------------------------------------------------ bugg zał liczba dwie 6 jako i w dodatku krówl xd
            for (int i = 0; i < temp.Count - 1; i++)
            {
                if (temp[i].liczba == temp[i + 1].liczba)
                {
                    licznik++;
                    wynik = temp[i].liczba;
                    if (temp[i].playerID == current.id || temp[i + 1].playerID == current.id) haveplayerscard = true;
                    if (licznik == 2) break;
                }
                else { licznik = 0; wynik = 0; } 

            }
            System.Diagnostics.Debug.WriteLine("Three of a Kind licznik =  " + licznik);
            if ((licznik >= 2) && haveplayerscard) { current.handrank = HandRank.ThreeOfAKind; current.handranknumber = wynik; return; } 
            licznik = 0;
            licznik2 = 0;
            wynik = 0;
            haveplayerscard = false;
            // Two Pair------------------------------------------------------------
            for (int i = 0; i < temp.Count - 1; i++)
            {
                if (temp[i].liczba == temp[i + 1].liczba && licznik2 == 0) 
                {
                    var = i;
                    licznik++;
                    if (temp[i].playerID == current.id || temp[i + 1].playerID == current.id) haveplayerscard = true;
                    wynik += temp[i].liczba;
                }
                if (temp[i].liczba == temp[i + 1].liczba && temp[var].liczba != temp[i].liczba)
                {
                    licznik2++;
                    wynik += temp[i].liczba;
                    if (temp[i].playerID == current.id || temp[i + 1].playerID == current.id) haveplayerscard = true;
                }

            }
            System.Diagnostics.Debug.WriteLine("Two Pair licznik =  " + licznik + " licznik 2 = " + licznik2);
            if (((licznik == 1) && ( licznik2 >= 1)) || (licznik == 2) && haveplayerscard) { current.handrank = HandRank.TwoPair; current.handranknumber = wynik; return; } 
            licznik = 0;
            licznik2 = 0;
            wynik = 0;
            haveplayerscard = false;
            // One Pair------------------------------------------------------------
            for (int i = 0; i < temp.Count - 1; i++)
            {
                if (temp[i].liczba == temp[i + 1].liczba)
                {
                   
                    licznik++;
                    wynik += temp[i].liczba;
                    if (temp[i].playerID == current.id || temp[i + 1].playerID == current.id) haveplayerscard = true;
                }
               

            }
            System.Diagnostics.Debug.WriteLine("One Pair licznik =  " + licznik );
            if ((licznik == 1) && haveplayerscard) { current.handrank = HandRank.OnePair; current.handranknumber = wynik; return; }
            licznik = 0;
            licznik2 = 0;
            wynik = 0;
            haveplayerscard = false;
            // One Pair------------------------------------------------------------
            current.handrank = HandRank.HighCard;
            if (current.hand[0].liczba > current.hand[1].liczba)
            {
                current.handranknumber = current.hand[0].liczba;
            }
            else
            {
                current.handranknumber = current.hand[1].liczba;
            }


                return; // z ręki ???

            // 3 te same i 2 nie wykrywa 3+2 pot trza naprawic dodawanie do raczej xdD nie wykrywa par 
        }

        void whoWon()
        {
            
            int winner = -1;
            List<int> tie = new List<int> { };
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].folded) continue;
                if (winner == -1) { winner = i; continue; }
                

                if (players[i].handrank == players[winner].handrank)
                {
                    if(players[i].handranknumber > players[winner].handranknumber)
                    {
                        winner = i;
                    } else  if (players[i].handranknumber == players[winner].handranknumber)
                    {

                        tie.Add(winner);
                        tie.Add(i);
                    }
                }


                if (players[i].handrank > players[winner].handrank)
                {
                    winner = i;
                }
                
            }
            System.Diagnostics.Debug.WriteLine("tie count " + tie.Count);
            if (tie.Count >0)
            {
                pot.Text = " tie  with";
                foreach (int item in tie)
                {
                    players[item].money += (int)(potValue / tie.Count); // wiem że są krajne przypadki albo nie nie wiem
                    pot.Text +=  " player " + players[winner].id;
                }
            }
            else
            {
                players[winner].money += potValue;
                pot.Text = " winner  player" + players[winner].id;
            }
            System.Diagnostics.Debug.WriteLine("winner " + winner);

        }

        bool waitTillNextTurn = false;

        void showCards(int var)
        {
            System.Diagnostics.Debug.WriteLine("player[" + var + "] liczba = " + players[var].handrank + " wartosc = " + players[var].handranknumber);
            for (int i = 0; i < players[var].hand.Count; i++)
            {
                players[var].hand[i].generateCard();
                
            }
            
            
        }

        void decideWinner()
        {
            List<Card> temp = new List<Card> { };
           // System.Diagnostics.Debug.WriteLine("arena count = " + arena.Count);
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].folded) continue;

                
                for (int j = 0; j < players[i].hand.Count; j++)
                {
                    temp.Add(players[i].hand[j]);
                }
                for (int j = 0; j < arena.Count; j++)
                {
                    //System.Diagnostics.Debug.WriteLine("arena "+j+"count " + arena[j].Count);
                    temp.Add(arena[j][0]);
                }
                evalute(temp, players[i]);
                showCards(i);
                temp.Clear();
            }
            whoWon();
            
            waitTillNextTurn = true;
        }




        int playersFolded = 0;
        void nextturn()
        {

            if (turn == 3) { System.Diagnostics.Debug.WriteLine("turn 3  decide Winner" ); decideWinner(); return; }
            if(playersFolded >= 3 ) { System.Diagnostics.Debug.WriteLine("folded > 3  decide Winner"); decideWinner(); return; }

            if (turn == 0)
            {
                risefun(players[0]);
               // randomChoiceOfPlayers(1,3);
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
                if (players[i].id != current.id && !players[i].folded)
                {
                    switch (rng.Next() % 10)
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
                            callfun(players[i]);
                            break;
                    }
                }
            }

            messege.Text = " do you fold rise or call";
        }


        
        void foldfun(player current)
        {
            int folded = 0;
            for (int i = 0; i < players.Count; i++) if (players[i].folded) folded++;
            if (folded >= 3) { System.Diagnostics.Debug.WriteLine("folded fun  decide Winner"); decideWinner(); }
            current.nameplate.Text = "player"+ current.id+ " money: "+ current.money + " Folded";
            current.folded = true;
            playersFolded++;
        }
        void callfun(player current)
        {
            if (currentRaise == 0) return;
            potValue += currentRaise;
            pot.Text = "pot: " + potValue;
            players[current.id].setMoney(current.money - currentRaise);
            //System.Diagnostics.Debug.WriteLine("player [" + current.id + "] called money = " + current.money);
            current.nameplate.Text = "player" + current.id + " money: " + current.money + " Called";

           
            
        }
        //raise bota w ost funkcji cos sie dzieje
        void risefun(player current)
        {
            currentRaise += rng.Next() % 100;
            potValue += currentRaise;
            pot.Text = "pot: " + potValue;

            players[current.id].setMoney(current.money - currentRaise);

           // System.Diagnostics.Debug.WriteLine("player [" + current.id + "] rised money = " + current.money);
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
            if (turn == 3) return;
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
            if (waitTillNextTurn) return;
            for (int i = 0; i < players.Count; i++)
            {
             //   System.Diagnostics.Debug.WriteLine("player [" + i + "] money = " + players[i].money);
            }
            
            if (!playercanclick)
            {
                
                revalArena();

                currentRaise = 0;
                turn++;
                playercanclick = true;
                nextturn();

            }
        }
        private void board_wait_Click(object sender, EventArgs e)
        {
            if (!waitTillNextTurn) return;
            messege.Text = "click somwhere ";
            factualnextturnclick = true;
        }

        bool factualnextturnclick = false;
        private void board_new_rozdanie_Click(object sender, EventArgs e)
        {
            if (!factualnextturnclick) return;
            System.Diagnostics.Debug.WriteLine("-------------------------");
            System.Diagnostics.Debug.WriteLine("nowe rozdanie");

            //resetownie rąk

            for (int i = 0; i < players.Count ; i++)
            {
                for (int j = 0; j < players[i].hand.Count; j++)
                {
                    players[i].hand[j].playerID = 999;
                }
                players[i].hand.Clear();
            }
            for (int i = 0; i < arena.Count; i++)
            {

                arena[i].Clear();
            }

            for (int i = 0; i < deck.Count; i++)
            {
                deck[i].Visible = false;
            }

            arena.Clear(); //:[

            Shuffle<Card>(deck);
            Shuffle<Card>(deck);


            ShowWarArena();
            for (int i = 5; i < 5 + players.Count * 2; i++)
            {
               
                players[(i - 5) % 4].hand.Add(deck[i + 10]);
            }
     
            for (int i = 0; i < 4; i++)
            {
                
                spawnhand(players[i]);
                //System.Diagnostics.Debug.WriteLine("player [" + i + "] hand = "+ players[i].hand.Count);
            }

            newGameHandler();


        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
