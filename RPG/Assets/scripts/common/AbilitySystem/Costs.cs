using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Costs 
{
    //стоимость абилки
    private float HPcost;
    private float MPcost;
    private float phArmorCost;
    private float mgArmorCost;
    //

    public Costs(float HP_COST,float MP_COST,float pARMOR_COST,float mARMOR_COST)
    {
        HPcost = HP_COST;
        MPcost = MP_COST;
        phArmorCost = pARMOR_COST;
        mgArmorCost = mARMOR_COST;
    }
    /// <Hp>
    public float GetHPCost() { return HPcost; }
    public void  SetHpCost(float value) { HPcost = value; }
    /// </Hp>
    /// <Mp>
    public float GetMpCost() { return MPcost; }
    public  void SetMpCost(float value) { MPcost = value; }
    ///</Mp>
    ///<phArmor>
    public float GetPhArmorCost() { return phArmorCost; }
    public  void SetPhArmorCost(float value) { phArmorCost = value; }
    ///</phArmor>
    ///<mgArmor>
    public float GetMgArmor() { return mgArmorCost; }
    public  void SetMgArmor(float value) { mgArmorCost = value; }
    ///</mgArmor>
    ///
    ///<forCheker>
    public bool IsHpEnough(float curHp) { return curHp > HPcost; }
    public bool IsMpEnough(float curMp) { return curMp > MPcost; }
    public bool IsPhArmorEnough(float curArmor) { return curArmor >= phArmorCost; }
    public bool IsMgArmorEnough(float curArmor) { return curArmor >= mgArmorCost; }
    ///</forCheker>
}
