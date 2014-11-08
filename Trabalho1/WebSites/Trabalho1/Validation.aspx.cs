using System;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Newtonsoft.Json;
public partial class Validation : System.Web.UI.Page
{
    public bool isValid = true;
    public string message = "";
    String Json = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGvXml();
    }
    private void GenerateJson()
    {
        XmlDocument livros = new XmlDocument();
        livros.Load(Server.MapPath("livros.xml"));
        Json = ConvertXMLToJSON.XmlToJSON(livros);
        lblJson.Text = Json;
        pnlJson.Style.Add("border-style", "solid");
    }
    private void BindGvXml()
    {
        DataSet dataset = new DataSet();
        dataset.ReadXml(Server.MapPath("~/livros.xml"));
        GvXML.DataSource = dataset.Tables[0].DefaultView;
        GvXML.DataBind();
    }
    private void MyValidatingEvent(object sender, ValidationEventArgs e)
    {
        isValid = false;
        message = e.Message;
    }
    public void AddBook()
    {
        XElement todosLivros = XElement.Load(Server.MapPath("~/livros.xml"));
        XElement livro = new XElement("livro");
        livro.Add(new XElement("titulo", txtTitulo.Text));
        livro.Add(new XElement("autor", txtAutor.Text));
        livro.Add(new XElement("editora", txtEditora.Text));
        todosLivros.Add(livro);
        todosLivros.Save(Server.MapPath("~/livros.xml"));
    }
    protected void btnInserir_Click(object sender, EventArgs e)
    {
        AddBook();
        ClearFields();
        BindGvXml();
    }
    private void ClearFields()
    {
        txtAutor.Text = string.Empty;
        txtEditora.Text = string.Empty;
        txtTitulo.Text = string.Empty;
        lblMensagem.Text = "";
        lblTextoValidacao.Text = "";
        lblJson.Text = "";
        pnlJson.Style.Clear();
    }
    protected void validaSchema_Click(object sender, EventArgs e)
    {
        XmlTextReader reader = new XmlTextReader(Server.MapPath("livros.xml"));
        XmlValidatingReader validator = new XmlValidatingReader(reader);
        validator.ValidationType = ValidationType.Schema;
        validator.ValidationEventHandler += new ValidationEventHandler(MyValidatingEvent);
        while (validator.Read())
        {
        }
        if (isValid)
        {
            lblTextoValidacao.Style.Add("Color", "green");
            lblMensagem.Text = "Validation By Schema";
            lblTextoValidacao.Text = "Document is Valid";
        }
        else
        {
            lblTextoValidacao.Style.Add("Color", "red");
            lblTextoValidacao.Text = "Document is NOT valid!";
            lblMensagem.Text = "Error: " + message;
        }
        reader.Close();
    }
    protected void validaDTD_Click(object sender, EventArgs e)
    {
        XmlTextReader reader = new XmlTextReader(Server.MapPath("livros.xml"));
        XmlValidatingReader validator = new XmlValidatingReader(reader);
        validator.ValidationType = ValidationType.DTD;
        validator.ValidationEventHandler += new ValidationEventHandler(MyValidatingEvent);
        while (validator.Read())
        {
        }
        if (isValid)
        {
            lblTextoValidacao.Style.Add("Color", "green");
            lblMensagem.Text = "Validation By DTD";
            lblTextoValidacao.Text = "Document is Valid";
        }
        else
        {
            lblTextoValidacao.Style.Add("Color", "red");
            lblTextoValidacao.Text = "Document is NOT valid!";
            lblMensagem.Text = "Error: " + message;
        }
        reader.Close();
    }
    protected void limpaValid_Click(object sender, EventArgs e)
    {
        ClearFields();
    }
    protected void mostraJson_Click(object sender, EventArgs e)
    {
        GenerateJson();
    }
}