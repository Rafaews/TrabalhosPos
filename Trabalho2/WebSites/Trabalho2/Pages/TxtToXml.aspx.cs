using System;
using System.IO;
using System.Xml;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data;

public partial class Pages_TxtToXml : System.Web.UI.Page
{
    public string path = @"c:\Users\joãorafael\documents\visual studio 2013\WebSites\Trabalho2\Files\exercicio1log.txt";
    string newFile = @"c:\Users\joãorafael\documents\visual studio 2013\WebSites\Trabalho2\Files\LogFile.txt";
    string xmlFile = @"c:\Users\joãorafael\documents\visual studio 2013\WebSites\Trabalho2\Files\LogFile.xml";
    public string text = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (File.Exists(xmlFile))
            {
                File.Delete(xmlFile);
            }
            if (File.Exists(newFile))
            {
                File.Delete(newFile);
            }
        }
    }

    protected void BtnOriginalFile_Click(object sender, EventArgs e)
    {
        nullGv1();
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

    protected void btnLogFile_Click(object sender, EventArgs e)
    {
        if(File.Exists(path))
        {
            nullGv1();
            if (File.Exists(newFile))
            {
                File.Delete(newFile);
            }
            StreamWriter writer = new StreamWriter(newFile);
            string line = null;
            TextReader reader = new StreamReader(path);
            while (true)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    if (line.Contains("\"") && !line.Contains("Action"))
                    {
                        line = ClearSpaces(line);
                        writer.WriteLine(line);
                    }
                }
                else
                {
                    break;
                }
            }
            writer.Close();
            writer = null;
            lblFile.Text = "<b>File Sussefuly Saved!!<br><a href=\"../Files/LogFile.txt\" target=\"_blank\" style=\"text-decoration:none\">>> View File <<</a><b>";
        }
        else
        {
            lblFile.Text = "<b>The File doesn't Exists<b>";
        }
        
    }

    private string ClearSpaces(string line)
    {
        line = line.Replace("\"", string.Empty);
        line = line.Replace("  ", "|");
        line = line.Replace("|||||||", "|");
        line = line.Replace("|||", "|");
        line = line.Replace("||", "|");
        return line;
    }

    protected void generateXML_Click(object sender, EventArgs e)
    {
        nullGv1();

        if (File.Exists(newFile))
        {
            if (File.Exists(xmlFile))
            {
                File.Delete(xmlFile);
            }
            XmlDocument logs = new XmlDocument();
            XmlNode raiz = logs.CreateElement("logs");
            logs.AppendChild(raiz);
            logs.Save(xmlFile);

            XElement docLogs = XElement.Load(xmlFile);
            string line = null;
            TextReader reader = new StreamReader(newFile);
            while (true)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    string[] items = line.Split('|');
                    if (line.Contains("accept"))
                        docLogs.Add(AddElements(items, 2));
                    else
                        docLogs.Add(AddElements(items, 1));
                }
                else
                    break;
            }
            reader.Close();
            reader = null;
            docLogs.Save(xmlFile);
            lblFile.Text = "<b>XML Sussefuly Saved<b>";
        }
        else
            lblFile.Text = "<b>First click log file<b>";
    }

    private XElement AddElements(string[] items, int type)
    {
        XElement log = new XElement("log");
        log.Add(new XElement("N_Reg", items[0]));
        log.Add(new XElement("Date", items[1]));
        log.Add(new XElement("Time", items[2]));
        log.Add(new XElement("Inter", items[3]));
        log.Add(new XElement("Origin", items[4]));
        log.Add(new XElement("Type", items[5]));
        log.Add(new XElement("Action", items[6]));

        if (type==1)
        {
            log.Add(new XElement("Service", items[7]));
            log.Add(new XElement("Source", items[8]));
            log.Add(new XElement("Destination", items[9]));
            log.Add(new XElement("Protocol", items[10]));
            log.Add(new XElement("Rule", items[11]));
            log.Add(new XElement("S_Port", items[12]));
            log.Add(new XElement("Wall", items[13]));
            log.Add(new XElement("Obs", items[14]));
        }
        else if (type == 2)
        {
            log.Add(new XElement("Service", "---"));
            log.Add(new XElement("Source", items[7]));
            log.Add(new XElement("Destination", items[8]));
            log.Add(new XElement("Protocol", items[9]));
            log.Add(new XElement("Rule", "---"));
            log.Add(new XElement("S_Port", "---"));
            log.Add(new XElement("Wall", items[10]));
            log.Add(new XElement("Obs", items[11] + items[12]));
        }
        return log;
    }

    protected void ViewXML_Click(object sender, EventArgs e)
    {
        if (File.Exists(xmlFile))
        {
            lblFile.Text = string.Empty;
            FillGv1();
            Gv1.PageIndex = 0;

            lblFile.Text = "<b><a href=\"../Files/LogFile.xml\" target=\"_blank\" style=\"text-decoration:none\">>> View XML File <<</a><b>";
        }
        else
            lblFile.Text = "<b>First Click Generate XML<b>";
        
    }

    protected void Gv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gv1.PageIndex = e.NewPageIndex;
        FillGv1();
    }

    private void nullGv1()
    {
        Gv1.DataSource = null;
        Gv1.DataBind();
    }

    private void FillGv1()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(xmlFile);
        Gv1.DataSource = ds;
        Gv1.DataBind();
    }
}