using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBuff : ScriptableBuff
{

    public float ExtraHP;
    // Start is called before the first frame update
  public HPBuff(float value)
    {
        ExtraHP = value;
        base.BuffImg= Resources.Load("GUI/BuffSprites/HPBuff") as Texture2D;
       
    }

    public override bool Equals(Object other)//на случай если залетит(метод будет перегружен для всех последующих классов)
    {
        Debug.Log("chexk on Equals HPBuffs");
        if (other == null || !this.GetType().Equals(other.GetType()))
            return false;
        else
        {
            HPBuff p = (HPBuff)other;
            return ExtraHP == p.ExtraHP && base.Equals(p);
        }


    }
}
