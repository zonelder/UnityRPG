using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableEntity : MonoBehaviour//��� ��� � ����� ������ ������� �������
{

    private void OnTriggerEnter(Collider collision)
    {
       if (collision.gameObject.tag == "weapon")//��� ������� ����� � �� �������
        {
            
             GameObject attaker = collision.gameObject.transform.parent.gameObject;//������ ������ ���������� �� ��� ������
            if(attaker.tag== "Player")//����� ���������� �� ������� � ������ ���� ��� �����
            {
                attaker.GetComponent<PlayerEnemyDisplay>().FightWith(gameObject);
            }
            Hit(collision.gameObject.GetComponent<Weapon>().CalculateDamage());
            if (UnitDead())
            {
                attaker.GetComponent<UnitStats>().GetExpFrom(GetComponent<UnitStats>());//���� ����� ��������� ����� �� ���� �� ������ ���� ������
            }

        }
       if(collision.gameObject.tag =="createdHitBox")
        {
            //���� ����� �� ����� �������� ������ ��� ������ � ��� � ������ ���� ����� ����� ��������� ��� ����� ������ � ��� ����� ��� �� �����������
            //�������� ����� ������� � � ��������. ���� � ������ ������� � ��������� ���������� � ��������� ����� � �� ������������
        }

        
    }

    public void Hit(float improvedDamage)
    {
        Debug.Log(Mathf.Floor(improvedDamage) + " damage done");
        GetComponent<UnitStats>().getDamage(improvedDamage);//������� ����
        
    }

    public bool UnitDead() { return GetComponent<UnitStats>().curHP <= 0; }
}
