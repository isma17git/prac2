using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace prac2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedurl = listBoxHistory.SelectedItem.ToString();
            webBrowser1.Navigate(selectedurl);
            listBoxHistory.Visible = false;
        }


        public void AddHistory(string url)
        {
            // Corrected the 'count' property to 'Items.Count'
            if (listBoxHistory.Items.Count == 0 || listBoxHistory.Items[listBoxHistory.Items.Count - 1].ToString() != url)
            {
                listBoxHistory.Items.Add(url);
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.hw.ac.uk");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
        
        public Form1(IContainer components, WebBrowser webBrowser1, Button button1, Button button2, Button button3, Button button4, TextBox textBox1, Button button5, ListBox listBoxHistory)
        {
            this.components = components;
            this.webBrowser1 = webBrowser1;
            this.button1 = button1;
            this.button2 = button2;
            this.button3 = button3;
            this.button4 = button4;
            this.textBox1 = textBox1;
            this.button5 = button5;
            this.listBoxHistory = listBoxHistory;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string WebPage = textBox1.Text.Trim();
            webBrowser1.Navigate(WebPage);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBoxHistory.BringToFront();
            //listBoxHistory.Visible = false;
            // 
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string currentUrl = webBrowser1.Url.ToString();

            // Only add the URL if it's not already in the history
            if (!listBoxHistory.Items.Contains(currentUrl))
            {
                AddHistory(currentUrl); // Add the current URL to history once it's fully loaded
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string homepage = "https://google.com";
            textBox1.Text = homepage;
            webBrowser1.Navigate(homepage);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBoxHistory.Visible = !listBoxHistory.Visible;
        }
    }
}
    
