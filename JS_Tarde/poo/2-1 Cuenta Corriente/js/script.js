var displayOutHtml;
/* Carlos Acevedo*/
var textSalida = "";
var arrayClientes = new Array();
var Titular;
var NumCC;
var Alta = false;
var IndexClienteSeleccionado;
var ClienteSeleccionado;
var CuentaSeleccionada;



/**
 * Método llamado desde el body en onload
 * Ahora mismo no es necesario pero va bien
 * recordar que contamos con ello.
 */
function iniciar() {
    displayOutHtml = document.getElementById("salidaTabla");
}

//#region clientes

function crearCliente(){
    Alta = true;
    Titular = ccTitular.value;
   
    if(Titular && !isClienteInSystem()){
        let dummyCliente = new Cliente(Titular);
        arrayClientes.push(dummyCliente);
        alert("Alta correcta de Cliente y cuenta inicial 666");
        agregarUnClienteASelect(dummyCliente);
        ccTitular.value ="";
    
    }   
}

function agregarUnClienteASelect(dummyClient){
    document.getElementById("cuandoclientes").style.display = "block";
    let clienteSelect = document.getElementById("listClientes");
   
    let fragment = document.createDocumentFragment();
    
        let opt = document.createElement("option");
        opt.innerHTML = dummyClient.titular;
        opt.value = dummyClient.titular;
        fragment.appendChild(opt);
    
    
    clienteSelect.appendChild(fragment);
}

function borrarCliente (){
    var seleccionado = document.getElementById("listClientes").selectedIndex;
   if (seleccionado==0){
       alert("Se bede seleccionar un cliente para proceder con su baja");
    }else{
        arrayClientes.splice(seleccionado-1,1);
        limpiarSelectYLlemnar();
    }
}

function listarTodosLosClientes(){
    let salida = "";
    if(arrayClientes.length>0){

        for(let pos=0; pos < arrayClientes.length ; pos++ ){
            salida += arrayClientes[pos].listarDatosCliente();
        }
        salidaTabla.innerHTML =""; 
        salidaTabla.innerHTML = salida;


    }else{
        alert("Tómate un cefelito y primero entra algún cliente:");
    }

}
 

  function limpiarSelectYLlemnar(){
    document.getElementById("cuandoclientes").style.display = "block";
    let clienteSelect = document.getElementById("listClientes");

    var length = clienteSelect.options.length;
        for (i = length-1; i >= 1; i--) {
            clienteSelect.options[i] = null;
        }
   
    let fragment = document.createDocumentFragment();
    arrayClientes.forEach(function(cliente,index){
        let opt = document.createElement("option");
        opt.innerHTML = cliente.titular;
        opt.value = cliente.titular;
        fragment.appendChild(opt);
    });
    
    clienteSelect.appendChild(fragment);
}
    
function seleccionCliente(){
    IndexClienteSeleccionado = document.getElementById("listClientes").selectedIndex;
    ClienteSeleccionado = arrayClientes[IndexClienteSeleccionado-1];
}

// Fin clientes

 /**
   * Aquí conmutamnos a GETION DE CLIENTES 
   * 
   * o
   * 
   *  A un cliente en concreto apara trabajar con sus cuentas
   *  
   */
  function visibleNoVisible(){

    if(ClienteSeleccionado){
        salidaTabla.innerHTML =""; 
  
        let btnsCliente = document.getElementById("btnsCliente");
        let btnsCuenta = document.getElementById("btnsCuenta");
        let inputsCuenta = document.getElementById("clienteCuenta");
        let inputCliente = document.getElementById("introClientes");
        let btnToggle = document.getElementById("trabajarCuentas");

        if(btnsCuenta.style.display === "none"){
            btnsCliente.style.display = "none";
            inputCliente.style.display = "none";
            btnsCuenta.style.display = "block"
            inputsCuenta.style.display ="block";
            btnToggle.innerText ="Trabajar con Getión de Clientes"
        }else{
            btnsCliente.style.display = "block";
            inputCliente.style.display = "block";
            btnsCuenta.style.display = "none";
            inputsCuenta.style.display ="none";
            btnToggle.innerHTML ="Trabajar con Cuetas de un Cliente"

        }
    }else{
        alert ("Seleccione un cliente antes, muchas gracias!!")
    }
    
  }

// Inicio Cuentas Corrientes


function altaCC(){
    let todoOK = false;
    NumeroCC = numCC.value;
   
    if(NumeroCC){
        let dummyCuenta = new Cuenta(ClienteSeleccionado.titular,NumeroCC);
        let yaEstaba =ClienteSeleccionado.addCuenta(dummyCuenta);
        if (yaEstaba){
            alert("Este cliente ya tiene este número de cuenta");
        }else{
            alert("Alta correcta cuenta: para cliente: ");

        }
        listTransacciones();
    }else{
        alert("Por favor, toma un café e indica el número de cuenta: ");
    }  
}



function ingresoCC(){
    CuentaSeleccionada = ClienteSeleccionado.getCuenta(numCC.value);
    if(CuentaSeleccionada && importe.value>0){
        CuentaSeleccionada.transaccion(importe.value);
        importe.value=0;
        listTransacciones();
    }else{
        alert("Por favor, toma un café e indica un importe superor a 0 o crea la cuenta: ");
    }
}
/**
 * En la retirada convertimos el importe en negativo
 */
