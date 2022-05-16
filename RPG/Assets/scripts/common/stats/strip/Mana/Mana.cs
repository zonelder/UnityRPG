using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mana :Strip
{

    public Mana(AbstractStrip abstractMP):base(abstractMP.Max(),abstractMP.Regen(), abstractMP.Atrophy())
    {
    }
    public Mana(float _maxMP) : base(_maxMP)
    { 
    }

    public Mana(float _maxMP, float MPreg, float MPAtrophy = 100) : base(_maxMP,MPreg,MPAtrophy)
    {
    }
}
