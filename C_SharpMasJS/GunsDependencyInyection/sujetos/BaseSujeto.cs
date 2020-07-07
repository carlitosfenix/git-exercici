using GunsDependencyInyection.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GunsDependencyInyection.sujetos
{
    class BaseSujeto : ISujeto
    {
        public IGun gun;
        private static int cuenta = 1;
        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public BaseSujeto(string nombre)
        {
            Nombre = $"{cuenta} - {nombre} => ";
            cuenta++;
        }

        public string Shoot()
        {
            return this.gun.Model + this.gun.Shoot();
        }

    }
}
