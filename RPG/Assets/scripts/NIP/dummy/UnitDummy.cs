using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDummy : UnitNIP
{
    public bool reviveAtOnce = true;
    public UnitDummy():base(700, 200, 0, 0, 0)
    {

        base.Exp.SetDieExpirience(200);
        StartExistence();

    }

    private  void Update()
    {
        if (state== LifeStates.DEAD)
        {
            Debug.Log("dummy has been killed");
            if(reviveAtOnce)
            {
                state = LifeStates.STABLE;
                Improved.HP.Refresh();
                                     
                Improved.MP.Refresh();            
            }

        }
    }
}
