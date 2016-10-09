<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NHibernate Demo 之 Web Site</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HyperLink ID="Schema" runat="server" NavigateUrl="~/Schema.aspx">[Schema Operations(Just NHibernate)]</asp:HyperLink>
    <asp:HyperLink ID="ViewData" runat="server" NavigateUrl="~/ViewData.aspx">[View Data]</asp:HyperLink>
    </form>
</body>
</html>
