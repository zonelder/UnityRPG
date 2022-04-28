using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Strip
{
    //когда игрок стоит в блоке -весь урон входит не в шкалу хп или мп а в блок.
    //когда урон прекращается должно пройти еще како-то время прежде чем начнется востановление блока
    //атрофия блока должна проявлятся когда игроку становиться тяжело использовать его( на пример по атрофии тела)

    private Cooldown recovery;//таймер от момен получения урона в блок до начала его востановления



    public Block(float _max) : base(_max) { }

    public Block(float _max, float reg, float atrophy = 0) : base(_max, reg, atrophy) { }


    public override void StripTick(float deltaTime, LifeStates state)
    {
        if (recovery.IsReady())
        {
            current += regen * deltaTime;
            if (current > max)
                current = max;

        }
        else
            recovery.TickTime(deltaTime);

        if (current <= 0)
            current = 0;
        if (state == AtrophyActivatorState)
        {
            current -= atrophy * deltaTime;
        }
    }

    public void DamageInBlockDone()
    {
        if (recovery.IsReady())//если урон был получен впервые за последнее время  то запускаем отсчет
            recovery.StartСountdown();
        else//если урон уже получался то обновляем таймер
            recovery.RestartCountdown();
    }
}
