using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryExpansion : ScriptableItem
{   // Start is called before the first frame update
    int addingCells = 1;
    public InventoryExpansion(int value)
    {
        addingCells = value;
        base.CountInStack = 10;
        base.ItemImg = Resources.Load<Texture2D>("Items/InventoryManipulater/Expansion");
        base.IsRemoveWhenUsed = true;
    }

    public override void Use(GameObject Unit)
    {
        Unit.GetComponent<Inventory>().InventorySize += addingCells;
    }

    public override bool Equals(Object other)//на случай если залетит(метод будет перегружен для всех последующих классов)
    {
        if (other == null || !this.GetType().Equals(other.GetType()))
            return false;
        else
        {
           // Debug.Log("findEqual");
            InventoryExpansion p = (InventoryExpansion)other;//от этого по хорошему избавиться
            return addingCells == p.addingCells && base.Equals(p);
        }


    }
}
