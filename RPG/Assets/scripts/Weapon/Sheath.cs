using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheath : MonoBehaviour
{
    [SerializeField] private GameObject _weapon;
    public bool IsActive => _weapon.activeSelf;

    public void PullWeapon()
    {
        _weapon.SetActive(false);
    }

    public void PlaceWeapon()
    {
        _weapon.SetActive(true);
    }
}
