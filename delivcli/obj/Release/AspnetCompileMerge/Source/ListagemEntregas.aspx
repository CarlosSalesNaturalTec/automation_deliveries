<%@  Language="C#" AutoEventWireup="true" CodeBehind="ListagemEntregas.aspx.cs" Inherits="delivcli.ListagemEntregas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="stylesheet" href="~/Content/bootstrap.min.css">
    <script src="~/Scripts/jquery.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>

</head>

<body>

    <asp:Literal ID="Literal1" runat="server"></asp:Literal>

    <!-- Busca e Paginação modelo: datatables.net -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
	    <link rel="stylesheet" href="//cdn.datatables.net/1.10.10/css/jquery.dataTables.min.css">
	    <script src="//cdn.datatables.net/1.10.10/js/jquery.dataTables.min.js"></script>
	    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
	    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.10/css/dataTables.bootstrap.min.css">
	    <script>
	    $(document).ready(function(){
	        $('#tabelaCli').DataTable({
	            "language": {
	                "processing": "Aguarde! Processando...",
	                "loadingRecords": "Aguarde! Carregando dados...",
		            "lengthMenu": "Mostrando _MENU_ registros por página",
		            "zeroRecords": "Nada encontrado",
		            "info": "Total de Registros:  _MAX_ ",
		            "infoEmpty": "Nenhum registro disponível",
		            "infoFiltered": "(filtrado)",
		            "search": "Pesquisa"
		        }
		    });
		});
	    </script>



</body>

</html>


