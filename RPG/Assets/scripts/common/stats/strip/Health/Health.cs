using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Health :Strip //
{


    public Health(AbstractStrip AbstractHP):base(AbstractHP.Max(), AbstractHP.Regen(), AbstractHP.Atrophy())
    {
    }
    public Health(float _maxHP) : base(_maxHP)
    {
       
    }

    public Health(float _maxHP, float HPreg, float HPAtrophy = 100) : base(_maxHP,HPreg,HPAtrophy)
    {
    }
}
