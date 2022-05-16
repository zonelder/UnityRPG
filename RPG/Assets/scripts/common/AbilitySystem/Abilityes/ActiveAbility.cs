using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ActiveAbility : AbstractAbility
{
    private int _strokesNum = 0;
    [SerializeReference]
    private List<Attack> _attack = new List<Attack>();
    public Cooldown cooldown;
    public ActiveAbility(float cooldown) { this.cooldown = new Cooldown(cooldown); }
    public int Size() => _strokesNum;
    public void AddAttack(Attack NewAttack)
    {
        _attack.Add(NewAttack);
        _strokesNum++;
    }
    public Attack GetAttackAt(int num)
    {
        return _attack[num];
    }
    public override void StartAbility()
    {
        isActive = true;
        cooldown.Start—ountdown();
    }
    public override void EndAbility()
    {
        isActive = false;
    }
    public bool IsUse() { return isActive; }
    public override bool IsActiveAbility() { return true; }
    public override bool IsPassiveAbility() { return false; }
}

