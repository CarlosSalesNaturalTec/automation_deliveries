<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Planilha.aspx.cs" Inherits="Abastecimento_Planilha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>


</head>

<body>

    <h3>Planilha Consolidação de Abastecimentos</h3>

    <div class="row">
        <div class="col-md-3">
            <h4 class="text-primary">
                <asp:Literal ID="Literal_Saldo" runat="server"></asp:Literal></h4>
        </div>
        <div class="col-md-3">
            <h4 class="text-primary">
                <asp:Literal ID="Literal_TotalCR" runat="server"></asp:Literal></h4>
        </div>
        <div class="col-md-3">
            <h4 class="text-primary">
                <asp:Literal ID="Literal_TotalDB" runat="server"></asp:Literal></h4>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <a href="Abastecimento_Novo.aspx" class="btn btn-primary">NOVA AUTORIZAÇÃO</a>
        </div>
        <div class="col-md-3">
            <a href="Abastecimento_Credito.aspx" class="btn btn-success">LANÇAR CRÉDITO</a>
        </div>
        <div class="col-md-3">
            <a href="Abastecimento_Relatorios.aspx" class="btn btn-primary">RELATÓRIOS</a>
        </div>
    </div>

    <br />

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
	    $(document).ready(function(){
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
