using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyDisplay : MonoBehaviour
{
    private bool is_fighting = false;
    private  GameObject Enemy;
     private float timer = 0;
   [SerializeField]
    private GUISkin EnemyHPbar;
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
            float HealthBarLen = Enemy.GetComponent<UnitStats>().Improved.HP.Current() / Enemy.GetComponent<UnitStats>().Improved.HP.Max();
            GUI.Box(new Rect(Screen.width / 2 - 127, 15, 254, 15)," ", EnemyHPbar.GetStyle("FullHPBar"));
            GUI.Box(new Rect(Screen.width/2-127, 15, 254 * HealthBarLen, 15), " ", EnemyHPbar.GetStyle("CurHPBar"));
            GUI.Box(new Rect(Screen.width / 2 - 127, 15, 254 , 15), Enemy.name, EnemyHPbar.GetStyle("EnemyName"));
        }
    }
}
