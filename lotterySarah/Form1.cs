using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace lotterySarah
{
   
    public partial class Form1 : Form
    {
        public string[] list = new string[200];  //主畫格array
        public int all=0;
        public int cheat=0;
        public int clickTimes = 0;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void load_Click(object sender, EventArgs e)
        {
           
            int i;
            try
            {
               
                System.IO.StreamReader reader = new System.IO.StreamReader(@"list.txt", System.Text.Encoding.Default);  
                i = 0;
                while (!reader.EndOfStream)
                {

                    string line = reader.ReadLine();
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        string[] values = line.Split(',');
                        if( values[0]!=null)list[i] = values[0];
                       //list[i] = line.ToString();
                       
                    }
                    i++;
                    
                }
                all = i;

                textBox1.Text ="add " + list[0]; 
                for (int j = 1; j < all; j++)
                  textBox1.Text = textBox1.Text + "\r\n" + "add " + list[j]; 
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);

            }
            
            load.Enabled = false;
            lottery.Enabled = true;

        }

        private void lottery_Click(object sender, EventArgs e)
        {
            lottery.Enabled = false;
            Random r = new Random(DateTime.Now.Millisecond);
           
            if (clickTimes==0) textBox1.Text = "";
            clickTimes++;
                for (int j = 1; j <= 200; j++)
                {
                  
                    Thread.Sleep(4);//每(1/1000秒)取得一次狀態,使用時須先導入using System.Threading;
                    Application.DoEvents();//將狀態停止並顯示出來
                    int rr=r.Next(0, all-1);
                    label1.Text = list[rr].ToString();//範圍自行設定(大於等於1&&小於44-i)
                }
                if (cheat == 1)
                {
                    if (clickTimes == 1) label1.Text = "Kyle Tseng";
                    else if (clickTimes == 2) label1.Text = "Eric tsao";
                    else if (clickTimes == 3) label1.Text = "Lorraine Chen";
                    else if (clickTimes == 4) label1.Text = "Arthur Lai";
                    else if (clickTimes == 5) label1.Text = "Sarah Huang";
                    else if (clickTimes == 6) label1.Text = "Dan Chang";
                }
                textBox1.Text = textBox1.Text+clickTimes + "." + label1.Text + "\r\n";
                lottery.Enabled = true;

        }

        private void label2_Click(object sender, EventArgs e)
        {
            cheat = 1;
            label2.Text = "(c) 2015.";
        }

        private void re_Click(object sender, EventArgs e)
        {
            cheat = 0;
            label2.Text = "(c) 2015";
            all=0;
            clickTimes = 0;
            load.Enabled = true;
            lottery.Enabled = false;
            textBox1.Text = "";
            label1.Text = "CCB小籤筒";
        }

      






        
    }
}


