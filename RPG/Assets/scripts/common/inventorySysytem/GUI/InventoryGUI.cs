using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGUI : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    private bool _inventoryOpen = false;

    [SerializeField] private GUISkin oneCellSkin;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventoryOpen = !_inventoryOpen;
        }
    }
    void OnGUI()
    {
        if (_inventoryOpen)
        {
            GUI.Box(new Rect(Screen.width - 310, 70, 300, 300), "inventory");
            for (int i = 0; i < _inventory.Size(); ++i)
            {
                GUI.Box(new Rect(Screen.width - 305 + (i % 5) * 58, 100 + (i / 5) * 58, 57, 57), " ");//пустая ячейка
                if (i < _inventory.OccupiedCellsSize())
                {
                    oneCellSkin.GetStyle("ItemImg").normal.background = _inventory[i].Item.GetTexture();
                    if (GUI.Button(new Rect(Screen.width - 305 + (i % 5) * 58, 100 + (i / 5) * 58, 57, 57), _inventory[i].Count.ToString(), oneCellSkin.GetStyle("ItemImg")))
                    {
                        _inventory.UseItemAt(i);
                    }

                }
            }
        }
    }
}
