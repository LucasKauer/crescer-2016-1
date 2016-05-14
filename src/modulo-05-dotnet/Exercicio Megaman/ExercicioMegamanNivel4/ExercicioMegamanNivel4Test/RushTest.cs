using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExercicioMegamanNivel4;
using ExercicioMegamanNivel4.Upgrades;

namespace ExercicioMegamanNivel4Test
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

        [TestMethod]
        public void RushNaoCausaDanoDeCombateEmMegaman()
        {
            var rush = new Rush();
            var megaman = new Megaman();

            rush.Atacar(megaman);

            Assert.AreEqual(100, megaman.Vida);
        }

        [TestMethod]
        public void RushComChip1TemAtaque3()
        {
            var rush = new Rush(Chip.Nivel1);
            var bot = new Bot();

            rush.Atacar(bot);

            Assert.AreEqual(97, bot.Vida);
        }

        [TestMethod]
        public void RushComChip3TemAtaque6()
        {
            var rush = new Rush(Chip.Nivel3);
            var bot = new Bot();

            rush.Atacar(bot);

            Assert.AreEqual(94, bot.Vida);
        }

        [TestMethod]
        public void RushComChip3TemDefesa4()
        {
            var rush = new Rush(Chip.Nivel3);
            var bot = new Bot();

            bot.Atacar(rush);

            Assert.AreEqual(99, rush.Vida);
        }
    }
}
