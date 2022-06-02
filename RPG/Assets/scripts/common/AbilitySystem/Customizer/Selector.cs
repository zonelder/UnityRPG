using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Selector : MonoBehaviour
{
    private SelectableKey _curSelection;
    [SerializeField]private Shift _shift;

    private void OnEnable()
    {
        _shift =transform.Find("abilityUser").gameObject.GetComponent<ShiftVisualizer>().VisualizedShift;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryReselectKey();
        }
    }

    private void ReplaceSelection(SelectableKey newSelection)
    {
        if(_curSelection !=null)
        {
            _curSelection.Deselect();
        }
 
        newSelection.Select();
        _curSelection = newSelection;
    }
    private void TryReselectKey()
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);
        foreach (var go in raycastResults)
        {

            if (go.gameObject.TryGetComponent(out SelectableKey possibleSeletion))
            {
                if(possibleSeletion!=_curSelection)
                ReplaceSelection(possibleSeletion);
                break;
            }

        }
    }


    private void OnGUI()
    {
        if(_curSelection!=null)
        {
            GUI.Label(new Rect(CustomerSettings.s_xBox +  CustomerSettings.s_borderOfffset, 56, Screen.width / 4, Screen.height / 10), "current Key: " );
            GUI.Label(new Rect(CustomerSettings.s_xBox +  2*CustomerSettings.s_borderOfffset, 69, Screen.width / 4, Screen.height / 10), "position: "+_shift.trajectory.GetKeyPosition(_curSelection.Index));
        }
    }
}
