using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stats
{//может возникать проблема с коруглением. нужны тесты
    public class Stats: BaseStats//хранение и расчеты для юнитов
    {

        public Cooldown armorRecovery;//отсчет до начала регена(надо как то обьявлять)

        public Damage damage = new Damage();//на урон влияет только бафы и экипировка. атрибуты игнорирую наличие показателя урона(не меняют его)
        //но не игнорируют шанс крита и его множитель

        public Stats(BaseStats baseStats)
        {

        }


        public Stats(int HP, int MP, int STR, int vitality, int intellect)
        {
            this.HP = HP;
            this.MP = MP;
            attributes.intellect = intellect;
            attributes.STR = STR;
            attributes.vitality = vitality;
 
        }

        /// <заметка_по_след_функциям>
        /// /все следующие методы сначала запускают базовый экземплят метода, который просто меняет значение. а потом поводят перерасчет вторичных характеристик
        /// </заметка_по_след_функциям>
        public override void ChangeSTR(int d_STR)
        {
            base.ChangeSTR(d_STR);
            damage.ChangeDamage(d_STR * 1.5f, d_STR * 1.5f);//меняем урон от силы.но это рудимент 
        }
        public override void ChangeDextresity(int d_dext)
        {
            base.ChangeDextresity(d_dext);
            //something to secondatyStats
        }
        public override void ChangeIntellect(int d_int)
        {
            base.ChangeIntellect(d_int);
            //something to secondary stats
        }
        public override void ChangeVitality(int d_vitality)
        {
            base.ChangeVitality(d_vitality);
            HP += Mathf.Floor(d_vitality * 3.6f);//HP за единицу живучести
            HPregen += Mathf.Floor(d_vitality * 1.2f);//регенерация хп на живучесть 
        }
        public override void ChangeWill(int d_will)
        {
            base.ChangeWill(d_will);
            MP += Mathf.Floor(d_will * 1.1f);//мп за единицу воли
            MPregen += Mathf.Floor(d_will * 0.5f);//реген за единицу воли
        }
        public override void ChangeLuck(int d_luck)
        {
            base.ChangeLuck(d_luck);
            damage.critChanсe += Mathf.Floor(d_luck*2.3f);//2.3 процента крита за каждыую единицу удачи
        }


   
       
    }
}