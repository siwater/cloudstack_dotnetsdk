using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

using CloudStack.SDK;

namespace CloudStack.SDK.Test2
{
    public partial class MainForm : Form
    {

        private Client client;

        public MainForm()
        {
            InitializeComponent();
            InitializeSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        #region Authentication Menu

        private void logonToolStripMenuItem_Click(object sender, EventArgs e) {
            CredentialsForm credentialsForm = new CredentialsForm("User Name", "Password", true, true);
            DialogResult r = credentialsForm.ShowDialog();
            if (r == DialogResult.OK) {
                try {
                    client = new Client(new Uri(textBoxUrl.Text));
                    client.Login(credentialsForm.UserName, credentialsForm.Password, credentialsForm.DomainName, credentialsForm.HashPassword);
                    UpdateCurentUser(credentialsForm.UserName);
                } catch (Exception ex) {
                    WriteToLogBox(ex.ToString());
                }
            }
        }

        private void ssoToolStripMenuItem_Click(object sender, EventArgs e) {
            CredentialsForm credentialsForm = new CredentialsForm("User Name", "SSO Key", true, false);
            DialogResult r = credentialsForm.ShowDialog();
            if (r == DialogResult.OK) {
                try {
                    client = new Client(new Uri(textBoxUrl.Text));
                    client.LoginWithSso(credentialsForm.UserName, credentialsForm.Password, credentialsForm.DomainName);
                    UpdateCurentUser(credentialsForm.UserName);
                } catch (Exception ex) {
                    WriteToLogBox(ex.ToString());
                }
            }
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SessionEstablished()) {
                try {
                    client.Logout();
                    client = null;
                    UpdateCurentUser("Not logged in");
                } catch (Exception ex) {
                    WriteToLogBox(ex.ToString());
                }
            }
        }

        private void useAPIKeysToolStripMenuItem_Click(object sender, EventArgs e) {
            CredentialsForm credentialsForm = new CredentialsForm("API Key", "Secret Key", false, false);
            DialogResult r = credentialsForm.ShowDialog();
            if (r == DialogResult.OK) {
                try {
                    client = new Client(new Uri(textBoxUrl.Text), credentialsForm.UserName, credentialsForm.Password);
                    WriteToLogBox("Warning: credentials have not be validated!!");
                    UpdateCurentUser(credentialsForm.UserName.Substring(0, 10));
                } catch (Exception ex) {
                    WriteToLogBox(ex.ToString());
                }
            }
        }

        private void cloneSessionToolStripMenuItem_Click(object sender, EventArgs e) {
            if ((client == null) ||
                string.IsNullOrEmpty(client.SessionKey) ||
                (client.Cookies == null)) {
                MessageBox.Show(
                    "You must first login or SSO to CloudStack to create a session to clone",
                    "No Session",
                    MessageBoxButtons.OK);
                return;
            }
            string sessionKey = client.SessionKey;
            CookieCollection cookies = client.Cookies;
            Cookie jsessionId = getSessionCookie(client.Cookies);
            if (jsessionId == null) {
                MessageBox.Show(
                    "No session cookie was found - unable to clone session",
                    "No Session",
                    MessageBoxButtons.OK);
                return;
            }
            Cookie newCookie = new Cookie(jsessionId.Name, jsessionId.Value);
            newCookie.Domain = jsessionId.Domain;
            newCookie.Path = jsessionId.Path;
            client = new Client(client.ApiAddress, sessionKey, newCookie);
            MessageBox.Show(
                "You session has been replaced with a clone using JSESSIONID cookie and sessionKey",
                "Cloned Session",
                MessageBoxButtons.OK);
        }

        private Cookie getSessionCookie(CookieCollection cookies) {
            if (cookies != null) {
                foreach (Cookie c in cookies) {
                    if (c.Name == "JSESSIONID") {
                        return c;
                    }
                }
            }
            return null;
        }

        private void UpdateCurentUser(string text) {
            this.labelCurrentUser.Text = text;
        }

        #endregion

        #region List Menu

        private void listZonesToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SessionEstablished()) {
                try {
                    ListZonesRequest request = new ListZonesRequest();
                    ListZonesResponse response = client.ListZones(request);
                    WriteToLogBox(response.XmlResponse.ToString());            
                } catch (Exception ex) {
                    WriteToLogBox(ex.ToString());
                }
            }
        }

        #endregion

        private bool SessionEstablished() {
            if (client == null) {
                MessageBox.Show("You have not authenticated to CloudStack", " Not Authenticated", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }


        #region Logging

        private void WriteToLogBox(string message) {
            if (InvokeRequired) {
                Invoke(new MethodInvoker(() => WriteToLogBox(message)));
            } else {
                textBoxLog.AppendText(message + "\r\n");
            }
        }

        private void buttonClearLog_Click(object sender, EventArgs e) {
            this.textBoxLog.Clear();
        }

        #endregion

        #region Persistent Settings

        private void InitializeSettings() {
            LoadSettings();
            AddSettingsEvents();
        }

        private void AddSettingsEvents() {
            this.textBoxUrl.Leave += (s, e) => SettingsChanged(s, e);
        }

        private void SettingsChanged(object sender, EventArgs e) {
            SaveSettings();
        }

        private void LoadSettings() {
            this.textBoxUrl.Text = Properties.Settings.Default.Url;
        }

        private void SaveSettings() {
            Properties.Settings.Default.Url = this.textBoxUrl.Text;
            Properties.Settings.Default.Save();
        }

        #endregion

 

   

      

    
    }
}
