<%@ Page Title="Entrar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="deliv._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Automation Deliveries - Web App para automação de entrega de encomendas  -->
    <!-- Autor      : Carlos Sales https://github.com/CarlosSalesNaturalTec  -->
    <!-- Ano        : 2016 -->
    <!-- Recursos   : JAVASCRIPT / GOOGLE MAPS API´s / ASP.NET / C# / CSS / SQL / Windows Azure -->
    <!-- Módulo     : LOGIN -->
    <!---------------------------------------------------------------------------------------------------------------------------------->
    
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

    <!-- Mensagens do sistema  -->
    <br /><p class="text-danger"><asp:Label ID="lbl_msg" runat="server"></asp:Label></p><br />

    <!-- Login -->
    <div class="row">
        <div class="col-lg-6">

            <div class="well bs-component">
                <form class="form-horizontal">
                    <fieldset>
                        <div class="form-group">
                            <label for="inputUser" class="col-lg-2 control-label">Usuário</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="inputUser" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="inputSenha" class="col-lg-2 control-label">Senha</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="inputSenha" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <br />
                                <asp:Button ID="bt_conectar" runat="server" Text="Conectar" OnClick="bt_conectar_Click" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>

        </div>
    </div>

    <!-- inputs que recebem coordenadas de geolocalização-->
    <input id="input1" name="txtlat" type="hidden" value="0"/>
    <input id="input2" name="txtlng" type="hidden" value="0"/>
    <input id="input3" name="txtacrcy" type="hidden" value="0"/>

    <!-- Script p/ envio de requisição HTTPS -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>

</asp:Content>
