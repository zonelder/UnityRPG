using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyDisplay : MonoBehaviour
{
    bool is_fighting = false;
    public  GameObject Enemy;
    float timer = 0;
   // public GUIStyle HPBar;
   // public GUIStyle fullBar;
    public GUISkin EnemyHPbar;
    public PlayerEnemyDisplay()
    {
       // HPBar.normal.background=Resources.Load("GUI/BarSprites/REDSprite") as Texture2D;
    }
    
    public  void FightWith(GameObject Unit)
    {
       // if()
        Enemy = Unit;
        is_fighting = true;
        timer = 0;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if(timer>5)
        {
            is_fighting = false;
            //delete Enemy;
        }
    }
     public void OnGUI()
    {

        
        if (is_fighting)
        {  
            float HealthBarLen = Enemy.GetComponent<UnitStats>().curHP / Enemy.GetComponent<UnitStats>()._improved.HP;
            GUI.Box(new Rect(Screen.width / 2 - 127, 15, 254, 15)," ", EnemyHPbar.GetStyle("FullHPBar"));
            GUI.Box(new Rect(Screen.width/2-127, 15, 254 * HealthBarLen, 15), " ", EnemyHPbar.GetStyle("CurHPBar"));
            GUI.Box(new Rect(Screen.width / 2 - 127, 15, 254 , 15), Enemy.name, EnemyHPbar.GetStyle("EnemyName"));
        }
    }
}
