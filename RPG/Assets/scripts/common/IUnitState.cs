using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum UnitState
{
    WAITING,
   USE_ABILITY,
   USE_ITEM,
}

public class IUnitState : MonoBehaviour
{
    public ActiveAbility curAbility;
    public Attack curAttack;
    public Weapon weapon;//��������� ������ �� �����
    public int curAttackIndex = 0;
    public UnitState state = UnitState.WAITING;
    public void  Update()
    {
        TryToUseSomething();
        if (state == UnitState.USE_ABILITY && curAbility.IsUse())
        {
            float finalSpeedAmp = curAttack.property.GetSpeedAmp();
            curAttack.TickTime(Time.deltaTime, finalSpeedAmp);
            if (!curAttack.shift.duration.IsReady())//���� ����� ������������
            {
                Shifting();
            }       
            if (curAttack.property.duration.IsReady())//���� ��������� �����
            {
                //curAttack.shift.alreadyUsed = false;
                curAttack.EndAttack();
                curAttackIndex++;
                if (curAttackIndex >= curAbility.Size())
                {
                    curAttackIndex = 0;
                    state = UnitState.WAITING;
                    weapon.SetToDefault();
                    EnableMove();
                }

                else
                {
                    
                    BeginNewAttack();
                }
            }
        }
        if(state==UnitState.USE_ITEM)
        {
            //����� ���� ������� � ��������� ��������+�������� �������
        }
    }
    private void Shifting()
    {
        Vector3 shift = curAttack.shift.VectorOfMove(gameObject);//����������� �������� � ������ ���� ���� ������� ����
        shift.Normalize();
        gameObject.transform.position += (shift) * curAttack.shift.Velocity() * curAttack.property.GetSpeedAmp() * Time.deltaTime;//�������� ��������� ����� �� �������� ������� � ������� ���������
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
        curAttack.property.duration.Start�ountdown();
    }
    public void TryToUseSomething()
    {
        if (Input.GetKeyDown(KeyCode.Q) && state == UnitState.WAITING)
        {
            UseAbilityAt(0);

        }
        if (Input.GetKeyDown("1") && state == UnitState.WAITING)
        {
            UseAbilityAt(1);

        }
    }
    private  void DisableMove() { gameObject.GetComponent<movement>().canMove = false; }
    private void EnableMove() { gameObject.GetComponent<movement>().canMove = true; }
}
