using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace CzatKlient
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private string addressIPServer = "127.0.0.1";
        private BinaryWriter write;
        private bool isActive = false;
        public Form1()
        {
            InitializeComponent();
            backgroundWorkerChat.Document.Write("<html><head><style>body,table { font-size: 10pt; font - family: Verdana; margin: 3px 3px 3px 3px; font - color: black; }</ style ></ head >< body width =\"" + (backgroundWorkerChat.ClientSize.Width - 20).ToString() + "\">");
        }
        #region Metoda odwołująca się do własności kontrolki webBrowser1 z poziomu innego wątku
        delegate void SetTextHTMLCallBack(string tekst);
        private void SetTextHTML(string tekst)
        {
            if (backgroundWorkerChat.InvokeRequired)
            {
                SetTextHTMLCallBack f = new SetTextHTMLCallBack(SetTextHTML);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.backgroundWorkerChat.Document.Write(tekst);
            }
        }
        delegate void SetScrollCallBack();
        private void SetScroll()
        {
            if (backgroundWorkerChat.InvokeRequired)
            {
                SetScrollCallBack f = new SetScrollCallBack(SetScroll);
                this.Invoke(f);
            }
            else
            {
                this.backgroundWorkerChat.Document.Window.ScrollTo(1, int.MaxValue);
            }
        }

        #endregion
        private void AddText(string who, string message)
        {
            SetTextHTML("<table><tr><td width=\"10%\"><b>[" + who + "]: </ b ></ td > ");           
            SetTextHTML("<td colspan=2>" + message + "</td></tr></table>");
            SetScroll();
        }

        private void backgroundWorkerMainThread_DoWork(object sender, DoWorkEventArgs e)
        {
            UdpClient client = new UdpClient(2500);
            IPEndPoint addressIP = new IPEndPoint(IPAddress.Parse(addressIPServer), 0);
            string message = "";
            while (!backgroundWorkerMainThread.CancellationPending)
            {
                Byte[] bufor = client.Receive(ref addressIP);
                string data = Encoding.UTF8.GetString(bufor);
                string[] cmd = data.Split(new char[] { ':' });
                if (cmd[1] == "BYE")
                {
                    AddText("system", "klient odłączony");
                    client.Close();
                    return;
                }
                if (cmd.Length > 2)
                {
                    message = cmd[2];
                    for (int i = 3; i < cmd.Length; i++)
                        message += ":" + cmd[i];
                }
                AddText(cmd[0], message);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNick.Text != String.Empty)
                {
                    client = new TcpClient(addressIPServer, 6969);
                    textBoxNick.ReadOnly = true;
                    NetworkStream ns = client.GetStream();
                    write = new BinaryWriter(ns);
                    write.Write(textBoxNick.Text + ":HI:" + "pusty");
                    BinaryReader read = new BinaryReader(ns);
                    string answer = read.ReadString();
                    if (answer == "HI")
                    {
                        backgroundWorkerMainThread.RunWorkerAsync();
                        isActive = true;
                        buttonConnect.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Serwer odmawia nawiązania połączenia");
                        buttonConnect.Enabled = true; client.Close();
                    }
                }
                else
                    MessageBox.Show("Wpisz swój nick");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie można nawiązać połączenia " + ex.Message);
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (isActive && textBoxMessage.Text != String.Empty)
                write.Write(textBoxNick.Text + ":SAY:" + textBoxMessage.Text);
            textBoxMessage.Text = String.Empty;
        }

        private void textBoxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buttonSend_Click(sender, null);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (write != null)
            {
                try
                {
                    write.Write(textBoxNick.Text + ":BYE:" + "pusty");
                    write.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Błąd");
                }
            }
            if (backgroundWorkerMainThread.IsBusy)
                backgroundWorkerMainThread.CancelAsync();
            if (client != null)
                client.Close();
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
