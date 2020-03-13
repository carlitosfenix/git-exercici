/* Carlos Acevedo*/
let displayOutHtml;
let displayOutHtmlTiempo;

function calcular() {
    var numEsPrimo = parseInt(display.value);
    var msgSalida = "Los numeros primos hasta: " + numEsPrimo + ", son o es: ";
    var resultado = ""
    var timeInicio = Date.now();
    var timeEmpleado;
   

    var esDivisible = false;
    for (var numEvaluar = 3; numEvaluar < numEsPrimo; numEvaluar++) {
        var divisor = 2;
        do {
            if (numEvaluar % divisor == 0) {
                esDivisible = true;
            }
            divisor++;

        } while (esDivisible == false && divisor < numEvaluar);

        if (!esDivisible) {
            resultado += numEvaluar + ", ";
        }
        esDivisible = false;
    }
    timeEmpleado = Date.now() - timeInicio;

    displayOutHtmlTiempo.innerHTML = timeEmpleado + " ms"
    displayOutHtml.innerHTML = msgSalida +  "2, "+ resultado;
}


function iniciar() {
    displayOutHtml = document.getElementById("salida");
    displayOutHtmlTiempo = document.getElementById("tiempoEmpleado");
}