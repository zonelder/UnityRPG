using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes 
{
    //<attributes>
    public int STR;//сила
    public int dextresity;//ловкость  
    public int intellect; //интелект
    public int vitality;//живучесть
    public int will;//воля
    public int luck;//удача
                    //еще один атрибут
                    //еще один атрибут
                    //</attributes>
    public Attributes()
    {
    }

    public Attributes(Attributes newAttr)
    {
        STR = newAttr.STR;
        dextresity = newAttr.dextresity;
        intellect = newAttr.intellect;
        vitality = newAttr.vitality;
        will = newAttr.will;
        luck = newAttr.luck;
        //
        //
    }
}
