<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StringsNFiles.aspx.cs" Inherits="Pages_StringsNFiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <h1>Working With Strings and Files</h1>
        <br />
        <asp:Button ID="btnOrignFile" runat="server" OnClick="BtnOriginalFile_Click" Text="Original File" />
        <asp:Button ID="btnFilDDL" runat="server" OnClick="BtnFillDDL_Click" Text="Fill DDL" />
        <asp:Button ID="Button3" runat="server"  Text="Save New File" OnClick="SaveNewFile_Click"/>
        <asp:Button ID="ReadNewFile" runat="server" Text="Read New File" OnClick="ReadNewFile_Click" />
        <br />
        <asp:DropDownList ID="ddlExercise" runat="server"></asp:DropDownList><br />
        <div style="text-align:center; border:inset; padding:5px;border-radius:10px;">
            <asp:Label Text="" ID="lblFile" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
