<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Veiculos_Lista.aspx.cs" Inherits="Veiculos_Lista" %>

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
    <h3>Frota de Veículos</h3>

    <div class="row">
        <div class="col-md-3">
            <div class="well">
                <h4 class="text-primary">
                    <p>Quantidade</p>
                </h4>
                <h3 class="text-primary"><b><i class="fa fa-car"></i>
                    <asp:Literal ID="Literal_Quant" runat="server"></asp:Literal></b>
                </h3>
                <a href="Veiculos_Novo.aspx" class="btn btn-success">NOVO VEÍCULO</a>
                <p></p>
            </div>
        </div>
    </div>

    <hr />
    <br />

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Busca e Paginação modelo: datatables.net -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>

    <link rel="stylesheet" href="//cdn.datatables.net/1.10.10/css/jquery.dataTables.min.css">
    <script src="//cdn.datatables.net/1.10.10/js/jquery.dataTables.min.js"></script>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.10/css/dataTables.bootstrap.min.css">

    <script>
        $(document).ready(function () {
            $('#tabela').DataTable({
                "language": {
                    "lengthMenu": "Mostrando _MENU_ registros por página",
                    "zeroRecords": "Nada encontrado",
                    "info": " _MAX_ registros no total",
                    "infoEmpty": "Nenhum registro disponível",
                    "infoFiltered": "(filtrado de _MAX_ registros no total)",
                    "search": "Pesquisa:"
                }
            });
        });
    </script>

</body>
</html>
