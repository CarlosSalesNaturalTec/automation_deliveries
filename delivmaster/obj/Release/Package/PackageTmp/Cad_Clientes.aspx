<%@ Page Title="Cadastro de Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cad_Clientes.aspx.cs" EnableEventValidation="false" Inherits="delivmaster.Cad_Clientes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Automation Deliveries - Web App para automação de entrega de encomendas  -->
    <!-- Criação    : Carlos Sales https://github.com/CarlosSalesNaturalTec  / 2016's-->
    <!-- Recursos   : ASP.NET / JAVASCRIPT / CSS / SQL / Windows Azure -->
    <!-- Módulo     : CADASTRO DE CLIENTES -->
    <!--------------------------------------------------------------------------------->

    <!-- Script para exibição de ícones-->
    <script src="https://use.fontawesome.com/8c3712a1dd.js"></script>

    <script type="text/javascript">
        function openModal() {
            $('#Modal_Edit_Delete').modal('show');
        }
    </script>
    
    <h1>Cadastro de Clientes</h1>

    <div class="row">
        <div class="col-sm-4 col-lg-4">
            <div class="dash-unitb">
                <dtitle>TOTAL DE CLIENTES CADASTRADOS</dtitle>
                <hr>
                <h1><i class="fa fa-th-list" style="font-size: 40px" aria-hidden="true"></i>
                    <asp:Label ID="lbl_total_clientes" runat="server" Text="999"></asp:Label> </h1>
                <button type="button" class="btn btn-success" data-toggle="modal" data-target="#Modal_Novo">Inserir Novo</button>
            </div>
        </div>
        <div class="col-sm-6 col-lg-6">
            <div class="dash-unitb">
                <dtitle>Outras Informações</dtitle>
                <hr>
            </div>
        </div>
    </div>

    <h2>Clientes Cadastrados</h2>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="80%" OnRowDataBound="GridView_RowDataBound" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="CLIENTE" />
            <asp:BoundField DataField="email" HeaderText="EMAIL" />
            <asp:BoundField DataField="Telefone" HeaderText="TELEFONES"/>
            <asp:BoundField DataField="Responsavel" HeaderText="RESPONSAVEL"/>
            <asp:BoundField DataField="Area_Unidade" HeaderText="ÁREA/UNIDADE"/>
            <asp:BoundField DataField="Usuario" HeaderText="USUÁRIO"/>
            <asp:BoundField DataField="ID_Cliente" HeaderText="ID"/>
        </Columns>
    </asp:GridView>

    <!-- modal NOVO  -->
    <div id="Modal_Novo" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Cadastrar novo Cliente</h4>
                </div>

                <div class="modal-body">
                    <p>Nome:</p>
                    <p><asp:TextBox id="txt_nome" runat="server" CssClass="input-lg"/></p>
                    <p>e-mail:</p>
                    <p><asp:TextBox id="txt_email" runat="server" CssClass="input-lg"/></p>
                    <p>Telefone:</p>
                    <p><asp:TextBox id="txt_telefone" runat="server" CssClass="input-lg"/></p>
                    <p>Responsável pelo Contrato:</p>
                    <p><asp:TextBox id="txt_responsavel" runat="server" CssClass="input-lg"/></p>
                    <p>Área/Unidade:</p>
                    <p><asp:TextBox id="txt_area_und" runat="server" CssClass="input-lg"/></p>
                    <p>Usuário:</p>
                    <p><asp:TextBox id="txt_user" runat="server" CssClass="input-lg"/></p>
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
                    <h4 class="modal-title">Cadastro de Clientes - Edição</h4>
                </div>

                <div class="modal-body">
                    <p>Nome:</p>
                    <p><asp:TextBox id="txt_edit_nome" runat="server" CssClass="input-lg"/></p>
                    <p>e-mail:</p>
                    <p><asp:TextBox id="txt_edit_email" runat="server" CssClass="input-lg"/></p>
                    <p>Telefone:</p>
                    <p><asp:TextBox id="txt_edit_telefone" runat="server" CssClass="input-lg"/></p>
                    <p>Responsável pelo Contrato:</p>
                    <p><asp:TextBox id="txt_edit_responsavel" runat="server" CssClass="input-lg"/></p>
                    <p>Área/Unidade:</p>
                    <p><asp:TextBox id="txt_edit_area_und" runat="server" CssClass="input-lg"/></p>
                    <p>Usuário:</p>
                    <p><asp:TextBox id="txt_edit_user" runat="server" CssClass="input-lg"/></p>

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
