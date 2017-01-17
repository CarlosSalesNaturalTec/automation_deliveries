<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Clientes.aspx.cs" Inherits="Clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>

</head>

<body>

    <h3>Cadastro de Clientes</h3>

    <div class="row">
        <div class="col-md-4">
           Quant.: <asp:Label ID="lblTotalDeRegistros" runat="server"></asp:Label>
        </div>
    </div>
    <br />


    <form class="form-horizontal">
        <fieldset>
            <div class="form-group">
                <div class="col-md-4">
                    <input type="text" class="form-control" id="inputNome" placeholder="Cliente / Contrato">
                </div>
                <div class="col-md-2">
                    <input type="button" class="btn btn-primary" id="btFiltro" value="Pesquisar">
                </div>
                <div class="col-md-1">
                    <a href="../Cadastros/ClienteNovo.aspx" class="btn btn-success">Novo</a>
                </div>
            </div>
        </fieldset>
    </form>



    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
</body>
</html>
