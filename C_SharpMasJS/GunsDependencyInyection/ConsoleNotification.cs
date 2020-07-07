using GunsDependencyInyection.guns;
using GunsDependencyInyection.interfaces;
using GunsDependencyInyection.sujetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunsDependencyInyection
{
    internal class ConsoleNotification : INotificationService
    {
        public void NotifySelectectGun(BaseSujeto sujeto)
        {
            Console.WriteLine($"El Sujeto: {sujeto.Nombre} , ha activado el arma: {sujeto.gun.Model}");
        }
    }
}
