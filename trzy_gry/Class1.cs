//using sun.awt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using Microsoft.CommandPalette.Extensions.Toolkit;

namespace trzy_gry
{
    
    class Card: PictureBox
    {
        public int cardID;
        public char znaczek;
        //private int liczba;
        public int liczba;
        public int Liczba
        {
            get
            {
                return liczba;
            }

            set
            {

                liczba = value;
                form.OnArenaChanged(playerID);

            }
        }
        public int playerID;

        public int wartosckarty;
        string[] lista = new string[17];
        public int cardheight = 260; // razie co to se zmien przy tworzeniu talii
        public int cardwidth = 160;
        bool played;
        Graphics grafika;

        
        void changesize(int width, int height)
        {
            cardwidth = width;
            cardheight = height;
        }

        public Card()
        {
            this.Size = new Size(cardwidth, cardheight - 60);
            generateCard2();
            grafika = Graphics.FromImage(this.Image);
            ControlPaint.DrawBorder(grafika, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
            this.Tag = Color.Red;
            //this.Click += image_Click;
           // this.AllowDrop = true;
           
          //  this.MouseDown += pictureBox1_MouseDown;

            //this.DragEnter += pictureBox2_DragEnter;
            //this.DragDrop += pictureBox2_DragDrop;
        }
        Form2 form;
        public Card(Form2 form)
        {
            this.form = form;
            this.Size = new Size(cardwidth, cardheight - 60);
            generateCard2();
            grafika = Graphics.FromImage(this.Image);
            ControlPaint.DrawBorder(grafika, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
            this.Tag = Color.Red;
            //this.Click += image_Click;
           // this.AllowDrop = true;

           // this.MouseDown += pictureBox1_MouseDown;

            //this.DragEnter += pictureBox2_DragEnter;
            //this.DragDrop += pictureBox2_DragDrop;
        }
        public void assignID(int id)
        {
            playerID = id;
        }

        public Card(int licz,char zna)
        {
            lista = ["2.png", "3.png", "4.png", "5.png", "6.png", "7.png", "8.png", "9.png", "10.png", "11.png", "12.png", "13.png",  "14.png", "k.png", "t.png", "p.png", "s.png"];
            znaczek = zna;
            liczba = licz;
            this.Tag = Color.Red;
            generateCard();
            //this.Click += image_Click;
            //this.AllowDrop = true;
            grafika = Graphics.FromImage(this.Image);
            //this.MouseDown += pictureBox1_MouseDown;

            //this.DragEnter += pictureBox2_DragEnter;
            //this.DragDrop += pictureBox2_DragDrop;

        }

      


        public void locationen(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        List<Image> loadImg()
        {
            List<Image> images = new List<Image>();
            string temp = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            images.Add(Image.FromFile(temp + "/res/" + liczba.ToString() + ".png"));
            images.Add(Image.FromFile(temp + "/res/" + znaczek.ToString() + ".png"));

           
            

            
            images.Add(Image.FromFile(temp + "/res/" + znaczek.ToString() + ".png"));
            images.Add(Image.FromFile(temp + "/res/" + liczba.ToString() + ".png"));

            return images;
        }
        const int borderSize = 2;

        public void generateCard2()
        {
 
            List<Image> images = loadImg();

            Bitmap combinedBitmap = new Bitmap(images[0].Width * 4 - 50, 750);

            using (Graphics g = Graphics.FromImage(combinedBitmap))
            {
                // Clear the background (optional)
                g.Clear(Color.White);

     

  
            }


            this.Image = new Bitmap(combinedBitmap, new Size(cardwidth, cardheight));
            this.Size = new Size(cardwidth, cardheight - 60);
            Graphics d = Graphics.FromImage(this.Image);
            ControlPaint.DrawBorder(d, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        public void generateCard()
        {

            List<Image> images = loadImg();
            Bitmap combinedBitmap = new Bitmap(images[0].Width*4-50, 750);
            
            using (Graphics g = Graphics.FromImage(combinedBitmap))
            {
                // Clear the background (optional)
                g.Clear(Color.White);

                // Loop through the images and draw them on the combined bitmap
                int x = 0;
                int z = 0;
                
                foreach (Image image in images)
                {
                    
                   
                    if (z <=1)
                    {
                        g.DrawImage(image, x, 0); // Adjust the position (x, y) as needed
                        x += image.Width; // Move to the next position


                    }
                    else
                    {
                        image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        g.DrawImage(image, x - 50, 450); // Adjust the position (x, y) as needed
                        
                        x += image.Width; // Move to the next position
                    }
                    z++;
                }
                int h = 450 + images[0].Height;
                int w = images[0].Width * 4 - 50;

                
                /*g.DrawLine(new Pen(Brushes.Black, 4), new Point(0, 0), new Point(0, h));
                g.DrawLine(new Pen(Brushes.Black, 4), new Point(0, 0), new Point(w, 0));
                g.DrawLine(new Pen(Brushes.Black, 4), new Point(0, h), new Point(w, h));
                g.DrawLine(new Pen(Brushes.Black, 4), new Point(w, 0), new Point(w, h));
                */
            }


            this.Image = new Bitmap(combinedBitmap, new Size(cardwidth, cardheight));
            this.Size = new Size(cardwidth, cardheight - 60);
            Graphics d = Graphics.FromImage(this.Image);
            ControlPaint.DrawBorder(d, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
            
            
           

        }


        public void generateCardReverse()
        {
            Image tem = Image.FromFile(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/res/" + "logo.png");

            Bitmap combinedBitmap = new Bitmap(435, 750);
            using (Graphics g = Graphics.FromImage(combinedBitmap))
            {
                g.Clear(Color.White);
                g.DrawImage(tem,0,150);
            }
            this.Image = new Bitmap(combinedBitmap, new Size(cardwidth, cardheight));
            this.Size = new Size(cardwidth, cardheight - 60);
            Graphics d = Graphics.FromImage(this.Image);
            ControlPaint.DrawBorder(d, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        public void pictureBox1_MouseEnter(object sender, PaintEventArgs e)
        {
            
            if (this.Tag == null) { this.Tag = Color.Red; } //Sets a default color
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, (Color)this.Tag, ButtonBorderStyle.Solid);
        }

        public void image_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("sender player id = " + this.liczba+" tah =  "+ this.Tag);
            ControlPaint.DrawBorder(grafika, this.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
            if ((Color)this.Tag == Color.Red) { 
                this.Tag = Color.Blue;
                
                ControlPaint.DrawBorder(grafika, this.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
            }
            else { this.Tag = Color.Red; ControlPaint.DrawBorder(grafika, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid); }
            this.Refresh();
            
        }

        private void beta_MouseEnter(object sender, EventArgs e)
        {
            
            ControlPaint.DrawBorder(grafika, this.ClientRectangle, Color.Blue, ButtonBorderStyle.Solid);
            //this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Cursor = Cursors.Hand;
        }

        private void beta_MouseLeave(object sender, EventArgs e)
        {
            ControlPaint.DrawBorder(grafika, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
            //this.SizeMode = PictureBoxSizeMode.Zoom;
            this.Cursor = Cursors.Default;
        }


        //---------------------------------------------------------------------nie dodtykac -----------------------------------------------------------------------------------//


        public bool drageed = false;


        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }
        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);
        public static Cursor CreateCursor(Bitmap bmp,
        int xHotSpot, int yHotSpot)
        {
            IconInfo tmp = new IconInfo();
            GetIconInfo(bmp.GetHicon(), ref tmp);
            tmp.xHotspot = xHotSpot;
            tmp.yHotspot = yHotSpot;
            tmp.fIcon = false;
            return new Cursor(CreateIconIndirect(ref tmp));
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            var img = this.Image;
            if (img == null) return;
            drageed = true;
            if (DoDragDrop(img, DragDropEffects.Move) == DragDropEffects.Move)
            {
                if (drageed == true)
                {
                    generateCard2();

                }
                //this.Image = null;
                drageed = false;


            }
        }

        void pictureBox2_DragEnter(object sender, DragEventArgs e)
        {
            Bitmap bitmap = new Bitmap(this.Image, new Size(cardwidth / 5, cardheight / 5));
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Move;
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(this.Image, 0, 0);
                }


                Cursor.Current = CreateCursor(bitmap, 0, 0);
            }



        }

        void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            Card sender2 = (Card)sender;
            if (this != sender2) { sender2.drageed = true; return; }
            else { sender2.drageed = false; }
            System.Diagnostics.Debug.WriteLine("sender player id = " + sender2.liczba.ToString() + "reciver player id = " + this.liczba.ToString());

            var bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            this.Image = bmp;

        }













    }


}
