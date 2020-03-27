var displayOutHtml;

var textSalida = "";
var ArrayHospitales = new Array();
var ArrayHoteles = new Array();
var ArrayCines = new Array();
var NombreHospitalAlta;
var Alta = false;

var Salto = "\r\n"; 


/* Carlos Acevedo*/

function iniciar() {
    displayOutHtml = document.getElementById("salidaTabla");

    /*
        Crearem, com a mínim:

        L’”Hospital de Vilafranca”, de 1.950 m² i 2 plantes. En aquest moment té 26 malalts. 
        L’”Hospital General de Catalunya”, de 25.350 m² i 10 plantes. En aquest moment té 315 malalts. 
        El “Cinema Montecarlo”, de  3180 m² i 1 planta.  El “Cinema Principal”, de 12.450 m² i 2 plantes. 
        L’”Hotel Hilton”, de 73.858 m² i 22 plantes. Té 583 habitacions.  L’”Hotel Pepita”, de 593 m² i 3 plantes.
        Té 12 habitacions. 
    */

   var hospVilafranca = new Hospital("Vilafranca", 2, 1950, 26);
   var hospGeneralCat = new Hospital("Hospital General de Catalunya", 10, 2530, 315);
   var cineMontecarlo = new Cine("Cinema Montecarlo", 1, 3180);
   var cinePrincipal  = new Cine("Cinema Principal",2 , 12450);
   var hotelHilton    = new Hotel("Hotel Hilton",22 , 73858,583);
   var hotelPepita    = new Hotel("Hotel Pepita", 3, 593,12);

   ArrayHospitales.push (hospVilafranca);
   ArrayHospitales.push(hospGeneralCat);
   ArrayCines.push(cineMontecarlo);
   ArrayCines.push(cinePrincipal);
   ArrayHoteles.push(hotelHilton);
   ArrayHoteles.push(hotelPepita);



   listEdificiosExistentes();
   

}

function listEdificiosExistentes(){

    salidaTabla.innerHTML = "";

    ArrayHospitales.forEach(function(hospital,index){
        textSalida += hospital.calcularCosteDeVigilancia();
        textSalida += hospital.repartirDinar();
        textSalida += hospital.limpiar();
    });

    ArrayHoteles.forEach(function(hotel,index){
        textSalida += hotel.calcularCosteDeVigilancia();
        textSalida += hotel.costesServicioHabitaciones();
        textSalida += hotel.limpiar();

    });

    ArrayCines.forEach(function(cine,index){
        textSalida += cine.calcularCosteDeVigilancia();
        textSalida += cine.projectarSessio(4.5, 232);
        textSalida += cine.limpiar();
    });
    salidaTabla.innerHTML = textSalida;  
}

function altaHospital(){
    Alta = true;
    NombreHospitalAlta = nomHospital.value;
    let numPlantas = numPlantasHospital.value;
    let supHospital = superficieHospital.value
    let numEnfermos = numEnfermosHospital.value;
   
    if(NombreHospitalAlta && numPlantas && supHospital>0 && numEnfermos>=0 && !isInSystem()){
        let dummy = new Hospital(NombreHospitalAlta,numPlantas,supHospital.numEnfermos);
        ArrayHospitales.push(dummy);
        alert("Alta correcta de Hospital");
       listEdificiosExistentes(); //TODO: Seguir por aquí
    } else {
        alert("Revise los datos, falta información");
    }  
}

function bajaHospital(){
    alert("TODO: segir por aquí");
}



/**
 * Método que nos devuelve un hospital si existe o avisa con un alert en caso contrario.
 * Nos sirve para las altas y para buscar
 * @returns hospital si existe con el mismo nombre.
 */
function isInSystem(){
    let existe =false;
    ArrayHospitales.forEach(function(hospital, index){
        if(hospital.nombre.trim()===NombreHospitalAlta.trim() ){
            if(Alta){
                 alert ("Ya existe un hospital: " + hospital.nombre);
            }
            existe =hospital;
        }
    });
    if (!Alta && !existe){
        alert ("No existe el Hospital "+ nombreHospitalAlta,);
    }
    Alta = false;
    
    return existe;
}




