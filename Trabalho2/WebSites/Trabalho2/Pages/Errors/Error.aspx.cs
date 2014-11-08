using System;
using System.Web.UI;

public partial class Pages_Errors_Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Exception lastError = Server.GetLastError();
            if (lastError.InnerException.Message != null)
            {
                lastError = lastError.InnerException;
            }
	lblMsgError.Text = lastError.Message;
        }

    }
}