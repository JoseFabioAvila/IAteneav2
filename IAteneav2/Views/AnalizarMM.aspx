<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnalizarMM.aspx.cs" Inherits="IAteneav2.Views.AnalizarMM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="well">
        <asp:Table ID="Table2" runat="server">
            <asp:TableHeaderRow>
                <asp:TableCell>
                    <h1>Analizar archivos de mensajes masivos</h1>
                </asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="AnalizarAMM" OnClick="analizarArchivosMM" runat="server" Text="Analizar archivos de mensajes masivos" CssClass="btn btn-lg btn-success"/>
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
