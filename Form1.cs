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
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Text.RegularExpressions;


namespace Image_Processing_CVC
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        //global variables
        //python location
        string pythonEXE = "Gesture_backend.exe";

        string gestureDictionary = "gesture dictionary.pdf";
        //glopal functions 
        void TextWrite(string name, string data)
        {
            string path = @""+ name + ".txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            StreamWriter text = new StreamWriter(path);
            text.Write("{0}\r\n", data);
            text.Close();
        }

        void check_for_pythonEXE()
        {
            //Thread.Sleep(10);
            //Process[] pname = Process.GetProcesses();
            //this.Text = pname.Length.ToString();

            Process[] pname = Process.GetProcessesByName("Gesture_backend");
            
           
            if (pname.Length == 0)
                {
                    
                    label1.Visible = false;
                    label2.Visible = false;
                    closeTheCameraToolStripMenuItem.Visible = false;
                    //stop the timer 
                    timer1.Stop();

            }
                
            

        }



        private void Form1_Load(object sender, EventArgs e)
        {
           
            // set a custom color
            //previous color (36, 49, 60)
            Color darkRGB1 = new Color();
            darkRGB1 = Color.FromArgb(22, 22, 24);
            Color darkRGB2 = new Color();
            darkRGB2 = Color.FromArgb(44, 44, 46);
            Color darkRGB3 = new Color();
            darkRGB3 = Color.FromArgb(220, 220, 220);
            this.BackColor = darkRGB1;
            menuStrip1.BackColor = darkRGB2;
            menuStrip1.ForeColor = darkRGB3;

            //add a round button for live video feed
            /*
            RoundButton liveVideoFeed = new RoundButton();
            this.Controls.Add(liveVideoFeed);
            liveVideoFeed.Location=new Point(400,50);
            */
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void uploadPhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string a=file.FileName;

            }
        }

        private void liveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        
        private void liveVideoFeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //call python and path arguements
            //write in mode.txt
            try
            { TextWrite("mode", "0"); }
            catch { Thread.Sleep(10); TextWrite("mode", "0"); }
           

            
            try
            {
                Process.Start(pythonEXE);
            }
            catch 
            {
                MessageBox.Show("error: "+pythonEXE+" file has been removed from its location !");
            }
            //show live button
            //start the timer 
            timer1.Enabled = true;
           
            timer1.Start();
            //timer1.Tick += timer1_Tick;

            //show turn off button
            closeTheCameraToolStripMenuItem.Visible = true;

        }

        private void uploadVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string a = file.FileName;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Visible == false)
            {
                label1.Visible = true;
                label2.Visible = true;
            }
            else 
            {
                label1.Visible = false;
                label2.Visible = false;
            }

            check_for_pythonEXE();
        }

        private void liveVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //change checked
            darkModeToolStripMenuItem.Checked = !darkModeToolStripMenuItem.Checked;

            // set a custom color for light mode
            //for darkmode
            Color darkRGB1 = new Color();
            darkRGB1 = Color.FromArgb(22, 22, 24);
            Color darkRGB2 = new Color();
            darkRGB2 = Color.FromArgb(44, 44, 46);
            Color darkRGB3 = new Color();
            darkRGB3 = Color.FromArgb(220, 220, 220);
            //for lightmode
            Color lightRGB1 = new Color();
            lightRGB1 = Color.FromArgb(255, 255, 255);
            Color lightRGB2 = new Color();
            lightRGB2 = Color.FromArgb(200, 200, 200);
            Color lightRGB3 = new Color();
            lightRGB3 = Color.FromArgb(15, 15, 15);
            //apply darkmode or lightmode
            //darkmode
            if (darkModeToolStripMenuItem.Checked==true) 
            {
                this.BackColor = darkRGB1;
                menuStrip1.BackColor = darkRGB2;
                menuStrip1.ForeColor = darkRGB3;
            }
            //lightmode
            else
            {
                this.BackColor = lightRGB1;
                menuStrip1.BackColor = lightRGB2;
                menuStrip1.ForeColor = lightRGB3;

            }
           

        }

        private void showGestureDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(gestureDictionary);
            }
            catch
            {
                MessageBox.Show("error: "+gestureDictionary+ " file has been removed from its location !");
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //change live label location
            label1.Location = new Point(30, this.Size.Height - 100);
            label2.Location = new Point(10, this.Size.Height - 78);
        }

        private void airDrawingModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { TextWrite("mode", "1"); }
            catch { Thread.Sleep(10); TextWrite("mode", "1"); }
            //call python and path arguements
            try
            {
                Process.Start(pythonEXE);
            }
            catch
            {
                MessageBox.Show("error: " + pythonEXE + " file has been removed from its location !");
            }
            //show live button
            //start the timer 
            timer1.Enabled = true;

            timer1.Start();

            //show turn off button
            closeTheCameraToolStripMenuItem.Visible = true;
        }

        private void mouseControlModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { TextWrite("mode", "2"); }
            catch { Thread.Sleep(10); TextWrite("mode", "2"); }
            //call python and path arguements
            try
            {
                Process.Start(pythonEXE);
            }
            catch
            {
                MessageBox.Show("error: " + pythonEXE + " file has been removed from its location !");
            }
            //show live button
            //start the timer 
            timer1.Enabled = true;

            timer1.Start();

            //show turn off button
            closeTheCameraToolStripMenuItem.Visible = true;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void closeTheCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //shut down the python backend
            try
            {
                foreach (var process in Process.GetProcessesByName("Gesture_backend"))
                {
                    process.Kill();
                }
            }
            catch
            {
                ;
            
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
/*
   public void live_button_cycle()
        {
            try
            {
                while (true)
                {
                    label1.Visible = true;
                    label2.Visible = true;
                    Thread.Sleep(750);
                    label1.Visible = false;
                    label2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
  
            Thread liveThread = new Thread(new ThreadStart(live_button_cycle));
            liveThread.Start();


            //create round button 
            
            RoundButton live = new RoundButton();
            this.Controls.Add(live);
            live.Size = new Size(5, 5);
            live.Text = "live";
            live.Font = new Font("new times roman", 12);
            live.ForeColor = Color.FromArgb(200,0,0) ;
            live.Location = new Point(200, 200);

*/
    
