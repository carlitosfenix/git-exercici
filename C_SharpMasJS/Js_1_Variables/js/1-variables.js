function alIniciar (){
    var numA = 5;
    var numB = 6;
    var suma = numA + numB;

console.log("1-Variables en js desde script aparte mediante el atributo src");
var sel = document.getElementById('js1');
sel.innerHTML= "texto posterior ejecución js, la suma es: "+suma;
sel.style.color ="blue";

primeraVariables ();

operadores();


}

function operadores (){
    var intOne = 1;
    var intTwo = 2;
    
    intOne += 3;
    intTwo++;
    console.log("La variable intOne vale: " + intOne++);
    console.log("La variable intOne vale: " + intOne);

}

function primeraVariables(){
    var entero = 23;
    var decimales = 45.5;//sufijo m para tipo decimal
    var doble=0.5;
    var fechaTiempo = new Date();
    var texto = "ejemplo de texo"; 
    var caracter = 'u'; //comilla simple
    var siOno = true;
    console.log("Variables tipadas: "+entero+", "+decimales+", "+fechaTiempo+", "+doble+", "+texto+", "+caracter+", "+siOno );
    var sel = document.getElementById('js2');
    sel.innerHTML= "Variables por asignacion siempre en js: "+entero+", "+decimales+", "+fechaTiempo+", "+doble+", "+texto+", "+caracter+", "+siOno ;
    sel.style.color ="orange";
    var texto = "Si no es un numero JS devolvera NaN: ";
    var entero = parseInt(texto,0);
    var sel = document.getElementById('parse');
    sel.innerHTML= "Resultado del parseInt: "+entero;
    sel.style.color ="green";
    


}
