using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryExpansion : ScriptableItem
{   
    private int addingCells;
    public InventoryExpansion(int value=1)
    {
        addingCells = value;
        base.CountInStack = 10;
        base.ItemImg = Resources.Load<Texture2D>("Items/InventoryManipulater/Expansion");
        base.IsRemoveWhenUsed = true;
    }

    public override void Use(GameObject Unit)
    {
        Unit.GetComponent<Inventory>().AddCells(addingCells);
    }

    public override bool Equals(Object other)
    {
        if (other == null || !this.GetType().Equals(other.GetType()))
            return false;
        else
        {

            InventoryExpansion p = (InventoryExpansion)other;
            return addingCells == p.addingCells && base.Equals(p);
        }


    }
}
