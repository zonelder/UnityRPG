using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftVisualizer : MonoBehaviour
{
    private static float s_holdTime = 0.5f;
    private static  int s_segmentCount=10;

    public Shift VisualizedShift;


    private void Awake()
    {
        VisualizedShift.SetStartTransform(transform);
    }
    private void Start()
    {
        VisualizedShift.Duration.Start—ountdown();
    }
    public void OnDrawGizmos()
    {
        for(int i=0;i<s_segmentCount-1;++i)
        {
            float t = (float)i / s_segmentCount;
            float next_t = (float)(i + 1) /s_segmentCount;
            Gizmos.DrawLine(VisualizedShift.PositionAt(t), VisualizedShift.PositionAt(next_t));
        }
    }

    private void Update()
    {
        if (VisualizedShift.Duration.IsReady())
            RestartShift();
        else
            VisualizedShift.Duration.TickTime(Time.deltaTime);
        transform.position = VisualizedShift.CurPosition();
    }

    private void RestartShift()
    {
        VisualizedShift.Duration.Start—ountdown();
    }

    public Vector3 GetLengths()
    {
        return VisualizedShift.GetLenghts();
    }
}
