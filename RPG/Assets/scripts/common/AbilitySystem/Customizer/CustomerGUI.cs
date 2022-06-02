using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CustomerGUI : MonoBehaviour
{


    private ShiftVisualizer _userShift;
    private LineRenderer _tragectoryLine;

    [SerializeField] private Transform parent;
    [SerializeField] private GameObject _KeyPrefab;

    private readonly List<GameObject> _keys = new List<GameObject>();
    public Vector3 GetScale(int index)
    {
       return  _userShift.VisualizedShift.Scale;
    }
    private void OnEnable()
    {
        _userShift = GameObject.Find("abilityUser").GetComponent<ShiftVisualizer>();
        parent.gameObject.AddComponent<LineRenderer>();
        _tragectoryLine = GameObject.Find("Objection").GetComponent<LineRenderer>();
        _tragectoryLine.startColor = Color.red;
        _tragectoryLine.endColor = Color.red;
        _tragectoryLine.startWidth = 0.1f;
        _tragectoryLine.endWidth = 0.1f;
        _tragectoryLine.positionCount = CustomerSettings.s_segmentCount;
        _tragectoryLine.useWorldSpace = false;
        for (int i = 0; i < _userShift.VisualizedShift.GetKeyLength(); ++i)
        {
            _keys.Add(Instantiate(_KeyPrefab,parent));
            _keys[i].name = "key " + i;
            _keys[i].transform.localPosition = _userShift.VisualizedShift.GetKeyLocalPosition(i);
            _keys[i].GetComponent<SelectableKey>().Index = i;
        }

    }

    private void Update()
    {
        RenderTrajectoryLine();
        PlaceKeysInRightPosition();
    }

    private void RenderTrajectoryLine()
    {
        Vector3 userheight = new Vector3(0, 1, 0);
        for (int i = 0; i <CustomerSettings.s_segmentCount; ++i)
        {
            float t = (float)i / CustomerSettings.s_segmentCount;
            _tragectoryLine.SetPosition(i, _userShift.VisualizedShift.LocalPositionAt(t) - userheight);

        }
    }
    private void PlaceKeysInRightPosition()
    {
        Vector3 userheight = new Vector3(0, 1, 0);
        for (int i = 0; i < _userShift.VisualizedShift.GetKeyLength(); ++i)
        {
            _keys[i].transform.localPosition = _userShift.VisualizedShift.GetKeyLocalPosition(i)-userheight;
        }
    }
    private void OnGUI()
    {
        // Перетащим все в UI buider
        Vector3 shiftLengths = _userShift.VisualizedShift.Scale;
        GUI.Box(new Rect(CustomerSettings.s_xBox, 0, Screen.width / 4, Screen.height),"ability settings");
        GUI.Label(new Rect(CustomerSettings.s_xBox + CustomerSettings.s_borderOfffset, 30, Screen.width / 4, Screen.height/10), "shift");
        GUI.Label(new Rect(CustomerSettings.s_xBox + 2 * CustomerSettings.s_borderOfffset, 43, Screen.width / 4, Screen.height / 10), "scale: " + shiftLengths);
    }
}
