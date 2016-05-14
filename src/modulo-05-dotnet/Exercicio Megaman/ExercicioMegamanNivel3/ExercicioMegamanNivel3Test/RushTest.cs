using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExercicioMegamanNivel3;
using ExercicioMegamanNivel3.Upgrades;

namespace ExercicioMegamanNivel3Test
{
    [TestClass]
    public class RushTest
    {
        [TestMethod]
        public void RushToString()
        {
            var rush = new Rush();

            Assert.AreEqual(
                "Vida: 100, Ataque: 4, Defesa: 3",
                rush.ToString()
                );
        }

        [TestMethod]
        public void RushSoEquipaDoisUpgrades()
        {
            var rush = new Rush();
            var bot = new Bot();

            rush.EquiparUpgrade(new CanhaoDePlasma());
            rush.EquiparUpgrade(new CanhaoDePlasma());
            rush.EquiparUpgrade(new CanhaoDePlasma());

            rush.Atacar(bot);

            Assert.AreEqual(92, bot.Vida);
        }

        [TestMethod]
        public void RushEquipandoMegamanConcede4DeAtaque()
        {
            var rush = new Rush();
            var megaman = new Megaman();
            var bot = new Bot();

            megaman.EquiparUpgrade(rush);

            megaman.Atacar(bot);

            Assert.AreEqual(90, bot.Vida);
        }

        [TestMethod]
        public void RushEquipandoMegamanConcede3DeDefesa()
        {
            var rush = new Rush();
            var megaman = new Megaman();
            var bot = new Bot();

            megaman.EquiparUpgrade(rush);
            bot.Atacar(megaman);

            Assert.AreEqual(98, megaman.Vida);
        }

        [TestMethod]
        public void RushComCanhaoDePlasmaConcede6DeAtaque()
        {
            var rush = new Rush();
            var megaman = new Megaman();
            var bot = new Bot();

            rush.EquiparUpgrade(new CanhaoDePlasma());

            megaman.EquiparUpgrade(rush);
            megaman.Atacar(bot);

            Assert.AreEqual(88, bot.Vida);
        }

        [TestMethod]
        public void RushComEscudoDeEnergiaConcede3DeDefesa()
        {
            var rush = new Rush();
            var megaman = new Megaman();
            var bot = new Bot();

            rush.EquiparUpgrade(new EscudoDeEnergia());
            megaman.EquiparUpgrade(rush);
            bot.Atacar(megaman);

            Assert.AreEqual(98, megaman.Vida);
        }
    }
}
