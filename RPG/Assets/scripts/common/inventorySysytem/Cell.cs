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
            {
                if (value == 0)
                    Item = null;
                _count = value;
            }
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


    public void Fill() => _count = Item.CountInStack;

    public int GetPlaceReminder(int AdditionalAmount)=> (CanPlaceAmount(AdditionalAmount)) ? 0:(_count + AdditionalAmount - Item.CountInStack);
    public int GetRemoveReminder(int removeAmount) => (CanRemoveAmount(removeAmount)) ? 0 : (removeAmount -_count);
    public void Desola() => Count = 0;
}
