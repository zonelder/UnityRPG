using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum UnitState
{
    WAITING,
   USE_ABILITY,
}
public class IUnitState : MonoBehaviour
{
    public ActiveAbility curAbility;
    public Attack curAttack;
    public Weapon weapon;
    public int curAttackIndex = 0;
    public UnitState state = UnitState.WAITING;
    public void  Update()
    {
        InputToActivateAbility();
        if (state == UnitState.USE_ABILITY && curAbility.IsUse())
        {
            AbilityAction();
        }
    }

    private void AbilityAction()
    {
        float finalSpeedAmp = curAttack.Property.SpeedAmp;//������ ��������� �� ������ ������ �� ����� �� � ������ �� �����, �� �����  � ��
        curAttack.TickTime(Time.deltaTime, finalSpeedAmp);

        if (!curAttack.Shift.Duration.IsReady())//���� ����� ������������
        {
            //Shifting();
            transform.position = curAttack.Shift.CurPosition();
        }
        if (curAttack.Property.Duration.IsReady())//���� ��������� �����
        {
            SwitchAttack();
        }
    }
    public void UseAbilityAt(int i)
    {
            curAbility = gameObject.GetComponent<SkillBook>().GetAbilityAt(i);
            if (curAbility.cooldown.IsReady())
            {
                state = UnitState.USE_ABILITY;
                curAbility.StartAbility();
                DisableMove();
                BeginNewAttack();
            }
    }
    public void BeginNewAttack()
    {
        GetComponent<movement>().RotateByCamera();
        curAttack = curAbility.GetAttackAt(curAttackIndex);
        curAttack.Shift.SetStartTransform(transform);
        weapon.SetAttackEffects(curAttack.Property);
        Debug.Log("start " + (curAttackIndex + 1) + "th attack");
        curAttack.StartAttack();
    }
    public void SwitchAttack()
    {
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
            curAttack.EndAttack();
            BeginNewAttack();
        }
    }
    public void InputToActivateAbility()
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
