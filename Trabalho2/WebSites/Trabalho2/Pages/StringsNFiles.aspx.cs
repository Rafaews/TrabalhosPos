using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Pages_StringsNFiles : System.Web.UI.Page
{
    public string path = @"c:\Users\joãorafael\documents\visual studio 2013\WebSites\Trabalho2\Files\exercicio1log.txt";
    string newFile = @"c:\Users\joãorafael\documents\visual studio 2013\WebSites\Trabalho2\Files\RecoveredRegistries.txt";
    public string text = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (File.Exists(newFile))
            {
                File.Delete(newFile);
            }
        }
    }
    
    protected void BtnOriginalFile_Click(object sender, EventArgs e)
    {
        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);
            while (sr.Peek() >= 0)
            {
                text = text + sr.ReadLine() + "<br>";
            }
            lblFile.Text = text;
        }
        else
            lblFile.Text = "<b>The File doesn't Exists<b>";
        
    }
    
    protected void BtnFillDDL_Click(object sender, EventArgs e)
    {
        if (ddlExercise.Items.Count == 0)
        {
            ddlExercise.Items.Add("---Date-- - --Time-- - -Destination");
            string line = null;
            TextReader reader = new StreamReader(path);
            while (true)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    if (line.Contains("accept"))
                    {
                        line = line.Replace("\"", string.Empty);
                        string[] items = line.Split(' ');
                        ddlExercise.Items.Add(items[2] + " - " + items[4] + " - " + items[18]);
                    }
                }
                else
                {
                    break;
                }
            }
            reader.Close();
            reader = null;
            lblFile.Text = "<b>Drop Down List Filled<b>";
        }
        else
        {
            lblFile.Text = "<b>Drop Down List is already Filled<b>";
        }
        
    }

    protected void SaveNewFile_Click(object sender, EventArgs e)
    {
        if (ddlExercise.Items.Count != 0)
        {
            try
            {
                if (File.Exists(newFile))
                {
                    File.Delete(newFile);
                }
                StreamWriter file = new StreamWriter(newFile);
                foreach (ListItem item in ddlExercise.Items)
                {
                    file.WriteLine(item);
                }
                file.Close();
                lblFile.Text = "<b>File Created<b>";
            }
            catch (Exception erro)
            {
                lblFile.Text = erro.Message;
            }
        }
        else
        {
            lblFile.Text = "<b>First Click Fill DDL<b>";
        }
        
    }

    protected void ReadNewFile_Click(object sender, EventArgs e)
    {
        if (File.Exists(newFile))
        {
            StreamReader sr = new StreamReader(newFile);
            while (sr.Peek() >= 0)
            {
               text = text + sr.ReadLine() + "<br>";
            }
            lblFile.Text = text;
            sr.Close();
            sr = null;
        }
        else
	    {
            lblFile.Text = "<b>First Click Save New File<b>";
	    }
        
        
    }
}