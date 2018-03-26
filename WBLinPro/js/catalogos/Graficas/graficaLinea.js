$(function () {
    $("#tabla").hide();
    $('#FechaInicio').datetimepicker({
        format: 'YYYY/MM/DD',
        //  locale: 'es',
        minDate: '+2017/01/01',
        maxDate: 'now'
    });

    $('#dtTable').DataTable({
        dom: 'Bfrtip',
        buttons: [
           'excel', 'pdf'
        ]
    });

    initGraficaLineas();
});

// *****
// Init DataTable
// Cosulta a la base y crea dinamicamente
// la tabla con registros obtenidos.
// *****


$('#FechaInicio').on('dp.change', function (e) {
    $('#FechaFin').empty();
    // document.getElementById("FechaFin").resetForm();
    //   .disabled = false;
    var fechaFin = '';
    e = $('#FechaInicio').val();
    fechaFin = String(e);
    console.log(e);

    $('#FechaFin').datetimepicker({
        format: 'YYYY/MM/DD',
        //locale: 'es',
        minDate: '+' + fechaFin,
        maxDate: '2018/12/31'
    });
});


function initGraficaLineas() {
    var datos = [];
    $('#FormReporte').show();

    $('#btnbuscar').click(function () {

        $('#detalleEnergia').empty();
        var idTabla = 1;
        var valido;
        var chartData = [];
        valido = validateForm();
        var fechaInicio = $('#FechaInicio').val();
        var fechaFin = $('#FechaFin').val();

        if (valido) {

            $.ajax({
                async: false,
                type: 'POST',
                url: 'WSLinPro.asmx/GraficaProyeccion',
                dataType: 'json',
                data: "{'fechaInicio':'" + fechaInicio + "','fechaFin':'" + fechaFin + "'}",
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    $.each(data, function (index, item) {
                        $.each(item.ListaRegistros, function (index1, item1) {
                            //console.log(item1.fechas + '----------' + item1.Porcentaje)
                            chartData.push({
                                name: item1.FechaCorta,
                                name2: item1.fechas,
                                value: item1.Porcentaje
                            });

                            datos.push([idTabla, item1.Porcentaje, item1.FechaCorta]);
                            idTabla++;

                        });

                        console.log(datos);

                        if (chartData.length == 0) {
                            showWarningMessage('Advertencia', 'No existen datos con los valores ingresados.');
                        } else {
                            showOkMessage('Información', 'Se mostrará una tabla y gráfia con los detalles.');
                        }
                    });

                }
            });

            var chart = AmCharts.makeChart("chartdiv", {
                "type": "serial",
                // "type": "areaspline",
                "theme": "light",
                "marginTop": 0,
                "marginRight": 80,
                "dataProvider": chartData,
                "valueAxes": [{
                    "axisAlpha": 0,
                    "position": "left"
                }],
                "graphs": [{
                    "id": "g1",
                    "balloonText": "[[category]]<br><b><span style='font-size:14px;'>[[value]] % OEE</span></b>",
                    "bullet": "round",
                    "bulletSize": 8,
                    "lineColor": "#d1655d",
                    "lineThickness": 2,
                    "negativeLineColor": "#637bb6",
                    "type": "smoothedLine",
                    "valueField": "value"
                }],
                "chartScrollbar": {
                    "graph": "g1",
                    "gridAlpha": 0,
                    "color": "#888888",
                    "scrollbarHeight": 55,
                    "backgroundAlpha": 0,
                    "selectedBackgroundAlpha": 0.1,
                    "selectedBackgroundColor": "#888888",
                    "graphFillAlpha": 0,
                    "autoGridCount": true,
                    "selectedGraphFillAlpha": 0,
                    "graphLineAlpha": 0.2,
                    "graphLineColor": "#c2c2c2",
                    "selectedGraphLineColor": "#888888",
                    "selectedGraphLineAlpha": 1

                },
                "chartCursor": {
                    //  "categoryBalloonDateFormat": "YYYY",
                    "cursorAlpha": 0,
                    "valueLineEnabled": true,
                    "valueLineBalloonEnabled": true,
                    "valueLineAlpha": 0.5,
                    "fullWidth": true
                },
                // "dataDateFormat": "YYYY",
                "categoryField": "name",
                "export": {
                    "enabled": false
                }
            });

            chart.addListener("rendered", zoomChart);
            if (chart.zoomChart) {
                chart.zoomChart();
            }
            function zoomChart() {
                chart.zoomToIndexes(Math.round(chart.dataProvider.length * 0.4), Math.round(chart.dataProvider.length * 0.55));
            }
            $('#FormParametros').data('bootstrapValidator').resetForm();
        } else {
            $('#FormParametros').show();
        }

        table = $('#dtTable').DataTable({
            "aLengthMenu": [
                [5, 10, 25, 50],
                [5, 10, 25, 50]
            ],
            "oLanguage": {
                "sUrl": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
            },
            data: datos,
            columns: [
                {
                    title: "#"
                },
                {
                    title: "Porcentaje"
                }, {
                    title: "Periodo"
                }
            ]
        });
        table.clear();
        table.rows.add(datos);
        table.draw();
        $("#tabla").fadeIn();
    });
}


// Validación formulario
function validateForm() {
    $("#FormParametros").bootstrapValidator({
        excluded: [':disabled'],
        live: 'enabled',
        submitButtons: 'button[id="btnbuscar"]',
        valid: 'glyphicon glyphicon-ok',
        invalid: 'glyphicon glyphicon-remove',
        fields: {
            FechaInicio: {
                selector: '#FechaInicio',
                group: '.form-group',
                validators: {
                    notEmpty: {
                        message: 'Debe ingresar una fecha de Inicio'
                    }
                }
            },
            FechaFin: {
                selector: '#FechaFin',
                group: '.form-group',
                validators: {
                    notEmpty: {
                        message: 'Debe ingresar una fecha final'
                    }
                }
            }
        }
    });

    $('#FormParametros').data('bootstrapValidator').validate();
    var valido = $('#FormParametros').data('bootstrapValidator').isValid();
    return valido;
}


