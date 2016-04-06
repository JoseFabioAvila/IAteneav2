<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnalizarLocal.aspx.cs" Inherits="IAteneav2.Views.Results" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />
    <br />
    <div class="well">
        <asp:Table ID="Table2" runat="server">
            <asp:TableHeaderRow>
                <asp:TableCell>
                    <h1>Analizar archivos o carpetas</h1>
                </asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:FileUpload id="FileUploadControl" runat="server"  CssClass="well"/>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" Width="1000"></asp:TextBox>
                    <asp:Button ID="Button1" OnClick="analizarEnDisco" runat="server" Text="Analizar Carpeta o Archivo" CssClass="btn btn-lg btn-success"/>
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
