using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyDisplay : MonoBehaviour
{
    private bool _isFighting = false;
    private  GameObject Enemy;
    private float timer = 0;
    private static float s_showingTime = 5;
    [SerializeField] private GUISkin EnemyHPbar;

    public  void FightWith(GameObject Unit)
    {
        Enemy = Unit;
        _isFighting = true;
        timer = 0;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if(timer>s_showingTime)
        {
            _isFighting = false;
        }
    }
     public void OnGUI()
    {

        
        if (_isFighting)
        {  
            float HealthBarLen = Enemy.GetComponent<UnitStats>().Improved.HP.Current() / Enemy.GetComponent<UnitStats>().Improved.HP.Max();
            GUI.Box(new Rect(Screen.width / 2 - 127, 15, 254, 15)," ", EnemyHPbar.GetStyle("FullHPBar"));
            GUI.Box(new Rect(Screen.width/2-127, 15, 254 * HealthBarLen, 15), " ", EnemyHPbar.GetStyle("CurHPBar"));
            GUI.Box(new Rect(Screen.width / 2 - 127, 15, 254 , 15), Enemy.name, EnemyHPbar.GetStyle("EnemyName"));
        }
    }
}
