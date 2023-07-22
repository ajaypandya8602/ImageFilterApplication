using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ImageFilterApplication
{
    public partial class Form1 : Form
    {
        string tempPath;
        SimpleTcpClient client;
        public Thread consoleThread;
        string filename;
        string orgImage;
        string g_ConsoleApplicationPath;
        string g_TempImageSaveFolder;

        int l_R;
        int l_G;
        int l_B;

        float l_X;
        float l_Y;
        double l_size;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(@"D:\tmpImages\");

                pnlImage.BackgroundImage = null;
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                // open file dialog   
                OpenFileDialog open = new OpenFileDialog();
                // image filters  
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box  

                    Image img;
                    using (var bmpTemp = new Bitmap(open.FileName))
                    {
                        img = new Bitmap(bmpTemp);
                    }

                    pnlImage.BackgroundImage = img;
                    filename = g_TempImageSaveFolder + "org.jpg";
                    orgImage = filename;

                    File.Delete(orgImage);
                    File.Copy(open.FileName, orgImage);
                }
            }
            catch(Exception e1)
            {
                
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            var fd = new SaveFileDialog();
            fd.Filter = "*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            fd.AddExtension = true;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                switch (Path.GetExtension(fd.FileName).ToUpper())
                {
                    case ".BMP":
                        pnlImage.BackgroundImage.Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case ".JPG":
                        pnlImage.BackgroundImage.Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".PNG":
                        pnlImage.BackgroundImage.Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["ConsoleApplicationPath"]))
            {
                MessageBox.Show("Please enter ConsoleApplicationPath in config file", "Image Editing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["TempImageSaveFolder"]))
            {
                MessageBox.Show("Please enter TempImageSaveFolder in config file", "Image Editing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            g_ConsoleApplicationPath = ConfigurationManager.AppSettings["ConsoleApplicationPath"];
            g_TempImageSaveFolder = ConfigurationManager.AppSettings["TempImageSaveFolder"];

            try
            {

                consoleThread = new Thread(() => startConsoleApplication());
                consoleThread.Start();

                Thread.Sleep(2000);

                client = new SimpleTcpClient();
                client.StringEncoder = Encoding.UTF8;
                client.DataReceived += Client_DataReceived;
                client.Connect("127.0.0.1", 8088);
                sendData("setTempFolderPath," + g_TempImageSaveFolder.Replace("\\","~") + ",");
            }
            catch(Exception e1)
            {
                MessageBox.Show("Unable to connect to server");
                return;
            }
        }

        public void sendData(string msg)
        {
            client.WriteLineAndGetReply(msg, TimeSpan.FromSeconds(3));
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            //MessageBox.Show(e.MessageString);

            String str = e.MessageString.Split(',')[1].Replace('~','\\');
            //MessageBox.Show(str);

//            MessageBox.Show(str.Length.ToString());
            String s = str.Substring(0, Math.Max(0, str.IndexOf('\0')));

            if (s != "")
            {
                Image img;
                using (var bmpTemp = new Bitmap(s))
                {
                    img = new Bitmap(bmpTemp);
                }

                pnlImage.BackgroundImage = img;
                tempPath = s;
            }
        }
       
        private void trk_brightness_Scroll(object sender, EventArgs e)
        {
            //MessageBox.Show("setBrightness," + filename + "," + trk_brightness.Value + ",");
            sendData("setBrightness," + filename + ","+ trk_brightness.Value+",");
        }

        public void startConsoleApplication()
        {

            try
            {
                //MessageBox.Show(System.Reflection.Assembly.GetEntryAssembly().Location);

                Process[] pname = Process.GetProcessesByName(g_ConsoleApplicationPath);

                if (pname.Length > 0)
                {
                    foreach (Process proces in pname)
                    {

                        proces.Kill();
                    }
                }
                var p = new Process();
                p.StartInfo.FileName = g_ConsoleApplicationPath;  // just for example, you can use yours.
                p.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Server not opening..");
                return;
            }

        }

        private void btnSaveBrightness_Click(object sender, EventArgs e)
        {
            filename = tempPath;
            trk_brightness.Value = 0;
        }

        private void trk_contrast_Scroll(object sender, EventArgs e)
        {
            double val = trk_contrast.Value;
            if (trk_contrast.Value == -4)
                val = 0.15;
            else if (trk_contrast.Value == -3)
                val = 0.25;
            else if (trk_contrast.Value == -2)
                val = 0.50;
            else if (trk_contrast.Value == -1)
                val = 0.75;
            else if (trk_contrast.Value == 0)
                val = 1;
            else if (trk_contrast.Value == 1)
                val = 1.15;
            else if (trk_contrast.Value == 2)
                val = 1.25;
            else if (trk_contrast.Value == 3)
                val = 1.5;
            else if (trk_contrast.Value == 4)
                val = 1.75;
            
            sendData("setContrast," + filename + "," + val + ",");
        }

        private void btnSaveContrast_Click(object sender, EventArgs e)
        {
            filename = tempPath;
            trk_contrast.Value = 0;
        }

        private void btnSaveSmooth_Click(object sender, EventArgs e)
        {
            filename = tempPath;
            trk_smooth.Value = 1;
        }

        private void trk_smooth_Scroll(object sender, EventArgs e)
        {
            sendData("setBlur," + filename + "," + trk_smooth.Value + ",");
        }

        private void btnResetImage_Click(object sender, EventArgs e)
        {
            filename = orgImage;
            trk_smooth.Value = 1;
            trk_contrast.Value = 0;
            trk_brightness.Value = 0;


            Image img;
            using (var bmpTemp = new Bitmap(orgImage))
            {
                img = new Bitmap(bmpTemp);
            }

            pnlImage.BackgroundImage = img;
        }

        private void cmbDefaultFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDefaultFilter.SelectedIndex == 0)
            {
                sendData("setBlackandWhite," + filename + ",");
            }
            else if (cmbDefaultFilter.SelectedIndex == 1)
            {
                sendData("setEdgeImage," + filename + ",");
            }
        }

        private void pnlImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pnlAddText.Visible = true;
            
            l_X =  e.X * ((float)pnlImage.BackgroundImage.Width / pnlImage.Width);
            l_Y =  e.Y * ((float)pnlImage.BackgroundImage.Height / pnlImage.Height);   
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                l_R = colorDlg.Color.R;
                l_G = colorDlg.Color.G;
                l_B = colorDlg.Color.B;

            }
        }

        private void btnSetText_Click(object sender, EventArgs e)
        {
            if(cmbFontSize.SelectedIndex == 0)
            {
                l_size = 0.2;
            }
            else if (cmbFontSize.SelectedIndex == 0)
            {
                l_size = 0.5;
            }
            else if (cmbFontSize.SelectedIndex == 1)
            {
                l_size = 0.8;
            }
            else if (cmbFontSize.SelectedIndex == 2)
            {
                l_size = 1;
            }
            else if (cmbFontSize.SelectedIndex == 3)
            {
                l_size = 1.2;
            }
            else if (cmbFontSize.SelectedIndex == 4)
            {
                l_size = 1.5;
            }
            else if (cmbFontSize.SelectedIndex == 5)
            {
                l_size = 1.8;
            }
            else if (cmbFontSize.SelectedIndex == 6)
            {
                l_size = 2;
            }
            else if (cmbFontSize.SelectedIndex == 7)
            {
                l_size = 2.2;
            }
            else if (cmbFontSize.SelectedIndex == 8)
            {
                l_size = 2.5;
            }
            else if (cmbFontSize.SelectedIndex == 9)
            {
                l_size = 2.8;
            }
            sendData("AddTextOnImage," + filename + "," +txtAddText.Text+ ","+ l_size + "," + l_X + "," + l_Y + "," + l_B + "," + l_G + "," + l_R + ",");

            pnlAddText.Visible = false;
        }

        private void btnApplytext_Click(object sender, EventArgs e)
        {
            filename = tempPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filename = tempPath;
        }
    }
}
