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

        XmlTextWriter writer = new XmlTextWriter("MailList.xml", System.Text.Encoding.UTF8);

        private void button2_Click(object sender, EventArgs e)
        {
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("People");
            foreach (ListViewItem lvi in listView1.Items)
            {
                createNode(lvi.SubItems[0].Text, lvi.SubItems[1].Text, lvi.SubItems[2].Text);
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show("Mailing List saved in XML file!");
        }

        private void createNode(string pName, string pEmail, string pCompany) {
            writer.WriteStartElement("Person");
            writer.WriteStartElement("Name");
            writer.WriteString(pName);
            writer.WriteEndElement();
            writer.WriteStartElement("Email");
            writer.WriteString(pEmail);
            writer.WriteEndElement();
            writer.WriteStartElement("Company");
            writer.WriteString(pCompany);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
