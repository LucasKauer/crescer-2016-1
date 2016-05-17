using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExercicioMegamanNivel2;
using ExercicioMegamanNivel2.Upgrades;

namespace ExercicioMegamanNivel2Test
{
    [TestClass]
    public class BotTest
    {
        [TestMethod]
        public void BotNasceComVida100Ataque5EDefesa0()
        {
            var bot1 = new Bot();
            var bot2 = new Bot();

            bot1.Atacar(bot2);

            Assert.AreEqual(95, bot2.Vida);
        }

        [TestMethod]
        public void BotToString()
        {
            var bot1 = new Bot();

            Assert.AreEqual(
                "Vida: 100, Ataque: 5, Defesa: 0",
                bot1.ToString()
                );
        }

        [TestMethod]
        public void BotToStringDepoisDeReceberAtaque()
        {
            var bot1 = new Bot();
            var bot2 = new Bot();

            bot2.Atacar(bot1);

            Assert.AreEqual(
                "Vida: 95, Ataque: 5, Defesa: 0",
                bot1.ToString()
                );
        }

        [TestMethod]
        public void BotToStringComUpgrade()
        {
            var bot1 = new Bot();

            bot1.EquiparUpgrade(new CanhaoDePlasma());

            Assert.AreEqual(
                "Vida: 100, Ataque: 5, Defesa: 0",
                bot1.ToString()
                );
        }

        [TestMethod]
        public void BotComCanhaoDePlasmaTemAtaque7()
        {
            var bot1 = new Bot();
            var bot2 = new Bot();

            bot2.EquiparUpgrade(new CanhaoDePlasma());
            bot2.Atacar(bot1);

            Assert.AreEqual(93, bot1.Vida);
        }

        [TestMethod]
        public void BotComEscudoDeEnergiaTemDefesa2()
        {
            var bot1 = new Bot();
            var bot2 = new Bot();

            bot2.EquiparUpgrade(new EscudoDeEnergia());
            bot1.Atacar(bot2);

            Assert.AreEqual(97, bot2.Vida);
        }

        [TestMethod]
        public void BotComBotasSuperVelocidadeTemAtaque6EDefesa1()
        {
            var bot1 = new Bot();
            var bot2 = new Bot();

            bot2.EquiparUpgrade(new BotasSuperVelocidade());
            bot1.Atacar(bot2);
            bot2.Atacar(bot1);

            Assert.AreEqual(96, bot2.Vida);
            Assert.AreEqual(94, bot1.Vida);
        }

        [TestMethod]
        public void BotNaoSomaMaisDe3Upgrades()
        {
            var bot1 = new Bot();
            var bot2 = new Bot();

            bot2.EquiparUpgrade(new CanhaoDePlasma());
            bot2.EquiparUpgrade(new CanhaoDePlasma());
            bot2.EquiparUpgrade(new CanhaoDePlasma());
            bot2.EquiparUpgrade(new CanhaoDePlasma());

            bot2.Atacar(bot1);

            Assert.AreEqual(89, bot1.Vida);
        }
    }
}
