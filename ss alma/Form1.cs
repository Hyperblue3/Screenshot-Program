using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace ss_alma
{
    public partial class Form1 : Form
    {
        string KayitYolu = @"C:\ssler";
        string ResimAdi()
        {
            return "SS_" + DateTime.Now.ToString().Replace(" ", "_").Replace(":", "_") + ".jpg";


        }
        void Kaydet(string resimadi)
        {
            if (!File.Exists(KayitYolu))
                Directory.CreateDirectory(KayitYolu);
            Screenshot().Save(KayitYolu + "\\" + resimadi + "", ImageFormat.Jpeg);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Home)
                Kaydet(ResimAdi());

        }
        public Form1()
        {
            InitializeComponent();
            



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kaydet(ResimAdi());
        }
        private void button2_Click(object sender, EventArgs e) { 
        Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Bitmap Screenshot()
        {
            this.Opacity = 0;
            //ss alan kodlar
            Bitmap Screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics GFX = Graphics.FromImage(Screenshot);
            GFX.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);

            this.Opacity = 1;
            return Screenshot;

        }

      
    }
}