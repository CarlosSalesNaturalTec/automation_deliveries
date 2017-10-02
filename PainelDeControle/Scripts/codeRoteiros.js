var input1 = document.getElementById('select_empresa');

/*
var defaultBounds = new google.maps.LatLngBounds(
    new google.maps.LatLng(-13.0099, -38.5323),
    new google.maps.LatLng(-12.7894, -38.2115));

var options1 = {
    bounds: defaultBounds
};

google.maps.event.addDomListener(window, 'load', function () {
    var places1 = new google.maps.places.Autocomplete(input1, options1);
});
*/

function carrega_cidades() {
    var e = document.getElementById("select_empresa");
    var v5 = e.options[e.selectedIndex].value;

    apagaCidades();
    cidades_cliente(v5);

}

function apagaCidades(){
    var x = document.getElementById("select_Cidade");
    for (i = 1; i <= x.length; i++) {
        x.remove(i - 1);
    }
}

function cidades_cliente(idAux) {

    $.ajax({
        type: "POST",
        url: "wspainel.asmx/Carrega_Cidades",
        data: '{param1: "' + idAux + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data, status) {

            var xY = document.getElementById("select_Cidade");
            var op = document.createElement("option");

            var itens = $.parseJSON(data.d);

            for (var i = 0; i < itens.length; i++) {
                op.text = itens[i].nome;
                op.value = itens[i].valor;
                xY.add(op,i);
            }
        },
        failure: function (response) {
            alert('Não foi possível carregar imagens');
        }
    });

    
}

function cancelar() {
    window.location.href = "../Home.aspx";
}

