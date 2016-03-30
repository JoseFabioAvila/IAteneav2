<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SqlTreeChart.aspx.cs" Inherits="SqlTreeChart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td align="center">
                    <table cellpadding="0" cellspacing="0" border="1" width="50%">
                        <tr>
                            <td align="center">
                                <h2>Sql Server Tree View</h2>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:TreeView ID="SqlTree"  style="font-size:13px;font-family:Tahoma;font-weight:bold;text-align:left;" ShowLines="true" ShowExpandCollapse="true" runat="server">
                                </asp:TreeView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
