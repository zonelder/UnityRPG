using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject carrier;

    private readonly List<Cell> _cells = new List<Cell>();
    [SerializeField] private int _inventorySize = 10;
    public int Size() => _inventorySize;
    public int OccupiedCellsSize() => _cells.Count;
    public Cell this[int index]
    {
        get=>_cells[index];    
    }


    public int WholeCount(ScriptableItem item)
    {
        int sum = 0;
        for (int i = 0; i < _cells.Count; ++i)
            if (item.Equals(_cells[i].Item))
            {
                sum += _cells[i].Count;
            }

        return sum;
    }
    public void AddItem(ScriptableItem NewItem,int addCount=1)
    {
        if (!Contains(NewItem))
        {
            _cells.Add(new Cell(NewItem, addCount));
        }
        else
        {
            int index = LastIndexOf(NewItem);
            if (_cells[index].CanPlaceAmount(addCount))
            {
                _cells[index].PlaceAmount(addCount);
            }
            else
            {   
                _cells.Add(new Cell(NewItem,_cells[index].GetPlaceReminder(addCount)));
                _cells[index].Fill();
            }
        }
    }
    public void AddCells(int additional) => _inventorySize += additional;

    public void RemoveItemAt(int index,int removeCount=1)
    {
        if (removeCount <= 0 || !_cells[index].CanRemoveAmount(removeCount))
            throw new System.ArgumentOutOfRangeException("invalid count of item to removeAt");
        if (index < 0 || index >= _cells.Count)
            throw new System.ArgumentOutOfRangeException();

        _cells[index].RemoveAmount(removeCount);
        if (_cells[index].Empty())
            _cells.RemoveAt(index);

    }
    public  void RemoveItem(ScriptableItem DeletedItem,int removeCount=1)
    {
        if (removeCount <= 0 || removeCount>WholeCount(DeletedItem))
            throw new System.ArgumentOutOfRangeException("invalid count of item to remove ");

        int index;
        int reminder = removeCount;
        while(reminder!=0)
        {
             index = LastIndexOf(DeletedItem);
            if (_cells[index].CanRemoveAmount(reminder))
            {
                RemoveItemAt(index, reminder);
                break;
            }
            else
            {
                reminder = _cells[index].GetRemoveReminder(reminder);
                RemoveItemAt(index, _cells[index].Count);
            }
        }
    }
    public void UseItemAt(int i)
    {
        _cells[i].Item.Use(carrier);
        if (_cells[i].Item.RemoveAfterUse())
            RemoveItemAt(i,1);
    }
    private bool Contains(ScriptableItem Item)
    {
        for(int i=0;i<_cells.Count;i++)
        {
            if (Item.Equals(_cells[i].Item))
                return true;
        }
        return false;
    }
    private int LastIndexOf(ScriptableItem Item)
    {
        int index = -1;
        for (int i = _cells.Count-1; i > -1; --i)
            if (Item.Equals(_cells[i].Item))
            {
                index = i;
                break;
            }

        return index;
    }

}
