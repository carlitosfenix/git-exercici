let displayOutHtml;
let nameInput;
let mailInput;
let dateInput;
let passwordInput;
var textSalida = "";
var hoteles = new Array();
var Nombre;


/* Carlos Acevedo*/

function validarFormularioEnSubmit() {
    var salida = "";
    validateTelYCP();
    salida = validarNoEmempty();
    salida = salida + textSalida;
    displayOutHtml.textContent = salida;
}

function iniciar() {
    displayOutHtml = document.getElementById("salidaTabla");
    nameInput = document.getElementById("name");
    secondNameInput = document.getElementById("secondName");
}

function pedirInsert(){
    Nombre = nameHotel.value;
    var numeroHabitaciones = numHabitaciones.value;
    var numeroPlantas = numPlantas.value;
    var superficieTotal = supTotal.value;
    let dummyHotel = new Hotel(Nombre,numeroHabitaciones,numeroPlantas,superficieTotal);
    hoteles.push(dummyHotel);
    pedirSelect();
}

function pedirUpdate () {
    Nombre = nameHotel.value;
    hoteles.forEach(recorrerColeccion);
    pedirSelect();
}

function recorrerColeccion(hotel, index){
   if(hotel.nombre.trim()===Nombre.trim()){
       console.log("son iguales"+Nombre+" y "+hotel.nombre)
       hoteles[index].numeroHabitaciones = numHabitaciones.value;
       hoteles[index].numeroPlantas = numPlantas.value;
       hoteles[index].superficieTotal = supTotal.value;
   }
}

function pedirSelect() {
    salidaTabla.innerHTML =""; //Limpiamos la pantalla antes de imprimir de nuevo
    hoteles.forEach(listarAll);

}
function listarAll(hotel, index) {
    var presupuesto = calcularMantenimentoPRE(index);
    salidaTabla.innerHTML += index + ") "+hotel.nombre+"<br>"+presupuesto+"<br><br>";
}

function pedirDelete() {
    Nombre = nameHotel.value;
    hoteles.forEach(borrarHotel);
    pedirSelect();
}

function borrarHotel(hotel, index){
    if(hotel.nombre.trim() === Nombre.trim()){
        hoteles.splice(index,1);
    }
}


function calcularMantenimentoPRE(index) {
    if(index == null)
        var index = hoteles.length-1;
    return hoteles[index].calcularMantenimento();
}



class Hotel{
    constructor(nombre, numeroHabitaciones, numeroPlantas, superficieTotal){
        this._nombre = nombre;
        this._numeroHabitaciones = numeroHabitaciones;
        this._numeroPlantas = numeroPlantas;
        this._superficieTotal = superficieTotal;
    }

    get nombre(){
        return this._nombre;
    }

    set nombre(nombre){
        this._nombre = nombre;
    }

    get numeroHabitaciones(){
        return this._numeroHabitaciones;
    }

    set numeroHabitaciones (numeroHabitaciones){
        this._numeroHabitaciones=numeroHabitaciones;
    }

    get numeroPlantas(){
       return this._numeroPlantas;
    }

    set numeroPlantas(numeroPlantas){
        this._numeroPlantas = numeroPlantas;
    }

    get superficieTotal(){
        return this._superficieTotal
    }

    set superficieTotal(superficieTotal){
        this._superficieTotal = superficieTotal;
    }

    calcularMantenimento(){
        var personal = this._numeroHabitaciones/20;
        var  importe = personal * 1500;
        console.log("El total de personas necesario des de "+personal+", y el gasto en este concepto es de "+importe+"€/mes");
        return "El total de personas necesario des de "+personal+", y el gasto en este concepto es de "+importe+"€/mes"; 
    }


}

