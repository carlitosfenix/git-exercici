using GunsDependencyInyection.guns;
using GunsDependencyInyection.sujetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunsDependencyInyection.interfaces
{
    interface INotificationService
    {
        void NotifySelectectGun(BaseSujeto sujeto);
    }
}
