<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Abastecimento_Lista.aspx.cs" Inherits="Abastecimento_Lista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/vendors/bootstrap/dist/css/bootstrap.min.css">
    <script src="~/vendors/jquery/dist/jquery.min.js"></script>
    <script src="~/vendors/bootstrap/dist/js/bootstrap.min.js"></script>

</head>

<body>

    <h3>Autorizações de Abastecimentos</h3>

    <a href="Abastecimento_Novo.aspx" class="btn btn-success">Novo</a>
    <br />
    
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

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