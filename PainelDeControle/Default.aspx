<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en">
  <head>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Painel de Controle </title>

    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- iCheck -->
    <link href="../vendors/iCheck/skins/flat/green.css" rel="stylesheet">
    <!-- bootstrap-progressbar -->
    <link href="../vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css" rel="stylesheet">
    <!-- JQVMap -->
    <link href="../vendors/jqvmap/dist/jqvmap.min.css" rel="stylesheet"/>
    <!-- bootstrap-daterangepicker -->
    <link href="../vendors/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet">
    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet">

  </head>

  <body class="nav-md">
    <div class="container body">
      <div class="main_container">
        <div class="col-md-3 left_col">
          <div class="left_col scroll-view">
            <div class="navbar nav_title" style="border: 0;">
              <a href="Default.aspx" class="site_title"><i class="fa fa-motorcycle"></i> <span>LOG Transportes</span></a>
            </div>

            <div class="clearfix"></div>
            
            <br />

            <!-- sidebar menu -->
            <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
              <div class="menu_section">
                <ul class="nav side-menu">
                  <li><a><i class="fa fa-table"></i> Cadastros <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="Clientes.aspx" target="iframe_a">Clientes</a></li>
                      <li><a href="Entregadores.aspx" target="iframe_a">Colaboradores</a></li>
                      <li><a href="Veiculos_Lista.aspx" target="iframe_a">Veículos</a></li>
                      <li><a href="Curriculuns.aspx" target="iframe_a">Banco de Curriculos</a></li>
                      <li><a href="Orcamento_lista.aspx" target="iframe_a">Orçamentos</a></li>
                    </ul>
                  </li>

                  <li><a><i class="fa fa-truck"></i> Operacional <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                        <li><a>Abastecimentos<span class="fa fa-chevron-down"></span></a>
                          <ul class="nav child_menu">
                            <li class="sub_menu"><a href="Abastecimento_Lista.aspx" target="iframe_a">Autorizações</a>
                            </li>
                            <li><a href="Abastecimento_Planilha.aspx" target="iframe_a">Planilha</a>
                            </li>
                              <li><a href="Abastecimento_Relatorios.aspx" target="iframe_a">Relatórios</a>
                            </li>
                          </ul>
                        </li>
                    </ul>
                  </li>

                    <li><a><i class="fa fa-bar-chart-o"></i> Relatórios <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="#" target="iframe_a">Produtividade</a></li>
                      <li><a href="#" target="iframe_a">Performance</a></li>
                        <li><a href="#" target="iframe_a">Distância Percorrida</a></li>
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
              </ul>

            </nav>
          </div>
        </div>
        <!-- /top navigation -->

        <!-- page content -->
         <div class="right_col" role="main">
            <iframe src="PainelPrincipal.aspx" height="2000px" width="100%" frameborder="0" name="iframe_a"><p>Seu browser não suporta iframes.</p></iframe> 
         </div>      
        <!-- /page content -->

      </div>
    </div>

    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
    
  </body>
</html>
