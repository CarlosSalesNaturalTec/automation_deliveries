<%@ Page Title="Mapa Localização Funcionários" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="delivcli.Mapa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <asp:Button ID="BtAtivos" runat="server" Text="ON-LINE" CssClass="btn btn-success btn-lg" OnClick="BtAtivos_Click" />
    <asp:Button ID="BtInativos" runat="server" Text="OFF-LINE" CssClass="btn btn-danger btn-lg" OnClick="BtInativos_Click" />
    <asp:Button ID="BtTodos" runat="server" Text="TODOS" CssClass="btn btn-info btn-lg" OnClick="BtTodos_Click" />


    <div class="row">
        <!-- MAPA -->
        <div class="col-sm-9 col-md-9 col-lg-9">
            <iframe height="700px" width="100%" frameborder="0" scrolling="no" src="/Mapa1.aspx"></iframe>
        </div>

        <div class="col-sm-3 col-md-3 col-lg-3">
            <iframe height="700px" width="100%" frameborder="0" scrolling="yes" src="/ListagemStatus.aspx"></iframe>
        </div>

    </div>

</asp:Content>
