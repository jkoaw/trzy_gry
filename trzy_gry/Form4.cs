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
    public partial class Form4 : Form
    {
        int finals = 0;
        karty_pas doprzs;
        Form1 parent;
        List<PictureBox> finalne = new List<PictureBox>();
        List<PictureBox> kolumny = new List<PictureBox>();
        List<List<karty_pas>> co_na_kolumnach = new List<List<karty_pas>>();
        List<karty_pas> talia = new List<karty_pas>();
        Image tyl;
        class karty_pas : Card
        {
            public int column = -1;
            public karty_pas wsk;
            public Image twarz;
            public int status = 1;
            public karty_pas()
            {
                return;
            }
            public karty_pas(int poz, char zna, string pom)
            {
                //System.Diagnostics.Debug.WriteLine("powiedzmy dzila");
                this.cardwidth = 80;
                this.cardheight = 190;
                this.liczba = poz;
                this.znaczek = zna;
                generateCard();
                this.twarz = this.Image;
            }
        }
        public Form4(Form1 par)
        {
            System.Diagnostics.Debug.WriteLine("tutaj");
            parent = par;
            InitializeComponent();
            string temp = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            tyl = Image.FromFile(temp + "/res/" + "logo.png");
            button_next_wave.Image = tyl;
            finalne.Add(final1);
            finalne.Add(final2);
            finalne.Add(final3);
            finalne.Add(final4);
            finalne.Add(final5);
            finalne.Add(final6);
            finalne.Add(final7);
            finalne.Add(final8);
            kolumny.Add(column1);
            co_na_kolumnach.Add(new List<karty_pas>());
            kolumny.Add(column2);
            co_na_kolumnach.Add(new List<karty_pas>());
            kolumny.Add(column3);
            co_na_kolumnach.Add(new List<karty_pas>());
            kolumny.Add(column4);
            co_na_kolumnach.Add(new List<karty_pas>());
            kolumny.Add(column5);
            co_na_kolumnach.Add(new List<karty_pas>());
            kolumny.Add(column6);
            co_na_kolumnach.Add(new List<karty_pas>());
            kolumny.Add(column7);
            co_na_kolumnach.Add(new List<karty_pas>());
            kolumny.Add(column8);
            co_na_kolumnach.Add(new List<karty_pas>());
            kolumny.Add(column9);
            co_na_kolumnach.Add(new List<karty_pas>());
            kolumny.Add(column10);
            co_na_kolumnach.Add(new List<karty_pas>());
            generateTalia();
            losuj_poczatek();


        }

        void generateTalia()
        {
            karty_pas nowy;
            for (int i = 2; i < 15; i++)
            {
                nowy = new karty_pas(i, 'k', "true");
                nowy.Click += karta_click;
                talia.Add(nowy);
                nowy = new karty_pas(i, 'k', "true");
                nowy.Click += karta_click;
                talia.Add(nowy);
                nowy = new karty_pas(i, 's', "true");
                nowy.Click += karta_click;
                talia.Add(nowy);
                nowy = new karty_pas(i, 's', "true");
                nowy.Click += karta_click;
                talia.Add(nowy);
                nowy = new karty_pas(i, 't', "true");
                nowy.Click += karta_click;
                talia.Add(nowy);
                nowy = new karty_pas(i, 't', "true");
                nowy.Click += karta_click;
                talia.Add(nowy);
                nowy = new karty_pas(i, 'p', "true");
                nowy.Click += karta_click;
                talia.Add(nowy);
                nowy = new karty_pas(i, 'p', "true");
                nowy.Click += karta_click;
                talia.Add(nowy);
                //talia.Add(new karty_pas(i, 'k'));
                //talia.Add(new karty_pas(i, 's'));
                //talia.Add(new karty_pas(i, 't'));
                //talia.Add(new karty_pas(i, 'p'));


            }

        }
        void losuj_poczatek()
        {
            int los;
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                los = rand.Next(0, talia.Count);
                for (int j = 0; j < 10; j++)
                {
                    los = rand.Next(0, talia.Count);
                    if (i < 4)
                    {
                        talia[los].generateCardReverse();
                        talia[los].status = 0;
                    }
                    if (i == 4 && j < 4)
                    {
                        talia[los].generateCardReverse();
                        talia[los].status = 0;
                    }
                    talia[los].column = j;
                    this.Controls.Add(talia[los]);
                    talia[los].BringToFront();
                    talia[los].Location = new Point(kolumny[j].Location.X, kolumny[j].Location.Y + 20 * co_na_kolumnach[j].Count);
                    co_na_kolumnach[j].Add(talia[los]);
                    if (co_na_kolumnach[j].Count > 1)
                    {
                        co_na_kolumnach[j][co_na_kolumnach[j].Count - 2].wsk = co_na_kolumnach[j][co_na_kolumnach[j].Count - 1];
                    }
                    talia.Remove(talia[los]);
                    if (i > 0)
                    {
                        co_na_kolumnach[j][co_na_kolumnach[j].Count - 2].wsk = co_na_kolumnach[j][co_na_kolumnach[j].Count - 1];
                    }
                }
            }
            for (int j = 0; j < 4; j++)
            {
                los = rand.Next(0, talia.Count);
                talia[los].column = j;
                this.Controls.Add(talia[los]);
                talia[los].BringToFront();
                talia[los].Location = new Point(kolumny[j].Location.X, kolumny[j].Location.Y + 20 * co_na_kolumnach[j].Count);
                co_na_kolumnach[j].Add(talia[los]);
                talia.Remove(talia[los]);
                co_na_kolumnach[j][co_na_kolumnach[j].Count - 2].wsk = co_na_kolumnach[j][co_na_kolumnach[j].Count - 1];

            }
        }

        private void button_next_wave_Click(object sender, EventArgs e)
        {
            int los;
            Random rand = new Random();
            //this.Controls.Add(nazwa);
            if (talia.Count >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    los = rand.Next(0, talia.Count);
                    talia[los].column = i;
                    this.Controls.Add(talia[los]);
                    talia[los].BringToFront();
                    talia[los].Location = new Point(kolumny[i].Location.X, kolumny[i].Location.Y + 20 * co_na_kolumnach[i].Count);
                    co_na_kolumnach[i].Add(talia[los]);
                    talia.Remove(talia[los]);
                    co_na_kolumnach[i][co_na_kolumnach[i].Count - 2].wsk = co_na_kolumnach[i][co_na_kolumnach[i].Count - 1];

                }
            }
            else
            {

            }
            if (talia.Count == 0)
            {
                button_next_wave.Image = null;
            }
        }
        private void karta_click(object sender, EventArgs e)
        {

            if (doprzs == null)
            {
                karty_pas pom = sender as karty_pas;
                System.Diagnostics.Debug.WriteLine("przypisanie");
                doprzs = pom;
                doprzs.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("sprawdznie");
                if (doprzs.wsk == null)
                {
                    karty_pas pom = sender as karty_pas;
                    int kolumna_docelowa = pom.column;
                    if (doprzs.liczba != 14)
                    {
                        if (co_na_kolumnach[kolumna_docelowa][co_na_kolumnach[kolumna_docelowa].Count - 1].liczba == doprzs.liczba + 1)
                        {
                            co_na_kolumnach[doprzs.column].Remove(doprzs);
                            co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].wsk = null;
                            if (co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].status == 0)
                            {
                                co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].status = 1;
                                co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].Image = co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].twarz;
                            }
                            doprzs.Location = new Point(kolumny[kolumna_docelowa].Location.X, kolumny[kolumna_docelowa].Location.Y + 20 * co_na_kolumnach[kolumna_docelowa].Count);
                            co_na_kolumnach[kolumna_docelowa].Add(doprzs);
                            co_na_kolumnach[kolumna_docelowa][co_na_kolumnach[kolumna_docelowa].Count - 2].wsk = co_na_kolumnach[kolumna_docelowa][co_na_kolumnach[kolumna_docelowa].Count - 1];
                            doprzs.column = kolumna_docelowa;
                            doprzs.BringToFront();
                            sprawdz_czy_final(doprzs.column);
                        }
                    }
                    else
                    {
                        if (co_na_kolumnach[kolumna_docelowa][co_na_kolumnach[kolumna_docelowa].Count - 1].liczba == 2)
                        {
                            co_na_kolumnach[doprzs.column].Remove(doprzs);
                            co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].wsk = null;
                            if (co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].status == 0)
                            {
                                co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].status = 1;
                                co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].Image = co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].twarz;
                            }
                            doprzs.Location = new Point(kolumny[kolumna_docelowa].Location.X, kolumny[kolumna_docelowa].Location.Y + 20 * co_na_kolumnach[kolumna_docelowa].Count);
                            co_na_kolumnach[kolumna_docelowa].Add(doprzs);
                            co_na_kolumnach[kolumna_docelowa][co_na_kolumnach[kolumna_docelowa].Count - 2].wsk = co_na_kolumnach[kolumna_docelowa][co_na_kolumnach[kolumna_docelowa].Count - 1];
                            doprzs.column = kolumna_docelowa;
                            doprzs.BringToFront();
                            sprawdz_czy_final(doprzs.column);
                        }
                    }
                }
                else
                {
                    karty_pas pom = sender as karty_pas;
                    int kolumna_docelowa = pom.column;
                    if (sprawdz(doprzs))
                    {
                        int licznik = 0;
                        karty_pas pomoc;
                        if (co_na_kolumnach[kolumna_docelowa][co_na_kolumnach[kolumna_docelowa].Count - 1].liczba == doprzs.liczba + 1)
                        {
                            doprzs.Location = new Point(kolumny[kolumna_docelowa].Location.X, kolumny[kolumna_docelowa].Location.Y + 20 * co_na_kolumnach[kolumna_docelowa].Count);
                            co_na_kolumnach[kolumna_docelowa].Add(doprzs);
                            co_na_kolumnach[kolumna_docelowa][co_na_kolumnach[kolumna_docelowa].Count - 2].wsk = co_na_kolumnach[kolumna_docelowa][co_na_kolumnach[kolumna_docelowa].Count - 1];
                            doprzs.BringToFront();
                            licznik += 1;
                            pomoc = doprzs.wsk;
                            while (pomoc != null)
                            {
                                licznik += 1;
                                co_na_kolumnach[doprzs.column].Remove(pomoc);
                                pomoc.column = kolumna_docelowa;
                                pomoc.Location = new Point(kolumny[kolumna_docelowa].Location.X, kolumny[kolumna_docelowa].Location.Y + 20 * co_na_kolumnach[kolumna_docelowa].Count);
                                co_na_kolumnach[kolumna_docelowa].Add(pomoc);
                                co_na_kolumnach[kolumna_docelowa][co_na_kolumnach[kolumna_docelowa].Count - 2].wsk = co_na_kolumnach[kolumna_docelowa][co_na_kolumnach[kolumna_docelowa].Count - 1];
                                pomoc.BringToFront();
                                pomoc = pomoc.wsk;

                            }
                            //for (int i = 0; i < licznik; i++)
                            //{
                                co_na_kolumnach[doprzs.column].Remove(co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1]);
                            //}
                            if (co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].status == 0)
                            {
                                co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].status = 1;
                                co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].Image = co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].twarz;
                            }
                            co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].wsk = null;
                            doprzs.column = kolumna_docelowa;
                            sprawdz_czy_final(doprzs.column);
                        }
                    }
                }
                doprzs.BorderStyle = BorderStyle.None;
                doprzs = null;
            }
        }
        private bool sprawdz(karty_pas cos)
        {
            if (cos.Liczba == 14)
            {
                if (cos.wsk == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (cos.wsk == null) return true;
            if (cos.liczba == 2 && cos.wsk.liczba == 14)
            {
                if(cos.wsk.wsk == null)
                {
                    return true;
                }
            }
            if (cos.znaczek == cos.wsk.znaczek && cos.liczba == cos.wsk.Liczba + 1)
            {
                if (cos.wsk == null)
                {
                    return true;
                }
                else
                {
                    return sprawdz(cos.wsk);
                }
            }
            return false;
        }
        private void sprawdz_czy_final(int ktora)
        {
            if (co_na_kolumnach[ktora][co_na_kolumnach[ktora].Count - 1].liczba != 14)
            {
                return;
            }
            for (int i = 1; i < 14; i++)
            {
                if (co_na_kolumnach[ktora][co_na_kolumnach[ktora].Count - 1 - i].liczba != 1 + i)
                {
                    return;
                }
            }
            finalne[finals].Image = co_na_kolumnach[ktora][co_na_kolumnach[ktora].Count - 1].Image;
            for (int i = 0; i < 14; i++)
            {
                this.Controls.Remove(co_na_kolumnach[ktora][co_na_kolumnach[ktora].Count - 1]);
                co_na_kolumnach[ktora].Remove(co_na_kolumnach[ktora][co_na_kolumnach[ktora].Count - 1]);
            }
            finals++;
            if (finals == 8)
            {
                this.Close();
            }
            if (co_na_kolumnach[ktora].Count > 0) co_na_kolumnach[ktora][co_na_kolumnach[ktora].Count - 1].wsk = null;

        }

        private void column_Click(object sender, EventArgs e)
        {
            if (doprzs == null)
            {
                return;
            }
            PictureBox pom = sender as PictureBox;
            int idx = 0;
            if (doprzs.wsk == null)
            {
                if (doprzs.liczba == 13)
                {
                    co_na_kolumnach[doprzs.column].Remove(doprzs);
                    co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].wsk = null;
                    if (co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].status == 0)
                    {
                        co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].status = 1;
                        co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].Image = co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].twarz;
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        if (kolumny[i] == pom)
                        {
                            idx = i;
                            break;
                        }
                    }
                    doprzs.Location = new Point(kolumny[idx].Location.X, kolumny[idx].Location.Y + 20 * co_na_kolumnach[idx].Count);
                    co_na_kolumnach[idx].Add(doprzs);
                    doprzs.column = idx;
                    doprzs.BringToFront();

                }
            }
            else
            {

                if(sprawdz(doprzs) && doprzs.liczba == 13)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (kolumny[i] == pom)
                        {
                            idx = i;
                            break;
                        }
                    }
                    int licznik = 0;
                    karty_pas pomoc;
                    doprzs.Location = new Point(kolumny[idx].Location.X, kolumny[idx].Location.Y + 20 * co_na_kolumnach[idx].Count);
                    co_na_kolumnach[idx].Add(doprzs);
                    doprzs.BringToFront();
                    licznik += 1;
                    pomoc = doprzs.wsk;
                    while (pomoc != null)
                    {
                        licznik += 1;
                        co_na_kolumnach[doprzs.column].Remove(pomoc);
                        pomoc.column = idx;
                        pomoc.Location = new Point(kolumny[idx].Location.X, kolumny[idx].Location.Y + 20 * co_na_kolumnach[idx].Count);
                        co_na_kolumnach[idx].Add(pomoc);
                        pomoc.BringToFront();
                        pomoc = pomoc.wsk;

                    }
                    for (int i = 0; i < licznik; i++)
                    {
                        co_na_kolumnach[doprzs.column].Remove(co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1]);
                    }
                    co_na_kolumnach[doprzs.column][co_na_kolumnach[doprzs.column].Count - 1].wsk = null;
                    doprzs.column = idx;
                }
            }
            doprzs.BorderStyle = BorderStyle.None;
            doprzs = null;
        }
    }
}
