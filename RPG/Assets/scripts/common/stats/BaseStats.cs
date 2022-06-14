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
        public Attributes Attributes = new Attributes();
        public BaseStats()
        {

        }

        public BaseStats(int hp, int mp, int STR, int vitality, int intellect)
        {
            HP = new AbstractStrip(hp);
            MP = new AbstractStrip(mp);
            Attributes.intellect = intellect;
            Attributes.STR = STR;
            Attributes.vitality = vitality;
        }

        public virtual void ChangeSTR(int d_STR)
        {
            Attributes.STR += d_STR;
        }
        public virtual void ChangeDextresity(int d_dext)
        {
            Attributes.dextresity += d_dext;
        }
        public virtual void ChangeIntellect(int d_int)
        {
            Attributes.intellect += d_int;
        }
        public virtual void ChangeVitality(int d_vitality)
        {
            Attributes.vitality += d_vitality;
        }

        public virtual void ChangeWill(int d_will)
        {
            Attributes.will += d_will;
        }
        public virtual void ChangeLuck(int d_luck)
        {
            Attributes.luck += d_luck;
        }

    }
}

