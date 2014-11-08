using System;

public partial class Pages_Home : System.Web.UI.Page
{
    public string url = "MultiplicationTables.aspx";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEx1_Click(object sender, EventArgs e)
    {
        url = "MultiplicationTables.aspx";
        lblExercício.Text = "Exercise #1";
    }

    protected void btnEx2_Click(object sender, EventArgs e)
    {
        url = "StringsNFiles.aspx";
        lblExercício.Text = "Exercse #2";
    }

    protected void btnEx3_Click(object sender, EventArgs e)
    {
        url = "TxtToXml.aspx";
        lblExercício.Text = "Exercse #3";
    }
}