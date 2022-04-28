using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class AbilityCheker //проверка на возможность использования
{

    public GameObject user;
    // Start is called before the first frame update

    public AbilityCheker(GameObject user)
    {
        this.user = user;
    }
   public bool ConditionAreMet(ActiveAbility ability)//можно перетащить в Costs
    {
        if(ability.cooldown.IsReady())
        {
            //ability isnt on cooldown
            UnitStats UserStat = user.GetComponent<UnitStats>();
            if (ability.costs.IsHpEnough(UserStat._improved.HP.Current()) && ability.costs.IsMpEnough(UserStat._improved.MP.Current()))
            {
                //hp and mp is enough
                //if()//frmors check 
                return true;
            }
        }
        return false;
    }
}
