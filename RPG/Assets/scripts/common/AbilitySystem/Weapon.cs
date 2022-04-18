using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AttackStats curAttackEffects=new AttackStats();
    public Damage curDamage;
    public Collider hitBox;
    private MeshFilter mesh;
    public void Awake() {//�� ����� ����� ����
        curDamage = gameObject.transform.parent.gameObject.GetComponent<UnitStats>()._improved.damage;//���������� ��� ������ ������ �������� �������� ��� � ��� -�������
    }
    public Collider GetHitBox() { return hitBox; }
    public  void SetHitBox(Collider NewHitBox) { hitBox = NewHitBox; }//����� ��� ������ ������ ��� ������ �������

    public void SetAttackEffects(AttackStats attackStats)//������� �����
    {
        curAttackEffects = attackStats;
    }

    public float CalculateDamage()
    {
        //���� � AttackStats  ����� ���-��, �������� �������� �� ������ �����, �� ������� ��� ��������� ���������� � ������� �������� ���� ��������� ������ � �� ���� ��� ���������� � ������ caclulate()
        return curDamage.calculate() * curAttackEffects.damageAmp;
    }
    public void SetToDefault()
    {
        curAttackEffects = new AttackStats();//���� ������ ���������
    }

}
