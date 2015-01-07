using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ZeroToProgrammer
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSuccess.Visible = false;

            if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlAnchor a = new HtmlAnchor();
                a.HRef = "#";
                a.InnerHtml = HttpContext.Current.User.Identity.Name;
                li.Controls.Add(a);
                ulUserInfo.Controls.Add(li);

                li = new HtmlGenericControl("li");
                HtmlButton btnLogout = new HtmlButton();
                btnLogout.Attributes.Add("class", "btn btn-default navbar-btn");
                btnLogout.InnerHtml = "Logout";
                btnLogout.ServerClick += Logout;
                li.Controls.Add(btnLogout);
                ulUserInfo.Controls.Add(li);

                ulLoginInfo.Visible = false;
                ulUserInfo.Visible = true;
            }
            else
            {
                ulLoginInfo.Visible = true;
                ulUserInfo.Visible = false;
            }
            
        }

        private void Logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            Response.Redirect("Login.aspx");
        }

        public void SetError(string text)
        {
            lblError.Text = text;
            divError.Visible = true;
        }

        public void SetSuccess(string text)
        {
            lblSuccess.Text = text;
            divSuccess.Visible = true;
        }
    }
}