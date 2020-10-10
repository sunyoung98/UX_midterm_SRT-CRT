using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleAndChoiceResponse
{
    public partial class CRT_2 : Form
    {
        Boolean init = false;
        PictureBox[] pictureBoxes;
        public CRT_2()
        {
            InitializeComponent();
            pictureBoxes = new PictureBox[] { pictureBox1, pictureBox2 };
            foreach (PictureBox p in pictureBoxes)
                p.Hide();
        }

        private void CRT_2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (init == false)
                    {
                        this.BackgroundImage = null;
                        foreach (PictureBox p in pictureBoxes)
                        {
                            p.Image = null;
                            p.Show();
                        }
                        init = true;
                    }
                    else
                    {

                    }
                    break;
            }
        }
    }
}
