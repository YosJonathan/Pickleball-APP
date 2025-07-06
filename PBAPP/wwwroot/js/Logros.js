var token = $('input[name="__RequestVerificationToken"]').val();
$('#logros').click(function () {
    $.ajax({
        url: rutaLogros,
        type: 'POST',
        data: {
            __RequestVerificationToken: token
        },
        success: function (respuesta) {
            alert(respuesta.partidos);
        },
        error: function (xhr, status, error) {
            console.error('Error en la petición:', error);
        }
    });
});