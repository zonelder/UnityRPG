using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public  Sheath Sheath;
    public AttackStats curAttackEffects=new AttackStats();
    public Damage curDamage;
    public Collider hitBox;
    private MeshFilter mesh;
    public void Awake()
    { 
        curDamage = gameObject.transform.parent.gameObject.GetComponent<UnitStats>().Improved.damage;
    }
    public Collider GetHitBox() { return hitBox; }
    public  void SetHitBox(Collider NewHitBox) { hitBox = NewHitBox; }

    public void SetAttackEffects(AttackStats attackStats)
    {
        curAttackEffects = attackStats;
    }

    public GeneratedDamage CalculateDamage()
    {
        GeneratedDamage damage = curDamage.calculate();
        damage.damage *= curAttackEffects.DamageAmp;
        return damage;
    }
    public void SetToDefault()
    {
        curAttackEffects = new AttackStats();// пустой экземпляр
    }

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
