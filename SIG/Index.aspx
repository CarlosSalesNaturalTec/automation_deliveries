﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>SIG - Sistema de Gestão - LOG Transportes</title>

    <!-- Bootstrap -->
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- bootstrap-daterangepicker -->
    <link href="vendors/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="build/css/custom.min.css" rel="stylesheet">
</head>

<body class="nav-md">
    <div class="container body">
        <div class="main_container">
            <div class="col-md-3 left_col">
                <div class="left_col scroll-view">
                    <div class="navbar nav_title" style="border: 0;">
                        <a class="site_title">
                            <img alt="" src="images/logo.png" width="25%" /><span><strong> S I G</strong></span></a>
                    </div>

                    <div class="clearfix"></div>

                    <!-- menu profile quick info -->
                    <div class="profile clearfix">
                        <div class="profile_pic">
                        </div>
                        <div class="profile_info">
                        </div>
                    </div>
                    <!-- /menu profile quick info -->

                    <!-- sidebar menu -->
                    <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
                        <div class="menu_section">
                            <ul class="nav side-menu">
                                <li><a><i class="fa fa-edit"></i>Cadastros <span class="fa fa-chevron-down"></span></a>
                                    <ul class="nav child_menu">
                                        <li><a href="https://sigcad.azurewebsites.net/Clientes.aspx" target="iframe_a">Clientes</a></li>
                                        <li><a href="https://sigcad.azurewebsites.net/Contratos.aspx" target="iframe_a">Contratos</a></li>
                                        <li><a href="https://sigcad.azurewebsites.net/Funcionarios.aspx" target="iframe_a">Funcionários</a></li>
                                        <li><a href="https://sigcad.azurewebsites.net/Veiculos_Lista.aspx" target="iframe_a">Veículos/Frota</a></li>
                                        <li><a href="https://sigcad.azurewebsites.net/Extras_Tabelas.aspx" target="iframe_a">Extras - Tabela de Preços</a></li>
                                    </ul>
                                </li>
                                <li><a><i class="fa fa-truck"></i>Operacional <span class="fa fa-chevron-down"></span></a>
                                    <ul class="nav child_menu">
                                        <li><a href="https://sigoperac.azurewebsites.net/Abastecimento_Planilha.aspx" target="iframe_a">Abastecimentos</a></li>
                                    </ul>
                                </li>
                                <li><a><i class="fa fa-table"></i>Comercial <span class="fa fa-chevron-down"></span></a>
                                    <ul class="nav child_menu">
                                        <li><a href="PainelPrincipal.aspx" target="iframe_a">Orçamentos</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <!-- /sidebar menu -->
                </div>
            </div>

            <!-- top navigation -->
            <div class="top_nav">
                <div class="nav_menu">
                    <nav>
                        <div class="nav toggle">
                            <a id="menu_toggle"><i class="fa fa-bars"></i></a>
                        </div>

                        <ul class="nav navbar-nav navbar-right">

                            <li class="">
                                <a href="javascript:;" class="user-profile dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                    <img src="images/userdefault.jpg" alt=""><asp:Label ID="lblUsuario1" runat="server" CssClass="text-primary"></asp:Label>
                                    <span class=" fa fa-angle-down"></span>
                                </a>
                                <ul class="dropdown-menu dropdown-usermenu pull-right">
                                    <li><a href="javascript:;">Perfil</a></li>
                                    <li><a href="Default.aspx"><i class="fa fa-sign-out pull-right"></i>Sair</a></li>
                                </ul>
                            </li>


                            <li role="presentation" class="dropdown">
                                <a href="javascript:;" class="dropdown-toggle info-number" data-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-envelope-o"></i>
                                    <span class="badge bg-green"></span>
                                </a>
                                <ul id="menu1" class="dropdown-menu list-unstyled msg_list" role="menu">
                                    <li>
                                        <a>
                                            <span>
                                                <span>Solicitações de Orçamento</span>
                                                <span class="time">0 Novas</span>
                                            </span>
                                        </a>
                                    </li>
                                    <li>
                                        <a>
                                            <span>
                                                <span>Curriculuns Cadastrados</span>
                                                <span class="time">0 novos</span>
                                            </span>
                                        </a>
                                    </li>
                                    <li>
                                        <a>
                                            <span>
                                                <span>Solicitações Clientes</span>
                                                <span class="time">0 novas</span>
                                            </span>
                                        </a>
                                    </li>
                                </ul>
                            </li>


                        </ul>
                    </nav>
                </div>
            </div>
            <!-- /top navigation -->

            <!-- page content -->
            <div class="right_col" role="main">
                <iframe src="PainelPrincipal.aspx" height="1000px" width="100%" frameborder="0" name="iframe_a">
                    <p>Seu browser não suporta iframes.</p>
                </iframe>
            </div>
            <!-- /page content -->

            <!-- footer content -->
            <footer>
                <div class="pull-right">
                    LOG Transportes - 2017
                </div>
                <div class="clearfix"></div>
            </footer>
            <!-- /footer content -->
        </div>
    </div>

    <!-- jQuery -->
    <script src="vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="vendors/nprogress/nprogress.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="build/js/custom.min.js"></script>

</body>

</html>
