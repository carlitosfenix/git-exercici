using GunsDependencyInyection.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunsDependencyInyection.guns
{
    class Disruptor : BaseGun
    {
        public Disruptor(string model) : base(model)
        { 
        }
        public override string Shoot()
        {
            return "Flium Flium Rawns Rawns";
        }
    }
}
