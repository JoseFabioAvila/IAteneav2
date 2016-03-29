<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnalizarWS.aspx.cs" Inherits="IAteneav2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead" >ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </!--div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div-->
    <div class="well">
        <asp:Table ID="Table1" runat="server">
            <asp:TableHeaderRow>
                <asp:TableCell>
                    <h1>Analizar web sites</h1>
                </asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>

                    <asp:TextBox ID="UrlText" runat="server" Width="900"></asp:TextBox>
                    <a> </a>
                    <asp:Button ID="AgregarSitio" runat="server" OnClick="AgregarSitio_Click" Text="Agregar website" Width="180" CssClass="btn btn-lg btn-primary"/>
                    <a> </a>
                    <asp:Button ID="QuitarSitio" runat="server" OnClick="QuitarSitio_Click"  Text="Quitar website" Width="150" CssClass="btn btn-lg btn-primary"/>

                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                        
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>                
                <asp:TableCell >

                    <br />
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h3 class="panel-title">Lista de websites</h3>
                        </div>
                        <div class="panel-body">
                            <asp:ListBox ID="ListaWebsites" runat="server"  Width="900"  CssClass="alert alert-info">
                                    
                            </asp:ListBox>
                        </div>
                    </div>
                        
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>

                    <br />
                    <asp:Button ID="AnalizarSite" runat="server" OnClick="analizarEnSite" Text="Analizar en el website" CssClass="btn btn-lg btn-success"/>
                    <a> </a>
                    <asp:Button ID="AnalizarAllSites" runat="server" OnClick="analizarEnTodos" Text="Analizar entodos los websites" CssClass="btn btn-lg btn-success"/>

                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    <div class="well">
        <asp:Table ID="Table3" runat="server">
            <asp:TableHeaderRow>
                <asp:TableCell>
                    <h1>Resultados de Analisis</h1>
                </asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <p class="accordion-inner" id="parrafo" >Aqui ira el resultado del analisis seleccionado anteriormente</p>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="1000" Height="800"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

</asp:Content>
