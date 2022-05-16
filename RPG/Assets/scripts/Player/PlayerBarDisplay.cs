using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarDisplay : MonoBehaviour
{
    [SerializeField]
    private GUISkin mySkin; // ���� ��� �������� �������� �����, � ���������� ��������� ��� ����� ��������� ����
    [SerializeField]
    private UnitPlayer Char; // ������ �� ������� ����� �����
    private bool Visible = true; //��������� ����

    void OnGUI()
    {
        if (Visible)
        {
            GUI.skin = mySkin;
            UnitStats PlayerSt = Char.GetComponent<UnitPlayer>();


            float MaxHealth = PlayerSt.Improved.HP.Max();
            float CurHealth = PlayerSt.Improved.HP.Current();
            float MaxMana = PlayerSt.Improved.MP.Max();
            float CurMana = PlayerSt.Improved.MP.Current();


            float HealthBarLen = CurHealth / MaxHealth; 
            float ManaBarLen = CurMana / MaxMana;
            float ExpBarLen = PlayerSt.Exp.DonePersent();

            GUI.Box(new Rect(10, 15, 254 * HealthBarLen, 15), " ", GUI.skin.GetStyle("HPbar"));
            GUI.Box(new Rect(10, 35, 254 * ManaBarLen, 15), " ", GUI.skin.GetStyle("MPbar"));
            GUI.Box(new Rect(10, 55, 254 * ExpBarLen, 15), " ", GUI.skin.GetStyle("EXPbar"));
            GUI.Box(new Rect(10, 10, 254, 64), " ", GUI.skin.GetStyle("PlayerBar"));
            GUI.Box(new Rect(Screen.width/2-7, Screen.height/2-7,14,14), " ", GUI.skin.GetStyle("Crosshair"));


        }
    }
}
