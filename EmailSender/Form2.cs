using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSender
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(textBox1.Text);
            lvi.SubItems.Add(textBox2.Text);
            lvi.SubItems.Add(textBox3.Text);
            listView1.Items.Add(lvi);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void addToRecipientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0) {
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    Form1.to += lvi.SubItems[1].Text + ";";
                }
            }
        }

        private void removeSelectedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    lvi.Remove();
                }
            }
        }

        private void removeAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
        }
    }
}
