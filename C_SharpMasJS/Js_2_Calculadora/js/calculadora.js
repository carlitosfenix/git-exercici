var numeroAHtml = Object;
var numeroBHtml;
var htmlSalida;
var textoSalida;

function inicio()
{

    numeroAHtml = document.getElementById("txtNum1");
    numeroBHtml = document.getElementById("txtNum2");
    htmlSalida = document.getElementById("salida");
    textoSalida = "";
    
}
 
function suma()
{
    let numeroA = numeroAHtml.value;
    let numeroB = numeroBHtml.value;
    //Dos formas de convertir tipo
    let numberSum = parseInt(numeroA) + (numeroB * 1);
    htmlSalida.innerHTML = textoSalida +"La suma da: " + numberSum ;

}

function resta()
{
    let numeroA = numeroAHtml.value;
    let numeroB = numeroBHtml.value;

    //Dos formas de convertir tipo
    let numberSum = parseInt(numeroA) - (numeroB * 1);
    htmlSalida.innerHTML = textoSalida +"La suma da: " + numberSum ;

}

function producto()
{
    let numeroA = numeroAHtml.value;
    let numeroB = numeroBHtml.value;

    //Dos formas de convertir tipo
    let numberSum = parseInt(numeroA) * (numeroB * 1);
    htmlSalida.innerHTML = textoSalida +"La suma da: " + numberSum ;

}

function division()
{
    let numeroA = numeroAHtml.value;
    let numeroB = numeroBHtml.value;

    //Dos formas de convertir tipo
    let numberSum = parseInt(numeroA) / (numeroB * 1);
    htmlSalida.innerHTML = textoSalida +"La suma da: " + numberSum ;

}