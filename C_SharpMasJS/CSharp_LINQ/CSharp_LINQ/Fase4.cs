

using System;
using System.Linq;


public class Fase4
{
    private string[] _nombres;
    public static string Separador = "*****************************************************";

    public string[] Nombres { get => _nombres; set => _nombres = value; }

    public Fase4(string[] miArray)
    {
        Nombres = miArray;
    }
    ///<summary>
    ///Entra una letra y filtraré por las que comiencen por dicha letra
    ///</summary>
    ///<param name="letra"> letra inicio,entrala en minúscula si quieres que se considere mayúscula y minúscula.</param>
    ///<returns> void </returns>
    public void ComeinzanPor(string letra)
    {
        //Con hibernate
        /*
        var comienzanO = from nomO in Nombres
                         where SqlMethods.Like(nomO, $"{letra}%") || SqlMethods.Like(nomO, $"{letra.ToUpper()}%")
                         orderby nomO
                         select nomO;
        Console.WriteLine("ComeinzanPorO() con Hibernate " + Fase4.Separador);
        foreach (var result in comienzanO)
        {
            Console.WriteLine(result);
        }*/

       
        //Con fluido o fluent
        var coienzanOFluent = Nombres
            .Where(nomO => nomO.StartsWith("o") || nomO.StartsWith("O"))
            .Select(nomO => nomO);
        Console.WriteLine("ComeinzanPorO() con fluent " +Separador);
        foreach (var result in coienzanOFluent)
        {
            Console.WriteLine(result);
        }
    
    }
    /// <summary>
    /// Filtraré por la longitud entrada
    /// </summary>
    /// <param name="longitud"></param>
    public void MasDeXLetras(int longitud)
    {
        var tmpIEnumerable = from nombre in Nombres
                             where nombre.Length>longitud
                             select nombre;
        Console.WriteLine($"MasDe {longitud} Letras() " + Fase4.Separador);
        foreach (var result in tmpIEnumerable)
        {
            Console.WriteLine(result);
        }
       

    }

    public void OrderDesc() 
    {
        var tmpDesc = from nomDesc in Nombres
                      orderby nomDesc descending
                      select nomDesc;
        Console.WriteLine("OrderDesc()" + Fase4.Separador);

        foreach (var result in tmpDesc) 
        {
            Console.WriteLine(result);

        }
    }

}
