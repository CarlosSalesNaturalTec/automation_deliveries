<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Funcionarios.aspx.cs" Inherits="Funcionarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">

    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>


</head>

<body>

    <h3>Cadastro de Funcionários</h3>

    <div class="row">
        
        <div class="col-md-3">
            <div class="well">
                <h5 class="text-primary">
                    <p>Funcionários Cadastrados</p>
                </h5>
                <h3 class="text-primary"><i class="fa fa-user"></i>
                    <b><asp:Literal ID="Literal_Quant" runat="server"></asp:Literal></b> 
                </h3>
                <a href="Funcionarios_Ficha.aspx?p1=1" class="btn btn-block btn-success"><i class="fa fa-plus-square"></i> NOVO FUNCIONÁRIO</a>
            </div>
        </div>

        <div class="col-md-3">
            <div class="well">
                <h5 class="text-primary">
                    <p>Listagem de Funcionários</p>
                </h5>
                <h3 class="text-primary"><i class="fa fa-users"></i>
                </h3>
                <a href="Funcionarios_Pesquisa.aspx" class="btn btn-block btn-success"><i class="fa fa-search"></i> PESQUISAR</a>
            </div>
        </div>

    </div>

</body>
</html>

