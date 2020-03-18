/*Como lo hace W3Schools. Yo usaría esta versión o la siguiente*/
/*class Persona{

    constructor(nombre, apellido, edad){
        this._nombre   = nombre;
        this._apellido = apellido;
        this._edad     = edad;
    }

    get nombre(){
        return this._nombre;
    }
    get apellido(){
        return this._apellido;
    }

    set apellido(apellido){
        this._apellido = apellido;
    }

    saludar(){
        return `Me llamo ${this._nombre} ${this._apellido} y tengo ${this._edad}`; 
    }
}

var persona = new Persona("Miguel", "Ruiz", 98);
console.log(persona);
var nombre = persona.nombre;
console.log(nombre);

persona.apellido = "Perez";
console.log(persona.saludar());*/

/*********************Una variante*************************/

 class Persona{
    constructor(nombre, apellido, edad){
        this.nombre   = nombre;
        this.apellido = apellido;
        this.edad     = edad;
    }

    get getNombre(){
        return this.nombre;
    }
    get getApellido(){
        return this.apellido;
    }

    set setApellido(apellido){
        this.apellido = apellido;
    }

    saludar(){
        return `Me llamo ${this.nombre} y tengo ${this.edad}`; 
    }
}

persona = new Persona("Miguel", "Ruiz", 98);

var nombre = persona.getNombre;
console.log(nombre);

persona.setApellido="Perez";
console.log(persona.saludar());

/***************************************************************/
/*Más parecido a Java pero sin modificadores de acceso*/
/*class Persona{
    constructor(nombre, apellido, edad){
        this.nombre   = nombre;
        this.apellido = apellido;
        this.edad     = edad;
    }

    getNombre(){
        return this.nombre;
    }
    getApellido(){
        return this.apellido;
    }

    setApellido(apellido){
        this.apellido = apellido;
    }

    saludar(){
        return `Me llamo ${this.nombre} ${this.apellido} y tengo ${this.edad}`; 
    }
}

persona = new Persona("Miguel", "Ruiz", 98, "hola");//Le da igual si le pasas más parámetros de lo normal
console.log(persona);

var nombre = persona.getNombre();//Aquí sí lo uso como un método
console.log(nombre);


persona.setApellido("Perez");//Aquí sí lo uso como un método
console.log(persona.saludar());*/


