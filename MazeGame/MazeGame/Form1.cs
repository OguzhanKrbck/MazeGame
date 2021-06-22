using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGame
{
    public partial class Form1 : Form
    {
        enum position
        {
            Left, Right, Up, Down
        }

        public Point basla = new Point(32, 25);
        public Point bitir1 = new Point(550, 318);
        public Point bitir2 = new Point(40, 318);
        public Point bitir3 = new Point(290, 130);
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            timer1.Start();
            if (e.KeyCode == Keys.Left)
            {
                obje1.Left = obje1.Left - 3;
                sorgula();
                son();
            }
            else if (e.KeyCode == Keys.Right)
            {
                obje1.Left = obje1.Left + 3;
                sorgula();
                son();

            }
            else if (e.KeyCode == Keys.Up)
            {
                obje1.Top = obje1.Top - 3;
                sorgula();
                son();
            }
            else if (e.KeyCode == Keys.Down)
            {
                obje1.Top = obje1.Top + 3;
                sorgula();
                son();
            }

        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            timer1.Stop();
        }
        public void sorgula()
        {
        
            foreach (var Lb in Controls.OfType<Label>())// label ve picturebox'ı bir arada kullanma
            {
                    
                    if (obje1.Bounds.IntersectsWith(Lb.Bounds))
                    {
                       
                    obje1.Location = basla;
                    bitiş();

                    }                             
            }
        }
        public void bitiş()
        {
            int son;
            Random a = new Random();
            son = a.Next(1,4);
            switch (son)
            {
                case 1:
                    bitiş_.Location = bitir1;
                    break;
                case 2:
                    bitiş_.Location = bitir2;
                    break;
                case 3:
                    bitiş_.Location = bitir3;
                    break;

            }
        }
        public void son()
        {
            if (obje1.Bounds.IntersectsWith(bitiş_.Bounds))
            {
                DialogResult dialogResult = MessageBox.Show("Devam Etmek İster Misin", "Tebrikler!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    obje1.Location = basla;
                    bitiş();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitiş();
        }
    }
}

