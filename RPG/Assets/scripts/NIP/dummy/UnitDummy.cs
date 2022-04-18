using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDummy : UnitNIP
{
    // Start is called before the first frame update
    public bool reviveAtOnce = true;
    public UnitDummy():base(700, 200, 0, 0, 0)//отвечает за базовые зарактеристики у данного юнита
    {
        // _base.HP = 700;
         //_base.MP = 200; 
        // _base.STR = 0;
        //  _base.vitality = 0;
        //  _base.energy = 0
        base.ExpForDeath = 200;//не работает зато раотает в start
        this.StartExistence();

    }
    public override void lvlUp()//перегружаем процедуру чтобы болванчик ненароком не апнул уровень
    {
        curEXP = 0;
    }
    public override void Start()
    {
        base.Start();
        base.ExpForDeath = 200;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (state== LifeStates.DEAD) //Если кол-во жизни меньше или равно 0
        {
            Debug.Log("dummy has been killed");
            //state = LifeStates.DEAD;
            //death = false;
            if(reviveAtOnce)
            {
                state = LifeStates.STABLE;
                curHP = _improved.HP; //Ставим 0 дабы наш бар не рисовался не корректно
                                      //death = true; //Ставим что персонаж мертв
                curMP = _improved.MP;
            }

        }
    }
}
