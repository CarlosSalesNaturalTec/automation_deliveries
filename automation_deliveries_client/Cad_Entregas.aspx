<%@ Page Title="Cadastro de Entregas" Culture="auto" UICulture="auto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cad_Entregas.aspx.cs" EnableEventValidation="false" Inherits="automation_deliveries_client.Cad_Entregas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Automation Deliveries CLIENT - Web App para automação de entrega de encomendas - Módulo Cliente -->
    <!-- Criação    : Carlos Sales https://github.com/CarlosSalesNaturalTec  / 2016's-->
    <!-- Recursos   : ASP.NET / JAVASCRIPT / CSS / SQL / Windows Azure -->
    <!-- Módulo     : CADASTRO DE ENTREGAS -->
    <!--------------------------------------------------------------------------------->

    <!-- Script para exibição de ícones -->
    <script src="https://use.fontawesome.com/8c3712a1dd.js"></script>

    <!-- Script Modal Edit -->
    <script type="text/javascript">
        function openModal() {
            $('#Modal_Edit_Delete').modal('show');
        }
    </script>
    <br />

    <!-- quadro TOTAL DE ENTREGAS -->
    <div class="row">

        <div class="col-sm-4 col-lg-4">
            <div class="dash-unitb">
                <dtitle>TOTAL DE ENTREGAS CADASTRADAS</dtitle>
                <hr>
                <h1><i class="fa fa-user" style="font-size: 40px" aria-hidden="true"></i>
                    <asp:Label ID="lbl_total_entregas" runat="server" Text="999"></asp:Label> </h1>
                <button type="button" class="btn btn-success" data-toggle="modal" data-target="#Modal_Novo">Inserir Nova</button>
            </div>
        </div>

        <div class="col-sm-6 col-lg-6">
            <div class="dash-unitb">                
                <dtitle>FILTRO</dtitle>
                <hr>
                 <h2><asp:TextBox ID="txtData" runat="server"  AutoPostBack="True" OnTextChanged="txtData_TextChanged"/>
                     <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server"
                         TargetControlID="txtData" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                     <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator5" runat="server"
                         ControlExtender="MaskedEditExtender5" ControlToValidate="txtData" EmptyValueMessage="Informe Data"
                         InvalidValueMessage="Data Invalida" Display="Dynamic" TooltipMessage="Data da Entrega" EmptyValueBlurredText="*"
                         InvalidValueBlurredMessage="*" ValidationGroup="MKE" />
                 </h2>
                <asp:DropDownList ID="cmb_funcionario" runat="server" class="dash-unitc" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="cmb_funcionario_SelectedIndexChanged"></asp:DropDownList>
                <p><asp:Label ID="lbl_mensagem" runat="server" Text=""></asp:Label>    </p>
            </div>
        </div>

    </div>

    <!-- Grid -->
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="90%" OnRowDataBound="GridView_RowDataBound" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="FUNCIONARIO" />
            <asp:BoundField DataField="Nome_Destinatario" HeaderText="DESTINATARIO" />
            <asp:BoundField DataField="Endereco" HeaderText="ENDEREÇO" />
            <asp:BoundField DataField="Bairro" HeaderText="BAIRRO"/>
            <asp:BoundField DataField="Cidade" HeaderText="CIDADE"/>
            <asp:BoundField DataField="Telefone" HeaderText="TELEFONE"/>
            <asp:BoundField DataField="Data_Encomenda" HeaderText="DATA"/>
            <asp:BoundField DataField="Cod_Encomenda" HeaderText="COD.ENCOMENDA"/>
            <asp:BoundField DataField="ID_Entrega" HeaderText="ID"/>
        </Columns>
    </asp:GridView>

    <!-- modal NOVO  -->
    <div id="Modal_Novo" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Cadastrar nova Entrega</h4>
                </div>

                <div class="modal-body">
                    <p>Funcionário:</p>
                    <p><asp:DropDownList ID="cmb_func_modal" runat="server" CssClass="input-lg"></asp:DropDownList></p>
                    <p>Destinatário:</p>
                    <p><asp:TextBox id="txt_nome" runat="server" CssClass="input-lg"/></p>
                    <p>Endereco:</p>
                    <p><asp:TextBox id="txt_end" runat="server" CssClass="input-lg"/></p>
                    <p>P.Ref.:</p>
                    <p><asp:TextBox id="txt_ref" runat="server" CssClass="input-lg"/></p>
                    <p>Bairro:</p>
                    <p><asp:TextBox id="txt_bairro" runat="server" CssClass="input-lg"/></p>
                    <p>Cidade:</p>
                    <p><asp:TextBox id="txt_cidade" runat="server" CssClass="input-lg"/></p>
                    <p>Cod.Encom:</p>
                    <p><asp:TextBox id="txt_encom" runat="server" CssClass="input-lg"/></p>
                    
                    <p>Data:</p>
                    <p><asp:TextBox id="txt_data" runat="server" CssClass="input-lg"/></p>
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                         TargetControlID="txt_data" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                     <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
                         ControlExtender="MaskedEditExtender2" ControlToValidate="txt_data" EmptyValueMessage="Informe Data"
                         InvalidValueMessage="Data Invalida" Display="Dynamic" TooltipMessage="Data da Entrega" EmptyValueBlurredText="*"
                         InvalidValueBlurredMessage="*" ValidationGroup="MKE" />

                    <p>Telefone</p>
                    <p><asp:TextBox id="txt_telefone" runat="server" CssClass="input-lg"/></p>
                    <p>Observações:</p>
                    <p><asp:TextBox id="txt_obs" runat="server" CssClass="input-lg"/></p>
                </div>

                <div class="modal-footer">
                    <asp:Button ID="bt_novo_fechar" runat="server" Text="Cancelar" CssClass="btn btn-default" data-dismiss="modal" />
                    <asp:Button ID="bt_novo_salvar" runat="server" Text="Salvar" CssClass="btn btn-success" OnClick="bt_novo_salvar_click" UseSubmitBehavior="false" data-dismiss="modal" />
                </div>

            </div>
        </div>
    </div>

     <!-- modal EDIT,DELETE -->
    <div id="Modal_Edit_Delete" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Cadastro de Funcionários - Edição</h4>
                </div>

                <div class="modal-body">
                    <p>Funcionário:</p>
                    <p><asp:DropDownList ID="cmb_edit_func" runat="server" CssClass="input-lg"></asp:DropDownList></p>
                    <p>Destinatário:</p>
                    <p><asp:TextBox id="txt_edit_nome" runat="server" CssClass="input-lg"/></p>
                    <p>Endereco:</p>
                    <p><asp:TextBox id="txt_edit_end" runat="server" CssClass="input-lg"/></p>
                    <p>P.Ref.:</p>
                    <p><asp:TextBox id="txt_edit_ref" runat="server" CssClass="input-lg"/></p>
                    <p>Bairro:</p>
                    <p><asp:TextBox id="txt_edit_bairro" runat="server" CssClass="input-lg"/></p>
                    <p>Cidade:</p>
                    <p><asp:TextBox id="txt_edit_cidade" runat="server" CssClass="input-lg"/></p>
                    <p>Cod.Encom:</p>
                    <p><asp:TextBox id="txt_edit_encom" runat="server" CssClass="input-lg"/></p>
                    
                    <p>Data:</p>
                    <p><asp:TextBox id="txt_edit_data" runat="server" CssClass="input-lg"/></p>
                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                         TargetControlID="txt_edit_data" Mask="99/99/9999" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                         OnInvalidCssClass="MaskedEditError" MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" />
                     <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                         ControlExtender="MaskedEditExtender1" ControlToValidate="txt_edit_data" EmptyValueMessage="Informe Data"
                         InvalidValueMessage="Data Invalida" Display="Dynamic" TooltipMessage="Data da Entrega" EmptyValueBlurredText="*"
                         InvalidValueBlurredMessage="*" ValidationGroup="MKE" />

                    <p>Telefone</p>
                    <p><asp:TextBox id="txt_edit_tel" runat="server" CssClass="input-lg"/></p>
                    <p>Observações:</p>
                    <p><asp:TextBox id="txt_edit_obs" runat="server" CssClass="input-lg"/></p>
                    <p>ID: <asp:Label ID="lbl_id" runat="server" Text=""></asp:Label></p>
                </div>

                <div class="modal-footer">
                    <asp:Button ID="Button5" runat="server" Text="Cancelar" CssClass="btn btn-default" data-dismiss="modal" />
                    <asp:Button ID="Button2" runat="server" Text="Excluir " CssClass="btn btn-danger" OnClick="bt_excluir_click" UseSubmitBehavior="false" data-dismiss="modal" />
                    <asp:Button ID="Button1" runat="server" Text="Alterar " CssClass="btn btn-success" OnClick="bt_editar_salvar_click" UseSubmitBehavior="false" data-dismiss="modal" />
                </div>

            </div>
        </div>
    </div>

</asp:Content>
