$('document').ready(function () {

    isPaused = false;

    $('.pause, .play').on('click', function () {
        $('.play, .pause').toggle();
        isPaused = !isPaused;
    });

    $('.cancel').on('click', function () {

        // Libera campos
        $('form input, form select, form button').attr('disabled', false);
        $('.play, .pause').toggle();
        isPaused = false;

        //Limpa contagem
        clearInterval(delay);

        // Limpa display
        $("div.panel-footer").html('');
    });

    $('#programa').on('change', function () {
        var tempo = $('#programa option:selected').data('tempo');
        var potencia = $('#programa option:selected').data('potencia');
        var caracter = $('#programa option:selected').data('caracter');

        $('#caracter').val(caracter);

        if ($(this).val() != "default") {
            $('#tempo').val(tempo).attr('readonly', true);
            $('#potencia').val(potencia).attr('readonly', true);
        } else {
            $('#tempo').val(tempo).attr('readonly', false);
            $('#potencia').val(potencia).attr('readonly', false);
        }
    });

    $('#btn-aquecimento-rapido').on('click', function () {
        $('#programa').val('default');
        $('#programa').trigger('change');

        $('#tempo').attr('readonly', true);
        $('#potencia').attr('readonly', true);
    });

    $('form').on('submit', function (evt) {
        evt.preventDefault();

        var programaObj = {
            nome: $('#programa').val(),
            potencia: $('#potencia').val(),
            tempo: $('#tempo').val(),
            instrucao: 'Instruction',
            caracter: $('#caracter').val()
        }

        $.ajax({
            url: '/Home/Executar',
            type: 'POST',
            dataType: 'JSON',
            data: {
                programa: programaObj,
                alimento: $('#alimento').val()
            },
            success: function (response) {
                console.log(response);
                if (response.success) {
                    $('div.panel-footer').html("");
                    $('form input, form select, #btn-aquecimento-rapido, #btn-aquecer').attr('disabled', true);

                    $('.pause').show();
                    $('.play').hide();
                    isPaused = false;

                    Aquecer();

                } else {
                    $('div.panel-footer').html('<div class="alert alert-danger";><button class="close" data-dismiss="alert" aria-hidden="true">' +
                        '&times;</button >' + response.result + '</div >');
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

});

function Aquecer() {

    var alimento = $('#alimento').val();
    var tempo = $('#tempo').val();
    tempo *= 1000; // Converte para milisegundos
    var potencia = $('#potencia').val();
    var caracter = $("#caracter").val();
    var stringAquecida = alimento;

    delay = setInterval(function () {
        if (!isPaused) {
            stringAquecida += getCaracter(caracter, potencia);
            $('div.panel-footer').html('<div style="word-break: break-word";>' + stringAquecida + '</div>');
        }
    }, 1000);

    setTimeout(function () {
        clearInterval(delay);
        $('div.panel-footer').html('<div class="alert alert-success" style="word-break: break-word";><button class="close" data-dismiss="alert" aria-hidden="true">' +
            '&times;</button > Aquecimento finalizado: <b>' + stringAquecida + '</b></div >');
        $('form input, form select, form button').attr('disabled', false);
    }, tempo);
}

function getCaracter(caracter, potencia) {
    caracterMontado = '';
    for (var i = 1; i <= potencia; i++) {
        caracterMontado += caracter;
    }
    return caracterMontado;
}