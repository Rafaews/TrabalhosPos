using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_MultiplicationTables : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtNumber.Focus();
        }
        
    }

    protected void btnGenerateTables_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNumber.Text == "0")
            {
                lblErro.Text = ("*The value entered can't be 0!");
                txtNumber.Focus();
            }
            else if (txtNumber.Text == string.Empty)
            {
                lblErro.Text = ("*Enter an integer!");
                txtNumber.Focus();
            }
            else
            {
                int number = Convert.ToInt32(txtNumber.Text);
                string[] Tables = Tabuada.GeraTabuada(number);
                for (int i = 0; i < number; i++)
                {
                    Label lbl = new Label();
                    lbl.Style.Add("float", "left");
                    lbl.Style.Add("width", "176px");
                    lbl.Style.Add("text-align", "center");
                    lbl.Style.Add("padding", "10px");
                    lbl.Style.Add("margin", "2px");
                    lbl.Style.Add("background-color", "#cccccc");
                    lbl.Style.Add("border-radius", "10px");
                    lbl.Text = "<b>" + Tables[i] + "<b>";
                    pnlTables.Controls.Add(lbl);
                    lblErro.Text = string.Empty;
                }
            }
        }
        catch
        {
            lblErro.Text = ("*The value entered is not a positive integer!");
            txtNumber.Text = string.Empty;
            txtNumber.Focus();
        }
    }
}