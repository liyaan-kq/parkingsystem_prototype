using System;
using System.Windows.Forms;
using ParkingSystem.Helpers;
using ParkingSystem.Logic;
using red_framework;

namespace ParkingSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Control missing = FormControls.FirstRequired(txtUsername, txtPassword);
            if (missing != null)
            {
                string message = !FormControls.Required(txtPassword, "Password") && missing == txtUsername
                    ? "Enter your username and password."
                    : missing == txtUsername ? "Enter your username." : "Enter your password.";
                StatusLine.Error(lblError, message, missing);
                return;
            }

            bool ok;
            try
            {
                ok = AuthService.Login(txtUsername.Text, txtPassword.Text);
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
                return;
            }

            if (!ok)
            {
                FormControls.ClearInputs(txtPassword);
                StatusLine.Error(lblError, "Invalid username or password.", txtPassword);
                return;
            }

            Hide();
            bool loggedOut;
            using (DashboardForm dashboard = new DashboardForm())
            {
                dashboard.ShowDialog();
                loggedOut = dashboard.LoggedOut;
            }

            if (loggedOut)
            {
                FormControls.ClearInputs(txtPassword);
                FormControls.ClearInputs(chkShowPassword);
                StatusLine.Clear(lblError);
                Show();
                txtPassword.Focus();
            }
            else
            {
                Close();
            }
        }
    }
}
