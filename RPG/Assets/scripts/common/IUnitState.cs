using System.Collections;
using UnityEngine;
using System;

public delegate void method();
public enum UnitState
{
    WAITING,
   USE_ABILITY,
}
public class IUnitState : MonoBehaviour
{
    public event Action OnAbilityStart;
    public event Action OnAbilityEnd;
    private UnitState state = UnitState.WAITING;
    private Coroutine _curAbility;
    private movement _unitMove;
    private UnitEntity _unit;
    private void  Update()
    {
        InputToActivateAbility();
    }
    private void UseAbilityAt(int i)
    {
        ActiveAbility curAbility = gameObject.GetComponent<SkillBook>().GetAbilityAt(i);
        if (curAbility.Cooldown.IsReady)
        {
            _curAbility = StartCoroutine(AbilityObserve(curAbility));
        }
    }

    private IEnumerator AbilityObserve(ActiveAbility curAbility)
    {
        state = UnitState.USE_ABILITY;
        OnAbilityStart?.Invoke();
        _unitMove.MoveStrategy.IsMoveable=false;
        yield return StartCoroutine(curAbility.AbilityByTime(_unit));
        state = UnitState.WAITING;
        OnAbilityEnd?.Invoke();
        _unitMove.MoveStrategy.IsMoveable = true;
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
        _unitMove =GetComponent<movement>();
        _unit = GetComponent<UnitEntity>();
    }
}
