var markers = [];
var image = 'images/motorbike24.png';
var myVar = setInterval(MostraMotoboys, 3000);

function MostraMotoboys() {

    var IDcli = document.getElementById('IDCli').value;

    $.ajax({
        type: "POST",
        url: "WebService1.asmx/MotoboysOnLine",
        data: '{param1: "' + IDcli + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            // formata retorno em formato padrão JSON 
            var strRetorno = "{\"counters\": " + response.d + "}";

            // apaga marcadores. 
            deleteMarkers();

            // parse Json
            var jsonData = JSON.parse(strRetorno);
            for (var i = 0; i < jsonData.counters.length; i++) {
                var counter = jsonData.counters[i];
                var cordTemp = new google.maps.LatLng(counter.Latitude, counter.Longitude);
                //exibe  marcador
                addMarker(cordTemp, counter.Nome);
            }

        },
        failure: function (response) {
            alert('Tente Novamente');
        }
    });

}

function addMarker(location, conteudo) {

    // exibe marcador
    var marker = new google.maps.Marker({
        position: location,
        title: conteudo,
        icon: image,
        map: map
    });

    // adiciona marcador em um array (para uso no deleteMarkers)
    markers.push(marker);


    //infwindow 
    var infowindow = new google.maps.InfoWindow({
        content: conteudo
    });
    //infowindow.open(marker.get('map'), marker);

    // aguarda click para exibir infowindow
    marker.addListener('click', function () {
        infowindow.open(marker.get('map'), marker);
    });

}

function deleteMarkers() {
    // apaga marcadores 
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(null);
    }
    markers = [];
}