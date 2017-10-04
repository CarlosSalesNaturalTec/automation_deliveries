function Roteiros_Avançar() {
    var idaux_1 = document.getElementById("select_empresa");
    var idaux_2 = idaux_1.options[idaux_1.selectedIndex].value;     //ID do cliente
    var aux3 = idaux_1.options[idaux_1.selectedIndex].text;         //Nome do cliente

    var id2aux_1 = document.getElementById("select_motoboy");
    var id2aux_2 = id2aux_1.options[id2aux_1.selectedIndex].value;  // ID do motoboy
    var aux4 = id2aux_1.options[id2aux_1.selectedIndex].text;       // Nome do Motoboy

    //validacoes
    if (idaux_2 == "0") { alert("Selecione um Cliente"); return }
    if (id2aux_2 == "0") { alert("Selecione um Motoboy"); return }
    
    var urlLink = "Roteiros.aspx?v1=" + idaux_2 + "&v2=" + id2aux_2 + "&v3=" + aux3 + "&v4=" + aux4;
    window.location.href = urlLink;
}

function Roteiros_Cancelar() {
    window.location.href = "Home.aspx";
}


function Roteiro_Excluir(r, USerID) {

    var conf = confirm("Confirma Exclusão de Roteiro?");
    if (conf == false) { return; }

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/Roteiro_Excluir",
        data: '{param1: "' + USerID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // excluir linha do Table
            var i = r.parentNode.parentNode.rowIndex;
            document.getElementById("tabela").deleteRow(i);
        },
        failure: function (response) {
            alert(response.d);
        }
    });


}