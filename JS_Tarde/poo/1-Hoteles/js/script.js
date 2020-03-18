let displayOutHtml;
let nameInput;
let mailInput;
let dateInput;
let passwordInput;
var textSalida = "";
var hoteles = new Array();


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
    var nombre = nameHotel.value;
    var numeroHabitaciones = numHabitaciones.value;
    var numeroPlantas = numPlantas.value;
    var superficieTotal = supTotal.value;
    let dummyHotel = new Hotel(nombre,numeroHabitaciones,numeroPlantas,superficieTotal);
    hoteles.push(dummyHotel);
}

function pedirUpdate () {

}

function pedirSelect() {
    hoteles.forEach(listarAll);

}
function listarAll(hotel, index) {
    salidaTabla.innerHTML += index + ") "+hotel.nombre+"<br>";
}

function pedirDelete() {

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



}

