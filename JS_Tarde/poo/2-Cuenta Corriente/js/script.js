var displayOutHtml;

var textSalida = "";
var arrayCuentas = new Array();
var Titular;
var NumCC;
var Alta = false;


/* Carlos Acevedo*/

function iniciar() {
    displayOutHtml = document.getElementById("salidaTabla");
}


function altaCC(){
    Alta = true;
    Titular = ccTitular.value;
    NumeroCC = numCC.value;
    let importeTran = importe.value;
   
    if(Titular && NumeroCC && !isInSystem()){
        let dummyCC = new Cuenta(Titular,NumeroCC);
        arrayCuentas.push(dummyCC);
        alert("Alta correcta de la cuenta");
        listTransacciones();
    }   
}


function ingresoCC(){
    let cuenta = isInSystem();
    if(cuenta){
        cuenta.transaccion(importe.value);
        listTransacciones();
    }
}
/**
 * En la retirada convertimos el importe en negativo
 */
function retiradaCC(){
    let cuenta = isInSystem();
    if(cuenta){
        cuenta.transaccion(importe.value * -1);
        listTransacciones();
    }
}
/**
 * Dejar cuenta a 0 como la mia
 */
function retirarCcTOT(){
    let cuenta = isInSystem();
    if(cuenta){
        let saldo =cuenta.saldo;
        cuenta.transaccion(saldo*-1);
        alert("Has limpiado la cuenta, Felicidades!!!!");
        listTransacciones();
    }
}
/**
 * Mostrar los datos básicos del Titulasr, NCC y saldo
 */
function listarDatosCC(){
    let cuenta = isInSystem();
    if(cuenta){
        var resumen = cuenta.listarDatosCuenta();
         //Limpiamos la pantalla antes de imprimir de nuevo
        salidaTabla.innerHTML =""; 
        salidaTabla.innerHTML = resumen;
    }
}



/**
 * Método encargado de listar todas las transacciones de un Titular y un Num CC concreto
 */
function listTransacciones() {
    //Limpiamos la pantalla antes de imprimir de nuevo
    salidaTabla.innerHTML =""; 
    arrayCuentas.forEach(listarAll);
}
function listarAll(cuenta, index) {
    let saldo = 0;
    let salida= "";
    if(cuenta.titular.trim()===ccTitular.value.trim() &&
    cuenta.numCC.trim()===numCC.value.trim()){
       salida = index + ") "+ cuenta.titular + "<br>" + "Num CC: " + cuenta.numCC + "<br><br>";
    
        for(let pos = 0 ; pos <cuenta.arrayTransacciones.length; pos++){
            salida += "Transacción n: "+ pos + " cantidad: " + cuenta.arrayTransacciones[pos]+ "<br>";
        }

        salidaTabla.innerHTML = salida + "<br>" + "Saldo: " + cuenta.saldo ;
    }   
}


/**
 * Método que nos devuelve una cuenta si existe o avisa con un alert en caso contrario
 * @returns cuenta si existe Titular y NumCC
 */
function isInSystem(){
    let existe =false;
    arrayCuentas.forEach(function(cuenta, index){
        if(cuenta.titular.trim()===ccTitular.value.trim() &&
            cuenta.numCC.trim()===numCC.value.trim()){
            if(Alta){
                 alert ("Ya existe una CC: "+cuenta.numCC+" para el titular: "+ cuenta.titular);
            }
            existe =cuenta;
        }
    });
    if (!Alta && !existe){
        alert ("No existe una CC: "+numCC.value+" para el titular: "+ ccTitular.value);
        clienteTieneOtraCuenta(ccTitular.value.trim());
    }
    Alta = false;
    
    return existe;
}


function clienteTieneOtraCuenta(titularNom){
    let mensaje="";
    for (let pos=0; pos < arrayCuentas.length; pos++){
        if(arrayCuentas[pos].titular.trim() == titularNom){
            mensaje +="Num CC: " +  arrayCuentas[pos].numCC + "<br>";
        }
    }
    if(mensaje){
        salidaTabla.innerHTML ="Usted" + titularNom + " tiene esta/s cuenta/s: <br><br>" + mensaje;
    }
}


class Cuenta{
    /**
     * Cuando creamos una nueva cuenta, el banco, que es muy majo, nos regala 50€ !!!!!
     * @param {*} titular 
     * @param {*} numCC 
     */
    constructor(titular, numCC){
        this._titular = titular;
        this._numCC = numCC;
        this._saldo = 50.0;
        this._numTransaccion=0;
        this._arrayTransacciones = [];
        this._arrayTransacciones[this._numTransaccion] = this._saldo;
    }

    get titular(){
        return this._titular;
    } 
   
    get numCC(){
        return this._numCC;
    }
  
    
    /**
     * 
     * @param {*} importe Si es positiva es una imposición.
     *  Si es negativa una retirada
     */
    transaccion(importe){
        this._arrayTransacciones.push(parseFloat(importe));  
    }

    get saldo(){
        this._saldo = 0;
        for (let posi=0; posi <this._arrayTransacciones.length; posi++){
            this._saldo +=this._arrayTransacciones[posi];
        }
        return this._saldo;
    }
    
    get arrayTransacciones(){
        return this._arrayTransacciones;
    }

    listarDatosCuenta(){
        return "Titular: " + this.titular + "<br> Num CC: " + this.numCC + "<br> Con un saldo = " + this.saldo;
    }

}



