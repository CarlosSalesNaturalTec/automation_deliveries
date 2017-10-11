var map;
var markers = [];
var latPonto1, lngPonto1, ltlg;

function initMap() {

    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -12.9525123, lng: -38.4535139 },
        zoom: 11
    });

    var input1 = document.getElementById('input_bairro');

    var defaultBounds = new google.maps.LatLngBounds(
        new google.maps.LatLng(-13.0099, -38.5323),
        new google.maps.LatLng(-12.7894, -38.2115)
        );

    var options1 = {
        bounds: defaultBounds
    };

    var places1 = new google.maps.places.Autocomplete(input1, options1);

    AtualizaMarcadores();

    document.getElementById("input_end").focus();

}


function Roteiros_cancelar() {
    window.location.href = "Roteiros_Clientes.aspx";
}

function obtemCoord() {

    // coordenadas geográficas / Marcadror no Mapa
    //===============================================================
    endereco = document.getElementById('input_bairro').value;
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ address: endereco }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            ltlg = results[0].geometry.location;
            latPonto1 = ltlg.lat();
            lngPonto1 = ltlg.lng();
        };
    });
    //=================================================================

}

function Roteiros_Salvar() {

    //validacoes
    var valid1 = document.getElementById("select_Cidade").value;
    if (valid1 == "0") { alert("Selecione a Cidade"); return; }

    var valid2 = document.getElementById("input_bairro").value;
    if (valid2 == "") { alert("Informe Bairro"); return; }

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

    var v10 = latPonto1;
    var v11 = lngPonto1;

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/Roteiro_Salvar",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '", param3: "' + v3 + '", param4: "' + v4 + '", param5: "' + v5 +
            '", param6: "' + v6 + '", param7: "' + v7 + '", param8: "' + v8 + '", param9: "' + v9 + '", param10: "' + v10 + '", param11: "' + v11 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            $("body").css("cursor", "default");
            document.getElementById("btsalvar").disabled = false;

            // adiciona Marcador
            endereco1 = document.getElementById('input_end').value;
            marker = new google.maps.Marker({
                position: ltlg,
                map: map,
                title: endereco1,
                animation: google.maps.Animation.DROP
            });

            RoteiroInsertLinha(response.d);

        },
        failure: function (response) {
            window.location.href = response.d;
        }
    });

}

function RoteiroInsertLinha(idEntrega) {

    var btDel = "<a class='w3-btn w3-round w3-hover-red w3-text-green' onclick='Roteiro_Excluir(this," + idEntrega + ")'><i class='fa fa-trash-o' aria-hidden='true'></i></a>&nbsp;&nbsp;";
    var col1 = btDel + document.getElementById('input_dest').value;

    var col2 = document.getElementById('input_end').value;
    var col3 = document.getElementById('input_bairro').value;

    var e = document.getElementById("select_Cidade")
    var col4 = e.options[e.selectedIndex].text   //cidade

    var col5 = latPonto1;
    var col6 = lngPonto1;

    var table = document.getElementById("MyTable");

    var row = table.insertRow(-1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);
    var cell4 = row.insertCell(3);
    var cell5 = row.insertCell(4);
    var cell6 = row.insertCell(5);

    cell1.innerHTML = col1;
    cell2.innerHTML = col2;
    cell3.innerHTML = col3;
    cell4.innerHTML = col4;
    cell5.innerHTML = col5;
    cell6.innerHTML = col6;

    //apaga formulario
    document.getElementById('input_dest').value = "";
    document.getElementById('input_end').value = "";
    document.getElementById('input_pref').value = "";
    document.getElementById('input_tel').value = "";

    document.getElementById("input_end").focus();

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
            AtualizaMarcadores();
        },
        failure: function (response) {
            alert(response.d);
        }
    });

}

function AtualizaMarcadores() {

    var v1 = document.getElementById("ID_Cli_Hidden").value;
    var v2 = document.getElementById("ID_Mot_Hidden").value;

    //monta marcadores
    $.ajax({
        type: "POST",
        url: "wspainel.asmx/Roteiro_Marcadores_Exibir",
        data: '{param1: "' + v1 + '", param2: "' + v2 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data, status) {

            //remove todos os marcadores
            for (var i = 0; i < markers.length; i++) {
                markers[i].setMap(null);
            }

            var itens = $.parseJSON(data.d);
            for (var i = 0; i < itens.length; i++) {
                exibirmarcador(itens[i].lat, itens[i].lng, itens[i].titulo);
            }

        },

        failure: function (response) {
            alert(response.d);
        }
    });

}

function exibirmarcador(lat, lng, titulo) {

    var position = new google.maps.LatLng(lat, lng)

    var marker = new google.maps.Marker({
        position: position,
        title: titulo,
        map: map
    });

    var infowindow = new google.maps.InfoWindow({
        content: titulo
    });

    marker.addListener('click', function () {
        infowindow.open(marker.get('map'), marker);
    });

    markers.push(marker);
}