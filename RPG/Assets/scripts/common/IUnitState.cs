using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum UnitState
{
    DEFAULT,
   USE_ABILITY,
}

public class IUnitState : MonoBehaviour
{
    public ActiveAbility curAbility;
    public Attack curAttack;
    public Cooldown attackTime;
    public Weapon weapon;//экземпляр оружия на юните
    public int curAttackIndex = 0;
    public UnitState state = UnitState.DEFAULT;
    public void  Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && state == UnitState.DEFAULT)
        {
            UseAbilityAt(0);
          
        }
        if (Input.GetKeyDown("1") && state == UnitState.DEFAULT)
        {
            UseAbilityAt(1);

        }
        if (state == UnitState.USE_ABILITY && curAbility.IsUse())
        {
            curAttack.property.speed = curAttack.property.GetShift().magnitude / curAttack.property.GetDuration();//скорость пермещение-дистанция/ время
            attackTime.TickTime(Time.deltaTime);//отсчитываем время пока идет атака
            Vector3 shift = gameObject.transform.forward * curAttack.property.GetShift().z + gameObject.transform.right * curAttack.property.GetShift().x + gameObject.transform.up * curAttack.property.GetShift().y;//вектор скалярного произведения?
            //очень похоже на {shift*vector(1,1,1)} только на выхоже тоже вектор
            gameObject.transform.position += (shift) * Time.deltaTime/ curAttack.property.GetDuration()* curAttack.property.GetSpeed();//duration/speedAmp =время проведения каста
            if (attackTime.IsReady())//если кончилось
            {
                curAttack.EndAttack();
                curAttackIndex++;
                if (curAttackIndex >= curAbility.Size())
                {
                    curAttackIndex = 0;
                    state = UnitState.DEFAULT;
                    weapon.SetToDefault();
                    EnableMove();
                }

                else
                {
                    
                    BeginNewAttack();
                }
            }
        }
    }
    public void UseAbilityAt(int i)
    {

        if(i==0)
        {
            curAbility = gameObject.GetComponent<SkillBook>().GetAbilityAt(0);//тоже связывает это юнит и другой(хорошо если бы тутв се такие связки были собраны)
            if (curAbility.cooldown.IsReady())
            {
                state = UnitState.USE_ABILITY;
                curAbility.StartAbility();
                DisableMove();
                BeginNewAttack();
            }
        }
        if (i == 1)
        {
            curAbility = gameObject.GetComponent<SkillBook>().GetAbilityAt(i);//тоже связывает это юнит и другой(хорошо если бы тутв се такие связки были собраны)
            if (curAbility.cooldown.IsReady())
            {
                state = UnitState.USE_ABILITY;
                curAbility.StartAbility();
                DisableMove();
                BeginNewAttack();
            }
        }
    }
    public void BeginNewAttack()
    {
        curAttack = curAbility.GetAttackAt(curAttackIndex);
        curAttack.StartAttack();
        weapon.SetAttackEffects(curAttack.property);
        StartAttackCountdown();
        Debug.Log("start " + (curAttackIndex + 1) + "th attack");
    }
    public void StartAttackCountdown()
    {
        attackTime = new Cooldown(curAbility.GetAttackAt(curAttackIndex).property.GetDuration()/ curAbility.GetAttackAt(curAttackIndex).property.GetSpeed());//duration/speedAmp =время проведения каста
        attackTime.StartСountdown();
    }

    private  void DisableMove() { gameObject.GetComponent<movement>().canMove = false; }
    private void EnableMove() { gameObject.GetComponent<movement>().canMove = true; }
}
