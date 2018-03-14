$(function () {
    validaSesion();
});

var session

function validaSesion() {
    session = $.cookie("sesion");
    $(".reUser").append(session);
    $("#bienvenido").append('<h5 class="text-center"><b>' + session + '</b></h5>');
}

/**
 * Función que muestra el mensaje de correcto
 * @param titulo
 * @param mensaje
 * @returns
 */
function showOkMessage(titulo, mensaje) {
    $.smallBox({
        title: titulo,
        content: mensaje,
        color: "#296191",
        timeout: 4000,
        icon: "fa fa-check swing animated"
    });
}

/**
 * Función que muestra el mensaje de error
 * @param titulo
 * @param mensaje
 * @returns
 */
function showErrorMessage(titulo, mensaje) {
    $.smallBox({
        title: titulo,
        content: mensaje,
        color: "#a90329",
        timeout: 4000,
        icon: "fa fa-times-circle swing animated"
    });
}

/**
 * Función que muestra el mensaje de precaución
 * @param titulo
 * @param mensaje
 * @returns
 */
function showWarningMessage(titulo, mensaje) {
    $.smallBox({
        title: titulo,
        content: mensaje,
        color: "#C79121",
        timeout: 4000,
        icon: "fa fa-warning swing animated"
    });
}