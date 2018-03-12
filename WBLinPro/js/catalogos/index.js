$(function () {
    validaSesion();
});

var session

function validaSesion() {
    session = $.cookie("sesion");
    $(".reUser").append(session);
    $("#bienvenido").append('<h5 class="text-center"><b>' + session + '</b></h5>');
}