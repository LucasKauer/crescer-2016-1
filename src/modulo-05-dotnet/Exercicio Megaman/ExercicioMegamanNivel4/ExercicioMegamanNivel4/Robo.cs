using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioMegamanNivel4
{
    public abstract class Robo
    {
        protected const Chip CHIP_PADRAO = Chip.Nivel2;

        public Robo(Chip chip = CHIP_PADRAO)
        {
            Vida = 100;
            Upgrades = new List<IUpgrade>();
            Ataque = 5;
            Defesa = 0;

            _chip = chip;
        }
        
        private Chip _chip;
        private int _ataqueBase;
        private int _defesaBase;


        protected List<IUpgrade> Upgrades;
        
        public int Vida { get; protected set; }
        
        protected virtual int Ataque
        {
            get
            {
                return _ataqueBase + BonusDeAtaquePorChip;
            }
            set
            {
                _ataqueBase = value;
            }
        }

        protected virtual int Defesa
        {
            get
            {
                return _defesaBase + BonusDeDefesaPorChip;
            }
            set
            {
                _defesaBase = value;
            }
        }



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
                Upgrades.Add(upgrade);
            }
        }

        public override string ToString()
        {
            return String.Format("Vida: {0}, Ataque: {1}, Defesa: {2}",
                this.Vida, this.Ataque, this.Defesa);
        }




        protected virtual bool PodeEquiparNovosUpgrades
        {
            get
            {
                return Upgrades.Count < 3;
            }
        }

        protected int BonusDeAtaquePorUpgrades
        {
            get
            {
                int bonus = 0;

                foreach (IUpgrade upgrade in Upgrades)
                    bonus += upgrade.BonusAtaque;

                return bonus;
            }
        }

        private int BonusDeDefesaPorUpgrades
        {
            get
            {
                int bonus = 0;

                foreach (IUpgrade upgrade in Upgrades)
                    bonus += upgrade.BonusDefesa;

                return bonus;
            }
        }

        private int BonusDeDefesaPorChip
        {
            get
            {
                switch (_chip)
                {
                    case Chip.Nivel3:
                        return 1;
                    default:
                        return 0;
                }
            }
        }

        private int BonusDeAtaquePorChip
        {
            get
            {
                switch (_chip)
                {
                    case Chip.Nivel1:
                        return -1;
                    case Chip.Nivel3:
                        return 2;
                    default:
                        return 0;
                }
            }
        }
    }
}
