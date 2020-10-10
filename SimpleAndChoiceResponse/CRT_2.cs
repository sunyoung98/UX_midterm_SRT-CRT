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
    public partial class CRT_2 : Form
    {
        public static string X_image = System.Windows.Forms.Application.StartupPath + "\\X_MARK.png";
        Boolean init = false;
        PictureBox[] pictureBoxes;
        int[] RandomTimer;
        int[] RandomButton;
        Random rand;
        double[] TimeCheck;
        int[] UserInput;
        Boolean[] saveTF;
        Stopwatch timer;
        Worker workerObject = new Worker();
        int userIndex = -1;
        Boolean userTestTime = false;
        private string fileName;
        private int num = 2;

        /*
pictureBoxes[0].ImageLocation=X_image;
pictureBoxes[0].Update();
*/
        public CRT_2()
        {
            InitializeComponent();
            pictureBoxes = new PictureBox[] { pictureBox1, pictureBox2 };
            foreach (PictureBox p in pictureBoxes)
                p.Hide();
            Random_Time_Generate();
            Random_Button_Generate(2);
            TimeCheck = new Double[20];
            UserInput = new int[20];
            saveTF = new Boolean[20];
            label1.Hide();
            closeBtn.Hide();

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
        private void Random_Button_Generate(int n)
        {
            RandomButton = new int[20];
            rand = new Random();
            for (int i = 0; i < 20; i++)
                RandomButton[i] = rand.Next(0, n);
            for (int i = 0; i < 20; i++)
                Console.Write(RandomButton[i] + " ");
            Console.WriteLine();
        }
        private async void StartTest()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Run(async () =>
                {
                    userTestTime = false;
                    userIndex = i;
                    timer = new Stopwatch();

                    foreach (PictureBox p in pictureBoxes)
                    {
                        p.Image = null;
                        p.Update();
                        p.BackColor = Color.White;
                        p.Show();
                    }
                    Task.Delay(RandomTimer[i]).Wait();
                    pictureBoxes[RandomButton[i]].ImageLocation = X_image;
                    pictureBoxes[RandomButton[i]].Update();
                    timer.Start();
                    userTestTime = true;
                    workerObject.RequestStart();
                    workerObject.DelayAsync(timer);
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
            tw.WriteLine("index , Actual, UserInput, TF, Time(ms)");
            for (int i = 0; i < 20; i++)
            {
                tw.WriteLine(i.ToString() + "," + RandomButton[i].ToString() + "," + UserInput[i].ToString() + "," + saveTF[i].ToString() + "," + TimeCheck[i].ToString());
            }
            tw.Close();
            fs.Close();
            foreach (PictureBox p in pictureBoxes)
                p.Hide();
            label1.Text = fileName + Environment.NewLine + "에 저장되었습니다.";
            label1.Update();
            label1.Show();
            closeBtn.Show();
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
                            p.BackColor = Color.White;
                            p.SizeMode = PictureBoxSizeMode.StretchImage;
                            p.Image = null;
                            p.Update();
                            p.Show();

                        }
                        StartTest();
                        init = true;
                    }
                    break;
                case Keys.C:
                    {
                        if (userTestTime)
                        {
                            workerObject.RequestStop();
                            timer.Stop();
                            Console.WriteLine("button0");
                            UserInput[userIndex] = 0;
                            if (UserInput[userIndex] == RandomButton[userIndex])
                                saveTF[userIndex] = true;
                            else
                                saveTF[userIndex] = false;
                            TimeCheck[userIndex] = timer.ElapsedMilliseconds;
                        }
                    }
                    break;
                case Keys.B:
                    {
                        if (userTestTime)
                        {
                            workerObject.RequestStop();
                            timer.Stop();
                            Console.WriteLine("button1");
                            UserInput[userIndex] = 1;
                            if (UserInput[userIndex] == RandomButton[userIndex])
                                saveTF[userIndex] = true;
                            else
                                saveTF[userIndex] = false;
                            TimeCheck[userIndex] = timer.ElapsedMilliseconds;
                        }
                    }
                    break;
                case Keys.Q:
                    {
                        if (userTestTime)
                        {
                            workerObject.RequestStop();
                            timer.Stop();
                            Console.WriteLine("Nothing");
                            UserInput[userIndex] = -1;
                            saveTF[userIndex] = false;
                            TimeCheck[userIndex] = 5000;
                        }
                    }
                    break;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
