using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteraction : ScriptableInteraction
{
    // � ����������� � ������ ����� ���� ���� ���� �� ���� �������������� � ������ ����� ����������� �������
    bool dialogStart=false;
    bool UnitTryToInteract = false;//�������� ���� �� � ������ ������� ��������������
    public GUIStyle ExitButton;//��� ��� ����� �������� � ������� ����� ���� ��� ������
    public GameObject Unit;
    void OnTriggerStay(Collider collision)
    { 
        
        Unit = collision.gameObject;
        if(Unit.tag=="weapon")
        {
            Unit=Unit.transform.parent.gameObject;//���� �������� ������ �� ������ �� �����
        }
        if (Unit.tag=="Player")
        {
           
           if(UnitTryToInteract)
            {
                UnitTryToInteract = false;//��� ��������������
                if(!dialogStart)
                {
                    this.Interact(Unit); 
                }
                
                  
            }
        }
        
       
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            UnitTryToInteract = true;
        if (Input.GetKey("escape") && dialogStart)
            this.EndInteract();

    }
   public override  void Interact(GameObject Unit)
    {
        Debug.Log("start inter");
        Unit.GetComponent<PlayerGUI>().inDialog = true;
        Unit.GetComponent<PlayerGUI>().isCameraFreeze = true;
        Unit.GetComponent<movement>().canMove = false;
        dialogStart = true;
    }
    public override void EndInteract()
    {
        Debug.Log("end Inter");
        Unit.GetComponent<PlayerGUI>().inDialog = false;
        Unit.GetComponent<PlayerGUI>().isCameraFreeze = false;
        Unit.GetComponent<movement>().canMove = true;
        dialogStart = false;
    }
    void OnGUI()
    {
        if(dialogStart)
        {
            GUI.Box(new Rect(0, 4 * Screen.height / 5, Screen.width, Screen.height / 5)," ");//������� �����
            if(GUI.Button(new Rect(4*Screen.width/5, 4 * Screen.height / 5+6, Screen.height/6, Screen.height/6)," Exit")){//������ ������(����� �� �������)

                this.EndInteract();
                }
            if (GUI.Button(new Rect(4 * Screen.width / 5- Screen.height / 6-1, 4 * Screen.height / 5 + 6, Screen.height / 6, Screen.height / 6), "GetBuff "))//����� ������
                {
                TimedAPBuff toUnit = new TimedAPBuff(10, 15, Unit);
                toUnit.Buff.Duration = 10;
                //toUnit.Buff.IsEffectStacked = true;
                Unit.GetComponent<BuffableEntity>().AddBuff(toUnit);
                }//buff button
            if (GUI.Button(new Rect(4 * Screen.width / 5 - 2*(Screen.height / 6 - 1), 4 * Screen.height / 5 + 6, Screen.height / 6, Screen.height / 6), "GetPosion "))
            {
                Unit.GetComponent<Inventory>().AddItem(new HealingPosion(100));

            }
            if (GUI.Button(new Rect(4 * Screen.width / 5 - 3 * (Screen.height / 6 - 1), 4 * Screen.height / 5 + 6, Screen.height / 6, Screen.height / 6), "GetExpansion "))
            {
                Unit.GetComponent<Inventory>().AddItem(new InventoryExpansion(3));

            }
            //exit button
        }
    }
}
