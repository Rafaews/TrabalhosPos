<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Pages_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; vertical-align:middle; height:100px;">
        <h1>Homework #2</h1>
        <h2><asp:Label Text="Exercise #1" runat="server" ID="lblExercício"/></h2>
        <asp:Button Text="Exercise #1" runat="server" ID="btnEx1" OnClick="btnEx1_Click"/>
        <asp:Button Text="Exercise #2" runat="server" ID="btnEx2" OnClick="btnEx2_Click"/>
        <asp:Button Text="Exercise #3" runat="server" ID="btnEx3" OnClick="btnEx3_Click"/><br /><br />
        <iframe src='<% =url %>'style="border-radius:10px; width:1400px; padding-bottom:20px" height="560"></iframe>
    </div>
    </form>
</body>
</html>
