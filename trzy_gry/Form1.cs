namespace trzy_gry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 xdd = new Form2(this);
            xdd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 xdd = new Form3(this);
            xdd.Show();
        }
    }
}
