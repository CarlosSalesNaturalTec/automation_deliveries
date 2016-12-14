<%@ Page Title="Relatório de Performance" Culture="auto" UICulture="auto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relatorio2.aspx.cs" EnableEventValidation="false" Inherits="delivcli.Relatorio2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h1>Performance no Período </h1>

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

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

</asp:Content>
