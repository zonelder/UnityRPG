using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public  Sheath Sheath;

    [SerializeField] private UnitStats _unit;

    public Collider hitBox;
    private MeshFilter mesh;
    public Collider GetHitBox() => hitBox;
    public  void SetHitBox(Collider NewHitBox) => hitBox = NewHitBox;
    public void ActivateHitBox()
    {
        gameObject.SetActive(true);
        hitBox.enabled = true;
    }
    public void DeactivateHitBox()
    {
        gameObject.SetActive(false);
        hitBox.enabled = false;
    }
}
