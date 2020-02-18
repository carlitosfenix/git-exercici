let acumulado = 0;
let media = 0;
let cuenta = 1;

function alIniciar() {


    arrays();

    var numA = 5;
    var numB = 6;
    var suma = numA + numB;

    console.log("1-Variables en js desde script aparte mediante el atributo src");
    var sel = document.getElementById('js1');
    sel.innerHTML = "texto posterior ejecución js, la suma es: " + suma;
    sel.style.color = "blue";

    primeraVariables();

    operadores();

    


}

function arrays()
{
    var miArray = Array();
    var keepdoing = true;
    var posicion = 1;
    while (keepdoing)
    {
        var nota = window.prompt("Entra la nota del alumno " + posicion+":");
        if (nota == "salir") {
            keepdoing = false;
        }
        else
        {
            nota = parseInt(nota, 0);
            if (isNaN(nota)) {
                alert("Por favor, entra una nota valida");
            }
            else
            {
                //Tenemos nota válida
                miArray.push(nota);
                posicion++;
                presentacion(miArray);
            }
        }
    }               
}

function presentacion(arrayNotas) { 
    //prenstamos Media, Max y Min
    
    
    var max, min;
    acumulado = 0;
    cuenta = 1;
    arrayNotas.forEach(functionMedia)
    {
        
    }
    
    arrayNotas.sort((a,b)=>a-b);
    min = arrayNotas[0];
    max = arrayNotas[arrayNotas.length - 1];
    console.log("media: " + media + " min: " + min + " max: " + max);
    var htmlOut = "";
    var mediaHTML = document.getElementById("med");
    var maxHTML = document.getElementById("max");
    var minHTML = document.getElementById("min");

    mediaHTML.innerHTML = htmlOut.concat('<p id="med">', media,'</p>');
    maxHTML.innerHTML =   htmlOut.concat('<p id="max">', max,  '</p>');
    minHTML.innerHTML =   htmlOut.concat('<p id="min">', min,  '</p>');

}


function functionMedia(item, index)
{
    
    acumulado += item;
    media = acumulado / cuenta;
    cuenta++;
 }

function minArray(array)
{
    var min = Math.min(null, array);
    return min;
}

function maxArray(array)
{
    var max = Math.max(null, array);
    return max;
}
  

function operadores() {
    var intOne = 1;
    var intTwo = 2;

    intOne += 3;
    intTwo++;
    console.log("La variable intOne vale: " + intOne++);
    console.log("La variable intOne vale: " + intOne);

}

function primeraVariables() {
    var entero = 23;
    var decimales = 45.5;//sufijo m para tipo decimal
    var doble = 0.5;
    var fechaTiempo = new Date();
    var texto = "ejemplo de texo";
    var caracter = 'u'; //comilla simple
    var siOno = true;
    console.log("Variables tipadas: " + entero + ", " + decimales + ", " + fechaTiempo + ", " + doble + ", " + texto + ", " + caracter + ", " + siOno);
    var sel = document.getElementById('js2');
    sel.innerHTML = "Variables por asignacion siempre en js: " + entero + ", " + decimales + ", " + fechaTiempo + ", " + doble + ", " + texto + ", " + caracter + ", " + siOno;
    sel.style.color = "orange";
    var texto = "Si no es un numero JS devolvera NaN: ";
    var entero = parseInt(texto, 0);
    var sel = document.getElementById('parse');
    sel.innerHTML = "Resultado del parseInt: " + entero;
    sel.style.color = "green";



}
