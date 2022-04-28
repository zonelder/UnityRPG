
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableItem : ScriptableObject
{
    public  int CountInStack;
    protected Texture2D ItemImg;
    protected bool IsRemoveWhenUsed;
    protected string description;
    public abstract void Use(GameObject Unit);
    public virtual bool Equals(Object other)
    {
        if (other == null || !this.GetType().Equals(other.GetType()))
             return false;
        else
        {
            ScriptableItem p = (ScriptableItem)other;
         return CountInStack ==p.CountInStack && IsRemoveWhenUsed == p.IsRemoveWhenUsed;
        }
        

    }

    public bool RemoveAfterUse() => IsRemoveWhenUsed;
    public Texture2D GetTexture() => ItemImg;
 
}
