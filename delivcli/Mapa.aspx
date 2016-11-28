<%@ Page Title="Mapa Localização Funcionários" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="delivcli.Mapa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div class="well">
        <asp:Button ID="BtAtivos" runat="server" Text="On-Line" CssClass="btn btn-success btn-lg" OnClick="BtAtivos_Click" />
        <asp:Button ID="BtInativos" runat="server" Text="Off-Line" CssClass="btn btn-danger btn-lg" OnClick="BtInativos_Click" />
        <asp:Button ID="BtTodos" runat="server" Text="Todos" CssClass="btn btn-info btn-lg" OnClick="BtTodos_Click" />
    </div>

    <div class="row">
        <!-- MAPA -->
        <div class="col-sm-10 col-md-10 col-lg-10">
            <iframe height="700px" width="100%" frameborder="0" scrolling="no" src="/Mapa1.aspx"></iframe>
        </div>      

        <div class="col-sm-2 col-md-2 col-lg-2">
            <iframe height="700px" width="100%" frameborder="0" scrolling="yes" src="/ListagemStatus.aspx"></iframe>
        </div>

    </div>

</asp:Content>
