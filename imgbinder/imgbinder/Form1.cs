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

namespace imgbinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //    void nothing()
            //    {
            //        int anything_number = 1;
            //        while (anything_number == 1)
            //        {
            //            break;
            //        }
            //    }
            //    nothing();

            //    i want to do this
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imagepath.Clear();
            string image_path = null;
            openFileDialog1.Title = "Choose Image File...";
            openFileDialog1.FileName = null;
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*) | *.*";
            openFileDialog1.InitialDirectory = System.Environment.CurrentDirectory;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image_path = openFileDialog1.FileName;
                imagepath.Text = image_path;
            }       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filepath.Clear();
            string file_path = null;
            openFileDialog2.Title = "Choose File...";
            openFileDialog2.FileName = null;
            openFileDialog2.Filter = "All files (*.*) | *.*";
            openFileDialog2.InitialDirectory = System.Environment.CurrentDirectory;
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                file_path = openFileDialog2.FileName;
                filepath.Text = file_path;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (imagepath.Text == "")
            {
                MessageBox.Show("Image File Was Not Selected!");
            }
            else
            {
                savepath.Clear();
                string save_path = null;
                saveFileDialog1.Title = "Save As...";
                string imgfile_ext = System.IO.Path.GetExtension(imagepath.Text);
                saveFileDialog1.FileName = "output" + imgfile_ext;
                saveFileDialog1.Filter = "All files (*.*) | *.*";
                saveFileDialog1.InitialDirectory = System.Environment.CurrentDirectory;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    save_path = saveFileDialog1.FileName;
                    savepath.Text = save_path;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            filebind(imagepath.Text, filepath.Text, savepath.Text);
        }

        public void filebind(string img, string file, string output)
        {
            if (string.IsNullOrEmpty(img) | string.IsNullOrEmpty(file) | string.IsNullOrEmpty(output))
            {
                MessageBox.Show("Something Paths Are Empty. Please Check.");
            }
            else
            {
                FileStream fs = new FileStream(output, FileMode.CreateNew, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);

                byte[] imgByte = File.ReadAllBytes(img);
                byte[] fileByte = File.ReadAllBytes(file);
                bw.Write(imgByte);
                bw.Write(fileByte);
                bw.Close();
                fs.Close();
                MessageBox.Show("Done!");
            }
        }
    }
}
