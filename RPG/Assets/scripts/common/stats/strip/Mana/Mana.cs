using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mana :Strip
{

    public Mana(AbstractStrip abstractMP):base(abstractMP.Max())
    {
        regen = abstractMP.Regen();
        atrophy = abstractMP.Atrophy();
        AtrophyActivatorState = LifeStates.BODY_ON_THE_EDGE;
    }
    public Mana(float _maxMP) : base(_maxMP)
    {
        AtrophyActivatorState = LifeStates.BODY_ON_THE_EDGE;
    }

    public Mana(float _maxMP, float MPreg, float MPAtrophy = 100) : base(_maxMP,MPreg,MPAtrophy)
    {
        AtrophyActivatorState = LifeStates.BODY_ON_THE_EDGE;
    }
}
