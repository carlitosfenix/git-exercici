using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class LineaPedido
{
	private string _plato;
	private float _precio;
	private static int _count;

	public string Plato { get => _plato; set => _plato = value; }
	public float Precio { get => _precio; set => _precio = value; }
	public static int Count { get => _count; set => _count = value; }

	public LineaPedido(string plato, float precio)
	{
		Plato = plato;
		Plato = precio;
		Count++;
	}


}
