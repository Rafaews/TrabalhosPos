<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TxtToXml.aspx.cs" Inherits="Pages_TxtToXml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<%--<body>--%>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <h1>Txt To Xml</h1>
        <asp:Button ID="btnOrignFile" runat="server" OnClick="BtnOriginalFile_Click" Text="Original File" />
        <asp:Button ID="btnLogFile" ToolTip="Read and Save a Log File" runat="server" Text="Log File" OnClick="btnLogFile_Click" />
        <asp:Button ID="generateXML" runat="server"  Text="Generate XML" OnClick="generateXML_Click" />
        <asp:Button ID="ReadNewFile" runat="server" Text="View XML Data" OnClick="ViewXML_Click" />
        <br /><br />
        <div style="text-align:center; border:inset; padding:5px;border-radius:10px;">
            <asp:Label Text="" ID="lblFile" runat="server" />
            <asp:GridView ID="Gv1" runat="server" style="text-align:center; margin:0px auto; margin-top:10px" AllowPaging="True" PageSize="12" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="Gv1_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerSettings FirstPageText="<<<<" LastPageText=">>>>" NextPageText=">>" PreviousPageText="<<" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
