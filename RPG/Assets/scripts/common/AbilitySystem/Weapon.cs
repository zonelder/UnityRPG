using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AttackStats curAttackEffects=new AttackStats();
    public Damage curDamage;
    public Collider hitBox;
    private MeshFilter mesh;
    public void Awake() {//из юнита берем урон
        curDamage = gameObject.transform.parent.gameObject.GetComponent<UnitStats>()._improved.damage;//получаетс€ что полсед такого действи€ величина там и тут -св€заны
    }
    public Collider GetHitBox() { return hitBox; }
    public  void SetHitBox(Collider NewHitBox) { hitBox = NewHitBox; }//метод дл€ замены оружи€ при эквипе другого

    public void SetAttackEffects(AttackStats attackStats)//беремиз юнита
    {
        curAttackEffects = attackStats;
    }

    public float CalculateDamage()
    {
        //если в AttackStats  будет что-то, способно повли€ть на расчет урона, то создаем тут временную переменную в которой собираем весь возможный импакт и от него уже обращаемс€ к методу caclulate()
        return curDamage.calculate() * curAttackEffects.damageAmp;
    }
    public void SetToDefault()
    {
        curAttackEffects = new AttackStats();//типа пустой экземпл€р
    }

}
