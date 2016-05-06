using ConsoleApplication4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraMediaTest
{
    [TestClass]
    public class ElfoTest
    {
        [TestMethod]
        public void ElfoAtiraFlechaEDescontaUma()
        {
            var elfo = new Elfo();

            elfo.AtirarFlecha();
            
            Assert.AreEqual(41, elfo.Flechas);
        }

        [TestMethod]
        public void ElfoMentirosoTemMaisQue10Flechas()
        {
            var elfo = new Elfo();

            Assert.AreEqual(42, elfo.Flechas);
        }

        [TestMethod]
        public void ElfoMentirosoTemMenosQue10Flechas()
        {
            var elfo = new Elfo();

            //for (int i = 0; i < length; i++)
            //{

            //}

            //while (true)
            //{
            //    break;
            //}

            for (int i = 0; i < 33; i++)
            {
                elfo.AtirarFlecha();
            }


            //switch (elfo.Flechas)
            //{
            //    case 10:
            //        break;
            //    default:
            //        break;
            //}

            Assert.AreEqual(20, elfo.Flechas);
        }
    }
}
