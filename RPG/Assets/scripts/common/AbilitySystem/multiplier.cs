using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Все множители буду описаны тут(множитель урона, скорости и тд).
[System.Serializable]
public class Multiplier
{
    [SerializeField][Range(1,3)]
    private float _value;

    public Multiplier(float value = 1)
    {
        _value = value;
    }

    public void SetValue(float value) => _value = value;
    public static Multiplier operator +(Multiplier a, Multiplier b) => new Multiplier(a._value + b._value - 1);

    // Eсли пишу myMultiplier+2 будет 0.02+value.
    public static Multiplier operator +(Multiplier a, float b) => new Multiplier(a._value + (b/100));
    public static Multiplier operator +(float a, Multiplier b) => new Multiplier((a/100) + b._value);



    public static Multiplier operator -(Multiplier a, Multiplier b) => new Multiplier(a._value - b._value + 1);
    public static Multiplier operator -(Multiplier a, float b) => new Multiplier(a._value - (b/100));
    public static Multiplier operator -(float a, Multiplier b) => new Multiplier(b._value-(a/100));



    public static implicit operator float(Multiplier multiplier)=> multiplier._value;

    public static implicit operator int(Multiplier multiplier) => (int)(multiplier._value*100);
}
