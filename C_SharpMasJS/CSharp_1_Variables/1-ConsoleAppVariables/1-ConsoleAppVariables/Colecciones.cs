using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
/**
* Clase para ver las distintas coleciones en C#
*/
public class Colecciones
{
	public Colecciones()
	{
		var devolucionLosArrays = LosArrays();
		var devolucionLasListas = LasListas();
		var devolucionLosDiccinarios = LosDiccionarios();
		Console.WriteLine(devolucionLosArrays);

	}
	/**
	 * Casos en los que conocemos de antemano el tamaño y no ha de variar
	 */
	public static string[] LosArrays()
	{
		string[] unArray = new string[20];
		for (var i = 0; i < unArray.Length; i++) 
		{
			unArray[i] = "valor y posición: "+i;
		}

		// Declare a two dimensional array.
		int[,] multiDimensionalArray1 = new int[2, 3];
		multiDimensionalArray1[1, 2] = 6;
		// equivale al 6 de abajo {0.0 0.1..}, {1.0---1.2}

		// Declare and set array element values.
		int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };
		return unArray;
	}
	/**
	 * Cuando es una lista sencilla pero el tamaño puede ser variable o no lo conocemos la longitud
	 */
	private List<double> LasListas()
	{
		var miList = new List<double>();
		int contador = 0;

		for (var i = 0; i < 20; i++) 
		{
			miList.Add(i);
		}

		try
		{	//ForEach son para solo lectura de las colecciones
			foreach (double elemento in miList)
			{
				//esta línea petará no podemos acceder desde foreach
				//miList[contador] = contador;
				Console.WriteLine("elemento :"+elemento);
				contador++;
			}
		}
		catch(InvalidOperationException e)
		{
			Console.WriteLine("al recorrer una lista desde un ForEach la podemos" +
				" 'cagar' si se nos ocurre modificarla desde el mismo. ERROR: "+ e);
		}

		for (var i = 0; i<miList.Count; i++)
		{
			miList[i] = miList[i] * 0.1;
			if (i > 10)
			{
				miList.RemoveAt(i);
			}
			else
			{
				Console.WriteLine($"miList[{i}] =" + miList[i]);
			}

		}

		return miList;
	}

	public Dictionary<string,string> LosDiccionarios()
	{
		Dictionary<string, string> extensiones = new Dictionary<string, string>();

		extensiones.Add("pdf", "acrobat.exe");
		extensiones.Add("txt", "notepad.exe");
		extensiones.Add("psd", "photoshop.exe");
		try
		{
			extensiones.Add("txt", "word.exe");
		}
		catch (Exception e)
		{

			Console.WriteLine("petará si queremos agregar la key existente txt, en dictionary "+e);
		}
		foreach(var parejaElemen in extensiones)
		{
			Console.WriteLine($"La Key:{parejaElemen.Key}, tiene el valor:{parejaElemen.Value}");
			if (!parejaElemen.Key.Equals("psd"))
			{ 
				extensiones.Remove(parejaElemen.Key);
			}
		}
		foreach (var parejaElemen in extensiones)
		{
			Console.WriteLine($"La Key:{parejaElemen.Key}, tiene el valor:{parejaElemen.Value}");
			
			
		}

		return new Dictionary<string,string>();
	}
}
