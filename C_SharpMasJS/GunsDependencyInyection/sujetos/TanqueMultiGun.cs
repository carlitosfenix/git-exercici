using GunsDependencyInyection.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunsDependencyInyection.sujetos
{
    class TanqueMultiGun : BaseSujeto
    {

 

        public TanqueMultiGun(IGun _gun, string nombre) : base (nombre)
        {
            ActiveGun(_gun);
        }

        public void ActiveGun(IGun _gun)
        {
            this.gun = _gun;
        }
       
    }
}
