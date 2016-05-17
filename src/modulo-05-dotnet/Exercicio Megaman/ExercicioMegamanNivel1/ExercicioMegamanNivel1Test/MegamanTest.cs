using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExercicioMegamanNivel1;

namespace ExercicioMegamanNivel1Test
{
    [TestClass]
    public class MegamanTest
    {
        [TestMethod]
        public void MegamanTemEhCriadoCom6DeAtaque()
        {
            var megaman = new Megaman();
            var bot = new Bot();

            megaman.Atacar(bot);

            Assert.AreEqual(94, bot.Vida);
        }

        [TestMethod]
        public void MegamanTemMenosDe30DeVidaCausa9NoAtaque()
        {
            var megaman = new Megaman();
            var bot = new Bot();

            megaman.ReceberAtaque(71);
            megaman.Atacar(bot);

            Assert.AreEqual(91, bot.Vida);
        }

        [TestMethod]
        public void MegamanToString()
        {
            var megaman = new Megaman();

            Assert.AreEqual(
                "Vida: 100, Ataque: 6, Defesa: 0",
                megaman.ToString()
                );
        }

        [TestMethod]
        public void MegamanToStringComMenosDe30DeVida()
        {
            var megaman = new Megaman();
            megaman.ReceberAtaque(71);

            Assert.AreEqual(
                "Vida: 29, Ataque: 6, Defesa: 0",
                megaman.ToString()
                );
        }
    }
}
