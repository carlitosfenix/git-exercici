var AnysTraspas = [];
var AnyNacimiento;
var NombreCompleto;
var DataNaixement;
var TuAnyIsBisiesto;

function iniciar() {
    
  faseUno();
  faseDos();
  faseTres();
  faseCuatro();
  
}

function faseUno(){

    let nom = "Carlos";
    let cognom1 = "Acevedo";
    let cognom2 = "Jiménez";

    let dia = 3;
    let mes = 2;
    let any = 2020;

    NombreCompleto = cognom2 + cognom1 +", "+ nom;
    DataNaixement = dia + "/" + mes + "/" + any;
    textFaseI.innerHTML = NombreCompleto + "<br>" + DataNaixement;
}

function faseDos(){
    let anyOrigen = 1948;
    AnyNacimiento = MiConsole.CapturaAnyNacimiento(); 
    AnysTraspas = VerQueAnysSonBisiestos(anyOrigen, AnyNacimiento);
    let inicioFrase = "La cantidad de Anys de Traspàs desde 1948 hasta "+ AnyNacimiento + ", es de: ";
    let cuentaBisiestos = AnysTraspas.length;
    textFaseII.innerHTML = (inicioFrase + cuentaBisiestos);
}

function faseTres(){

    let salida = "Los años bisiestos desde 1984 hasta tu año son: ";
    for(pos = 0; pos < AnysTraspas.length; pos++) 
    {
        salida += AnysTraspas[pos] + ", ";
    }
    TuAnyIsBisiesto = EsBisiesto(AnyNacimiento);
    let afirmativo = "Tu año de nacimiento " + AnyNacimiento + ", SÍ es Bisiesto";
    let negativo = "Tu año de nacimiento " + AnyNacimiento + ", NO es Bisiesto";
    let resultado =  TuAnyIsBisiesto ? afirmativo : negativo;
    textFaseIII.innerHTML = salida + "<br>" + resultado;

}


function faseCuatro(){

    var reNombre   = "El meu nom és: " + NombreCompleto;
    var reFecha    = "Vaig néixer el: " + DataNaixement;
    var reLoes = TuAnyIsBisiesto ? "és de traspàs" : "no es de traspàs";
    var reBisiesto = "El meu any de naixement " + reLoes;
    textFaseIV.innerHTML = reNombre + "<br>" + reFecha + "</br>" + reBisiesto;

}

function VerQueAnysSonBisiestos(anyInicio, anyFinal)
{ 
    let anysTraspas = [];
    var count = 0;
    for (var any = anyInicio; any <= anyFinal; any++)
    {
        if (EsBisiesto(any))
        {
            anysTraspas[count] = any;
            count++;
        }
    }
    return anysTraspas;
}

function EsBisiesto(any)
{
    var esBisiesto = any % 4;
    if ((esBisiesto == 0 && any % 100 > 0) || (any % 400 == 0))
    {
        return true;
    }
    return false;
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


/**
 * Clase auxiliar para captar el año de nacimiento
 * usando el método estático CapturaAnyNacimiento()
 */
class MiConsole{
    constructor(){   
    }

    static CapturaAnyNacimiento()
    {
        let anyNacimiento = 2020;
        let correcto = false;
			do
			{
                anyNacimiento = Number.parseInt(prompt("Introduce tu año de nacimiento, por favor:"));
                correcto = Number.isInteger(anyNacimiento);
				if (!correcto) alert("Por favor, ¡ entra un año correcto! ");

			}while(!correcto);
		return anyNacimiento;
    }
}

