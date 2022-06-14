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
    private UnitState state = UnitState.WAITING;
    private Coroutine _curAbility;
    private movement _unitMove;
    private UnitStats _unit;
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
        _unitMove.GetMoveStrategy().DisableMove();
        yield return StartCoroutine(curAbility.AbilityByTime(_unit));
        state = UnitState.WAITING;
        _unitMove.GetMoveStrategy().EnableMove();
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
        _unit = GetComponent<UnitStats>();
    }
}
