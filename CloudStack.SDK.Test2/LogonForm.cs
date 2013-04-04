using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

using CloudStack.SDK;

namespace CloudStack.SDK.Test2
{
    public partial class LogonForm : Form
    {
        public LogonForm()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
        }

        private void WriteToLogBox(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => WriteToLogBox(message)));
            }
            else
            {
                textBoxLog.AppendText(message + "\r\n");
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Client client = new Client(new Uri(textBoxUrl.Text));
            client.Login(textBoxUsername.Text, textBoxPassword.Text, true);
            WriteToLogBox("Logged on to API");

            ListZonesRequest request = new ListZonesRequest();
            ListZonesResponse response = client.ListZones(request);
            WriteToLogBox(response.ToString());          
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
