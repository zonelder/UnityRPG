using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stats
{
    [System.Serializable]
    public class Stats//хранение и расчеты для юнитов
    {
        public Mana MP;
        public Health HP;
        public Stamina SP;
        public float accuracy;
        public float armor;
        public float armorRegen;

        public Attributes attributes;
        public Damage damage;

        public Stats(BaseStats baseStats)
        {
            HP = new Health(baseStats.HP);
            MP = new Mana(baseStats.MP);
            attributes =new Attributes(baseStats.attributes);
            damage = new Damage();
        }


        public Stats(int HP, int MP, int STR, int vitality, int intellect)
        {
            this.HP = new Health(HP);
            this.MP = new Mana(MP);
            damage = new Damage();
            attributes = new Attributes();
            attributes.intellect = intellect;
            attributes.STR = STR;
            attributes.vitality = vitality;
 
        }

        public  void ChangeSTR(int d_STR)
        {
            attributes.STR += d_STR;
            damage.ChangeDamage(d_STR * 1.5f, d_STR * 1.5f);
        }
        public  void ChangeDextresity(int d_dext)
        {
            attributes.dextresity += d_dext;
            //something to secondatyStats
        }
        public void ChangeIntellect(int d_int)
        {
            attributes.intellect += d_int;
            //something to secondary stats
        }
        public  void ChangeVitality(int d_vitality)
        {
            attributes.vitality += d_vitality;
            HP.AddToMax(Mathf.Floor(d_vitality * 3.6f));
            HP.AddRegen(Mathf.Floor(d_vitality * 1.2f));
        }
        public void ChangeWill(int d_will)
        {
            attributes.will += d_will;
            MP.AddToMax(Mathf.Floor(d_will * 1.1f));
            MP.AddRegen(Mathf.Floor(d_will * 0.5f));
        }
        public void ChangeLuck(int d_luck)
        {
            attributes.luck += d_luck;
            damage.critChanсe += Mathf.Floor(d_luck*2.3f);
        }


   
       
    }
}