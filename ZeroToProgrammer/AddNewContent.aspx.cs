using System;
using ZeroToProgrammer.Tables;

namespace ZeroToProgrammer
{
    public partial class AddNewContent : System.Web.UI.Page
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
            if (!IsPostValid())
                return;
            
            try
            {
                NewsTable.Add(txtTitle.Text, txtContent.Text);
            }
            catch (Exception ex)
            {
                MasterPage.SetError("Error saving to database:\n" + ex.Message);
                return;
            }

            MasterPage.SetSuccess("News added successfully!");
        }

        private bool IsPostValid()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MasterPage.SetError("Please enter a title");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MasterPage.SetError("Please enter some content");
                return false;
            }

            return true;
        }
    }
}