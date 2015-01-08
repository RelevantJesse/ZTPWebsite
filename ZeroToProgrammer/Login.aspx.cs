using System;
using System.Web.Security;
using ZeroToProgrammer.Tables;

namespace ZeroToProgrammer
{
    public partial class Login : System.Web.UI.Page
    {
        private Site _masterPage;
        private Site MasterPage
        {
            get
            {
                if (_masterPage == null)
                    _masterPage = Page.Master as Site;

                return _masterPage;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MasterPage.SetError("User doesn't exist");
                return;
            }

            string passwordHash = UsersTable.GetUserPassword(txtUsername.Text);

            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                MasterPage.SetError("User doesn't exist");
                return;
            }

            if (!BCrypt.Net.BCrypt.Verify(txtPassword.Text, passwordHash))
            {
                MasterPage.SetError("Fail");
            }
            else
            {
                FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, false);
                MasterPage.SetSuccess("Logged in!");
            }
        }

        
    }
}