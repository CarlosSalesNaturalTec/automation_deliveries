<%@ Page Title="Cadastro de Entregas (Geocoding)" Culture="auto" UICulture="auto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cad_Entregas_Geocoding.aspx.cs" EnableEventValidation="false" Inherits="delivcli.Cad_Entregas_Geocoding" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Automation Deliveries CLIENT - Web App para automação de entrega de encomendas -->
    <!-- Criação    : Carlos Sales https://github.com/CarlosSalesNaturalTec  / 2016's-->
    <!-- Recursos   : ASP.NET / C# / JAVASCRIPT / CSS / SQL / Windows Azure -->
    <!-- Módulo     : CADASTRO DE ENTREGAS com GEOCODING-->
    <!--------------------------------------------------------------------------------->

    <br />

    <div class="row">
        <div class="col-sm-3">
            <asp:Label ID="Label1" runat="server" Text="Endereço"></asp:Label>
        </div>
        <div class="col-sm-2">
            <asp:Label ID="Label4" runat="server" Text="Número"></asp:Label>
        </div>
        <div class="col-sm-2">
            <asp:Label ID="Label2" runat="server" Text="Bairro"></asp:Label>
        </div>
        <div class="col-sm-2">
            <asp:Label ID="Label3" runat="server" Text="Cidade"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-3">
            <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:TextBox ID="txtBairro" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:TextBox ID="txtCidade" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="bt_buscar_click"/>
        </div>
    </div>  

    <div class="row">
        <div class="col-sm-3">
            <asp:Label ID="Label5" runat="server" Text="Destinatário"></asp:Label>
        </div>
        <div class="col-sm-2">
            <asp:Label ID="Label6" runat="server" Text="P.Ref."></asp:Label>
        </div>
        <div class="col-sm-2">
            <asp:Label ID="Label7" runat="server" Text="Telefone"></asp:Label>
        </div>
        <div class="col-sm-2">
            <asp:Label ID="Label8" runat="server" Text="Observações"></asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-3">
            <asp:TextBox ID="txtDestinatario" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:TextBox ID="txtPref" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:TextBox ID="txtObs" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="Button2" runat="server" Text="Salvar " CssClass="btn btn-success" />
        </div>
    </div>

    <!-- MAPA -->
    <br />
    <iframe height="400px" width="100%" frameborder="0" scrolling="no" src="/Mapa2.aspx"></iframe>
    
    <p></p>

    <asp:Label ID="lblLat" runat="server" Text="Lat: 0"></asp:Label>
    <asp:Label ID="lblLong" runat="server" Text="Long: 0"></asp:Label>

</asp:Content>
