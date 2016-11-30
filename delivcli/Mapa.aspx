<%@ Page Title="Mapa Localização Entregadores" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="delivcli.Mapa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">

        <!-- Mapa / marcadores nos locais de ENTREGA / Marcadores nos Entregadores On-Line -->
        <br />
        <div class="col-sm-9 col-md-9 col-lg-9">
            <iframe height="600px" width="100%" frameborder="0" scrolling="no" src="/Mapa1.aspx"></iframe>
        </div>

        <!-- Listagem ENtregadores On Line e OFF Line-->
        <div class="col-sm-3 col-md-3 col-lg-3">
            <iframe height="600px" width="100%" frameborder="0" scrolling="yes" src="/ListagemStatus.aspx"></iframe>
        </div>

        <!-- Listagem Entregas A Realizar-->

        <!-- Listagem Entregas A Caminho-->

        <!-- Listagem Entregas Entregues-->

        <!-- Listagem Entregas Retornadas -->



    </div>

</asp:Content>
