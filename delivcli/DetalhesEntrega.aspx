<%@ Page Title="Detalhes da Entrega" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="DetalhesEntrega.aspx.cs" Inherits="delivcli.DetalhesEntrega" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Detalhes da Entrega</h1>

    <div class="row">
        <div class="col-sm-9 col-md-9 col-lg-9">
            <iframe height="600px" width="100%" frameborder="0" scrolling="no" src="/DetalhesMapa.aspx"></iframe>
        </div>

        <div class="col-sm-3 col-md-3 col-lg-3">
            <iframe height="600px" width="100%" frameborder="0" scrolling="yes" src="/DetalhesStatus.aspx"></iframe>
        </div>
    </div>

</asp:Content>