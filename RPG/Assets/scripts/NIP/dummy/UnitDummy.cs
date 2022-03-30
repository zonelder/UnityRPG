using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDummy : UnitNIP
{
    // Start is called before the first frame update
    
    public UnitDummy():base(700, 0, 0, 0, 0)//отвечает за базовые зарактеристики у данного юнита
    {
        // _base.HP = 700;
        // _base.MP = 0; 
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
        if (curHP <= 0) //Если кол-во жизни меньше или равно 0
        {
            Debug.Log("dummy has been killed");
            death = false;
            curHP = _improved.HP; //Ставим 0 дабы наш бар не рисовался не корректно
            //death = true; //Ставим что персонаж мертв
        }
    }
}
