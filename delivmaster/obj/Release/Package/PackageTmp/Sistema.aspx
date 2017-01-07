<%@ Page Title="Sistema" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sistema.aspx.cs" EnableEventValidation="false" Inherits="delivmaster.Sistema" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Automation Deliveries - Web App para automação de entrega de encomendas  -->
    <!-- Autor      : Carlos Sales https://github.com/CarlosSalesNaturalTec  / 2016's-->
    <!-- Ano        : 2016      -->
    <!-- Recursos   : ASP.NET / C# / JAVASCRIPT / CSS / SQL / Windows Azure -->
    <!-- Módulo     : CADASTRO DE USUARIOS E SENHAS -->
    <!--------------------------------------------------------------------------------->

    <!-- Script para exibição de ícones-->
    <script src="https://use.fontawesome.com/8c3712a1dd.js"></script>

    <script type="text/javascript">
        function openModal() {
            $('#Modal_Edit_Delete').modal('show');
        }
    </script>
    
    <h1>Cadastro de Usuários e Senhas</h1>

    <div class="row">
        <div class="col-sm-4 col-lg-4">
            <div class="dash-unitb">
                <dtitle>TOTAL DE USUÁRIOS CADASTRADOS</dtitle>
                <hr>
                <h1><i class="fa fa-user" style="font-size: 40px" aria-hidden="true"></i>
                    <asp:Label ID="lbl_total_usuarios" runat="server" Text="999"></asp:Label> </h1>
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

    <h2>Usuarios Cadastrados</h2>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="80%" OnRowDataBound="GridView_RowDataBound" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Usuario" HeaderText="USUARIO" />
            <asp:BoundField DataField="nivel" HeaderText="NIVEL" />
            <asp:BoundField DataField="ID_User" HeaderText="ID"/>
        </Columns>
    </asp:GridView>

    <!-- modal NOVO  -->
    <div id="Modal_Novo" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Cadastrar novo Usuário</h4>
                </div>

                <div class="modal-body">
                    <p>Usuário:</p>
                    <p><asp:TextBox id="txt_user" runat="server" CssClass="input-lg"/></p>
                    <p>Nivel:</p>
                    <p><asp:TextBox id="txt_nivel" runat="server" CssClass="input-lg" TextMode="Number" /></p>
                    <p>Senha:</p>
                    <p><asp:TextBox id="txt_senha" runat="server" CssClass="input-lg" TextMode="Password"/></p>
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
                    <h4 class="modal-title">Cadastro de usuarios - Edição</h4>
                </div>

                <div class="modal-body">
                    <p>Usuário:</p>
                    <p><asp:TextBox id="txt_edit_user" runat="server" CssClass="input-lg"/></p>
                    <p>Nivel:</p>
                    <p><asp:TextBox id="txt_edit_nivel" runat="server" CssClass="input-lg"/></p>
                    <p>Senha:</p>
                    <p><asp:TextBox id="txt_edit_senha" runat="server" CssClass="input-lg" TextMode="Password"/></p>
                    <p>ID: <asp:Label ID="lbl_edit_id" runat="server" Text=""></asp:Label></p>
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
