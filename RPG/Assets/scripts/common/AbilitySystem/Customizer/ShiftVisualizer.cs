using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftVisualizer : MonoBehaviour
{
    private static float s_holdTime = 0.5f;
    private static  int s_segmentCount=10;

    public Shift VisualizedShift;
    public bool IsPlaying;

    private void Awake()
    {
        VisualizedShift.SetStartTransform(transform);
    }
    private void Start()
    {
        VisualizedShift.Duration.Start—ountdown();
    }
    private void Update()
    {
        if(IsPlaying)
        {
            if (VisualizedShift.Duration.IsReady())
                RestartShift();
            else
                VisualizedShift.Duration.TickTime(Time.deltaTime);
            transform.localPosition = VisualizedShift.CurLocalPosition();
        }
        
    }

    private void RestartShift()
    {
        VisualizedShift.Duration.Start—ountdown();
    }
}
