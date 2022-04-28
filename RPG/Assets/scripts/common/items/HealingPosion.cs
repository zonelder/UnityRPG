using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPosion : ScriptableItem
{
    private float recoverHP = 100;
    public HealingPosion(float value)
    {
        recoverHP = value;
        base.ItemImg = Resources.Load<Texture2D>("Items/Potions/HP");
        base.CountInStack = 100;
        base.IsRemoveWhenUsed = true;
    }
     
    public override bool Equals(Object other)
    {
        if (other == null || !this.GetType().Equals(other.GetType()))
        {
            return false;
        }
        else
        {
           
            HealingPosion HP = (HealingPosion)other;
            return (HP.recoverHP == this.recoverHP && base.Equals(HP));
        }
       
    }
    public override void  Use(GameObject Unit)
    {
        Unit.GetComponent<UnitStats>()._improved.HP.AddToCurrent(recoverHP);
    }
}
