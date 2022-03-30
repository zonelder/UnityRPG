using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUI : MonoBehaviour
{
    public bool showStats;
    public bool inDialog;
    public bool isCameraFreeze;
    public bool InventoryOpen;

    PlayerGUI()
    {
        showStats = false;
        inDialog = false;
        isCameraFreeze=false;
        InventoryOpen = false;
    }
}
