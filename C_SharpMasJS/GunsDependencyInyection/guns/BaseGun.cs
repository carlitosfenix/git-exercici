using GunsDependencyInyection.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunsDependencyInyection.guns
{
    abstract class BaseGun : IGun
    {
        private static int cuenta = 1;
        private string _model;
        public string Model {
            get => _model;
            set => _model = value;
        }

        public BaseGun(string model)
        {
            Model = $"{cuenta} - {model} => ";
            cuenta++;
        }
        public abstract string Shoot();
       
    }
}
