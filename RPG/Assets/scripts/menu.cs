using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
public bool showMenu;
public int  window;
public float lifeTime = 5.0f; //������������ ����� ����������� ����
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
       if (curTime > lifeTime) //���� ����� ����� �� ������������ �����
        {
            showMenu = false; //��������� ����
            window = 0;
            curTime = 0; //���������� ������
        }
       if (showMenu == false & Input.anyKeyDown) //���� ���� ��������� � ������ ����� �������
        {
            showMenu = true; //�������� ����
            window = 1;
        }
    }
    void OnGUI()
    {
        if (window == 1) //���� ���� 1
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 200, 220), "����"); //������� ���� � ����

            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "����� ����"))
            {
                SceneManager.LoadScene("test level"); //��������� ������� 1
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), "���������"))
            {
                window = 2; //��������� ���� ��������
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "�� ����"))
            {
                window = 3; //������� ���������� �� ������� ����
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 80, 180, 30), "�����"))
            {
                window = 4; //�������� ���� ������
            }
        }
        //����� ��� ����������
        if (window == 2)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 200, 250), "���������");
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 40, 180, 30), "����"))
            {
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 30), "�����"))
            {
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 40, 180, 30), "�����"))
            {
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 80, 180, 30), "����������"))
            {
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 120, 180, 30), "�����"))
            {
                window = 1;
            }
        }

        if (window == 3)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 80, 200, 220), "�� ����");
            GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 0, 180, 40), "���� � �������");
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 100, 180, 30), "�����"))
            {
                window = 1;
            }
        }

        if (window == 4)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 60, 200, 120), "�����?");
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 20, 180, 30), "��"))
            {
                Application.Quit(); //����� �� ����
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 20, 180, 30), "���"))
            {
                window = 1;
            }
        }

        if (window == 0) //���� ��� ���� �� ��������� ����
        {
            useGUILayout = false;
        }
    }
}

