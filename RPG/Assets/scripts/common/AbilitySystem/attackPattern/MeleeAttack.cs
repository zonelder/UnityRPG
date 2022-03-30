using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    //стоит ли хитбокс тут держать или всеже 
    public Weapon weapon;//возможнос стоит поменять модификатор на private(передвать его всеранво никуда не стоит а если надо то лучше обраться к через юнита)
    public MeleeAttack(GameObject user)//создавая атаку в редакторе обращаемся к этому конструктору,и он автоматически передает ссылку на оружие
    {
        weapon = user.transform.Find("weapon").gameObject.GetComponent<Weapon>();
    }

    public override void StartAttack()
    {
       
        weapon.hitBox.enabled=true;
        Debug.Log("hitBox enabled");
        base.StartAttack();
    }
    public override void EndAttack()
    {
        
        weapon.hitBox.enabled=false;//когщда атака закончилось отрубаем хитбокс чтобы он слуайно не ранил кого-то не в проццессе атаки;(хотя может и не надо, решим дальше)
        Debug.Log("hitbox disabled");
        base.EndAttack();
    }
}
