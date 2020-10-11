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
    public partial class CRT_4 : Form
    {
        public string X_image = System.Windows.Forms.Application.StartupPath + "\\X_MARK.png";
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
        String fileName;
        private int num = 4;
        /*
        pictureBoxes[0].ImageLocation=X_image;
        pictureBoxes[0].Update();
         */
        Boolean can_cancel = true;
        public CRT_4()
        {
            InitializeComponent();
            pictureBoxes =new PictureBox[]{ pictureBox1, pictureBox2, pictureBox3, pictureBox4};
            foreach (PictureBox p in pictureBoxes)
                p.Hide();
            Random_Time_Generate();
            Random_Button_Generate(4);
            TimeCheck = new Double[20];
            UserInput = new int[20];
            saveTF = new Boolean[20];
            label1.Hide();
            closeBtn.Hide();
            KeyPreview = true;
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
                    int result = await workerObject.DelayAsync(timer);
                    if (result == -1)
                    {
                        workerObject.RequestStop();
                        timer.Stop();
                        Console.WriteLine("Nothing");
                        UserInput[userIndex] = -1;
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
            tw.WriteLine("index , Actual, UserInput, TF, Time(ms)");
            for (int i = 0; i < 20; i++)
            {
                tw.WriteLine(i.ToString()+","+RandomButton[i].ToString() + "," + UserInput[i].ToString() + "," + saveTF[i].ToString() + "," + TimeCheck[i].ToString());
            }
            tw.Close();
            fs.Close();
            foreach (PictureBox p in pictureBoxes)
                p.Hide();
            label1.Text = fileName + Environment.NewLine + "에 저장되었습니다.";
            label1.Update();
            label1.Show();
            closeBtn.Show();
            can_cancel = true;
        }
        public T[] Shuffle<T>(T[] array)
        {
            var random = new Random();
            for (int i = array.Length; i > 1; i--)
            {
                // Pick random element to swap.
                int j = random.Next(i); // 0 <= j <= i-1
                                        // Swap.
                T tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }
            return array;
        }


        private void Random_Time_Generate()
        {
            RandomTimer = new int[20];
            rand = new Random();
            for (int i = 0; i < 20; i++)
                RandomTimer[i] = rand.Next(1000, 3000);
            for (int i = 0; i < 20; i++)
                Console.Write(RandomTimer[i]+" ");
            Console.WriteLine();
        }
        private void Random_Button_Generate(int n)
        {
            RandomButton = new int[20];
            int[] RandomNum = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            RandomNum = Shuffle<int>(RandomNum);
            for (int i = 0; i < 20; i++)
            {
                if (i < 5)
                    RandomButton[RandomNum[i]] = 0;
                else if(5<=i && i<10)
                    RandomButton[RandomNum[i]] = 1;
                else if (10 <= i && i < 15)
                    RandomButton[RandomNum[i]] = 2;
                else 
                    RandomButton[RandomNum[i]] = 3;
            }
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
                case Keys.X:
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
                case Keys.C:
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
                case Keys.B:
                    {
                        if (userTestTime)
                        {
                            workerObject.RequestStop();
                            timer.Stop();
                            Console.WriteLine("button2");
                            UserInput[userIndex] = 2;
                            if (UserInput[userIndex] == RandomButton[userIndex])
                                saveTF[userIndex] = true;
                            else
                                saveTF[userIndex] = false;
                            TimeCheck[userIndex] = timer.ElapsedMilliseconds;
                        }
                    }
                    break;
                case Keys.N:
                    {
                        if (userTestTime)
                        {
                            workerObject.RequestStop();
                            timer.Stop();
                            Console.WriteLine("button3");
                            UserInput[userIndex] = 3;
                            if (UserInput[userIndex] == RandomButton[userIndex])
                                saveTF[userIndex] = true;
                            else
                                saveTF[userIndex] = false;
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

        private void CRT_4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!can_cancel)
                Application.Exit();

        }
    }
}
