﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Schema.aspx.cs" Inherits="Schema" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NHibernate Demo 之 Web Site</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="Default.aspx">[Back To Main]</a>
    </div>
    <div>
        <asp:Button ID="CreateSchema" runat="server" Text="Create Schema & Init" OnClick="CreateSchema_Click" />
        <asp:Button ID="DropSchema" runat="server" Text="Drop Schema" OnClick="DropSchema_Click" />
    </div>
    <asp:Label ID="Status" runat="server" Text="" />
    </form>
</body>
</html>
