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

        if(this.Contains(NewItem))//���� ������� ��� ���� � ���������
        {

            //int i = cells.LastIndexOf(NewItem);
            int i = this.LastIndexOf(NewItem);
            if (CountOfItem[i]+count>cells[i].CountInStack)//���� ������� ������� �����������
            {
               
                int much = (cells[i].CountInStack - count);
                CountOfItem[i] +=much ;//���������� ������� �����

                cells.Add(NewItem);//� �������� ����� ������ ��� ��������
                CountOfItem.Add(count - much);
            }
            else//���� ��������� ����� � ������ ������
            {
                CountOfItem[i] += count;//������
            }
            
        }
        else //������ �������� ��� ���
        {
            cells.Add(NewItem);//�������� ��� ���;
            CountOfItem.Add(count);
        }
    }
    public void RemoveItem(ScriptableItem DeletedItem,int count=1)
    {
        if (count <= 0)//�� ������ ������������ ������ � �������
            return;
        // int i = cells.LastIndexOf(DeletedItem);
        int i = this.LastIndexOf(DeletedItem);
        if (i < 0 || i >= cells.Count)
            Debug.Log("Try to REMOVE ITEM BUT INDEX IS out of range with"+ i);
        else
        {
            if (CountOfItem[i] - count < 0)//���� ����� ����������� �� ������ �������� ������
            {
                int much = count - CountOfItem[i];//����������� ������� ������� ����� ���� ��� ����� ��� ������;
                cells.RemoveAt(i);
                CountOfItem.RemoveAt(i);//������� ��� ������ � �������� �� ����������
                this.RemoveItem(DeletedItem, much);//������� �������
            }
            else//���� ����� ����������� ������ �������� ���
            {
                CountOfItem[i] -= count;//������ �������� �������
            }

            if (CountOfItem[i] <= 0)//�������� �� ��������������� 
            {
                cells.RemoveAt(i);
                CountOfItem.RemoveAt(i);
            }
        }
        
    }

    public void UseItemAt(int i)
    {
        if (carrier.GetComponent<IUnitState>().state == UnitState.WAITING)//������ �����. ���� ����������� ��� ��� ��� �� ��� ������ ������� ��� �������� � �������
        {
            cells[i].Use(carrier);
            carrier.GetComponent<IUnitState>().state = UnitState.USE_ITEM;
            carrier.GetComponent<IUnitState>().itemTime = new Cooldown(cells[i].usingDuration);
            carrier.GetComponent<IUnitState>().itemTime.Start�ountdown();
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
                GUI.Box(new Rect(Screen.width - 305 + (i % 5) * 58, 100 + (i / 5) * 58, 57, 57), " ");//������ ������
                if (i < cells.Count)//���� ������ �� ������ 
                {
                    oneCellSkin.GetStyle("ItemImg").normal.background = cells[i].ItemImg;
                if (GUI.Button(new Rect(Screen.width - 305 + (i % 5) * 58, 100 + (i / 5) * 58, 57, 57), CountOfItem[i].ToString(), oneCellSkin.GetStyle("ItemImg")))//������ �� ��� � �����
                {
                    if (i < cells.Count)
                        this.UseItemAt(i);
                }

                }
            }
        }
    }
}
