using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YandexAPI.Maps;

namespace WindowsFormsSampleYandexAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YandexAPI.Maps.GeoCode geoCode = new GeoCode();

            string ResultSearchObject = geoCode.SearchObject("Алматы, " + textBox1.Text.Trim());
            label2.Text = geoCode.GetPoint(ResultSearchObject);
            string ImageUrl = geoCode.GetUrlMapImage(ResultSearchObject, Int32.Parse(comboBox1.Text), 650, 450);
            pictureBox1.Image = geoCode.DownloadMapImage(ImageUrl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label2.Text = "";
            comboBox1.Text = "17";
            pictureBox1.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Url = "http://maps.yandex.ru/?text=Казахстан, Алматы, Айтиева, 42";
        }
    }
}
