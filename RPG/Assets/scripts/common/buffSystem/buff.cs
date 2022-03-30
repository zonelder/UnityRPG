using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ScriptableBuff: ScriptableObject
{

    /**
     * Time duration of the buff in seconds.
      
     */
    //public int ID;
    public Texture2D BuffImg;
    public float Duration;

    /**
     * Duration is increased each time the buff is applied.
     */
    public bool IsDurationStacked;

    /**
     * Effect value is increased each time the buff is applied.
     */
    public bool IsEffectStacked;



    public virtual bool Equals(Object other)//на случай если залетит(метод будет перегружен для всех последующих классов)
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