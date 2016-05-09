using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioMegamanNivel2
{
    public abstract class Robo
    {
        public Robo()
        {
            Vida = 100;
            _upgrades = new List<IUpgrade>();
            Ataque = 5;
            Defesa = 0;
        }

        private List<IUpgrade> _upgrades;



        public int Vida { get; protected set; }
        
        protected virtual int Ataque { get; set; }

        protected virtual int Defesa { get; set; }



        public virtual void Atacar(Robo robo)
        {
            int ataque = this.Ataque + BonusDeAtaquePorUpgrades;
            robo.ReceberAtaque(ataque);
        }

        public virtual void ReceberAtaque(int ataque)
        {
            int dano = ataque - (this.Defesa + BonusDeDefesaPorUpgrades);

            if(dano > 0)
            {
                this.Vida -= dano;
            }
        }

        public void EquiparUpgrade(IUpgrade upgrade)
        {
            if(PodeEquiparNovosUpgrades)
            {
                _upgrades.Add(upgrade);
            }
        }

        public override string ToString()
        {
            return String.Format("Vida: {0}, Ataque: {1}, Defesa: {2}",
                this.Vida, this.Ataque, this.Defesa);
        }




        private bool PodeEquiparNovosUpgrades
        {
            get
            {
                return _upgrades.Count < 3;
            }
        }

        protected int BonusDeAtaquePorUpgrades
        {
            get
            {
                int bonus = 0;

                foreach (IUpgrade upgrade in _upgrades)
                    bonus += upgrade.BonusAtaque;

                return bonus;
            }
        }

        private int BonusDeDefesaPorUpgrades
        {
            get
            {
                int bonus = 0;

                foreach (IUpgrade upgrade in _upgrades)
                    bonus += upgrade.BonusDefesa;

                return bonus;
            }
        }
    }
}
