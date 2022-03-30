using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarDisplay : MonoBehaviour
{
    public GUISkin mySkin; // ���� ��� �������� �������� �����, � ���������� ��������� ��� ����� ��������� ����
    public UnitPlayer Char; // ������ �� ������� ����� �����
    public bool Visible = true; //��������� ����
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnGUI()
    {
        if (Visible)
        {
            //��������� mySkin ������� ������ ��� GUI
            GUI.skin = mySkin;
            //�������� ���������� PlayerSt ��������� PlayerStats
            //� ���������� � Unity ����� ������� �� ������
            UnitStats PlayerSt = (UnitStats)Char.GetComponent("UnitPlayer");
            //�������� ��������
            float MaxHealth = PlayerSt._improved.HP;
            float CurHealth = PlayerSt.curHP;
            float MaxMana = PlayerSt._improved.MP;
            float CurMana = PlayerSt.curMP;
            float needExp = PlayerSt.ExpToUp;
            float curExp = PlayerSt.curEXP;
            //����������� ���������� ������ ������ ��������
            float HealthBarLen = CurHealth / MaxHealth; //���� �������� �� ��� �� ����� ��������
                                                        //����������� ���������� ������ ������ ����
            float ManaBarLen = CurMana / MaxMana; //���� �������� �� ��� �� ����� ��������
                                                  //����������� ���������� ������ ������ �����
            float ExpBarLen = curExp / needExp; //���� �������� �� ��� �� ����� ��������

            //������ ��� ���
          
 
            //������ �����
            
            //������ �������� ������
            GUI.Box(new Rect(10, 15, 254 * HealthBarLen, 15), " ", GUI.skin.GetStyle("HPbar"));
            //������ ���� ������
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
