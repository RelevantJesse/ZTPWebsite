using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ZeroToProgrammer.Tables;

namespace ZeroToProgrammer
{
    public partial class News : System.Web.UI.Page
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
            BuildNewsSection();
        }

        private void BuildNewsSection()
        {
            DataTable news;
            try
            {
                news = NewsTable.GetNews();
            }
            catch (Exception ex)
            {
                MasterPage.SetError("Error saving to database:\n" + ex.Message);
                return;
            }

            if (news.Rows.Count == 0)
            {
                MasterPage.SetError("No results found");
                return;
            }

            foreach (DataRow row in news.Rows)
            {
                Panel panel = new Panel();

                HtmlGenericControl header = new HtmlGenericControl("h2");
                header.InnerHtml = row["Title"].ToString();
                panel.Controls.Add(header);

                HtmlGenericControl date = new HtmlGenericControl("p");
                date.InnerHtml = ((DateTime) row["ModifiedDate"]).ToString("M/d/yyyy");
                panel.Controls.Add(date);

                HtmlGenericControl body = new HtmlGenericControl("p");
                body.InnerHtml = row["Content"].ToString();
                panel.Controls.Add(body);

                pnlNews.Controls.Add(panel);
            }
        }
    }
}