function retiradaCC(){
    CuentaSeleccionada = ClienteSeleccionado.getCuenta(numCC.value);
    if(CuentaSeleccionada && importe.value>0){
        CuentaSeleccionada.transaccion(importe.value * -1);
        importe.value=0;
        listTransacciones();
    }else{
        alert("Por favor, toma un café e indica un importe superor a 0 o crea la cuenta: ");
    }
    if(CuentaSeleccionada.saldo < 0){
        alert ("TIENES 48 HORAS PARA REGULARIZAR TU SITUACIÓN (POR SER AUTONOMO CON SIEMPRE CUBIERTO) ");
    }
}
/**
 * Dejar cuenta a 0 como la mia
 */
function retirarCcTOT(){
    CuentaSeleccionada = ClienteSeleccionado.getCuenta(numCC.value);
    let saldo =CuentaSeleccionada.saldo;
    if(CuentaSeleccionada && saldo > 0){
        CuentaSeleccionada.transaccion(saldo*-1);
        alert("Has limpiado la cuenta, Felicidades!!!!");
        listTransacciones();
    }else{
        alert("LA CUENTA NO SE PUEDE CERRAR POR ESTAR EN NUMEROS ROJOS. TIENES 48 HORAS PARA REGULARIZAR TU SITUACIÓN (CON SIEMPRE CUBIERTO) ");
    }
}
/**
 * Mostrar los datos básicos del Titulasr, NCC y saldo
 */
function listarDatosCC(){
    CuentaSeleccionada = ClienteSeleccionado.getCuenta(numCC.value);
    if(CuentaSeleccionada){
        var resumen = CuentaSeleccionada.listarDatosCuenta();
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
    let salida = "";
   
    salidaTabla.innerHTML =""; 
    CuentaSeleccionada = ClienteSeleccionado.getCuenta(numCC.value);
    
    salida =  "Num CC: " + CuentaSeleccionada.numCC+ ") "+ CuentaSeleccionada.titular + "<br>" +  "<br><br>";
    for(let pos = 0 ; pos <CuentaSeleccionada.arrayTransacciones.length; pos++){
        salida += "Transacción n: "+ pos + " cantidad: " + CuentaSeleccionada.arrayTransacciones[pos]+ "<br>";
    }
    salidaTabla.innerHTML = salida + "<br>" + "Saldo: " + CuentaSeleccionada.saldo ;
    
}   

/**
 * Método que nos devuelve un cliente si existe y avisa con un alert, en caso contrario devuelve un false
 * @returns cuenta si existe Titular y NumCC
 */
function isClienteInSystem(){
    let existe =false;
    arrayClientes.forEach(function(cliente,index){
        if(ccTitular.value.trim()===cliente.titular){
            if(Alta){
                alert ("Ya existe el cliente " + cliente.titular + " en el sistema");
           }
           existe =cliente;

        }

    });
    return existe;
}

function listarTodasCCCliente(){
    salidaTabla.innerHTML =""; 
    let salida = ClienteSeleccionado.listarDatosCliente();
    salidaTabla.innerHTML = salida;
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


//Fin cuentas corrientes

//Inicio Clases


class Cliente{
    /**
     * Primero crearemos a los clientes con una cuenta de bienvenida, cuenta 0
     * @param {*} titular 
     * 
     */
    constructor(titular){
        this._titular = titular;
        this._arrayCuentas = [];
        this._arrayCuentas[0] = new Cuenta (titular,666);
    }

    get titular(){
        return this._titular;
    }
    
    get arrayCuentas(){
        return this._arrayCuentas;
    }

    /**
     * 
     * @param {*} importe Si es positiva es una imposición.
     *  Si es negativa una retirada
     */
    addCuenta(dummyCuent){
        let isExiste =false; 
        let pos = 0;
       while(!isExiste && pos < this._arrayCuentas.length ){
           
            if(this._arrayCuentas[pos].numCC == dummyCuent.numCC){
                isExiste = true;
            }
            pos++
        }
        if(!isExiste){
            let dummyCuenta = new Cuenta(this._titular,dummyCuent.numCC);
            this._arrayCuentas.push(dummyCuenta);
        }
        return isExiste;    
    }
         
    /**
     * Método para solicitar por número de cuenta del cliente activo
     * @param {*} numCC 
     * @returns Si no se locacliza la cuenta: nos devuelte false.
     *  Si se localiza nos devuelve el objeto cuenta correspondiente 
     */
    getCuenta (numCC){
        let isEncontrada =false; 
        let pos = 0;
       while(!isEncontrada && pos < this._arrayCuentas.length ){
           
            if(this._arrayCuentas[pos].numCC == numCC){
                isEncontrada = this._arrayCuentas[pos];
            }
            pos++
        }
        return isEncontrada;
    }

    get arrayCuentas(){
        return  this._arrayCuentas;
    }
    listarDatosCliente(){
        let saldoTotal =0;
        let salida="Cliente: " + this.titular + "<br> Cantidad de cuentas: " + this._arrayCuentas.length + "<br>";
       for(let pos=0; pos < this._arrayCuentas.length; pos++){
           salida += this._arrayCuentas[pos].listarDatosCuenta();
           saldoTotal += this._arrayCuentas[pos].saldo
       }
       salida +=  "Con un saldo TOTAL = " +saldoTotal+"<br><br>";
       return salida;
    }
   
}


class Cuenta{
    /**
     * Cuando creamos una nueva cuenta, el banco, que es muy majo,
     *  nos regala 50€ (cuenta amiga de ING!!!), transacción 0 !!!!!
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
        return "Titular: " + this.titular + "<br> Num CC: " + this.numCC + "<br> Saldo CC = " + this.saldo+"<br>";
    }

}



