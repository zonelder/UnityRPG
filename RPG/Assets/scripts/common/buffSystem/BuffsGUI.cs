using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsGUI : MonoBehaviour
{
    [SerializeField] private GUISkin buffBar;

    [SerializeField] private BuffableEntity _buffArray;


    private string FormatingDuration(float duration)=>System.String.Format("{0:0.0}c", duration);
    private string FormatingStacks(int effectStacks) => (effectStacks > 1) ? (effectStacks.ToString()) : " ";

    private void OnGUI()
    {
            int xBarPos = Screen.width / 3;
            int yBarPos = 3 * Screen.height / 4;
            int iconSize = 20;
            for (int i = 0; i <_buffArray.Size ; ++i)
            {
                buffBar.GetStyle("ImgAndTimer").normal.background = _buffArray[i].Buff.BuffImg;
                GUI.Box(new Rect(xBarPos + (iconSize + 1) * i, yBarPos, iconSize, iconSize), FormatingDuration(_buffArray[i].Duration), buffBar.GetStyle("ImgAndTimer"));
                GUI.Box(new Rect(xBarPos + (iconSize + 1) * i, yBarPos, iconSize, iconSize), FormatingStacks(_buffArray[i].EffectStacks), buffBar.GetStyle("EffectStacks"));

            }
    }
}
