let displayOutHtml;
let nameInput;
let mailInput;
let dateInput;
let passwordInput;
var textSalida = "";


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

function validarNoEmempty() {
    var avisosIternos = ""
        //displayOutHtml.innerHTML = nameInput.value;

    if (!nameInput.value || nameInput.value == "") {
        avisosIternos += "Has de indicar un nombre <br>";
        nameError.textContent = "Has de indicar un nombre";
        alert(avisosIternos);
    }
    if (secondNameInput.value != null || secondNameInput.value.length < 1) {
        avisosIternos += "Has de indicar el apellido";
        secondNameError.textContent = "Has de indicar el apellido";
        alert(avisosIternos);
    }




    return avisosIternos;
}

function validateTelYCP() {
    var phoneNumber = document.getElementById('phone').value;
    var postalCode = document.getElementById('cp').value;
    var phoneRGEX = /a{3,6}/;
    var postalRGEX = /a{5}/;
    var phoneResult = phoneRGEX.test(phoneNumber);
    var postalResult = postalRGEX.test(postalCode);
    if (phoneResult == false) {
        textSalida += "Por favor entra un número de teléfono válido";
        alert('Por favor entra un número de teléfono válido <br>');
    }

    if (postalResult == false) {
        textSalida += 'Por favor, entra un CP válido<br>';
        alert('Por favor, entra un CP válido');
    }

    return true;
}