using GunsDependencyInyection.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunsDependencyInyection.guns
{
    class Gatling : BaseGun
    {
        public Gatling(string model) : base(model)
        {
        }
        public override string Shoot()
        {
            return "fla fla fla fla,  fla fla fla fla,  fla fla fla fla";
        }
    }
}
