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
    public Weapon weapon;//��������� ������ �� �����
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
            curAttack.property.BaseDuration.TickTime(Time.deltaTime);//������� �� ��� ����
            Vector3 shift = curAttack.property.VectorOfMove(gameObject);
            shift.Normalize();
            //����� ������ �� {shift*vector(1,1,1)} ������ �� ������ ���� ������

            //tickWithAmp shift.GetDuration()/curAttack.property.GetSpeed();
            gameObject.transform.position += (shift) * curAttack.property.VelocityAt(curAttack.property.BaseDuration.curTime()) * Time.deltaTime;//duration/speedAmp =����� ���������� �����
            if (curAttack.property.BaseDuration.IsReady())//���� ���������
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
            curAbility = gameObject.GetComponent<SkillBook>().GetAbilityAt(0);//���� ��������� ��� ���� � ������(������ ���� �� ���� �� ����� ������ ���� �������)
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
            curAbility = gameObject.GetComponent<SkillBook>().GetAbilityAt(i);//���� ��������� ��� ���� � ������(������ ���� �� ���� �� ����� ������ ���� �������)
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
        //attackTime = new Cooldown(curAbility.GetAttackAt(curAttackIndex).property.GetImprovedDuration());//duration/speedAmp =����� ���������� �����
        //attackTime.Start�ountdown();
        curAttack.property.BaseDuration.Start�ountdown();
    }

    private  void DisableMove() { gameObject.GetComponent<movement>().canMove = false; }
    private void EnableMove() { gameObject.GetComponent<movement>().canMove = true; }
}
