using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stats
{
    public class BaseStats//тут не производитьс€ никаких расчетов, а просто хран€тьс€ базовые значени€ дл€ апределленных юнитов
    {
        //<abstract stats>
        public float HP;
        public float MP;//mind points
        public float SP;//speed point насколько быстро действует персонаж(дввигаетс€ юзает анимации и тд)
        public float stamina;
        public float accuracy;//точность(разброс при стрельбе и направлении хитбоксов+ ∆≈Ћј“≈Ћ№Ќќ добавить вариациию дл€ аттак в зависимости от точности(насколько персонаж может следовать первоначальному шаблону))
        public float HPregen;//регенераци€ хп
        public float MPregen;//регенераци€ мп
        public float SPregen;//реген стамины
        public float armor;
        public float armorRegen;


        public Attributes attributes = new Attributes();
        public BaseStats()//пусть пока все будет public но после инициализации здесь можно будет только мен€ть и никак не устанавливать начени€
        {

        }

        public BaseStats(int HP, int MP, int STR, int vitality, int intellect)
        {
            this.HP = HP;
            this.MP = MP;
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

