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
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("People");
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
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
            XmlDocument doc = new XmlDocument();
            doc.Load("MailList.xml");
            foreach (ListViewItem lvi in listView1.Items)
            {
                XmlNode person = doc.CreateElement("Person");
                XmlNode pName = doc.CreateElement("Name");
                XmlNode pEmail = doc.CreateElement("Email");
                XmlNode pCompany = doc.CreateElement("Company");
                pName.InnerText = lvi.SubItems[0].Text;
                pEmail.InnerText = lvi.SubItems[1].Text;
                pCompany.InnerText = lvi.SubItems[2].Text;
                person.AppendChild(pName);
                person.AppendChild(pEmail);
                person.AppendChild(pCompany);
                doc.DocumentElement.AppendChild(person);
                doc.Save("MailList.xml");
            }
            MessageBox.Show("Mailing List saved in XML file!");
        }
    }
}
