<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Validation.aspx.cs" Inherits="Validation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trabalho1</title>
</head>
<body style="margin-left:450px; width:900px;">
    <form id="form1" runat="server">
                <div style="float:left; display:block; margin-left:-430px; border:solid; padding:10px; position:absolute;">
                    <h2>Todos os Livros</h2>
                    <asp:GridView ID="GvXML" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="titulo" HeaderText="Título" />
                            <asp:BoundField DataField="autor" HeaderText="Autor" />
                            <asp:BoundField DataField="editora" HeaderText="Editora" />
                        </Columns>
                    </asp:GridView>
                    <div>
                        <h2 style="text-align:center;">
                            <a href="livros.xml" target="_blank">Visualizar Qrquivo XML</a>
                        </h2>
                    </div>
                </div>
                    <asp:Panel runat="server" width="420px" Style="padding:10px" BorderStyle="Solid">
                        <h2>Adiciona Livros</h2>
                        <table border="0">
                            <tr>
                                <td>Titulo: </td>
                                <td><asp:TextBox runat="server" ID="txtTitulo" style="margin-left: 0px" Width="230px" /></td>
                            </tr>
                            <tr>
                                <td>Autor: </td>
                                <td><asp:TextBox runat="server" ID="txtAutor" Width="230px" /></td>
                            </tr>
                            <tr>
                                <td>Editora: </td>
                                <td><asp:TextBox runat="server" ID="txtEditora" /></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:Button Text="Inserir" ID="btnInserir" runat="server" OnClick="btnInserir_Click" /></td>
                            </tr>
                        </table>
                    </asp:Panel>
        <div>
                    <asp:Panel runat="server" Style="padding:10px;margin-top:10px" Width="420px" BorderStyle="Solid">
                        <asp:Button Text="Validar Xml (Schema)" runat="server" ID="validaSchema" OnClick="validaSchema_Click" />
                        <asp:Button Text="Validar Xml (DTD)" runat="server" id="validaDTD" OnClick="validaDTD_Click" />
                        <asp:Button Text="Limpar Validação" runat="server" ID="limpaValid" OnClick="limpaValid_Click" />
                        <h2><asp:Label Text="" ID="lblTextoValidacao" runat="server" /></h2>
                        <h3><asp:Label Text="" ID="lblMensagem" runat="server" /></h3>
                    </asp:Panel>
            <asp:Panel runat="server" Width="420px" Style="margin-top:10px; padding:10px; border:solid;">
                <asp:Button Text="Gerar JSON" runat="server" id="mostraJson" OnClick="mostraJson_Click" />  
                <asp:Panel ID="pnlJson" runat="server" Width="410px" Style="margin-top:10px">
                    <asp:Label Text="" ID="lblJson" runat="server" />   
                </asp:Panel>
            </asp:Panel>
                </div>
    </form>
</body>
</html>
