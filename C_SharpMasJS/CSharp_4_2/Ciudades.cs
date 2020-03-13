using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Ciudades
{
    //Declaración privada de los atributos Encapsulación
    private static int _cantidad;
    private string _nombre;

    //Acceso publico protegido a los atributos con getters y setters
    public string Nombre
    {
        get => _nombre;
        set => _nombre = value;
    }

    //Constructor con parámetro e incremento de
    public Ciudades(string nombre)
    {
        Nombre = nombre;
        Cantidad++;
    }
    //Por cada instancia de Ciudad incrementamos el contador
	

    // A read-only static property:
    public static int Cantidad => _cantidad;

}
