<%@ Page Title="Entregas Realizadas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Realizar.aspx.cs" EnableEventValidation="false" Inherits="deliv.Realizar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Automation Deliveries ENTREGAS - Web App para automação de entrega de encomendas -->
    <!-- Criação    : Carlos Sales https://github.com/CarlosSalesNaturalTec  -->
    <!-- Ano        : 2016 -->
    <!-- Recursos   : ASP.NET / JAVASCRIPT / CSS / SQL / Windows Azure -->
    <!-- Módulo     : DELIVERIES - ENTREGAS À REALIZAR-->
    <!--------------------------------------------------------------------------------->

    <!-- Script Modal Detalhes -->
    <script type="text/javascript">
        function openModal() {
            $('#Modal_Detalhes').modal('show');
        }
    </script>

     <!-- data corrente e nome do funcionário -->
    <br />
    <ul class="breadcrumb">
        <li class="active">
            <asp:Label ID="lbl_data" runat="server"></asp:Label> - <asp:Label ID="lbl_ID_Funcionario" runat="server"></asp:Label>
        </li>
    </ul>

    <h3 class="text-warning">ENTREGAS À REALIZAR</h3>
    <br />

    <!-- Grid -->
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView_RowDataBound" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Bairro" HeaderText="BAIRRO"/>
            <asp:BoundField DataField="Endereco" HeaderText="ENDEREÇO" />
            <asp:BoundField DataField="Ponto_Ref" HeaderText="P.REFERENCIA" />
            <asp:BoundField DataField="ID_Entrega" HeaderText="ID"/>
        </Columns>
    </asp:GridView>

    <!-- modal DETALHES -->
    <div id="Modal_Detalhes" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h3 class="modal-title"><asp:Label ID="lbl_nome" runat="server"></asp:Label></h3>
                </div>

                <div class="modal-body">
                    <p><asp:Label ID="lbl_endereco" runat="server"></asp:Label></p>                    
                    <p><asp:Label ID="lbl_ref" runat="server"></asp:Label></p>
                    <p><asp:Label ID="lbl_bairro" runat="server"></asp:Label></p>
                    <p>Tel: <asp:Label ID="lbl_telefone" runat="server"></asp:Label> - Cod: <asp:Label ID="lbl_cod" runat="server"></asp:Label> </p>
                    <p><asp:Label ID="lbl_obs" runat="server"></asp:Label></p>
                    <div class="page-header"></div>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                        <asp:ListItem>ENTREGUE</asp:ListItem>
                        <asp:ListItem>MUDOU-SE</asp:ListItem>
                        <asp:ListItem>AUSENTE</asp:ListItem>
                        <asp:ListItem>NÃO QUIS REC.</asp:ListItem>
                        <asp:ListItem>ÁREA DE RISCO</asp:ListItem>
                        <asp:ListItem>END.INSUF.</asp:ListItem>
                        <asp:ListItem>Num.INEXISTENTE</asp:ListItem>
                    </asp:RadioButtonList>
                 </div>

                <div class="modal-footer">
                    <asp:Button ID="bt_atualizar" runat="server" Text="ATUALIZAR" CssClass="btn btn-success" OnClick="bt_atualizar_click" UseSubmitBehavior="false" data-dismiss="modal" />
                    <asp:Button ID="bt_fechar" runat="server" Text="FECHAR" CssClass="btn btn-default" data-dismiss="modal" />
                </div>

            </div>
        </div>
    </div>

</asp:Content>
