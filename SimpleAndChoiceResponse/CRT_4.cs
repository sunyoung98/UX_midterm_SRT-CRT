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
    public partial class CRT_4 : Form
    {
        Boolean init = false;
        PictureBox[] pictureBoxes;
        public CRT_4()
        {
            InitializeComponent();
            pictureBoxes =new PictureBox[]{ pictureBox1, pictureBox2, pictureBox3, pictureBox4};
            foreach (PictureBox p in pictureBoxes)
                p.Hide();

        }

        private void CRT_4_KeyDown(object sender, KeyEventArgs e)
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
