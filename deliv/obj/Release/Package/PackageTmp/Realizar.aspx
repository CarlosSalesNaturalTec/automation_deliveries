<%@ Page Title="Entregas Realizadas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Realizar.aspx.cs" EnableEventValidation="false" Inherits="deliv.Realizar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Automation Deliveries ENTREGAS - Web App para automação de entrega de encomendas -->
    <!-- Criação    : Carlos Sales https://github.com/CarlosSalesNaturalTec  -->
    <!-- Ano        : 2016 -->
    <!-- Recursos   : JAVASCRIPT / GOOGLE MAPS API´s / ASP.NET / C# / CSS / SQL / Windows Azure -->
    <!-- Módulo     : DELIVERIES - ENTREGAS À REALIZAR-->
    <!--------------------------------------------------------------------------------->

    <asp:Timer ID="Timer1" runat="server" Interval="60000"></asp:Timer>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"></asp:UpdatePanel>

    <!-- Requisição de Geolocalização (Google Geolocation API) via Jquery/Ajax POST-->
    <script type="text/javascript">
        $.ajax({
            url: "https://www.googleapis.com/geolocation/v1/geolocate?key=AIzaSyCOmedP-f3N7W7CPxaRoCZJ5mTMm6g0Ycc",
            type: "POST",
            success: function (data) {
                document.getElementById("input1").value = data.location.lat
                document.getElementById("input2").value = data.location.lng
                document.getElementById("input3").value = data.accuracy
            }
        });
    </script>


    <!-- Script Modal Detalhes -->
    <script type="text/javascript">
        function openModal() {
            $('#Modal_Detalhes').modal('show');
        }
    </script>

     <!-- data corrente e ID do funcionário -->
    <br /><ul class="breadcrumb">
        <li class="active">
            <asp:Label ID="lbl_data" runat="server"></asp:Label> - <asp:Label ID="lbl_ID_Funcionario" runat="server"></asp:Label>
        </li>
    </ul>

    <!-- Cabeçalho -->
    <h2 class="text-warning">ENTREGAS À REALIZAR</h2>   <br />

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
                    <asp:Button ID="bt_atualizar" runat="server" Text="ATUALIZAR" CssClass="btn btn-success" OnClick="bt_atualizar_click"  UseSubmitBehavior="false" data-dismiss="modal" />
                    <asp:Button ID="bt_fechar" runat="server" Text="FECHAR" CssClass="btn btn-default" data-dismiss="modal" />
                </div>

            </div>
        </div>
    </div>

    <!-- inputs que recebem coordenadas de geolocalização-->
    <br />
    <input id="input1" name="txtlat" type="hidden" value="0"/>
    <input id="input2" name="txtlng" type="hidden" value="0"/>
    <input id="input3" name="txtacrcy" type="hidden" value="0"/>
    
 </asp:Content>