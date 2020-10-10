using SternbergTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleAndChoiceResponse
{
    public partial class SRT : Form
    {
        public string X_image = System.Windows.Forms.Application.StartupPath + "\\X_MARK.png";
        Boolean init = false;
        int[] RandomTimer;
        Random rand;
        double[] TimeCheck;
        Boolean[] saveTF;
        Stopwatch timer;
        Worker workerObject = new Worker();
        int userIndex = -1;
        Boolean userTestTime = false;
        String fileName;
        private int num = 1;
        /*
        pictureBoxes[0].ImageLocation=X_image;
        pictureBoxes[0].Update();
         */
        Boolean can_cancel = true;
        public SRT()
        {
            InitializeComponent();
            pictureBox1.Hide();
            Random_Time_Generate();
            TimeCheck = new Double[20];
            saveTF = new Boolean[20];
            label1.Hide();
            closeBtn.Hide();
            KeyPreview = true;

        }
        private void Random_Time_Generate()
        {
            RandomTimer = new int[20];
            rand = new Random();
            for (int i = 0; i < 20; i++)
                RandomTimer[i] = rand.Next(1000, 3000);
            for (int i = 0; i < 20; i++)
                Console.Write(RandomTimer[i] + " ");
            Console.WriteLine();
        }
        private async void StartTest()
        {
            can_cancel = false;
            for (int i = 0; i < 20; i++)
            {
                await Task.Run(async () =>
                {
                    userTestTime = false;
                    userIndex = i;
                    timer = new Stopwatch();
                        pictureBox1.Image = null;
                    pictureBox1.Update();
                    pictureBox1.BackColor = Color.White;
                    pictureBox1.Show();
                  
                    Task.Delay(RandomTimer[i]).Wait();
                    pictureBox1.ImageLocation = X_image;
                    pictureBox1.Update();
                    timer.Start();
                    userTestTime = true;
                    workerObject.RequestStart();
                    int result = await workerObject.DelayAsync(timer);
                    if (result == -1)
                    {
                        workerObject.RequestStop();
                        timer.Stop();
                        Console.WriteLine("Nothing");
                        saveTF[userIndex] = false;
                        TimeCheck[userIndex] = 5000;
                    }
                });


            }
            DirectoryInfo dtif = new DirectoryInfo(Application.StartupPath + "\\log");
            if (!dtif.Exists)
            {
                dtif.Create();
            }
            fileName = "\\log\\" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + "_num" + num.ToString() + ".txt";
            Console.WriteLine(fileName);
            FileInfo file = new FileInfo(Application.StartupPath + fileName);
            if (!file.Exists)
            {
                FileStream f = file.Create();
                f.Close();
            }
            FileStream fs = file.OpenWrite();
            TextWriter tw = new StreamWriter(fs);
            tw.WriteLine("index, TF, Time(ms)");
            for (int i = 0; i < 20; i++)
            {
                tw.WriteLine(i.ToString() + "," + saveTF[i].ToString() + "," + TimeCheck[i].ToString());
            }
            pictureBox1.Hide();
            label1.Text = fileName + Environment.NewLine + "에 저장되었습니다.";
            label1.Update();
            label1.Show();
            closeBtn.Show();
            tw.Close();
            fs.Close();
            can_cancel = true;

        }

        private void SRT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (init == false)
                    {
                        this.BackgroundImage = null;
                        pictureBox1.BackColor = Color.White;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Image = null;
                        pictureBox1.Update();
                        pictureBox1.Show();
                        StartTest();
                        init = true;
                    }
                    else
                    {
                        if (userTestTime)
                        {
                            workerObject.RequestStop();
                            timer.Stop();
                            Console.WriteLine("button0");
                            saveTF[userIndex] = true;
                            TimeCheck[userIndex] = timer.ElapsedMilliseconds;
                        }
                    }
                    break;

            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SRT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!can_cancel)
                e.Cancel = true;

        }
    }
}
