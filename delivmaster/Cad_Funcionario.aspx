<%@ Page Title="Cadastro de Funcionários" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cad_Funcionario.aspx.cs" EnableEventValidation="false" Inherits="delivmaster.Cad_Funcionario" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Automation Deliveries - Web App para automação de entrega de encomendas  -->
    <!-- Criação    : Carlos Sales https://github.com/CarlosSalesNaturalTec  / 2016's-->
    <!-- Recursos   : ASP.NET / JAVASCRIPT / CSS / SQL / Windows Azure -->
    <!-- Módulo     : CADASTRO DE CLIENTES -->
    <!--------------------------------------------------------------------------------->


    <!-- Script para exibição de ícones -->
    <script src="https://use.fontawesome.com/8c3712a1dd.js"></script>
    
    <script type="text/javascript">
        function openModal() {
            $('#Modal_Edit_Delete').modal('show');
        }
    </script>

    <!-- combo selecionar CLIENTE-->
    <h3><asp:DropDownList ID="cmb_cliente" runat="server" class="form-control" Width="80%" AutoPostBack="True" OnSelectedIndexChanged="cmb_cliente_SelectedIndexChanged"></asp:DropDownList></h3>
    
    <!-- quadro TOTAL DE REGISTROS  / OUTRAS INFORMAÇÕES-->
    <div class="row">
        <div class="col-sm-4 col-lg-4">
            <div class="dash-unitb">
                <dtitle>TOTAL DE FUNCIONÁRIOS CADASTRADOS</dtitle>
                <hr>
                <h1><i class="fa fa-user" style="font-size: 40px" aria-hidden="true"></i>
                    <asp:Label ID="lbl_total_motoboys" runat="server" Text="999"></asp:Label> </h1>
                <button type="button" class="btn btn-success" data-toggle="modal" data-target="#Modal_Novo">Inserir Novo</button>
            </div>
        </div>

        <div class="col-sm-6 col-lg-6">
            <div class="dash-unitb">
                <dtitle>Outras Infrmações</dtitle>
                <hr>
            </div>
        </div>
    </div>

    <!-- Grid -->
    <h2><asp:Label ID="lbl_cliente" runat="server" Text=""></asp:Label></h2>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="80%" OnRowDataBound="GridView_RowDataBound" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="NOME" />
            <asp:BoundField DataField="email" HeaderText="EMAIL" />
            <asp:BoundField DataField="Telefone" HeaderText="TELEFONE"/>
            <asp:BoundField DataField="WhatsApp" HeaderText="WHATSAPP"/>
            <asp:BoundField DataField="Veiculo" HeaderText="VEICULO"/>
            <asp:BoundField DataField="Modelo" HeaderText="MODELO"/>
            <asp:BoundField DataField="Placa" HeaderText="PLACA"/>
            <asp:BoundField DataField="ID_Motoboy" HeaderText="ID"/>
        </Columns>
    </asp:GridView>

    <!-- modal NOVO  -->
    <div id="Modal_Novo" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Cadastrar novo Funcionário</h4>
                </div>

                <div class="modal-body">
                    <p>Cliente:</p>
                    <p><asp:TextBox id="txt_cliente_modal_novo" runat="server" Enabled="false" CssClass="input-lg"/></p>
                    <p>Nome:</p>
                    <p><asp:TextBox id="txt_nome" runat="server" CssClass="input-lg"/></p>
                    <p>e-mail:</p>
                    <p><asp:TextBox id="txt_email" runat="server" CssClass="input-lg"/></p>
                    <p>Telefone:</p>
                    <p><asp:TextBox id="txt_telefone" runat="server" CssClass="input-lg"/></p>
                    <p>WhatsApp:</p>
                    <p><asp:TextBox id="txt_whatsapp" runat="server" CssClass="input-lg"/></p>
                    <p>Veiculo:</p>
                    <p><asp:TextBox id="txt_veiculo" runat="server" CssClass="input-lg"/></p>
                    <p>Modelo:</p>
                    <p><asp:TextBox id="txt_modelo" runat="server" CssClass="input-lg"/></p>
                    <p>Placa:</p>
                    <p><asp:TextBox id="txt_placa" runat="server" CssClass="input-lg"/></p>
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
                    <p>Nome:</p>
                    <p><asp:TextBox id="txt_edit_nome" runat="server" CssClass="input-lg"/></p>
                    <p>e-mail:</p>
                    <p><asp:TextBox id="txt_edit_email" runat="server" CssClass="input-lg"/></p>
                    <p>Telefone:</p>
                    <p><asp:TextBox id="txt_edit_telefone" runat="server" CssClass="input-lg"/></p>
                    <p>WhatsApp:</p>
                    <p><asp:TextBox id="txt_edit_whatsapp" runat="server" CssClass="input-lg"/></p>
                    <p>Veiculo:</p>
                    <p><asp:TextBox id="txt_edit_veiculo" runat="server" CssClass="input-lg"/></p>
                    <p>Modelo:</p>
                    <p><asp:TextBox id="txt_edit_modelo" runat="server" CssClass="input-lg"/></p>
                    <p>Placa:</p>
                    <p><asp:TextBox id="txt_edit_placa" runat="server" CssClass="input-lg"/></p>
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
