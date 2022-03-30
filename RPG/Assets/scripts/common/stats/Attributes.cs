using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes 
{
    //<attributes>
    public int STR;//сила(урон от обьектных хитбоксов(оружие на пример) предельная настройка аттак базированых на таких хитбоксах))
    public int dextresity;//ловкость  
    public int intellect; //интелект(урон от любых созданных хитбоксов, предельная величина хитбоксов) 
    public int vitality;//живучесть(хп,регенерация)
    public int will;//воля-увеличивает мп и реген мп
    public int luck;//удача-влияет на любые пересчеты со случайными величины(шанс крита, распределение урона и тд)
                    //еще один атрибут(надо куда то деть крит урон, может сюда а может в предыдущие атрибуты)
                    //еще один атрибут
                    //поднять до 8
                    //</attributes>
    public Attributes()
    {
    }
}
