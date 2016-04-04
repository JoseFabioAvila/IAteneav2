<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="IAteneav2.About" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <br />
    <h3>Este es un proyecto desarrollado para el curso de Inteligencia artificial del TEC sede San Carlos.</h3>
    <br />
    <p >Conssites en una apliacion que realice un analisis que le permita determinar si en un determinado archivo, grupo de archivos, conjuntos de paginas web, que tema se </p>
    <p>trata segun la categoria y el idioma del mismo. La aplicaion debe aprender por si misma a diferenciar las categorias y el idioma.</p>
    
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="btnUpload_Click" />
    <hr />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#3AC0F2"
        HeaderStyle-ForeColor="White" RowStyle-BackColor="#A1DCF2">
        <Columns>
            <asp:BoundField DataField="FileName" HeaderText="File Name" />
            <asp:BoundField DataField="CompressedSize" HeaderText="Compressed Size (Bytes)" />
            <asp:BoundField DataField="UncompressedSize" HeaderText="Uncompressed Size (Bytes)" />
        </Columns>
    </asp:GridView>


    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="800" Height="800"></asp:TextBox>
    <br />
    <br />

    

    <br />
    <br />
    <asp:TreeView ID="Treeview1" Target="_blank" runat="server" ShowCheckBoxes="All">
        <Nodes>
            <asp:TreeNode Text="hola1">
                <asp:TreeNode  Text="hola1.1">
                    <asp:TreeNode  Text="hola1.1.1">
                        <asp:TreeNode  Text="hola1.1.1.1">

                        </asp:TreeNode>

                    </asp:TreeNode>
                </asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
        <Nodes>
            <asp:TreeNode Text="hola2"></asp:TreeNode>
        </Nodes>
        <Nodes>
            <asp:TreeNode Text="hola3"></asp:TreeNode>
        </Nodes>

    </asp:TreeView>
    <%--<% foreach (var dir in new DirectoryInfo("C:\\Users").GetDirectories()) { %>
        Directory: <%= dir.Name %><br />

        <% foreach (var file in dir.GetFiles()) { %>
            <%= file.Name %><br />
        <% } %>
        <br />
    <% } %>--%>

</asp:Content>
