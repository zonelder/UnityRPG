
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableItem : ScriptableObject
{
    public int CountInStack;
    public Texture2D ItemImg;
    public bool IsRemoveWhenUsed;
    public string description;
    public float usingDuration=0.0f;
    public abstract void Use(GameObject Unit);
    public virtual bool Equals(Object other)//на случай если залетит(метод будет перегружен для всех последующих классов)
    {
        if (other == null || !this.GetType().Equals(other.GetType()))
             return false;
        else
        {
            ScriptableItem p = (ScriptableItem)other;
         return CountInStack ==p.CountInStack && IsRemoveWhenUsed == p.IsRemoveWhenUsed;
        }
        

    } 
 
}
