using System;
using System.Windows.Forms;
using TradingCompany.BL.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TradingCompany.WF
{
    public partial class LoginForm : Form
    {
        protected readonly IAuthManager _authManager;
        public LoginForm(IAuthManager authManager)
        {
            InitializeComponent();

            _authManager = authManager;
        }

        private void doLogin()
        {
            if (_authManager.Login(tbUsername.Text, tbPassword.Text))
            {
                DialogResult = DialogResult.OK;
                Program.CurrentUserID = _authManager.GetId(tbUsername.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            doLogin();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                doLogin();
            }
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tbPassword.Select();
            }
        }
    }
}
