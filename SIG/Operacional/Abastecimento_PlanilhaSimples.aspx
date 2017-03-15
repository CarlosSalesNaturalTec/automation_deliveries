<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_PlanilhaSimples.aspx.cs" Inherits="Abastecimento_PlanilhaSimples" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>

</head>

<body>

   <a href="Abastecimento_Planilha.aspx" class="btn btn-primary">VOLTAR</a>

    <h3>Planilha Consolidação de Abastecimentos</h3>
    <br />

    <div class="row">
        <div class="col-md-3">
            <div class="well">
                <h4><p>Saldo Atual:</p></h4>
                <h3 class="text-primary"><b><asp:Literal ID="Literal_Saldo" runat="server"></asp:Literal></b></h3>
            </div>
        </div>

        <div class="col-md-3">
            <div class="well">
                <h4><p>Total de Créditos:</p></h4>
                <h3 class="text-success"><b><asp:Literal ID="Literal_TotalCR" runat="server"></asp:Literal></b></h3>
            </div>
        </div>

        <div class="col-md-3">
            <div class="well">
                <h4><p>Total de Débitos:</p></h4>
                <h3 class="text-danger"><b><asp:Literal ID="Literal_TotalDB" runat="server"></asp:Literal></b></h3>
            </div>
        </div>
    </div>


    <!-- Planilha  -->
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <!-- Planilha  -->

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
