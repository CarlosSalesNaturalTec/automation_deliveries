<%@ Page Title="Mapa Localização Funcionários" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="delivcli.Mapa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- combo selecionar CLIENTE-->
    <h3><asp:DropDownList ID="cmb_func" runat="server" class="form-control" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="cmb_func_SelectedIndexChanged"></asp:DropDownList></h3>

    <!-- MAPA -->
    <iframe height="500px" width="100%" frameBorder="0" scrolling="no" src="/Mapa1.aspx"></iframe>

</asp:Content>
