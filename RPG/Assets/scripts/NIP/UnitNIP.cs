using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitNIP : UnitStats
{
    // Start is called before the first frame update
    public UnitNIP(int HP,int MP,int STR,int vitality,int energy):base(HP, MP, STR, vitality, energy)
    {
    }
    public  override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
