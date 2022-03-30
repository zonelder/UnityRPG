using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
public bool showMenu;
public int  window;
public float lifeTime = 5.0f; //Максимальное время отображения меню
private float curTime;
    // Start is called before the first frame update
    void Start()
    {
        showMenu = true;
        window = 1;
    }

    // Update is called once per frame
    void Update()
    {
     if(showMenu==true)
        {
            curTime += Time.deltaTime;
        }
       if (curTime > lifeTime) //Если время дошло до максимальной точки
        {
            showMenu = false; //Отключаем меню
            window = 0;
            curTime = 0; //Сбрасываем таймер
        }
       if (showMenu == false & Input.anyKeyDown) //Если меню выключено и нажата любая клавиша
        {
            showMenu = true; //Включаем меню
            window = 1;
        }
    }
    void OnGUI()
    {
        if (window == 1) //Если окно 1
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 200, 220), "Меню"); //Создаем окно с меню

            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "Новая игра"))
            {
                SceneManager.LoadScene("test level"); //Загружаем уровень 1
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), "Настройки"))
            {
                window = 2; //открываем окно настроек
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Об игре"))
            {
                window = 3; //Выводим информацию об Автарах игры
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 80, 180, 30), "Выход"))
            {
                window = 4; //Вызываем окно выхода
            }
        }
        //Далее все аналогично
        if (window == 2)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 200, 250), "Настройки");
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "Игра"))
            {
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), "Аудио"))
            {
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "Видео"))
            {
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 80, 180, 30), "Управление"))
            {
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 120, 180, 30), "Назад"))
            {
                window = 1;
            }
        }

        if (window == 3)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 200, 220), "Об игре");
            GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 40), "Инфа о разрабе");
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 100, 180, 30), "назад"))
            {
                window = 1;
            }
        }

        if (window == 4)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 60, 200, 120), "Выход?");
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 20, 180, 30), "Да"))
            {
                Application.Quit(); //Выход из игры
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 20, 180, 30), "Нет"))
            {
                window = 1;
            }
        }

        if (window == 0) //Если это окно то выключаем меню
        {
            useGUILayout = false;
        }
    }
}

