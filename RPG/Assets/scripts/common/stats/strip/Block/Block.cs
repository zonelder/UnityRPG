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


    public void DamageInBlockDone()
    {
        if (recovery.IsReady())//если урон был получен впервые за последнее время  то запускаем отсчет
            recovery.StartСountdown();
        else//если урон уже получался то обновляем таймер
            recovery.RestartCountdown();
    }
}
