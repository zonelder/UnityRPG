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
    private ActiveAbility _curAbility;
    private Attack _curAttack;
    [SerializeField]private Weapon _weapon;
    private int curAttackIndex = 0;
    private UnitState state = UnitState.WAITING;

    private movement _unitMove;
    private void  Update()
    {
        InputToActivateAbility();
        if (state == UnitState.USE_ABILITY && _curAbility.IsUse())
        {
            AbilityAction();
        }
    }

    private void AbilityAction()
    {
        float finalSpeedAmp = _curAttack.Property.SpeedAmp;//Должно учитывать не только бонусы от атаки но и бонусы от бафов, от экипы  и тд
        _curAttack.TickTime(Time.deltaTime, finalSpeedAmp);

        if (!_curAttack.Shift.Duration.IsReady())//если время перемещаться
        {
            //Shifting();
            transform.position = _curAttack.Shift.CurPosition();
        }
        if (_curAttack.Property.Duration.IsReady())//если кончилась атака
        {
            SwitchAttack();
        }
    }
    private void UseAbilityAt(int i)
    {
            _curAbility = gameObject.GetComponent<SkillBook>().GetAbilityAt(i);
            if (_curAbility.cooldown.IsReady())
            {
                state = UnitState.USE_ABILITY;
                _curAbility.StartAbility();
                _unitMove.DisableMove();
                BeginNewAttack();
            }
    }
    public void BeginNewAttack()
    {
        _unitMove.RotateByCamera();
        _curAttack = _curAbility.GetAttackAt(curAttackIndex);
        _curAttack.Shift.SetStartTransform(transform);
        _weapon.SetAttackEffects(_curAttack.Property);
        Debug.Log("start " + (curAttackIndex + 1) + "th attack");
        _curAttack.StartAttack();
    }
    private void SwitchAttack()
    {
        _curAttack.EndAttack();
        curAttackIndex++;
        if (curAttackIndex >= _curAbility.Size())
        {
            curAttackIndex = 0;
            state = UnitState.WAITING;
            _weapon.SetToDefault();
            _unitMove.EnableMove();
        }

        else
        {
            _curAttack.EndAttack();
            BeginNewAttack();
        }
    }
    private void InputToActivateAbility()
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
    private void OnEnable()
    {
        _unitMove = gameObject.GetComponent<movement>();
    }
}
