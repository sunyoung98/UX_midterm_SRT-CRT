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
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SRT_startbtn_Click(object sender, EventArgs e)
        {
            SRT srt = new SRT();
            srt.ShowDialog();
        }

        private void CRT2_startbtn_Click(object sender, EventArgs e)
        {
            CRT_2 crt2 = new CRT_2();
            crt2.ShowDialog();
        }

        private void CRT4_startbtn_Click(object sender, EventArgs e)
        {
            CRT_4 crt4 = new CRT_4();
            crt4.ShowDialog();
        }

    }
}
