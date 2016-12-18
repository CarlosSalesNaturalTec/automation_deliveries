﻿<%@ Page Title="Cadastro de Funcionários" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cad_Funcionario.aspx.cs" EnableEventValidation="false" Inherits="delivcli.Cad_Funcionario" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Automation Deliveries - Web App para automação de entrega de encomendas  -->
    <!-- Criação    : Carlos Sales https://github.com/CarlosSalesNaturalTec  -->
    <!-- Ano        : 2016 -->
    <!-- Recursos   : ASP.NET / C# / JAVASCRIPT / CSS / SQL / Windows Azure -->
    <!-- Módulo     : CADASTRO DE FUNCIONARIOS -->
    <!--------------------------------------------------------------------------------->

    <!-- Script para exibição de ícones -->
    <script src="https://use.fontawesome.com/8c3712a1dd.js"></script>

    <!-- Script para abertura de Modal  -->
    <script type="text/javascript">
        function openModal() {
            $('#Modal_Edit_Delete').modal('show');
        }
    </script>
    <br />

    <!-- quadro TOTAL DE REGISTROS  / OUTRAS INFORMAÇÕES-->
    <div class="row">
        <div class="col-sm-4 col-lg-4">
            <div class="dash-unitb">
                <dtitle>TOTAL DE FUNCIONÁRIOS CADASTRADOS</dtitle>
                <hr>
                <h1><i class="fa fa-user" style="font-size: 40px" aria-hidden="true"></i>
                    <asp:Label ID="lbl_total_motoboys" runat="server" Text="999"></asp:Label>
                </h1>
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
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView_RowDataBound" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="NOME" />
            <asp:BoundField DataField="Telefone" HeaderText="TELEFONE" />
            <asp:BoundField DataField="WhatsApp" HeaderText="WHATSAPP" />
            <asp:BoundField DataField="Veiculo" HeaderText="VEICULO" />
            <asp:BoundField DataField="Modelo" HeaderText="MODELO" />
            <asp:BoundField DataField="Placa" HeaderText="PLACA" />
            <asp:BoundField DataField="Usuario" HeaderText="USUÁRIO" />
            <asp:BoundField DataField="ID_Motoboy" HeaderText="ID" />
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
                    <p>Nome:</p>
                    <p>
                        <asp:TextBox ID="txt_nome" runat="server" CssClass="input-lg" />
                    </p>
                    <p>Telefone:</p>
                    <p>
                        <asp:TextBox ID="txt_telefone" runat="server" CssClass="input-lg" />
                    </p>
                    <p>WhatsApp:</p>
                    <p>
                        <asp:TextBox ID="txt_whatsapp" runat="server" CssClass="input-lg" />
                    </p>
                    <p>Veiculo:</p>
                    <p>
                        <asp:TextBox ID="txt_veiculo" runat="server" CssClass="input-lg" />
                    </p>
                    <p>Modelo:</p>
                    <p>
                        <asp:TextBox ID="txt_modelo" runat="server" CssClass="input-lg" />
                    </p>
                    <p>Placa:</p>
                    <p>
                        <asp:TextBox ID="txt_placa" runat="server" CssClass="input-lg" />
                    </p>
                    <p>Usuário:</p>
                    <p>
                        <asp:TextBox ID="txt_user" runat="server" CssClass="input-lg" />
                    </p>
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
                    <p>
                        <asp:TextBox ID="txt_edit_nome" runat="server" CssClass="input-lg" />
                    </p>
                    <p>Telefone:</p>
                    <p>
                        <asp:TextBox ID="txt_edit_telefone" runat="server" CssClass="input-lg" />
                    </p>
                    <p>WhatsApp:</p>
                    <p>
                        <asp:TextBox ID="txt_edit_whatsapp" runat="server" CssClass="input-lg" />
                    </p>
                    <p>Veiculo:</p>
                    <p>
                        <asp:TextBox ID="txt_edit_veiculo" runat="server" CssClass="input-lg" />
                    </p>
                    <p>Modelo:</p>
                    <p>
                        <asp:TextBox ID="txt_edit_modelo" runat="server" CssClass="input-lg" />
                    </p>
                    <p>Placa:</p>
                    <p>
                        <asp:TextBox ID="txt_edit_placa" runat="server" CssClass="input-lg" />
                    </p>
                    <p>Usuário:</p>
                    <p>
                        <asp:TextBox ID="txt_edit_user" runat="server" CssClass="input-lg" />
                    </p>

                    <p>
                        ID:
                        <asp:Label ID="lbl_id" runat="server" Text=""></asp:Label>
                    </p>
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