/**
 * Esta clase no podremos instanciarla
 * tenemos que extenderla e implementar los abstract
 */
class Edificio{
    /**
     * 
     * @param {*} nombre 
     * @param {*} numPlantas 
     * @param {*} superficie 
     */
    constructor(nombre, numPlantas, superficie){
        this._nombre = nombre;
        this._numPlantas = numPlantas;
        this._superficie = superficie;
    }

    get nombre(){
        return this._nombre;
    }

    get numPlantas(){
        return this._numPlantas;
    }

    get superficie(){
        return this._superficie;
    }

    /**
     * Mostramos tiempo necesario para la limpieza y el coste
     */
    limpiar(){
        let coste=1;
        let tiempo = (this._superficie /5);
        if(this._numPlantas > 0){
            tiempo += (this._numPlantas * 0.5);
        }  
        
        return  "-El tiempo diario necesario para la limpieza de "+ this.nombre +
         " es de: "+tiempo+ "m. y el importe mensual es de: "+ coste * 30 + "€" + Salto + Salto;
    }
    /**
     *  @see En JS no tenemos Abstract, pero podemos usar esto
     *   Mostra el que costarà al mes contractar vigilants a cada edifici.
     *   Es considera que cada vigilant d’hotel u hospital pot vigilar 1000 m². Per tant, si un edifici té una superfície de 5500 m², necessitarem 6 vigilants.
     *   En canvi, els vigilants dels cinemes poden vigilar 3000 m². Contractar cada vigilant costa als propietaris de l’edifici 1.300 euros mensuals,
     *   però els vigilants d’hotels cobren un plus de perillositat de 500 euros mensuals.
     *  @returns coste por mes
     */
    calcularCosteDeVigilancia(){
        throw new Error("Este método es abstracto y requiere concreción en cada clase descendiente");  
         return 0; //Coste mensual 
    }


}

class Hotel extends Edificio{
    constructor(nombre, numPlantas, superficie, numHabitaciones){
        super(nombre, numPlantas, superficie);
        this._numHabitaciones = numHabitaciones
    }

    get numHabitaciones (){
        return this._numHabitaciones;
    }

    //@Override
    calcularCosteDeVigilancia(){
        let numVigilantes = Math.ceil(super.superficie / 1000);
        let costeVigilante = 1300+500;
        return  "==> El Hotel" + super.nombre + " necesita " + numVigilantes +
         " vigilantes y el coste mensual total es de: " + (numVigilantes * costeVigilante) + " " + Salto;  
    }

    /**
    En els hotels cada dia passa el servei d’habitacions. Es calcula que cada membre del servei pot atendre 20 habitacions.
    Es crearà un mètode que calculi, i mostri per pantalla:
      a) Quantes persones són necessàries per atendre el servei d’habitacions l’hotel.
      b) Quin és el total necessari pels sous d’aquestes persones, tenint en compte que cada persona cobra 1.000 euros al mes. 
     */
    costesServicioHabitaciones(){
        let numPersonalHabitaciones = Math.ceil(this.numHabitaciones/20);
        let costePersonalMes = 1000;
        return "-El Hotel" + super.nombre + " necesita " + numPersonalHabitaciones +
         " personas para el servicio de habitaciones y el coste mensual total es de: "+
          (numPersonalHabitaciones * costePersonalMes) + " " + Salto;  
    }
}
/**
 * Hospital tenemos: calcularCosteDeVigilancia(), repartirDinar()
 */
class Hospital extends Edificio{
    constructor(nombre, numPlantas, superficie, enfermos){
        super(nombre, numPlantas, superficie);
        this._enfermos = enfermos;
    }

    set enfermos(enfermos){
        this._enfermos = enfermos;
    }
    get enfermos(){
        return this._enfermos;
    }

      //@Override
      calcularCosteDeVigilancia(){
        let numVigilantes = Math.ceil(super.superficie / 1000);
        let costeVigilante = 1300;
        return "==> El Hospital " + super.nombre + " necesita " + numVigilantes +
         " vigilantes y el coste mensual total es de: " + numVigilantes * costeVigilante + Salto;  

    }

