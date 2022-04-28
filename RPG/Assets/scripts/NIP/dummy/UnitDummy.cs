using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDummy : UnitNIP
{
    public bool reviveAtOnce = true;
    public UnitDummy():base(700, 200, 0, 0, 0)//отвечает за базовые зарактеристики у данного юнита
    {

        base.exp.SetDieExpirience(200);
        this.StartExistence();

    }

    protected override void Update()
    {
        base.Update();
        if (state== LifeStates.DEAD)
        {
            Debug.Log("dummy has been killed");
            if(reviveAtOnce)
            {
                state = LifeStates.STABLE;
                _improved.HP.Refresh();
                                     
                _improved.MP.Refresh();            
            }

        }
    }
}
