<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Scripts_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>LOGIN Painel de Controle</title>

    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="../vendors/animate.css/animate.min.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet">

    <script src="Scripts/jquery-3.1.1.min.js" type="text/javascript"></script>

    <script type = "text/javascript">
        function TentarLogin() {            

            $.ajax({
                type: "POST",
                url: "WebService.asmx/Identificador",
                data: '{user: "' + document.getElementById("txtNome").value + '", pwd: "' + document.getElementById("txtpwd").value + '"  }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
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
            <form id="form1" runat="server">
              <h1>Painel de Controle</h1>
              <div>
                <input type="text" class="form-control" placeholder="Usuário" id="txtNome"/>
              </div>
              <div>
                <input type="password" class="form-control" placeholder="Senha" required="" id="txtpwd" />
              </div>
              <div>
                  <input type="button" value="ENTRAR" onclick="TentarLogin()" class="btn btn-default" />
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <p class="change_link">Primeiro Acesso?
                  <a href="#signup" class="to_register">Solicitar uma Conta</a>
                </p>

                <div class="clearfix"></div>
                <br />

                <div>
                  <h1><i class="fa fa-motorcycle"></i> Log Transportes</h1>
                  <a href="https://play.google.com/store/apps/details?id=br.com.loglogistica.logapp"> Baixar Aplicativo de Rastreamento na Google Play Store</a>  
                </div>                

              </div>
            </form>
          </section>
        </div>

        <div id="register" class="animate form registration_form">
          <section class="login_content">
            <form>
              <h1>Solicitar Acesso</h1>
              <div>
                <input type="text" class="form-control" placeholder="Empresa" required="" />
              </div>
                <div>
                    <input type="text" class="form-control" placeholder="Nome do Contato" required="" />
                </div>
              <div>
                <input type="email" class="form-control" placeholder="Email" required="" />
              </div>
              <div>
                <a class="btn btn-default submit" href="#">Solicitar</a>
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <p class="change_link">Já é Cliente ?
                  <a href="#signin" class="to_register">Login</a>
                </p>

                <div class="clearfix"></div>
                <br />

                  <div>
                      <h1><i class="fa fa-motorcycle"></i> Log Transportes</h1>
                      <p>©2017 All Rights Reserved.</p>
                  </div>
              </div>
            </form>
          </section>
        </div>
      </div>
    </div>
  </body>


</html>
