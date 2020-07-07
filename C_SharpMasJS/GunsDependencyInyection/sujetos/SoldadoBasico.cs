using GunsDependencyInyection.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunsDependencyInyection.sujetos
{
    /// <summary>
    /// Soldado al que al instanciar inyectamos el arma seleccinada
    /// Unda sóla arma por instancia u objeto
    /// </summary>
    class SoldadoBasico :BaseSujeto
    {
        
        private static int cuenta = 1;

        public SoldadoBasico(IGun _gun, string nombre) : base(nombre)
        {  
            this.gun = _gun;
            cuenta++;
        }

    }
}
