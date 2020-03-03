let displayValue;
let displayValue2

let displayOutHtml
    /* Carlos Acevedo*/


function hayUnNegativo() {
    displayOutHtml.value = "";

    var asterisco = "*";
    var linea = "";
    var textoSalida = "";

    for (var i = 25; i > 1; i--) {

        linea = "";
        for (var nAster = 1; nAster < i; nAster++) {
            linea = linea + asterisco
        }
        textoSalida = textoSalida + linea + "<br>";;
    }
    displayOutHtml.innerHTML = textoSalida;
}

function iniciar() {
    displayOutHtml = document.getElementById("salidaTabla");
}