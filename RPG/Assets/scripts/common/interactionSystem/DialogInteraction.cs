using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteraction : AbstractInteraction
{
    private bool dialogStart=false;
    private bool UnitTryToInteract = false;
    public GUIStyle ExitButton;
    public GameObject Unit;
    void OnTriggerStay(Collider collision)
    { 
        
        Unit = collision.gameObject;
        if(Unit.tag=="weapon")
        {
            Unit=Unit.transform.parent.gameObject;//если залетело оружие то меняем на юнита
        }
        if (Unit.tag=="Player")
        {
           
           if(UnitTryToInteract)
            {
                UnitTryToInteract = false;//уже взаимодейстуем
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
        Unit.transform.Find("playerCam").GetComponent<moveCam>().CameraFreeze =true;
        Unit.GetComponent<movement>().MoveStrategy.IsMoveable=false;
        dialogStart = true;
    }
    public override void EndInteract()
    {
        Debug.Log("end Inter");
        Unit.transform.Find("playerCam").GetComponent<moveCam>().CameraFreeze = false;
        Unit.GetComponent<movement>().MoveStrategy.IsMoveable=true;
        dialogStart = false;
    }
    void OnGUI()
    {
        if(dialogStart)
        {
            GUI.Box(new Rect(0, 4 * Screen.height / 5, Screen.width, Screen.height / 5)," ");//полоска снизу
            ButtonExit();
            BuffButton();
            HealButton();
            ExpansionButton();
        }
    }

    private void ButtonExit()
    {
        if (GUI.Button(new Rect(4 * Screen.width / 5, 4 * Screen.height / 5 + 6, Screen.height / 6, Screen.height / 6), " Exit"))
        {

            this.EndInteract();
        }
    }
    private void BuffButton()
    {

        if (GUI.Button(new Rect(4 * Screen.width / 5 - Screen.height / 6 - 1, 4 * Screen.height / 5 + 6, Screen.height / 6, Screen.height / 6), "GetBuff "))
        {
            TimedAPBuff toUnit = new TimedAPBuff(10,15, Unit);
            toUnit.Buff.Duration = 10;
            Unit.GetComponent<BuffableEntity>().AddBuff(toUnit);
        }
    }
    private void HealButton()
    {
        if (GUI.Button(new Rect(4 * Screen.width / 5 - 2 * (Screen.height / 6 - 1), 4 * Screen.height / 5 + 6, Screen.height / 6, Screen.height / 6), "GetPosion "))
        {
            Unit.GetComponent<Inventory>().AddItem(new HealingPosion(100));
        }
    }
    private void ExpansionButton()
    {
        if (GUI.Button(new Rect(4 * Screen.width / 5 - 3 * (Screen.height / 6 - 1), 4 * Screen.height / 5 + 6, Screen.height / 6, Screen.height / 6), "GetExpansion "))
        {
            Unit.GetComponent<Inventory>().AddItem(new InventoryExpansion(3));

        }
    }

}
