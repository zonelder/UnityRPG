using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBuff : ScriptableBuff
{

    public float ExtraHP;
  public HPBuff(float value)
    {
        ExtraHP = value;
        base.BuffImg= Resources.Load("GUI/BuffSprites/HPBuff") as Texture2D;
       
    }

    public override bool Equals(ScriptableBuff other)
    {
        if (other == null || !this.GetType().Equals(other.GetType()))
            return false;
        else
        {
            HPBuff p = (HPBuff)other;
            return ExtraHP == p.ExtraHP && base.Equals(p);
        }


    }
}
