using GunsDependencyInyection.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunsDependencyInyection.guns
{
    class Laser : BaseGun
    {
        public Laser(string model) : base(model)
        {
        }
        public override string Shoot()
        {
            return "fffissssss ffisssssss fisssssss";
        }
    }
}
