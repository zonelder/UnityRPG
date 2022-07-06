using UnityEngine;

namespace stats
{
    [System.Serializable]
    public class Stats//хранение и расчеты для юнитов
    {
        public Mana MP;
        public Health HP;
        public Stamina SP;

        public Attributes Attributes;
        public Damage Damage;
        public SecondaryStats Amplifiers;

        public Stats(BaseStats baseStats)
        {
            HP = new Health(baseStats.HP);
            MP = new Mana(baseStats.MP);
            Attributes =new Attributes(baseStats.Attributes);
            Damage = new Damage();
            Amplifiers = new SecondaryStats();
        }


        public Stats()
        {
            Damage = new Damage();
            Amplifiers = new SecondaryStats();
            Attributes = new Attributes();
        }

        public GeneratedDamage CalculateDamage()
        {
            GeneratedDamage damage = Damage.calculate();
            damage.damage *=Amplifiers.DamageAmp;
            return damage;
        }
        public void AddAttackEffects(AttackStats attackStats)
        {
           Amplifiers.AttackSpeedAmp += attackStats.DamageAmp;
        }
        public void DistractAttackEffects(AttackStats attackStats)
        {
            Amplifiers.AttackSpeedAmp -= attackStats.DamageAmp;
        }

        public void ChangeSTR(int d_STR)
        {
            Attributes.STR += d_STR;
            Damage.ChangeDamage(d_STR * 1.5f, d_STR * 1.5f);
        }
        public  void ChangeDextresity(int d_dext)
        {
            Attributes.dextresity += d_dext;
            //something to secondatyStats
        }
        public void ChangeIntellect(int d_int)
        {
            Attributes.intellect += d_int;
            //something to secondary stats
        }
        public  void ChangeVitality(int d_vitality)
        {
            Attributes.vitality += d_vitality;
            HP.AddToMax(Mathf.Floor(d_vitality * 3.6f));
            HP.AddRegen(Mathf.Floor(d_vitality * 1.2f));
        }
        public void ChangeWill(int d_will)
        {
            Attributes.will += d_will;
            MP.AddToMax(Mathf.Floor(d_will * 1.1f));
            MP.AddRegen(Mathf.Floor(d_will * 0.5f));
        }
        public void ChangeLuck(int d_luck)
        {
            Attributes.luck += d_luck;
            Damage.ChangeCritChance(Mathf.Floor(d_luck*2.3f));
        }    
    }
}