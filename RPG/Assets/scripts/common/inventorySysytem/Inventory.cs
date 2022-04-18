using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int InventorySize = 10;
    public bool inventoryOpen = false;
    public GameObject carrier;
    public GUISkin oneCellSkin;
    List<ScriptableItem> cells = new List<ScriptableItem>(0);
    List<int> CountOfItem = new List<int>(0);
    Inventory()
    {
    }
    public void AddItem(ScriptableItem NewItem,int count=1)
    {

        if(this.Contains(NewItem))//елси предмет уже есть в инвенторе
        {

            //int i = cells.LastIndexOf(NewItem);
            int i = this.LastIndexOf(NewItem);
            if (CountOfItem[i]+count>cells[i].CountInStack)//если столько пихнуть невозмоожно
            {
               
                int much = (cells[i].CountInStack - count);
                CountOfItem[i] +=much ;//допихиваем сколько можно

                cells.Add(NewItem);//и выдел€ем новую €чейку под предметы
                CountOfItem.Add(count - much);
            }
            else//если заппихать можно в старые €чейки
            {
                CountOfItem[i] += count;//пихаем
            }
            
        }
        else //такого предмета еще нет
        {
            cells.Add(NewItem);//посел€ем его там;
            CountOfItem.Add(count);
        }
    }
    public void RemoveItem(ScriptableItem DeletedItem,int count=1)
    {
        if (count <= 0)//на случай неправильных влетов в функцию
            return;
        // int i = cells.LastIndexOf(DeletedItem);
        int i = this.LastIndexOf(DeletedItem);
        if (i < 0 || i >= cells.Count)
            Debug.Log("Try to REMOVE ITEM BUT INDEX IS out of range with"+ i);
        else
        {
            if (CountOfItem[i] - count < 0)//если после выкидывани€ не должно остатьс€ ничего
            {
                int much = count - CountOfItem[i];//высчитываем сколько удалить после того как уйдет эта €чейка;
                cells.RemoveAt(i);
                CountOfItem.RemoveAt(i);//удал€ем эту €чейку и обнул€ем ее содержимое
                this.RemoveItem(DeletedItem, much);//удал€ем остатки
            }
            else//если после выкидывани€ должно остатьс€ еще
            {
                CountOfItem[i] -= count;//просто уменьшим счетчик
            }

            if (CountOfItem[i] <= 0)//проверка на состо€тельность 
            {
                cells.RemoveAt(i);
                CountOfItem.RemoveAt(i);
            }
        }
        
    }

    public void UseItemAt(int i)
    {
        if (carrier.GetComponent<IUnitState>().state == UnitState.WAITING)//лишн€€ св€зь. надо перестроить все так что бы тут только юзалось без проверок и процего
        {
            cells[i].Use(carrier);
            carrier.GetComponent<IUnitState>().state = UnitState.USE_ITEM;
            carrier.GetComponent<IUnitState>().itemTime = new Cooldown(cells[i].usingDuration);
            carrier.GetComponent<IUnitState>().itemTime.Start—ountdown();
            if (cells[i].IsRemoveWhenUsed)
                this.RemoveItem(cells[i]);
        }
        else
            Debug.Log("cant use it now");
      
    }
    public bool Contains(ScriptableItem Item)
    {
        for(int i=0;i<cells.Count;i++)
        {
            if (Item.Equals(cells[i]))
                return true;
        }
        return false;
    }
    public int LastIndexOf(ScriptableItem Item)
    {
        int index = 0;
        for (int i = 0; i < cells.Count; i++)
            if (Item.Equals(cells[i]))
                index = i;

        return index;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryOpen =!inventoryOpen;
        }
    }
    void OnGUI()
    {
        if (inventoryOpen)//
        {
            GUI.Box(new Rect(Screen.width - 310, 70, 300, 300), "inventory");
            for (int i = 0; i <InventorySize; ++i)
            {
                GUI.Box(new Rect(Screen.width - 305 + (i % 5) * 58, 100 + (i / 5) * 58, 57, 57), " ");//пуста€ €чейка
                if (i < cells.Count)//если €чейка не пуста€ 
                {
                    oneCellSkin.GetStyle("ItemImg").normal.background = cells[i].ItemImg;
                if (GUI.Button(new Rect(Screen.width - 305 + (i % 5) * 58, 100 + (i / 5) * 58, 57, 57), CountOfItem[i].ToString(), oneCellSkin.GetStyle("ItemImg")))//рисуем то что в €чейе
                {
                    if (i < cells.Count)
                        this.UseItemAt(i);
                }

                }
            }
        }
    }
}
