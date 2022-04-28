using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ScriptableBuff: ScriptableObject
{

    public Texture2D BuffImg;
    public float Duration;
    public bool IsDurationStacked;
    public bool IsEffectStacked;



    public virtual bool Equals(Object other)
    {
        if (other == null || !this.GetType().Equals(other.GetType()))
            return false;
        else
        {
            ScriptableBuff p = (ScriptableBuff)other;
            return Duration == p.Duration && IsDurationStacked == p.IsDurationStacked && IsEffectStacked==p.IsEffectStacked;
        }


    }
}