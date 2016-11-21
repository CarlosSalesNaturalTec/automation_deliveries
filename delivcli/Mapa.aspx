<%@ Page Title="Mapa Localização Funcionários" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="delivcli.Mapa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <div class="row">

        <div class="col-sm-4 col-lg-4">
            <!-- combo selecionar CLIENTE-->
            <asp:DropDownList ID="cmb_func" runat="server" class="form-control" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="cmb_func_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <div class="col-sm-4 col-lg-4">
            <!-- Data do histório-->
            <asp:TextBox ID="txtData" runat="server" AutoPostBack="True" OnTextChanged="txtData_TextChanged" />
            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server"
                TargetControlID="txtData" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator5" runat="server"
                ControlExtender="MaskedEditExtender5" ControlToValidate="txtData" EmptyValueMessage="Informe Data"
                InvalidValueMessage="Data Invalida" Display="Dynamic" TooltipMessage="Data da Entrega" EmptyValueBlurredText="*"
                InvalidValueBlurredMessage="*" ValidationGroup="MKE" />
        </div>

    </div>

    <!-- MAPA -->
    <iframe height="700px" width="100%" frameborder="0" scrolling="no" src="/Mapa1.aspx"></iframe>

</asp:Content>
