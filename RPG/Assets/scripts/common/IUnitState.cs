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
        float finalSpeedAmp = curAttack.property.speedAmp;//ƒолжно учитывать не только бонусы от атаки но и бонусы от бафов, от экипы  и тд
        curAttack.TickTime(Time.deltaTime, finalSpeedAmp);
        if (!curAttack.shift.duration.IsReady())//если врем€ перемещатьс€
        {
            Shifting();
        }
        if (curAttack.property.duration.IsReady())//если кончилась атака
        {
            SwitchAttack();
        }
    }
    private void Shifting()
    {
        Vector3 shift = curAttack.shift.VectorOfMove(gameObject);//направление движени€ с учетом того куда смотрит юнит
        shift.Normalize();
        gameObject.transform.position += (shift) * curAttack.shift.Velocity() * curAttack.property.speedAmp * Time.deltaTime;//измен€ем положение юнита по заданому вектору с заданой скоростью
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
        weapon.SetAttackEffects(curAttack.property);
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
