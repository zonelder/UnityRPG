using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    //����� �� ������� ��� ������� ��� ����� 
    public Weapon weapon;//��������� ����� �������� ����������� �� private(��������� ��� �������� ������ �� ����� � ���� ���� �� ����� �������� � ����� �����)
    public MeleeAttack(GameObject user)//�������� ����� � ��������� ���������� � ����� ������������,� �� ������������� �������� ������ �� ������
    {
        weapon = user.transform.Find("weapon").gameObject.GetComponent<Weapon>();
    }

    public override void StartAttack()
    {
        base.StartAttack();
        weapon.hitBox.enabled=true;
        Debug.Log("hitBox enabled");
       
    }
    public override void EndAttack()
    {
        
        weapon.hitBox.enabled=false;//������ ����� ����������� �������� ������� ����� �� ������� �� ����� ����-�� �� � ��������� �����;(���� ����� � �� ����, ����� ������)
        Debug.Log("hitbox disabled");
        base.EndAttack();
    }
}
