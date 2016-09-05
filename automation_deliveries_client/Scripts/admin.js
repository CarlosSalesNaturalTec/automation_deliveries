// DIGICLOCK
(function () {
	var clock = document.querySelector('digiclock');
	
	var pad = function(x) {
		return x < 10 ? '0'+x : x;
	};
	
	var ticktock = function() {
		var d = new Date();
		
		var h = pad( d.getHours() );
		var m = pad( d.getMinutes() );
		var s = pad( d.getSeconds() );
		
		var current_time = [h,m,s].join(':');
		
		clock.innerHTML = current_time;
		
	};
	
	ticktock();
	
	// Calling ticktock() every 1 second
	setInterval(ticktock, 1000);
	
}());


/* ---------- Notifications ---------- */
	$('.noty').click(function(e){
		e.preventDefault();
		var options = $.parseJSON($(this).attr('data-noty-options'));
		noty(options);
	});


    /* ---------- ENTREGAS EFETUADAS  ---------- */
	$(function () {
	    $('#container_painel1').highcharts({
	        chart: {
	            renderTo: 'load',
	            margin: [0, 0, 0, 0],
	            backgroundColor: null,
	            plotBackgroundColor: 'none'
	        },

	        title: {
	            text: null
	        },

	        tooltip: {
	            formatter: function () {
	                return this.point.name + ': ' + this.y + ' %';

	            }
	        },
	        series: [
				{
				    borderWidth: 2,
				    borderColor: '#F1F3EB',
				    shadow: false,
				    type: 'pie',
				    name: 'Income',
				    innerSize: '65%',
				    data: [
                        { name: 'Total de Encomendas Entregues', y: 45.0, color: '#fa1d2d' },
                        { name: 'A Entregar', y: 55.0, color: '#3d3d3d' }
				    ],
				    dataLabels: {
				        enabled: false,
				        color: '#000000',
				        connectorColor: '#000000'
				    }
	        }]
	    });
	});

	/* ---------- FUNCIONÁRIOS EM CAMPO  ---------- */
	$(function () {
	    $('#container_painel2').highcharts({
	        chart: {
	            renderTo: 'load',
	            margin: [0, 0, 0, 0],
	            backgroundColor: null,
	            plotBackgroundColor: 'none',

	        },

	        title: {
	            text: null
	        },

	        tooltip: {
	            formatter: function () {
	                return this.point.name + ': ' + this.y + ' %';

	            }
	        },
	        series: [
				{
				    borderWidth: 2,
				    borderColor: '#F1F3EB',
				    shadow: false,
				    type: 'pie',
				    name: 'Income',
				    innerSize: '65%',
				    data: [
                        { name: 'Funcionarios em campo', y: 80.0, color: '#b2c831' },
                        { name: 'Faltantes', y: 20.0, color: '#3d3d3d' }
				    ],
				    dataLabels: {
				        enabled: false,
				        color: '#000000',
				        connectorColor: '#000000'
				    }
				}]
	    });
	});

    /* ---------- ENTREGAS NO PERÍODO ---------- */
	$(function () {
	    $('#container_painel3').highcharts({
	        chart: {
	            type: 'column',
	            backgroundColor: null,
	            plotBackgroundColor: 'none'
	        },
	        title: {
	            text: null
	        },
	        xAxis: {
	            categories: ['20/08', '21/08', '22/08', '23/08', '24/08']
	        },
	        yAxis: {
	            min: 0,
	            title: {
	                text: 'Total de Entregas'
	            }
	        },
	        tooltip: {
	            pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>',
	            shared: true
	        },
	        plotOptions: {
	            column: {
	                stacking: 'percent'
	            }
	        },
	        series: [
                {
                    name: 'Nao Entregues',
                    data: [2, 2, 3, 2, 1],
                    color: '#b2c831'
                },
                {
	            name: 'Entregues',
	            data: [15, 13, 14, 17, 15]
	        }]
	    });
	});

