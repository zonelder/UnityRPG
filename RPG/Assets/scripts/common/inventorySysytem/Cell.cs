using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{

    private int _count;
    public int Count
    {
        get => _count;
        private set
        {
            if (value < 0)
                throw new System.ArgumentOutOfRangeException("can't be negative");
            else
                _count = value;
        }
    }
    public ScriptableItem Item { get; set; }

    public Cell(ScriptableItem item,int cout)
    {
        Count = cout;
        Item = item;
    }
    public bool Empty() => _count == 0;
    public bool CanPlaceAmount(int additionalAmount) => _count + additionalAmount <= Item.CountInStack;
    public bool CanRemoveAmount(int amount) => _count >= amount;
    public void PlaceAmount(int amount)
    {
        if (!CanPlaceAmount(amount))
            throw new System.ArgumentOutOfRangeException("cell can't hold that amount");
        _count += amount;         
    }

    public void RemoveAmount(int amount)
    {
        if (!CanRemoveAmount(amount))
            throw new System.ArgumentOutOfRangeException("can't remove more, than cell hold");
        _count -= amount;
    }

}
