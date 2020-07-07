using GunsDependencyInyection.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunsDependencyInyection.guns
{
    class Phaser :BaseGun
    {
        public Phaser(string model) : base (model)
        { 
        }
        public override string Shoot()
        {
            return "flew flew flew";
        }
    }
}
