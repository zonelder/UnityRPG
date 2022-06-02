using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField] private int _inventorySize = 10;
    [SerializeField] private GameObject carrier;


    private readonly List<Cell> _cells = new List<Cell>();
    public int Size() => _inventorySize;
    public int OccupiedCellsSize() => _cells.Count;
    public Cell this[int index]
    {
        get=>_cells[index];    
    }

    public void AddItem(ScriptableItem NewItem,int count=1)
    {

        if(Contains(NewItem))
        {

            int index = LastIndexOf(NewItem);
            int suit = count;
            if(!_cells[index].CanPlaceAmount(count))
            {
                suit= _cells[index].Item.CountInStack - count;
                _cells.Add(new Cell(NewItem,count- suit));

            }
            _cells[index].PlaceAmount(suit);
        }
        else
        {
            _cells.Add(new Cell(NewItem, count));
        }
    }
    public void AddCells(int additional) => _inventorySize += additional;
    public  void RemoveItem(ScriptableItem DeletedItem,int removeCount=1)
    {
        if (removeCount <= 0)
            throw new System.ArgumentOutOfRangeException("cant remove negative count of items");

        int index = this.LastIndexOf(DeletedItem);
        if (index == -1)
            throw new System.ArgumentException("such item not found");

        if (_cells[index].CanRemoveAmount(removeCount))
        {
            _cells[index].RemoveAmount(removeCount);
        }
        else
        {
            _cells.RemoveAt(index);
            RemoveItem(DeletedItem, removeCount - _cells[index].Count);
            return;
        }
        if (_cells[index].Empty())
            _cells.RemoveAt(index);
        
    }
    public void UseItemAt(int i)
    {
     
            _cells[i].Item.Use(carrier);
            if (_cells[i].Item.RemoveAfterUse())
                RemoveItem(_cells[i].Item,1);      
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
        int index = 0;
        for (int i = 0; i < _cells.Count; i++)
            if (Item.Equals(_cells[i].Item))
                index = i;

        return index;
    }

}
