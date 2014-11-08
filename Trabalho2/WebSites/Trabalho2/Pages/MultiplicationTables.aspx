<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MultiplicationTables.aspx.cs" Inherits="Pages_MultiplicationTables" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <h1>Generate Multiplication Table</h1>
        <h2>Enter an integer:<asp:TextBox runat="server" ID="txtNumber" Width="30px" Style="text-align:center;font-size:large; border:none; font-weight:bold;"/>
        <asp:Button ID="btnGenerateTables" runat="server" Text="Generate Tables" OnClick="btnGenerateTables_Click" /></h2>
        <asp:Label Text="" runat="server" ID="lblErro" Style="color:red" /><br />
        <asp:Panel runat="server" ID="pnlTables" Style="text-align:center; width:1000px; margin: 0px auto;"></asp:Panel>
    </div>
    </form>
</body>
</html>
