using GunsDependencyInyection.guns;
using GunsDependencyInyection.sujetos;
using System;
using System.Runtime.CompilerServices;

namespace GunsDependencyInyection
{
    class Program
    {
        static void Main(string[] args)
        {
            Line();
            Console.WriteLine("Guns & Dependency Inyection");
            Line(); NewLine();

            // 1- Soldado Básico: sólo 1 arma. Inyección de dependiencia con un Arma en el contructor
            Line();
            SoldadoBasico SoldadoRasoAntonioFernandez = new SoldadoBasico(new Phaser("Phaser"), "Antonio Fernández");
            Ataque(SoldadoRasoAntonioFernandez);
            Line(); NewLine();

            // 2- Tanque Multi Gun. Inyección de dependiencia con un Arma en el contructor y en el método ActiveGun
            Line();
            Phaser PhaserTanqueta =  new Phaser("Phaser Tanqueta");
            Laser LaserTanqueta = new Laser("Laser Tanqueta");
            Disruptor Disruptor = new Disruptor("Disruptor Tanqueta");
           
            TanqueMultiGun TanquetaAcorazada = new TanqueMultiGun(PhaserTanqueta, "Tanqueta 1 división");
            Ataque(TanquetaAcorazada);
           
            TanquetaAcorazada.ActiveGun(LaserTanqueta);
            Ataque(TanquetaAcorazada);

            TanquetaAcorazada.ActiveGun(Disruptor);
            Ataque(TanquetaAcorazada);

            TanquetaAcorazada.ActiveGun(PhaserTanqueta);
            Ataque(TanquetaAcorazada);
            Line(); NewLine();

            // 3- Soldado Multi Gun con inyección de dependiencia con la ConsoleNotificacition
            Line();
            var superSoldadoConsoleNotification = new ConsoleNotification();
            Phaser phaserSuperSoldado = new Phaser("Phaser SuperSoldado");
            Laser laserSuperSoldado = new Laser("Laser SuperSoldado");
            Disruptor disruptorSuperSoldado = new Disruptor("Disruptor SuperSoldado");
            Gatling gatlingSuperSoldado = new Gatling("Gatling SuperSoldado");

            SoldadoMultiGun superSoldadoPepeWeller = new SoldadoMultiGun(phaserSuperSoldado, "Pepe Weller", superSoldadoConsoleNotification);
            Ataque(superSoldadoPepeWeller);
            superSoldadoPepeWeller.ActiveGun(laserSuperSoldado, superSoldadoConsoleNotification);
            Ataque(superSoldadoPepeWeller);
            Ataque(superSoldadoPepeWeller);
            superSoldadoPepeWeller.ActiveGun(disruptorSuperSoldado, superSoldadoConsoleNotification);
            superSoldadoPepeWeller.ActiveGun(gatlingSuperSoldado, superSoldadoConsoleNotification);
            Line();

        }

        private static void Line()
        {
            string lineaSeparacion = "************************************" +
                "*********************************************************";
            Console.WriteLine(lineaSeparacion);
        }

        private static void NewLine()
        {
            string salto = "\r\n";
            Console.WriteLine(salto);
        }

        private static void Ataque(BaseSujeto baseSujeto)
        {
            Console.WriteLine($"{baseSujeto.Nombre}: {baseSujeto.Shoot()}");
        }

    }
}
