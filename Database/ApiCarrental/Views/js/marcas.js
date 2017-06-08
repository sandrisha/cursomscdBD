$(document).ready(function () {

    function GetMarcas() {
        var urlAPI = 'http://localhost:51083/api/marcas';

        $.get(urlAPI, function (respuesta, estado) {

            console.log(respuesta);
            $('#resultados').html('');
            // COMPRUEBO EL ESTADO DE LA LLAMADA
            if (estado === 'success') {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR

                var relleno = '';

                $.each(respuesta.dataMarcas, function (indice, elemento) {

                    relleno = '<ul>';
                    relleno += '    <li>';
                    relleno += elemento.denominacion;
                    relleno += '    </li>';
                    relleno += '</ul>';

                    $('#resultados').append(relleno);
                });
            }
        });
    }

    $('#btnAddMarca').click(function () {
        //debugger;
        var nuevaMarca = $('#txtMarcaDenominacion').val();
        var urlAPI = 'http://localhost:51083/api/marcas';

        var dataNuevaMarca = {
            id: 0,
            denominacion: nuevaMarca
        };
        //debugger;

        $.ajax({
            url: urlAPI,
            type: "POST",
            dataType: 'json',
            data: dataNuevaMarca,
            success: function (respuesta) {
                //debugger;
                console.log(respuesta);
            },
            error: function (respuesta) {
                console.log(respuesta);
            }
        });
    });

    GetMarcas();

});



//FUNCION PARA TIPOS DE COMBUSTIBLES
$(document).ready(function () {

    function GetTipoCombustible() {
        var urlAPI = 'http://localhost:51083/api/Combustibles';

        $.get(urlAPI, function (respuesta, estado) {

            console.log(respuesta);
            $('#resultados').html('');
            // COMPRUEBO EL ESTADO DE LA LLAMADA
            if (estado === 'success') {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR

                var relleno = '';

                $.each(respuesta.dataCombustibles, function (indice, elemento) {

                    relleno = '<ul>';
                    relleno += '    <li>';
                    relleno += elemento.denominacion;
                    relleno += '    </li>';
                    relleno += '</ul>';

                    $('#resultados').append(relleno);
                });
            }
        });
    }

    $('#btnAddCombustible').click(function () {
        //debugger;
        var nuevoTipoCombustible = $('#txtCombustibleDenominacion').val();
        var urlAPI = 'http://localhost:51083/api/Combustibles';

        var dataNuevoTipoCombustible = {
            id: 0,
            denominacion: nuevoTipoCombustible
        };
        //debugger;

        $.ajax({
            url: urlAPI,
            type: "POST",
            dataType: 'json',
            data: dataNuevoTipoCombustible,
            success: function (respuesta) {
                //debugger;
                console.log(respuesta);
            },
            error: function (respuesta) {
                console.log(respuesta);
            }
        });
    });

    GetTipoCombustible();

});
