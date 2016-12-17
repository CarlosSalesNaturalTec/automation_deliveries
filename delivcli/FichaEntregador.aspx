<%@ Page Title="Histórico Entregador" Culture="auto" UICulture="auto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FichaEntregador.aspx.cs" EnableEventValidation="false" Inherits="delivcli.FichaEntregador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Histórico Entregador</h1>

    <div class="row">
        <div class="col-sm-4 col-lg-4">
            <h4>De:<asp:TextBox ID="txtPer1" runat="server" AutoPostBack="True" OnTextChanged="txtPer1_TextChanged"/>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server"
                    TargetControlID="txtPer1" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator5" runat="server"
                    ControlExtender="MaskedEditExtender5" ControlToValidate="txtPer1" EmptyValueMessage="Informe Data"
                    InvalidValueMessage="Data Invalida" Display="Dynamic" TooltipMessage="Periodo Inicial" EmptyValueBlurredText="*"
                    InvalidValueBlurredMessage="*" ValidationGroup="MKE" />
            </h4>
        </div>

        <div class="col-sm-4 col-lg-4">
            <h4>Até:<asp:TextBox ID="TxtPer2" runat="server" AutoPostBack="True" OnTextChanged="TxtPer2_TextChanged"/>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                    TargetControlID="TxtPer2" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                    ControlExtender="MaskedEditExtender1" ControlToValidate="TxtPer2" EmptyValueMessage="Periodo Final"
                    InvalidValueMessage="Data Invalida" Display="Dynamic" TooltipMessage="Periodo Final" EmptyValueBlurredText="*"
                    InvalidValueBlurredMessage="*" ValidationGroup="MKE" />
            </h4>
        </div>

    </div>
    
    <div class="row">
        <div class="col-sm-9 col-md-9 col-lg-9">
            <iframe height="500px" width="100%" frameborder="0" scrolling="no" src="/EntregadorMapa.aspx"></iframe>
        </div>

        <div class="col-sm-3 col-md-3 col-lg-3">
            <iframe height="500px" width="100%" frameborder="0" scrolling="yes" src="/EntregadorDist.aspx"></iframe>
        </div>
    </div>

</asp:Content>
