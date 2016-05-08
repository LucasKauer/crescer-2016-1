using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExercicioMegamanNivel1;

namespace ExercicioMegamanNivel1Test
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
    }
}
