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

namespace MailKutusu
{
    public partial class Form1 : Form
    {
        public List<Mesaj> mesajlar = new List<Mesaj>();
        public Form1()
        {
            InitializeComponent();
            //for (int i = 1; i <= 4; i++)
            //{
            //    StreamReader sr = new StreamReader("./mesajlar/" + i + ".txt");
            //    string icerik = sr.ReadToEnd();
            //    //MessageBox.Show(icerik);

            //    Mesaj mesaj = new Mesaj();
            //    mesaj.Baslik = Convert.ToString(i);
            //    mesaj.Icerik = icerik;
            //    mesajlar.Add(mesaj);
            // }

            var txtFiles = Directory.EnumerateFiles("./mesajlar/", "*.txt");
            foreach(string file in txtFiles)
            {
                //StreamReader sr = new StreamReader(file);
                //string line = sr.ReadLine();

                var filecontent = File.ReadAllText(file);
                MessageBox.Show(filecontent);
                //split; dosyayı yazıyı parçalar
                var texts = filecontent.Split('\n');

                Mesaj mesaj = new Mesaj();
                mesaj.Baslik = texts[0];
                mesaj.Gonderen = texts[1];
                mesaj.Alici = texts[2];
                for(int i=3; i<texts.Count(); i++)
                {
                    mesaj.Icerik += texts[i];
                }
               // mesaj.Icerik = texts[3];

                mesajlar.Add(mesaj);

            }

            comboBox1.DataSource = null;
            comboBox1.DataSource = mesajlar;
            comboBox1.DisplayMember = "Baslik";
        
    }

        private void button1_Click(object sender, EventArgs e)
        {

            Mesaj mesaj = new Mesaj();
            mesaj.Baslik = textBox1.Text;
            mesaj.Gonderen = textBox2.Text;
            mesaj.Alici = textBox3.Text;
            mesaj.Icerik = richTextBox1.Text;

            StreamWriter writer = new StreamWriter("./mesajlar/" + mesaj.Baslik + ".txt");
            writer.WriteLine(mesaj.Baslik);
            writer.WriteLine(mesaj.Gonderen);
            writer.WriteLine(mesaj.Alici);
            writer.WriteLine(mesaj.Icerik);
            writer.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mesaj mesaj = (Mesaj)comboBox1.SelectedItem;
            richTextBox1.Text = comboBox1.SelectedItem.ToString();

        }
    }
}
