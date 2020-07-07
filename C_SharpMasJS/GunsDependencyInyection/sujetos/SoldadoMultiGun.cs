using GunsDependencyInyection.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunsDependencyInyection.sujetos
{
    class SoldadoMultiGun : BaseSujeto
    {

        public SoldadoMultiGun(IGun _gun, string nombre, INotificationService notificationService) : base (nombre)
        {
            ActiveGun(_gun, notificationService);
        }

        public void ActiveGun(IGun _gun, INotificationService notificationService)
        {
            this.gun = _gun;
            notificationService.NotifySelectectGun(this);
        }
   
    }
}
