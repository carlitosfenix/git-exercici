// Carlos Acevedo
// Colecciones en JS

function colecciones() { 
    var colors = ['red', 'green', 'blue'];
    colors.push('orange');

    colors.forEach(function (color) {
        console.log(color);
    });

    mapas();
    logArrayElements();
    logArrayElementsDelete();
    logArrayElements();
}

function mapas() { 
    var miMap = new Map();
    miMap.set("bcn", "Barcelona");
    miMap.set("mad", "Madrid");
    miMap.set("val", "Valencia");
    miMap.set("sev", "Sevilla");

    console.log("miMap es un array? "+Array.isArray(miMap));
    miMap.clear();

    miMap.forEach(logArrayElements);       
}
/**
 * Mostramos todos los elementos por consola
 * @param {*} element 
 * @param {*} index 
 * @param {*} array 
 */
function logArrayElements(element, index, array) {
    console.log('a[' + index + '] = ' + element);
}
  
/**
 * 
 * @param {*} element 
 * @param {*} index 
 * @param {*} logArrayElementsDelete en caso de array es igual, es el objeto que contiene la coleccion 
 */
function logArrayElementsDelete(element, index, map) {
   // map.delete(element);
    map.clear();
    console.log('a[' + index + '] = ' + element);
  }
  