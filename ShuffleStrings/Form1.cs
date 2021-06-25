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


namespace ShuffleStrings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            statusStrip1.Items[0].Text = "Готов к работе";
            statusStrip1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.ShowDialog();

            string filename = openFileDialog1.FileName;

            statusStrip1.Items[0].Text = "Работаю...";
            statusStrip1.Refresh();


            //MessageBox.Show(filename);
            listBox1.Items.Clear();
 
            string[] nabor1 = new string[1];
            

            string path = @filename;

          
            // асинхронное чтение
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                int count = 0;
                while ((line =  sr.ReadLine()) != null)
                {
                    nabor1[count] = line;
                    Array.Resize(ref nabor1, nabor1.Length + 1);
                    //Console.WriteLine(line);
                    count = count + 1;
                }
                Array.Resize(ref nabor1, nabor1.Length - 1);
                //MessageBox.Show(Convert.ToString(nabor1.Length));
                //listBox1.Items.AddRange(nabor1);
                listBox1.Items.AddRange(nabor1);

                label3.Text = "Количество строк: " + Convert.ToString(listBox1.Items.Count);
                label3.Refresh();

                
                string[] nabor2 = new string[nabor1.Length];
                

                Array.Copy(nabor1, nabor2, nabor1.Length);

                Random randomize = new Random();
                string nline;
                for (int i = 0; i < nabor2.Length-1; i++)
                {

                    
                    int rnd = randomize.Next(nabor2.Length - 1);

                    if (i!=rnd)
                    {
                        nline = nabor2[i];
                        nabor2[i] = nabor2[rnd];
                        nabor2[rnd] = nline;


                    }

                }

                listBox2.Items.Clear();
                listBox2.Items.AddRange(nabor2);

                label4.Text = "Количество строк: " + Convert.ToString(listBox2.Items.Count);
                label4.Refresh();
            }

            statusStrip1.Items[0].Text = "Готов к работе";
            statusStrip1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            statusStrip1.Items[0].Text = "Работаю..";
            statusStrip1.Refresh();
            string[] nabor1 = new string[1];
            string[] nabor2 = new string[1];
            Array.Resize(ref nabor1, listBox1.Items.Count);

            for (int i = 0; i < listBox1.Items.Count - 1; i++)
            {

                nabor1[i] = Convert.ToString(listBox1.Items[i]);

            }

            Array.Resize(ref nabor2, nabor1.Length);
            Array.Copy(nabor1, nabor2, nabor1.Length);
            Array.Resize(ref nabor2, nabor1.Length-1);


            Random randomize = new Random();
            string nline;
            for (int i = 0; i < nabor2.Length - 1; i++)
            {

                
                int rnd = randomize.Next(nabor2.Length - 1);

                if (i != rnd)
                {
                    nline = nabor2[i];
                    nabor2[i] = nabor2[rnd];
                    nabor2[rnd] = nline;


                }

            }

            listBox2.Items.Clear();
            listBox2.Items.AddRange(nabor2);
            statusStrip1.Items[0].Text = "Готов к работе";
            statusStrip1.Refresh();
        }

 

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listBox1.Items.Count - 1; i++)
            {
                sb.Append(listBox2.Items[i]+"\n");
            }

            string s = sb.ToString();
            System.IO.File.WriteAllText(filename, s);
            MessageBox.Show("Файл сохранен");
        }
    }
}
