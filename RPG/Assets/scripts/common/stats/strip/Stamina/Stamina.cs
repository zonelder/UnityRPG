using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Stamina :Strip
{
    public Stamina(float _maxSP) : base(_maxSP) { }

    public Stamina(float _maxSP, float SPreg, float SPAtrophy = 10) : base(_maxSP,SPreg,SPAtrophy)
    {
    }

}
