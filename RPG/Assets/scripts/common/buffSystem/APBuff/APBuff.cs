using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APBuff : ScriptableBuff
{
    
    public  float ExtraMinAP;
    public  float  ExtraMaxAP;
    public APBuff(float a,float b)
    {
        ExtraMinAP =a;
        ExtraMaxAP = b;
        base.BuffImg = Resources.Load<Texture2D>("GUI/BuffSprites/APBuff");
        base.IsEffectStacked = true;
    }

    public override bool Equals(ScriptableBuff other)
    {

        if (other == null || !this.GetType().Equals(other.GetType()))
            return false;
        else
        {
            APBuff p = (APBuff)other;
            return ExtraMinAP == p.ExtraMinAP && ExtraMaxAP == p.ExtraMaxAP && base.Equals(p);
        }


    }
}
