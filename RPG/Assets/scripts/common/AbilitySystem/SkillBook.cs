using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBook : MonoBehaviour//��� ��� ���������� ���� ����� ��� ������ � ��������� ��������� � ������������(��� ������ ������ ���� ���������/������� ����������� ���� ��������� � ��� ����������(����� �� ������ �� ������))
{
    //��� ��� ����� �������� ��� ���� �� ������� ����� ����� ������ �� ����� ������� ��� ����� ������������ �������� ��������� �� ���� ����� �� ����� ����� ���
    public int size=0;
    public List<ActiveAbility> ability = new List<ActiveAbility>();//��������� �������� ������������
    public void Start()//��� ����� ������ � ��������� ��������� ������ ��� ����������
    {
        ActiveAbility NewAbility = new ActiveAbility(10);
        Attack firstAttack= new MeleeAttack(gameObject);
        firstAttack.property.SetDamageAmp(2.0f);
        firstAttack.property.SetSpeed(3.0f);
        firstAttack.property.SetDuration(2.0f);
        firstAttack.property.SetShift(new Vector3(-2,0,0));
        Attack secondAttack = new MeleeAttack(gameObject);
        secondAttack.property.SetDamageAmp(1.0f);
        secondAttack.property.SetDuration(3.0f);
        secondAttack.property.SetSpeed(1.5f);
        secondAttack.property.SetShift(new Vector3(4, 0, 0));
        Attack therdAttack = new MeleeAttack(gameObject);
        therdAttack.property.SetDamageAmp(5.0f);
        therdAttack.property.SetDuration(1.0f);
        therdAttack.property.SetSpeed(1.5f);
        therdAttack.property.SetShift(new Vector3(0, 3, 0));
        NewAbility.AddAttack(firstAttack);
        NewAbility.AddAttack(secondAttack);
        NewAbility.AddAttack(therdAttack);
        AddAbility(NewAbility);


        ActiveAbility NewAbility2 = new ActiveAbility(10);
        Attack firstAttack2 = new MeleeAttack(gameObject);
        firstAttack2.property.SetDamageAmp(2.0f);
        firstAttack2.property.SetSpeed(2.0f);
        firstAttack2.property.SetDuration(1.0f);
        firstAttack2.property.SetShift(new Vector3(-2, 0, -1));
        Attack secondAttack2 = new MeleeAttack(gameObject);
        secondAttack2.property.SetDamageAmp(1.0f);
        secondAttack2.property.SetDuration(1.0f);
        secondAttack2.property.SetSpeed(2.0f);
        secondAttack2.property.SetShift(new Vector3(4, 0, 0));
        Attack therdAttack2 = new MeleeAttack(gameObject);
        therdAttack2.property.SetDamageAmp(5.0f);
        therdAttack2.property.SetDuration(1.0f);
        therdAttack2.property.SetSpeed(2.0f);
        therdAttack2.property.SetShift(new Vector3(-2, 0, 3));
        Attack fothAttack2 = new MeleeAttack(gameObject);
        fothAttack2.property.SetDamageAmp(5.0f);
        fothAttack2.property.SetDuration(1.0f);
        fothAttack2.property.SetSpeed(2.0f);
        fothAttack2.property.SetShift(new Vector3(0, 0, -2));
        NewAbility2.AddAttack(firstAttack2);
        NewAbility2.AddAttack(secondAttack2);
        NewAbility2.AddAttack(therdAttack2);
        NewAbility2.AddAttack(fothAttack2);
        AddAbility(NewAbility2);
    }
    public void Update()
    {
        for(int i=0;i<size;++i)
        {
            if(!(ability[i].cooldown.IsReady()))//���� ���� � ��
            {
                ability[i].cooldown.TickTime(Time.deltaTime);// �������� ������
            }
        }
    }
    public ActiveAbility GetAbilityAt(int i)
    {
        return ability[i];
    }
    public void AddAbility(ActiveAbility newAbility)
    {
        size++;
        ability.Add(newAbility);//������ ���������� ��� ������ � ������ ��� �������� �� ����������(���� ���� ����� ����� ������ �������� ����� � ��� � �����������
    }
    public void RemoveAbility(ActiveAbility newAbility)
    {
        size--;
        ability.Remove(newAbility);//������� ������(����� �� �������� � ���� �������� �� ������)
    }
    public void RemoveAt(int i)
    {
        size--;
        ability.RemoveAt(i);
    }
    public void CreateVoidAbility()
    {
        size++;
        ability.Add(new ActiveAbility(1));//������� ��������� �������� ������� ����� ����� ���������� � ����� ����������� ��� ���������
    }


}