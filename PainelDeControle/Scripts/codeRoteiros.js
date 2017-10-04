var input1 = document.getElementById('input_end');

var defaultBounds = new google.maps.LatLngBounds(
    new google.maps.LatLng(-13.0099, -38.5323),
    new google.maps.LatLng(-12.7894, -38.2115)
    );

var options1 = {
    bounds: defaultBounds
};

google.maps.event.addDomListener(window, 'load', function () {
    var places1 = new google.maps.places.Autocomplete(input1, options1);
    document.getElementById("input_dest").focus();
});

function Roteiros_cancelar() {
    window.location.href = "Roteiros_Clientes.aspx";
}


function Roteiros_Salvar() {

    //validacoes
    var valid1 = document.getElementById("select_Cidade").value;
    if (valid1 == "0") { alert("Selecione a Cidade"); return; }

    var valid2 = document.getElementById("input_bairro").value;
    if (valid2 == "") { alert("Informe Bairro"); return; }

    var valid3 = document.getElementById("input_dest").value;
    if (valid3 == "") { alert("Informe Destinatário"); return; }

    //envia para webservice
    $("body").css("cursor", "progress");
    document.getElementById("btsalvar").disabled = true;

    var v1 = document.getElementById("ID_Cli_Hidden").value;
    var v2 = document.getElementById("ID_Mot_Hidden").value;

    var v3 = document.getElementById("input_dest").value;
    var v4 = document.getElementById("input_end").value;
    var v5 = document.getElementById("input_bairro").value;

    var e = document.getElementById("select_Cidade")
    var v6 = e.options[e.selectedIndex].text   //cidade
    var v7 = e.options[e.selectedIndex].value  // valor 

    var v8 = document.getElementById("input_pref").value;
    var v9 = document.getElementById("input_tel").value;

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/Roteiro_Salvar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 + '", param6: "' + v6 + '", param7: "' + v7 + '", param8: "' + v8 + '", param9: "' + v9 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("body").css("cursor", "default");
            document.getElementById("btsalvar").disabled = false;
            RoteiroInsertLinha();
        },
        failure: function (response) {
            window.location.href = response.d;
        }
    });

}

function RoteiroInsertLinha() {

    var col1 = document.getElementById('input_dest').value;
    var col2 = document.getElementById('input_end').value;
    var col3 = document.getElementById('input_bairro').value;

    var e = document.getElementById("select_Cidade")
    var col4 = e.options[e.selectedIndex].text   //cidade

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
    document.getElementById('input_dest').value = "";
    document.getElementById('input_end').value = "";
    document.getElementById('input_bairro').value = "";
    document.getElementById('input_pref').value = "";
    document.getElementById('input_tel').value = "";
    
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
            document.getElementById("MyTable").deleteRow(i);
        },
        failure: function (response) {
            alert(response.d);
        }
    });


}