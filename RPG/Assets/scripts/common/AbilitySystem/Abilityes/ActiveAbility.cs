using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AbilityEvent();
[System.Serializable]
public class ActiveAbility : AbstractAbility
{
    public Cooldown Cooldown;

    public event AbilityEvent OnAbilityEnd;
    public event AbilityEvent OnAbilityStart;

    [SerializeReference] private List<Attack> _attack = new List<Attack>();
    public ActiveAbility(float cooldown) => Cooldown = new Cooldown(cooldown);
    public int StrokesCount => _attack.Count;
    public void AddAttack(Attack NewAttack)
    {
        _attack.Add(NewAttack);
    }
    public Attack GetAttackAt(int index)=> _attack[index];

    public IEnumerator AbilityByTime(UnitEntity unit)
    {
        Cooldown.Start—ountdown();
        OnAbilityStart?.Invoke();

        for (int i = 0; i <StrokesCount; ++i)
        {
            yield return unit.StartCoroutine(_attack[i].AttackByTime(unit));
        }

        OnAbilityEnd?.Invoke();
    }
}

