using System;
using System.IO;

public class MiConsole
{
	public MiConsole()
	{	
	}
	public static int CapturaAnyNacimiento()
	{
		var anyNacimiento = 2020;
		try
		{
			bool correcto = false;
			do
			{
				correcto = int.TryParse(Console.ReadLine(), out anyNacimiento);
				if (!correcto) Console.WriteLine("Por favor, ¡un año correcto! ");

			}while(correcto == false) ;
		}
		catch (IOException e) { 
		
		}

		return anyNacimiento;
	}
}
