using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarDisplay : MonoBehaviour
{
    public GUISkin mySkin; // Скин где хранятся текстуры баров, В инспекторе назначить наш новый созданный скин
    public UnitPlayer Char; // Объект на котором висят статы
    public bool Visible = true; //Видимость бара
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnGUI()
    {
        if (Visible)
        {
            //назначаем mySkin текущим скином для GUI
            GUI.skin = mySkin;
            //получаем переменную PlayerSt компонент PlayerStats
            //В инспекторе в Unity нужно указать на игрока
            UnitStats PlayerSt = (UnitStats)Char.GetComponent("UnitPlayer");
            //получаем значения
            float MaxHealth = PlayerSt._improved.HP;
            float CurHealth = PlayerSt.curHP;
            float MaxMana = PlayerSt._improved.MP;
            float CurMana = PlayerSt.curMP;
            float needExp = PlayerSt.ExpToUp;
            float curExp = PlayerSt.curEXP;
            //расчитываем коэффицент длинны полосы здоровья
            float HealthBarLen = CurHealth / MaxHealth; //если умножить на сто то будут проценты
                                                        //расчитываем коэффицент длинны полосы маны
            float ManaBarLen = CurMana / MaxMana; //если умножить на сто то будут проценты
                                                  //расчитываем коэффицент длинны полосы опыта
            float ExpBarLen = curExp / needExp; //если умножить на сто то будут проценты

            //рисуем сам бар
          
 
            //полоса опыта
            
            //полоса здоровья игрока
            GUI.Box(new Rect(10, 15, 254 * HealthBarLen, 15), " ", GUI.skin.GetStyle("HPbar"));
            //полоса маны игрока
            GUI.Box(new Rect(10, 35, 254 * ManaBarLen, 15), " ", GUI.skin.GetStyle("MPbar"));
            GUI.Box(new Rect(10, 55, 254 * ExpBarLen, 15), " ", GUI.skin.GetStyle("EXPbar"));
            GUI.Box(new Rect(10, 10, 254, 64), " ", GUI.skin.GetStyle("PlayerBar"));


        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
