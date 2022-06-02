using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class XArrow : MonoBehaviour, IDragHandler
{
    private Shift _shift;
    private int _keyIndex;
    private static float sensitivity = 0.01f;

    public void Awake()
    {
        // просто ужас который вскрывает плохую арзитектуру
        _keyIndex = transform.parent.transform.parent.GetComponent<SelectableKey>().Index;
        _shift = transform.parent.transform.parent.transform.parent.Find("abilityUser").GetComponent<ShiftVisualizer>().VisualizedShift;
    }
    public int KeyIndex
    {
        set { _keyIndex = value; }
    }
    public void OnDrag(PointerEventData data)
    {
        _shift.trajectory.MoveKey(_keyIndex, _shift.trajectory.GetKeyTime(_keyIndex), _shift.trajectory.GetKeyPosition(_keyIndex) + new Vector3(sensitivity * data.delta.x, 0, 0));
    }



}

