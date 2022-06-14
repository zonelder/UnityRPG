using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UnitPlayer : HittableEntity
{
    private int pointstat = 0; //кол-во поинтов дающихся при повышении(только для игрока)(вынести окно с хаарктеристиками в одельный класс?)
    public bool showStats;
    public UnitPlayer():base(1000,600,20,20,20)
    {
        showStats = false;
        Base.HP = new AbstractStrip(1000,10,100);

        StartExistence();
        Improved.Damage = new Damage(30, 40, 30, 1.5f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            showStats = !showStats;
        }
        if (Exp.isEnouth())
        {
            Exp.lvlUp();
            pointstat += 5;
        }
    }

    void OnGUI()
    {
        if (!showStats)
            useGUILayout = false;
        else
        {
            // Негибко- перетащим в UI Builder 
            GUI.Box(new Rect(10, 70, 300, 300), "stats");
            GUI.Label(new Rect(10, 95, 300, 300), "LvL: " + Exp.level());
            GUI.Label(new Rect(10, 110, 300, 300), "hp: " + Improved.HP.Max());
            GUI.Label(new Rect(10, 125, 300, 300), "mp: " + Improved.MP.Max());
            GUI.Label(new Rect(10, 140, 300, 300), "expToUp: " + Exp.RequiredExp());
            GUI.Label(new Rect(10, 155, 300, 300), "str: " + Improved.Attributes.STR);
            GUI.Label(new Rect(10, 170, 300, 300), "vitality: " + Improved.Attributes.vitality);
            GUI.Label(new Rect(10, 185, 300, 300), "intellect: " + Improved.Attributes.intellect);
            GUI.Label(new Rect(10, 200, 300, 300), "damage: " + Improved.Damage.Min+ " ~ "+ Improved.Damage.Max);
            if (pointstat > 0) 
            {
                GUI.Label(new Rect(10, 250, 300, 20), "points " + pointstat.ToString());
                PlusStrButton();
                PlusVitalityButton();
                PlusManIntellectButton();
            }
        }
        if (state == LifeStates.DEAD)
        {
            OnDeadGUI();
        }    
    }

    private void PlusStrButton()
    {
        if (GUI.Button(new Rect(150, 155, 20, 20), "+")) //Для силы
        {
            if (pointstat > 0)
            {
                pointstat -= 1;
                Base.ChangeSTR(1);
                Improved.ChangeSTR(1);
            }
        }
    } 
    private void PlusVitalityButton()
    {
        if (GUI.Button(new Rect(150, 170, 20, 20), "+")) //Для живучести
        {
            if (pointstat > 0)
            {
                pointstat -= 1;
                Base.ChangeVitality(1);
                Improved.ChangeVitality(1);
            }
        }
    }

    private void PlusManIntellectButton()
    {
        if (GUI.Button(new Rect(150, 185, 20, 20), "+")) //Для маны
        {
            if (pointstat > 0)
            {
                pointstat -= 1;
                Base.ChangeIntellect(1);
                Improved.ChangeIntellect(1);
            }
        }
    }

    private void OnDeadGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), "Переиграть"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
