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
    document.getElementById("input_end").focus();
});

function Roteiros_cancelar() {
    window.location.href = "Roteiros_Clientes.aspx";
}


function Roteiros_Salvar() {

    var valid1 = document.getElementById("select_Cidade").value;
    if (valid1 == "0") {
        alert("Selecione a Cidade");
        return;
    }

    $("body").css("cursor", "progress");
    document.getElementById("btsalvar").disabled = true;

    var v1 = document.getElementById("ID_Cli_Hidden").value;
    var v2 = document.getElementById("ID_Mot_Hidden").value;
    var v3 = document.getElementById("input_dest").value;
    var v4 = document.getElementById("input_end").value;
    var v5 = document.getElementById("input_bairro").value;

    var e = document.getElementById("select_Cidade")
    var v6a = e.options[e.selectedIndex].value  // valor 
    var v6b = e.options[e.selectedIndex].text   //cidade

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/Salvar_Roteiro",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + ', param5: "' + v5 + ', param6: "' + v6 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            RoteiroInsertLinha();
        },
        failure: function (response) {
            alert(response.d);
        }
    });


}

function RoteiroInsertLinha() {

    var col1 = document.getElementById('input_dest').value;
    var col2 = document.getElementById('input_end').value;
    var col3 = document.getElementById('input_bairro').value;
    var col4 = document.getElementById('select_Cidade').value;

    var table = document.getElementById("MyTable");

    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);

    cell1.innerHTML = col1;
    cell2.innerHTML = col2;
    cell3.innerHTML = col3;

    //apaga formulario
    document.getElementById('input_DEPNome').value = "";
    document.getElementById('input_DEPparent').value = "";
    document.getElementById('input_DEPNasc').value = "";

}