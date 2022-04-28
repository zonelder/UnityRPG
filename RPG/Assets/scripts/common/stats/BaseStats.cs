using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stats
{
    public class BaseStats//тут не производиться никаких расчетов, а просто храняться базовые значения для апределленных юнитов
    {
        //<abstract stats>
        public AbstractStrip HP;
        public AbstractStrip MP;
        public AbstractStrip SP;
        public float accuracy;
        public float armor;
        public float armorRegen;
        public Attributes attributes = new Attributes();
        public BaseStats()
        {

        }

        public BaseStats(int HP, int MP, int STR, int vitality, int intellect)
        {
            this.HP = new AbstractStrip(HP);
            this.MP = new AbstractStrip(MP);
            attributes.intellect = intellect;
            attributes.STR = STR;
            attributes.vitality = vitality;
        }
        public virtual void ChangeSTR(int d_STR)
        {
            attributes.STR += d_STR;
        }
        public virtual void ChangeDextresity(int d_dext)
        {
            attributes.dextresity += d_dext;
        }
        public virtual void ChangeIntellect(int d_int)
        {
            attributes.intellect += d_int;
        }
        public virtual void ChangeVitality(int d_vitality)
        {
            attributes.vitality += d_vitality;
        }

        public virtual void ChangeWill(int d_will)
        {
            attributes.will += d_will;
        }
        public virtual void ChangeLuck(int d_luck)
        {
            attributes.luck += d_luck;
        }

    }
}