    /**
     * En l’hospital es reparteix dinar pels malalts tres vegades al dia.
     * Hi haurà una funció repartirDinar() en el lloc adient que mostrarà,
     * quan sigui cridada, el missatge “S’estan repartint xxx racions”,
     * on xxx haurà de contenir el número de malalts de l’hospital.
     * Aquest número pot variar al llarg del temps, i per tant, s’haurà de permetre accedir a l’atribut corresponent,
     * tant per llegir-lo com per modificar-lo, encara que no es faci directament. 
     */
    repartirDinar(){
        return "-Es l'hora de un àpat i s’estan repartint" + this.enfermos + "racions" + Salto;
    }
    
}

class Cine extends Edificio{
    constructor(nombre, numPlantas, superficie){
        super(nombre, numPlantas, superficie);
    }

      //@Override
      calcularCosteDeVigilancia(){
        let numVigilantes = Math.ceil(super.superficie / 3000);
        let costeVigilante = 1300;
        return "==> El cine" + super.nombre + " necesita " + numVigilantes +
         " vigilantes y el coste mensual total es de: "
         + numVigilantes * costeVigilante + Salto;  

    }
    /**
     * 
     * En el cinema es crearà el mètode projectarSessio(),
     *  que mostrarà el missatge “S’han recaptat xxx.xx euros”,
     *  tenint en compte que, per calcular la recaptació,
     *  s’ha de multiplicar el preu d’una entrada pel número d’assistents a la sessió. 
     * Per tant, la funció projectarSessió haurà de rebre com a paràmetres el número d’assistents i el preu de l’entrada per aquella sessió. 
     * 
     */
    projectarSessio(precioEntrada, numAsistentes){
        return "-S’han recaptat" + parseFloat(precioEntrada * numAsistentes).toFixed(2) + Salto + Salto;
    }
    
}

/*
Edifici i diverses classes derivades. No s’instanciarà cap objecte de la classe Edifici,
 sinó que s’instanciaran objectes de les classes derivades d’aquesta. 
 
Tots els edificis tindran certes dades comunes (nom, número de plantes, superficie (m²)) que es donaran en crear l’edifici i no es modificaran,
 però sí que s’haurà de poder accedir a elles per llegir-les.
 
Es crearà un mètode netejar() en la classe adient, la qual mostrarà per pantalla el temps que s’ha trigat a netejar l’edifici, 
tenint en compte que es tarda en netejar un minut per cada 5 m². A més, si un edifici té més d’una planta, es tarda a pujar mig minut d’una planta a una altra.
Per tant, afegirem mig minut per cada planta addicional. Per cada minut de feina es pagarà un euro diari. A més, com que es neteja cada dia, per obtenir el cost mensual,
haurem de multiplicar per 30 (aquest cost mensual també es mostrarà per pantalla) 
 
SI SOBRA TIEMPO COMPLICAR CINE CON ESTO
 
En el cinema es passa una pel·lícula diverses vegades al dia (en funció del dia de la setmana o de si és un dia festiu). En funció del dia i la hora, en cada sessió es cobrarà l’entrada a un preu diferent. Es crearà en el lloc adient la funció projectarSessio(),
que mostrarà el missatge “S’han recaptat xxx.xx euros”, tenint en compte que, per calcular la recaptació, s’ha de multiplicar el preu d’una entrada pel número d’assistents a la sessió, que no podrà superar l’aforament màxim.
Per tant, la funció projectarSessió haurà de rebre com a paràmetres el número d’assistents i el preu de l’entrada per aquella sessió. El número d’assistents a la sessió no pot ser més gran que l’aforament total de la sala. 
Preu sessió: El cost de l’entrada entre setmana és 5.50€, Divendres, dissabte i diumenge: El cost de l’entrada abans de les 16h és 6.50€ i a partir de les 16h és 7.50€


 
Es pot completar la pràctica creant altres edificis i implementant altres funcions per aquests edificis i altres edificis. 
*/




