
$(document).ready(function () {

    var dadosArray = [];
    var dadosArray2 = [];

    dadosArray.push(document.getElementById('Bloco1_Dados').value)
    Graf_Pizza('Bloco1_Chart', dadosArray);

    dadosArray2.push(document.getElementById('Bloco2_Dados').value)
    Graf_Pizza('Bloco2_Chart', dadosArray2);


});

function Graf_Pizza(idBloco, dadosGraf) {
    
    Highcharts.chart(idBloco, {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: ''
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false
                },
                showInLegend: true
            }
        },
        series: [{
            name: 'Total',
            colorByPoint: true,
            data: dadosGraf
        }]
    });

}