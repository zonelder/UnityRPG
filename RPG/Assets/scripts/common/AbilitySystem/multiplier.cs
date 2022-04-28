using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier//все множители буду описаны тут(множитель урона, скорости и тд)
{
    public float value;

    public Multiplier(float value = 1)
    {
        this.value = value;
    }

    public static Multiplier operator +(Multiplier a, Multiplier b) => new Multiplier(a.value + b.value - 1);
    public static Multiplier operator +(Multiplier a, float b) => new Multiplier(a.value + (b/100));//если пишу myMultiplier+2 будет 0.02+value
    public static Multiplier operator +(float a, Multiplier b) => new Multiplier((a/100) + b.value);



    public static Multiplier operator -(Multiplier a, Multiplier b) => new Multiplier(a.value - b.value + 1);
    public static Multiplier operator -(Multiplier a, float b) => new Multiplier(a.value - (b/100));
    public static Multiplier operator -(float a, Multiplier b) => new Multiplier(b.value-(a/100));



    public static implicit operator float(Multiplier multiplier)=> multiplier.value;

    public static implicit operator int(Multiplier multiplier) => (int)(multiplier.value*100);
}
