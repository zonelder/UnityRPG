using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCustomizer//класс в котором будет вестись настрйока абилки(конкретной уже абилки а не всех что есть в книга способностей)
{
    //желательно все так парами реализовывать чтобы иметь максимум отдачи при настройке
    void SetDamageAmp(ActiveAbility ability,int attackNum,float AmpValue)
    {
        SetDamageAmp(ability.GetAttackAt(attackNum),AmpValue);
    }
    void SetDamageAmp(Attack attack, float AmpValue)
    {
        attack.property.SetDamageAmp(AmpValue);
    }

}
