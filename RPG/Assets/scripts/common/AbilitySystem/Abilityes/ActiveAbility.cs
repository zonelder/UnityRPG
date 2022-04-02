using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAbility : AbstractAbility
{
    private int strokesNum = 0;
    private List<Attack> attack = new List<Attack>();
    public  Cooldown cooldown;
    public Costs costs;
    public ActiveAbility(float cooldown) { this.cooldown = new Cooldown(cooldown); }
    public int Size() { return strokesNum; }
    public void AddAttack(Attack NewAttack)
    {
        attack.Add(NewAttack);
        strokesNum++;
    }
    public Attack GetAttackAt(int num)
    {
        return attack[num];
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

