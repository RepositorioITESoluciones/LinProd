$(function () {
    init();
    console.log('Start Login');
});

function init() {
    bootsVal();
    $('#btnValida').click(function () {
        bootsVal();
        $('#form_login').data('bootstrapValidator').validate();
        var n = $('#form_login').data('bootstrapValidator').isValid();
        if (n) {
            var $this = $(this);
            $this.button('loading');
            setTimeout(function () {
                $this.button('reset');
                acceder();
            }, 1000);
            
        } else {
            bootsVal();
        }
    });
}

/* Validación form */
function bootsVal() {
    $("#form_login").bootstrapValidator({
        live: 'enabled',
        submitButtons: 'button[id="btnValida"]',
        message: 'Valor invalido',
        fields: {
            usuario: {
                selector: '#usuario',
                group: '.validate',
                validators: {
                    notEmpty: {
                        message: 'Campo usuario obligatorio'
                    }
                }
            },
            pass: {
                selector: '#pass',
                group: '.validate',
                validators: {
                    notEmpty: {
                        message: 'Campo contraseña obligatorio'
                    },
                    stringLength: {
                        min: 8,
                        message: 'Contraseña minima de 8 digitos'
                    }
                }
            }
        }
    })
}

/* Validación de campos */
function validarCampo(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8)
        return true;
    patron = /^[a-zA-Z]+$/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

/* Ajax Login */
function acceder() {
    var arr = [];
    $.ajax({
        async: false,
        type: 'POST',
        dataType: "text",
        url: 'WSLinPro.asmx/AccesoDatos',
        data: {
            usuario: $("#usuario").val(),
            contrasena: $("#pass").val()
        },
        success: function (data) {
            var resultadoXML = data.substring(76, data.indexOf('</string>'));

            if (resultadoXML == "Error") {
                showErrorMessage("dsadsa", "Error: Usuario o contraseña incorrecta.");
            } else {
                var variableUsuario = resultadoXML;
                $.cookie('sesion', variableUsuario);
                console.log($.cookie('sesion'));
                window.location.href = "Index.html#welcome.html";
            }

        }
    });
}

window.onload = function () {
    var usuario = document.getElementById('usuario');
    usuario.onpaste = function (e) {
        e.preventDefault();
    }

    var pass = document.getElementById('pass');
    pass.onpaste = function (e) {
        e.preventDefault();
    }
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
        icon: "fa fa-exclamation-circle swing animated"
    });
}