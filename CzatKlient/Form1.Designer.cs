namespace CzatKlient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorkerMainThread = new System.ComponentModel.BackgroundWorker();
            this.buttonSend = new System.Windows.Forms.Button();
            this.backgroundWorkerChat = new System.Windows.Forms.WebBrowser();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.textBoxNick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backgroundWorkerMainThread
            // 
            this.backgroundWorkerMainThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMainThread_DoWork);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(817, 584);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "Wyślij";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // backgroundWorkerChat
            // 
            this.backgroundWorkerChat.IsWebBrowserContextMenuEnabled = false;
            this.backgroundWorkerChat.Location = new System.Drawing.Point(12, 214);
            this.backgroundWorkerChat.MinimumSize = new System.Drawing.Size(20, 20);
            this.backgroundWorkerChat.Name = "backgroundWorkerChat";
            this.backgroundWorkerChat.Size = new System.Drawing.Size(880, 338);
            this.backgroundWorkerChat.TabIndex = 1;
            this.backgroundWorkerChat.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.backgroundWorkerChat.WebBrowserShortcutsEnabled = false;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(13, 558);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(879, 20);
            this.textBoxMessage.TabIndex = 2;
            this.textBoxMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMessage_KeyDown);
            // 
            // textBoxNick
            // 
            this.textBoxNick.Location = new System.Drawing.Point(48, 19);
            this.textBoxNick.Name = "textBoxNick";
            this.textBoxNick.Size = new System.Drawing.Size(100, 20);
            this.textBoxNick.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nick:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(48, 45);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 5;
            this.buttonConnect.Text = "Połącz";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(48, 75);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonDisconnect.TabIndex = 6;
            this.buttonDisconnect.Text = "Wyjdź";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 619);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNick);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.backgroundWorkerChat);
            this.Controls.Add(this.buttonSend);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerMainThread;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.WebBrowser backgroundWorkerChat;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.TextBox textBoxNick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
    }
}

