﻿<%@ Page Title="Painel Principal" Language="C#" Culture="auto" UICulture="auto" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" EnableEventValidation="false" Inherits="automation_deliveries_client._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Automation Deliveries CLIENT - Web App para automação de entrega de encomendas - Módulo Cliente -->
    <!-- Criação    : Carlos Sales https://github.com/CarlosSalesNaturalTec  / 2016's-->
    <!-- Recursos   : ASP.NET / JAVASCRIPT / CSS Bootstrap / SQL / Windows Azure -->
    <!-- Módulo     : PAINEL PRINCIPAL -->
    <!---------------------------------------------------------------------------------------------------------------------------------->

    <style type="text/css">
        body {
            padding-top: 70px;
        }
    </style>
     
    <!-- LINHA 01 -->
     <div class="row">

        <!-- DATA -->
        <div class="col-sm-4 col-lg-4">
            <div class="half-unit">
                <dtitle>Data</dtitle>
                <hr>
                <div class="clockcenter">
                     <h3><asp:Label ID="lbl_data" runat="server" Text=""></asp:Label></h3>
                </div>
            </div>
        </div>

        <!-- HORA LOCAL-->
        <div class="col-sm-4 col-lg-4">
            <div class="half-unit">
                <dtitle>Hora Local</dtitle>
                <hr>
                <div class="clockcenter">
                     <h3><digiclock>10:10:10</digiclock></h3>
                </div>
            </div>
        </div>

        <!-- TOTAL DE ENTREGAS DO DIA -->
        <div class="col-sm-4 col-lg-4">
            <div class="half-unit">
                <dtitle>Total de Entregas do Dia</dtitle>
                <hr>
                <div class="clockcenter">
                    <h3><asp:Label ID="lbl_total_entregas_dia" runat="server"></asp:Label></h3>
                </div>
            </div>
        </div>

    </div>  

    <!-- LINHA 02 -->
    <div class="row">

        <!-- FUNCIONARIOS EM CAMPO-->
        <div class="col-sm-4 col-lg-4">
            <div class="dash-unit">
                <dtitle>% Funcionários em Campo</dtitle>
                <hr>
                <div id="container_painel2" style="width: 200px; height: 200px; margin: 0 auto"></div>
            </div>
        </div>

        <!-- ENTREGAS EFETUADAS  -->
        <div class="col-sm-4 col-lg-4">
            <div class="dash-unit">
                <dtitle>% Entregas Efetuadas</dtitle>
                <hr>
                <div id="container_painel1" style="width: 300px; height: 300px; margin: 0 auto"></div>
            </div>
        </div>

        <!-- ENTREGAS NO PERÍODO  -->
        <div class="col-sm-4 col-lg-4">
            <div class="dash-unit">
                <dtitle>% Entregas no Período</dtitle>
                <hr>
                <div id="container_painel3" style="min-width: 280px; height: 280px; margin: 0 auto"></div>
            </div>
        </div>

    </div>  
    
    <!-- SCRIPTS e Stylos RESPONSAVEIS PELA CONSTRUÇÃO DOS GRÁFICOS -->
    <script type="text/javascript" src="Scripts/admin.js"></script>
    <script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>

</asp:Content>
