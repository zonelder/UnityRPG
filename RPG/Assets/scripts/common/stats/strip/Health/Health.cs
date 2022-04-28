using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Health :Strip //
{


    public Health(AbstractStrip AbstractHP):base(AbstractHP.Max())
    {
        regen = AbstractHP.Regen();
        atrophy = AbstractHP.Atrophy();
        AtrophyActivatorState = LifeStates.MIND_ON_THE_EDGE;
    }
    public Health(float _maxHP) : base(_maxHP)
    {
        AtrophyActivatorState = LifeStates.MIND_ON_THE_EDGE;
    }

    public Health(float _maxHP, float HPreg, float HPAtrophy = 100) : base(_maxHP,HPreg,HPAtrophy)
    {
        AtrophyActivatorState = LifeStates.MIND_ON_THE_EDGE;
    }
}
