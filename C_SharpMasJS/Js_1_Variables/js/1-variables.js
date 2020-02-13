function alIniciar (){
    var numA = 5;
    var numB = 6;
    var suma = numA + numB;

console.log("1-Variables en js desde script aparte mediante el atributo src");
var sel = document.getElementById('js1');
sel.innerHTML= "texto posterior ejecución js, la suma es: "+suma;
sel.style.color ="blue";



}
