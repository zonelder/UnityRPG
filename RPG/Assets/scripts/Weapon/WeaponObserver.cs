using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObserver : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public Weapon GetWeapon() => _weapon;
}
