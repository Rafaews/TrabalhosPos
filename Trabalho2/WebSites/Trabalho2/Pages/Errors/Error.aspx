﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Pages_Errors_Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; margin-top:100px">
        <h1 style="background-color:red; width:35px; text-align:center; margin:0 auto">!</h1>
        <h2 style="color:red">Error: <asp:Label Text="" runat="server" ID="lblMsgError" /></h2>
    </div>
    </form>
</body>
</html>