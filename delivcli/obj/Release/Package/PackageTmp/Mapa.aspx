<%@ Page Title="Situação Atual" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="delivcli.Mapa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Situação Atual</h1>

    <div class="row">
        <!-- Mapa / marcadores nos locais de ENTREGA / Marcadores nos Entregadores On-Line -->
        <div class="col-sm-9 col-md-9 col-lg-9">
            <iframe height="500px" width="100%" frameborder="0" scrolling="no" src="/Mapa1.aspx"></iframe>
        </div>

        <!-- Listagem ENtregadores On Line e OFF Line-->
        <div class="col-sm-3 col-md-3 col-lg-3">
            <iframe height="500px" width="100%" frameborder="0" scrolling="yes" src="/ListagemStatus.aspx"></iframe>
        </div>
    </div>

    <h1>Listagem</h1>
    <div class="row">
        <!-- Listagem de Entregas por Status-->
        <div class="col-sm-12 col-md-12 col-lg-12">
            <iframe height="700px" width="100%" frameborder="0" scrolling="yes" src="/ListagemEntregas.aspx"></iframe>
        </div>
    </div>

</asp:Content>
