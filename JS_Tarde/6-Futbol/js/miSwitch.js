var valorSelected = "";

function inicio() {
    mostrarOcultar34(false);
}

function valoracion() {
    var valor1 = document.getElementById("cantidad").value
    var valor2 = document.getElementById("cantidad2").value
    switch (valorSelected) {
        case "Porter":
            //
            break;
        case "Defensa":
            //
            break;
        case "Migcampista":
            //
            break;
        case "Davanter":

    }
}

function mostrarOcultar12(hacemos) {
    var blockNone = (hacemos) ? "block" : "none";
    conceptos.style.display = blockNone;
    conceptos34.style.display = "none";
}

function mostrarOcultar34(hacemos) {
    var blockNone = (hacemos) ? "block" : "none";
    conceptos.style.display = blockNone;
    conceptos34.style.display = blockNone;
}

function selectPuesto(valor) {
    valorSelected = valor;

    var eleOutHtml = document.getElementById("salida");
    var valorContepto = "";
    var valorContepto2 = "";
    document.getElementById("conceptoLb");
    document.getElementById("conceptoLb2");

    switch (valorSelected) {
        case "Porter":
            valorContepto = "Parades";
            mostrarOcultar12(true);
            break;
        case "Defensa":
            valorContepto = "Pilotes robades";
            mostrarOcultar12(true);
            break;
        case "Migcampista":
            valorContepto = "Asissistencies";
            valorContepto2 = "Pelotas robades";
            mostrarOcultar34(true);
            break;
        case "Davanter":
            valorContepto = "Asissistencies";
            valorContepto2 = "Goles";
            mostrarOcultar34(true);
            break;
        default:
            valido = false;
            break;
    }
    conceptoLb.innerHTML = valorContepto;
    conceptoLb2.innerHTML = valorContepto2



}

/*TODO:
Al final de la temporada, un club de fútbol vol saber el valor de mercat dels seus jugadors. En funció d’algunes característiques el valor de mercat pujarà o baixarà.
Primer se li demanarà a l’usuari quina ocupació ocupa el jugador: Porter, defensa, migcampista o davanter.

Si el jugador introduït és porter, el programa demanarà a l’usuari el nombre de parades que ha fet el porter aquesta temporada. Si el porter ha fet més de 150 parades, el programa ha de mostrar per pantalla: El porter ha pujat la seva valoració en 1 milió d’euros. Si el porter ha fet entre 100 i 150 parades, el programa ha de mostrar per pantalla: El porter ha pujat la seva valoració en mig milió d’euros. Si el porter ha fet entre 50 i 99 parades: el programa ha de mostrar per pantalla: El porter segueix amb la mateixa valoració. Si el porter ha fet menys de 50 parades: el programa ha de mostrar per pantalla: El porter ha baixat la seva valoració en 1 milió d’euros.

Si el jugador introduït és defensa, el programa demanarà a l’usuari el nombre de pilotes robades que ha fet el defensa aquesta temporada. Si el defensa ha robat més de 300 pilotes, el programa ha de mostrar per pantalla: El defensa ha pujat la seva valoració en 1 milió d’euros. Si ha robat entre 200 i 300 pilotes, el programa ha de mostrar per pantalla: El defensa ha pujat la seva valoració en mig milió d’euros. Si ha robat entre 100 i 199 pilotes: el programa ha de mostrar per pantalla: El defensa segueix amb la mateixa valoració. Si ha robat menys de 100 pilotes: el programa ha de mostrar per pantalla: El defensa ha baixat la seva valoració en 1 milió d’euros. S’ha de tenir en compte, que si el defensa, ha tingut més de 15 targetes grogues, automàticament, s’ha d’informar a l’usuari, que el preu del defensa ha baixat en 1 milió d’euros.

Si el jugador és migcampista, el programa demanarà a l’usuari el nombre d’assistencies i pilotes robades pel jugador aquesta temporada. Si el migcampista ha robat més de 100 pilotes, i ha donat més de 10 assistències, el programa ha de mostrar per pantalla: El migcampista ha pujat la seva valoració en 1 milió d’euros. Si ha robat entre 50 i 99 pilotes, i ha donat entre 5 i 9 assistències, el programa ha de mostrar per pantalla: El migcampista ha pujat la seva valoració en mig milió d’euros. Si ha robat entre 25 i 49 pilotes i ha donat entre 1 i 4 assistències: el programa ha de mostrar per pantalla: El migcampista segueix amb la mateixa valoració. Si ha robat menys de 25 pilotes i no ha donat cap assistència: el programa ha de mostrar per pantalla: El migcampista ha baixat la seva valoració en 1 milió d’euros.

Si el jugador és un davanter, el programa demanarà a l’usuari el nombre de gols marcats i les assistències donades aquesta temporada. Si el davanter ha fet més de 15 gols i ha donat més de 10 assistències, el programa ha de mostrar per pantalla: El davanter ha pujat la seva valoració en 5 milions d’euros. Si el davanter ha fet entre 10 i 14 gols i ha donat entre 5 i 9 assistències, el programa ha de mostrar per pantalla: El davanter ha pujat la seva valoració en 3 milions d’euros. Si el davanter ha fet entre 5 i 9 gols i ha donat entre 5 i 9 assistències, el programa ha de mostrar per pantalla: El davanter ha pujat la seva valoració en 1 milió d’euros. Si el davanter ha fet menys de 5 gols i ha donat menys de 5 assistències, el programa ha de mostrar per pantalla: El davanter ha baixat la seva valoració en 3 milions d’euros.

 */