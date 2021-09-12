using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgSwift_GUI
{
    public partial class AgSwift_MainWindow : Form
    {
        public AgSwift_MainWindow()
        {
            InitializeComponent();
        }

        private void pictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.White, 3);
            System.Drawing.Point pt1 = new System.Drawing.Point(100, 100);
            System.Drawing.Point pt2 = new System.Drawing.Point(200, 200);

            g.DrawLine(p, pt1, pt2);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            MessageBox.Show("All your base are belong to us", "Lmao", MessageBoxButtons.OK);
        }

        private void AgSwift_MainWindow_Load(object sender, EventArgs e)
        {
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            double x = MousePosition.X;
            double y = MousePosition.Y;

            string msg = "X: " + x.ToString() + " Y: " + y.ToString();
            MessageBox.Show(msg, "Test", MessageBoxButtons.OK);
        }
    }
}
