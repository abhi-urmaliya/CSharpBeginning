using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace EmailSender
{
    public partial class Form1 : Form
    {
        public static string to;
        public Form1()
        {
            InitializeComponent();
            Form2 f = new Form2();
            f.ShowDialog();
            recipients.Text = to;
            emailFrom.Text = EmailSender.Properties.Settings.Default.EmailFrom;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                if (!emailFrom.Text.Contains("@outlook.com"))
                {
                    MessageBox.Show("Enter a valid email address with @outlook.com", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (emailPassword.Text == "")
                {
                    MessageBox.Show("Enter password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (recipients.Text == "")
                {
                    MessageBox.Show("Enter recipient(s)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (subject.Text == "") {
                    DialogResult dialogRes = MessageBox.Show("Are you sure you want to send mail without subject?","Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogRes == DialogResult.No) {
                        return;
                    }
                }
                if (body.Text == "")
                {
                    DialogResult dialogRes = MessageBox.Show("Are you sure you want to send mail without body?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogRes == DialogResult.No)
                    {
                        return;
                    }
                }
                MailMessage message = new MailMessage();
                message.From = new MailAddress(emailFrom.Text);
                message.Subject = subject.Text;
                message.Body = body.Text;
                foreach (string s in recipients.Text.Split(';'))
                    message.To.Add(s);
                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential(emailFrom.Text, emailPassword.Text);
                client.Host = "smtp.live.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Send(message);
            }
            catch { MessageBox.Show("There was an error sending the message! Make sure you typed in your credentials correctly and you have an internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { button1.Enabled = true; }
        }

        private void saveAsDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailSender.Properties.Settings.Default.EmailFrom = emailFrom.Text;
            EmailSender.Properties.Settings.Default.Save();
        }
    }
}
