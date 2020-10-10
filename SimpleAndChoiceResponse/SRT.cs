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
    public partial class SRT : Form
    {
        Boolean init = false;
        public SRT()
        {
            InitializeComponent();
            pictureBox1.Hide();
        }

        private void SRT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (init == false)
                    {
                        this.BackgroundImage = null;
                        pictureBox1.Show();
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
