﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>SIG - Sistema de Gestão - LOG Transportes</title>

     <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap -->
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="vendors/animate.css/animate.min.css" rel="stylesheet">
    
    <!-- Custom Theme Style -->
    <link href="build/css/custom.min.css" rel="stylesheet">

    <script src="Scripts/jquery-3.1.1.min.js" type="text/javascript"></script>

    <script type = "text/javascript">
        function TentarLogin() {

            document.getElementById("btLogin").style.cursor = "progress";

            $.ajax({
                type: "POST",
                url: "WebService.asmx/Identificador",
                data: '{user: "' + document.getElementById("txtNome").value + '", pwd: "' + document.getElementById("txtpwd").value + '"  }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                    document.getElementById("btLogin").style.cursor = "default";
                }
            });
        }
        function OnSuccess(response) {
            var linkurl = response.d;
            window.location.href = linkurl;
        }
    </script> 

</head>
 
<body class="login">

    
    <div>
      <a class="hiddenanchor" id="signup"></a>
      <a class="hiddenanchor" id="signin"></a>

      <div class="login_wrapper">
        <div class="animate form login_form">
          <section class="login_content">
              <img alt="" src="images/logo.png" width="60%"/>
            <form>
              <h1><strong>S I G</strong></h1>
              <div>
                <input type="text" class="form-control" placeholder="Usuário" required="" id="txtNome"/>
              </div>
              <div>
                <input type="password" class="form-control" placeholder="Senha" required="" id="txtpwd"/>
              </div>
              <div>
                 <input id="btLogin" type="button" value="ENTRAR" onclick="TentarLogin()" class="btn btn-default" />
              </div>

              <div class="clearfix"></div>

              <div class="separator">

                <div class="clearfix"></div>
                <br />

                <div><h4><strong>SISTEMA INTEGRADO DE GESTÃO</strong></h4>
                    <h5><i class="fa fa-copyright"></i> LOG Transportes. 2017</h5>
                </div>
              </div>
            </form>
          </section>
        </div>

        <div id="register" class="animate form registration_form">
          <section class="login_content">
            <form>
              <h2>Acesso não Autorizado</h2>
              
              <div>
                <a class="btn btn-default submit" href="#signin">TENTAR NOVAMENTE</a>
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <p class="change_link">Senha ou usuário Inválidos</p>
                <div class="clearfix"></div>
                <br />

                <div><h4><strong>SISTEMA INTEGRADO DE GESTÃO</strong></h4>
                    <h5><i class="fa fa-copyright"></i> LOG Transportes. 2017</h5>
                </div>
              </div>
            </form>
          </section>
        </div>
      </div>
    </div>

     <!-- Foco  -->
    <script type="text/javascript">
        document.getElementById("txtNome").focus();
    </script>

  </body>

</html>