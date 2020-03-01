let display;
let operacionClicada;
let operacion;
let pendiente="false";
let valDisplay;
let numeroA=0;
let numeroB=0;
let memoria=0;
/* Carlos Acevedo*/

function memoriaF(v){
	let objBtnMr = document.getElementById("btnMr");
	switch(v){
		case "btnMin": //restamos a la memoria
			memoria -= parseInt(display.value);
			break;
		case "btnMmas": //sumamos a la memoria
			memoria += parseInt(display.value);
			break;
		case "btnMr": //Leer meroria
			display.value = memoria;
			brea;
		case"btnMc": //Reset memoria
			memoria = 0;
			break;
	}
	if(memoria>0){
		objBtnMr.className="btnVerde";
	}else{
		objBtnMr.className="btnGris";
	}
}

function iniciar(){
	display = document.getElementById("display");
}

function limpiar(){
	display.value ="0";

}

function coma(){
	//TODO: revisar negado o iverso como va en JS el ! de Java
	if(display.value.indexOf(".")> -1){
		
	}else{
		display.value+=".";
	}
}

function pressNumber(n){
	
	if(pendiente=="true"){
		display.value="0";
		pendiente="false";
	}else{

	}
	valDisplay =display.value;
	if(valDisplay=="0"){
		valDisplay=n;
	}else{
		valDisplay+=n;
	}
	display.value=valDisplay;
}

function operaracion(v){
	operacionClicada = document.getElementById(v).value;
	switch(operacionClicada){
		case "+":
			numeroA=display.value;
			operacion ="+";
		break;
			case "-":
			numeroA=display.value;
			operacion ="-";
		break;
		case "*":
			numeroA=display.value;
			operacion ="*";
		break;
			case "/":
			numeroA=display.value;
			operacion ="/";
		break;
	}
	pendiente = "true";

}

function operar(){
	switch(operacion){
		case "+":
			numeroB = parseFloat(numeroA) + parseFloat(display.value);
			break;
		case "-":
			numeroB = parseFloat(numeroA) - parseFloat(display.value);
			break;
		case "*":
			numeroB = parseFloat(numeroA) * parseFloat(display.value);
			break;
		case "/":
			numeroB = parseFloat(numeroA) / parseFloat(display.value);
			break;
	}
	
	display.value=numeroB;
}


function signChange() {
	if (!display.value.startsWith("-")) {
		display.value = "-" + display.value;
	} else { 
		var longitud =display.value.length;
		display.value = display.value.substring(1,longitud);
	}
}