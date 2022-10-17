//Moshoaliba,K-34316345

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data.OleDb;

namespace CellNumber_creator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtInput2.Text,out int age) && int.TryParse(txtInput3.Text,out int num))
            {
                SaveFile();
            }
            else
            {
                MessageBox.Show("incorrect input!!");
            }
        }

        private void SaveFile()
        {
            try
            {
                int randNumber;
                Random rand = new Random();
                randNumber = rand.Next(1000000, 3000001);

                const double price = 3.50;

                StreamWriter outputFile;
                
                if(saveD.ShowDialog() == DialogResult.OK)
                {
                    string path = saveD.FileName;
                    outputFile = File.CreateText(path);
                    outputFile.WriteLine("A simcard has been requested by " + txtInput.Text+" "+txtInput1.Text);
                    outputFile.WriteLine("Who is " + txtInput2.Text + " years ");
                    outputFile.WriteLine("\nThe details are as follows:");
                    outputFile.WriteLine("old numbers: " + txtInput3.Text);
                    if(radioButton1.Checked)
                    {
                        outputFile.WriteLine("New numbers: 076" + randNumber);
                        outputFile.WriteLine("Network: Vodacom");
                        outputFile.WriteLine("Price: R" +price*5);
                    }
                    else if(radioButton2.Checked)
                    {
                        outputFile.WriteLine("New numbers: 064" + randNumber);
                        outputFile.WriteLine("Network: MTN");
                        outputFile.WriteLine("Price: R" + price * 3);
                    }
                    else if(radioButton3.Checked)
                    {
                        outputFile.WriteLine("New numbers: 082" + randNumber);
                        outputFile.WriteLine("Network: Cell C");
                        outputFile.WriteLine("Price: R" + price * 1.50);
                    }

                    outputFile.Close();
                    MessageBox.Show("Done!!");

                }
                else
                {
                    MessageBox.Show("No file selected");
                }

            }
            catch(Exception)
            {
                MessageBox.Show("Error while trying to save !!");
            }
        }

        private void OpenFile()
        {
            StreamReader readFile;

            try
            {
                if(openD.ShowDialog() == DialogResult.OK)
                {
                    string path = openD.FileName;
                    readFile = File.OpenText(path);

                    while(!readFile.EndOfStream)
                    {
                        listBox1.Items.Add(readFile.ReadLine());
                    }

                    readFile.Close();
                }
                else
                {
                    MessageBox.Show("No path selected!!");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error while opening file!!");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
