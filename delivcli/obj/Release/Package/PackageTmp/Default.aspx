<%@ Page Title="Conectar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="delivcli._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Automation Deliveries - Web App para automação de entrega de encomendas  -->
    <!-- Autor      : Carlos Sales https://github.com/CarlosSalesNaturalTec  -->
    <!-- Ano        : 2016 -->
    <!-- Recursos   : ASP.NET / C# / JAVASCRIPT / CSS / SQL / Windows Azure -->
    <!-- Módulo     : LOGIN -->
    <!---------------------------------------------------------------------------------------------------------------------------------->

    <!-- Mensagens do sistema  -->
    <br />
    <p class="text-danger"><asp:Label ID="lbl_msg" runat="server"></asp:Label></p>
    <br />
    
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
                                <asp:Button ID="bt_conectar" runat="server" Text="Conectar" OnClick ="bt_conectar_Click" CssClass="btn btn-success"/>
                            </div>
                        </div>
                    </fieldset>
                </form>
            </div>

        </div>
    </div>

</asp:Content>
