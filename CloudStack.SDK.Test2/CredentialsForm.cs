using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CloudStack.SDK.Test2 {

    public partial class CredentialsForm : Form {

        public CredentialsForm(string userNameLabelText, string passwordLabelText, bool showDomain, bool showHashCheck) {
            InitializeComponent();
            labelDomainName.Visible = showDomain;
            textBoxDomain.Visible = showDomain;
            labelUserName.Text = userNameLabelText;
            labelPassword.Text = passwordLabelText;
            CancelButton = this.buttonCancel;
            buttonOK.DialogResult = DialogResult.OK;
            checkBoxHashPassword.Visible = showHashCheck;
        }

        public string UserName { get { return this.textBoxUserName.Text; } }

        public string Password { get { return this.textBoxPassword.Text; } }

        public string DomainName { get { return this.textBoxDomain.Text; } }

        public bool HashPassword { get { return this.checkBoxHashPassword.Checked; } }

        private void buttonOK_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
