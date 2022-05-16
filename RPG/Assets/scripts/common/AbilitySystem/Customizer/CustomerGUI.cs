using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGUI : MonoBehaviour
{
    private static float s_xBox = 3 * Screen.width / 4;
    private static float s_borderOfffset = 5;
    private ShiftVisualizer _userShift;
    private static int s_segmentCount = 30;
    private LineRenderer _tragectoryLine;
    [SerializeField]
    private GameObject _endKeyPrefab;
    private GameObject _endKey;

    private void OnEnable()
    {
        _userShift = GameObject.Find("abilityUser").GetComponent<ShiftVisualizer>();

        _tragectoryLine = GameObject.Find("abilityUser").GetComponent<LineRenderer>();
        _tragectoryLine.startColor = Color.red;
        _tragectoryLine.endColor = Color.red;
        _tragectoryLine.startWidth = 0.1f;
        _tragectoryLine.endWidth = 0.1f;
        _tragectoryLine.positionCount = s_segmentCount;

       
    }

    private void Update()
    {
        Vector3 userheight = new Vector3(0, 1, 0);
        for (int i = 0; i < s_segmentCount ; ++i)
        {
            float t = (float)i / s_segmentCount;
            _tragectoryLine.SetPosition(i, _userShift.VisualizedShift.PositionAt(t)-userheight);
            
        }
    }
    public void OnGUI()
    {
        // Перетащим все в UI buider
        Vector3 shiftLengths = _userShift.GetLengths();
        GUI.Box(new Rect(s_xBox, 0, Screen.width / 4, Screen.height),"ability settings");
        GUI.Label(new Rect(s_xBox+s_borderOfffset, 30, Screen.width / 4, Screen.height/10), "shift");
        GUI.Label(new Rect(s_xBox + 2*s_borderOfffset, 43, Screen.width / 4, Screen.height / 10), "forward distance: "+shiftLengths.z);
        GUI.Label(new Rect(s_xBox + 2*s_borderOfffset, 56, Screen.width / 4, Screen.height / 10), "right distance:     " + shiftLengths.x);
        GUI.Label(new Rect(s_xBox + 2*s_borderOfffset, 69, Screen.width / 4, Screen.height / 10), "up distance:        " + shiftLengths.y);
    }
}
