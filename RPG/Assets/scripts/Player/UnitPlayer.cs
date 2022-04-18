using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UnitPlayer : UnitStats
{
    int pointstat = 0; //кол-во поинтов дающихся при повышении(только для игрока)
    public bool showStats;
    public UnitPlayer():base(1000,600,20,20,20)
    {
        //кастомныые
       // _base.HP = 1000;
       // _base.MP = 600;
       // _base.STR = 20;
        //_base.vitality = 20;
        //_base.energy = 20;
        _improved.damage.minDMG = 30;
        _improved.damage.maxDMG = 40;
        _improved.HPregen = 10;
        //this.newImprovedStats();
        //this.newDmg();
        showStats = false;
        StartExistence();
    }

   public override  void Start()
    {
        base.Start();
        curHP = _improved.HP / 2;
    }


    // Update is called once per frame
    public override void Update()
    {
        base.Update();
            if (Input.GetKeyDown(KeyCode.P)) //Принажатии на клавишу P
            {
            //GetComponent<PlayerGUI>().showStats = !GetComponent<PlayerGUI>().showStats;//меняем открываем или закрываем окно(фигня связывает этот юнит и другой)
            showStats = !showStats;
            }

        if (curEXP >=ExpToUp) //Если количество опыта у нас рано и ли больше нужного кол-ва опыта
        {
            this.lvlUp(); //повышаем уровень
            pointstat += 5; //Добавляем очки статов
        }
    }

    void OnGUI()
    {
        if (showStats)
        {
            GUI.Box(new Rect(10, 70, 300, 300), "stats");
            GUI.Label(new Rect(10, 95, 300, 300), "LvL: " + lvl);
            GUI.Label(new Rect(10, 110, 300, 300), "hp: " + _improved.HP);
            GUI.Label(new Rect(10, 125, 300, 300), "mp: " + _improved.MP);
            GUI.Label(new Rect(10, 140, 300, 300), "exp: " + ExpToUp);
            GUI.Label(new Rect(10, 155, 300, 300), "str: " + _improved.attributes.STR);
            GUI.Label(new Rect(10, 170, 300, 300), "vitality: " + _improved.attributes.vitality);
            GUI.Label(new Rect(10, 185, 300, 300), "intellect: " + _improved.attributes.intellect);
            GUI.Label(new Rect(10, 200, 300, 300), "damage: " + _improved.damage.minDMG+ " ~ "+ _improved.damage.maxDMG);
            if (pointstat > 0) //если очков статов больше 0 делаем кнопки для повышения статов
            {
                GUI.Label(new Rect(10, 250, 300, 20), "points " + pointstat.ToString());
                if (GUI.Button(new Rect(150, 155, 20, 20), "+")) //Для силы
                {
                    if (pointstat > 0)
                    {
                        pointstat -= 1;
                        _base.ChangeSTR(1);
                        _improved.ChangeSTR(1);
                    }
                }
                if (GUI.Button(new Rect(150, 170, 20, 20), "+")) //Для живучести
                {
                    if (pointstat > 0)
                    {
                        pointstat -= 1;
                        _base.ChangeVitality(1);
                        _improved.ChangeVitality(1);
                    }
                }
                if (GUI.Button(new Rect(150, 185, 20, 20), "+")) //Для маны
                {
                    if (pointstat > 0)
                    {
                        pointstat -= 1;
                        //_base.energy += 1;
                        _base.ChangeIntellect(1);
                        _improved.ChangeIntellect(1);
                    }
                }
            }
        }
        else// if (showstat == 0)
            useGUILayout = false; //Скрываем окно статов
        if (base.death == true) //Если умерли
        {
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), "Переиграть")) //Ресуем кнопку переиграть
            {
               SceneManager.LoadScene(0);
            }
        }

        
    }
}
