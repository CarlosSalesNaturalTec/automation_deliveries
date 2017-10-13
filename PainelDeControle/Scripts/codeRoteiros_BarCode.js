$(document).ready(function () {
    document.getElementById("input_end").focus();
});

function voltar() {
    window.location.href = "Roteiros_Clientes1.aspx";
}

function Adicionar() {

    //validacoes
    var valid1 = document.getElementById("input_end").value;
    if (valid1 == "") { alert("Informe Número da Entrega"); return; }

    var valid2 = document.getElementById("input_bairro").value;
    if (valid2 == "") { alert("Informe Bairro"); return; }

    var e = document.getElementById("select_Cidade")
    var v4 = e.options[e.selectedIndex].text   //nome da cidade
    if (v4 == "") { alert("Selecione uma Cidade"); return; }

    // envia para webservice
    $("body").css("cursor", "progress");
    document.getElementById("btSalvar").disabled = true;

    var v1 = document.getElementById("ID_Cli_Hidden").value;   
    var v2 = document.getElementById("input_end").value;
    var v3 = document.getElementById("input_bairro").value;

    var v5 = e.options[e.selectedIndex].value  // valor da encomenda (interno LOG)
    var v6 = document.getElementById("input_valor").value;      // valor do cliente

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/Roteiro_Salvar_2",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '", param6: "' + v6 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            $("body").css("cursor", "default");
            document.getElementById("btSalvar").disabled = false;

            RoteiroInsertLinha(response.d);

        },
        failure: function (response) {
            window.location.href = response.d;
        }
    });

}

function RoteiroInsertLinha(idEntrega) {

    var btDel = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='Roteiro_Excluir(this," + idEntrega + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";
    var col1 = btDel + document.getElementById('input_end').value;

    var col2 = document.getElementById('input_bairro').value;

    var e = document.getElementById("select_Cidade")
    var col3 = e.options[e.selectedIndex].text   //cidade

    var col4 = document.getElementById('input_valor').value;

    var table = document.getElementById("MyTable");

    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);
    var cell4 = row.insertCell(3);

    cell1.innerHTML = col1;
    cell2.innerHTML = col2;
    cell3.innerHTML = col3;
    cell4.innerHTML = col4;

    //apaga formulario
    document.getElementById("input_valor").value = "";
    document.getElementById("input_end").value = "";

    document.getElementById("input_end").focus();

}

function Roteiro_Excluir(r, USerID) {

    var conf = confirm("Confirma Exclusão de Roteiro?");
    if (conf == false) { return; }

    $("body").css("cursor", "progress");

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/Roteiro_Excluir",
        data: '{param1: "' + USerID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // excluir linha do Table
            var i = r.parentNode.parentNode.rowIndex;
            document.getElementById("MyTable").deleteRow(i);
            $("body").css("cursor", "default");
        },
        failure: function (response) {
            alert(response.d);
        }
    });

}
