using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_4_3
{
    class Ciudad:IComparable<Ciudad>
    {
        //OK: Implementar Icomparable
        private static int _cuenta;
        private string _nombre;


        public Ciudad(string nombre)
        {
            Nombre = nombre;
            _cuenta++;
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public static int Cuenta => _cuenta;


        public int CompareTo(Ciudad other)
        {
            return this.Nombre.CompareTo(other.Nombre);
        }
    }
}
