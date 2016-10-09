<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewData.aspx.cs" Inherits="ViewData" %>

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
        <fieldset>
            <legend>Add User</legend>
            <table border="1" width="600" cellpadding="4" cellspacing="0">
                <tr>
                    <td width="100" align="right">
                        USER ID
                    </td>
                    <td>
                    <asp:TextBox ID="txtUSER_ID" runat="server" ValidationGroup="Add" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtUSER_ID" ErrorMessage="Need User Id" 
                            SetFocusOnError="True" ValidationGroup="Add">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="100" align="right">
                        USER NAME
                    </td>
                    <td>
                        <asp:TextBox ID="txtUSER_NAME" runat="server" ValidationGroup="Add" 
                            Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtUSER_NAME" ErrorMessage="Need User Name" 
                            SetFocusOnError="True" ValidationGroup="Add">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="100" align="right">
                        PASSOWORD
                    </td>
                    <td>
                        <asp:TextBox ID="txtPASSWORD" runat="server" TextMode="Password" 
                            ValidationGroup="Add" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtPASSWORD" ErrorMessage="Need Passord" 
                            SetFocusOnError="True" ValidationGroup="Add">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="100" align="right">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" 
                            ValidationGroup="Add" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="Add" />
                    </td>
                </tr>
                <tr>
                    <td width="100" align="right">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="labelMSG" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
        <fieldset>
            <legend>List User</legend>
            <table border="1" width="600" cellpadding="1" cellspacing="0">
                <tr>
                    <td align="center">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            Width="100%" onrowcancelingedit="GridView1_RowCancelingEdit" 
                            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                            onrowupdating="GridView1_RowUpdating">
                            <Columns>
                                <asp:BoundField DataField="USER_ID" HeaderText="USER_ID" ReadOnly="True" />
                                <asp:TemplateField HeaderText="USER_NAME">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtROW_USER_NAME" runat="server" Text='<%# Bind("USER_NAME") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("USER_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    </form>
</body>
</html>
