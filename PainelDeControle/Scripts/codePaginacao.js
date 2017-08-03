$(document).ready(function () {
    $('#tabela').DataTable({
        "order": [[0, "desc"]],
        "language": {
            "emptyTable": "Sem dados",
            "info": "Exibindo _START_ a _END_ de _TOTAL_ registros",
            "infoEmpty": "Exibindo 0 a 0 de 0 registros",
            "infoFiltered": "(Filtrado de _MAX_ registros)",
            "lengthMenu": "Exibindo _MENU_ registros",
            "loadingRecords": "Carregando...",
            "processing": "Processando...",
            "search": "Pesquisa:",
            "zeroRecords": "Sem Registros",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            }
        }
    });
});