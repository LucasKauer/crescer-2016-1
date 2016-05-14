using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExercicioMegamanNivel2;
using ExercicioMegamanNivel2.Upgrades;

namespace ExercicioMegamanNivel2Test
{
    [TestClass]
    public class ProtomanTest
    {
        [TestMethod]
        public void ProtomanEhCriadoCom2DeDefesa()
        {
            var protoman = new Protoman();
            var bot = new Bot();

            bot.Atacar(protoman);

            Assert.AreEqual(97, protoman.Vida);
        }

        [TestMethod]
        public void ProtomanMorreUmaVezETem20DeVida()
        {
            var protoman = new Protoman();
            protoman.ReceberAtaque(102);

            Assert.AreEqual(20, protoman.Vida);
        }

        [TestMethod]
        public void ProtomanMorreUmaVezETemAtaque7()
        {
            var protoman = new Protoman();
            var bot = new Bot();

            protoman.ReceberAtaque(102);
            protoman.Atacar(bot);

            Assert.AreEqual(93, bot.Vida);
        }

        [TestMethod]
        public void ProtomanMorreDuasVezesENaoPodeReviver()
        {
            var protoman = new Protoman();

            protoman.ReceberAtaque(102);
            protoman.ReceberAtaque(22);

            Assert.AreEqual(0, protoman.Vida);
        }

        [TestMethod]
        public void ProtomanTemAtaque5()
        {
            var protoman = new Protoman();
            var bot = new Bot();
            
            protoman.Atacar(bot);

            Assert.AreEqual(95, bot.Vida);
        }

        [TestMethod]
        public void ProtomanComEscudoDeEnergiaTemDefesa4()
        {
            var protoman = new Protoman();
            var bot = new Bot();

            protoman.EquiparUpgrade(new EscudoDeEnergia());
            bot.Atacar(protoman);

            Assert.AreEqual(99, protoman.Vida);
        }

        [TestMethod]
        public void ProtomanComBotasDaVelocidadeMorreUmaVezETemAtaque8()
        {
            var protoman = new Protoman();
            var bot = new Bot();

            protoman.EquiparUpgrade(new BotasSuperVelocidade());
            protoman.ReceberAtaque(103);

            protoman.Atacar(bot);

            Assert.AreEqual(92, bot.Vida);
        }

        [TestMethod]
        public void ProtomanToString()
        {
            var protoman = new Protoman();

            Assert.AreEqual(
                "Vida: 100, Ataque: 5, Defesa: 2",
                protoman.ToString()
                );
        }

        [TestMethod]
        public void ProtomanToStringDepoisDeMorrer()
        {
            var protoman = new Protoman();
            protoman.ReceberAtaque(102);

            Assert.AreEqual(
                "Vida: 20, Ataque: 7, Defesa: 2",
                protoman.ToString()
                );
        }
    }
}
