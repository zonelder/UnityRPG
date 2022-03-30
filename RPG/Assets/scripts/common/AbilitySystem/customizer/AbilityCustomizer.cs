using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCustomizer//����� � ������� ����� ������� ��������� ������(���������� ��� ������ � �� ���� ��� ���� � ����� ������������)
{
    //���������� ��� ��� ������ ������������� ����� ����� �������� ������ ��� ���������
    void SetDamageAmp(ActiveAbility ability,int attackNum,float AmpValue)
    {
        SetDamageAmp(ability.GetAttackAt(attackNum),AmpValue);
    }
    void SetDamageAmp(Attack attack, float AmpValue)
    {
        attack.property.SetDamageAmp(AmpValue);
    }

}
