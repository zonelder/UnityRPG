using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitEntity))]
public class UnitDummy : MonoBehaviour
{
    public bool reviveAtOnce = true;
    private UnitEntity _dummy;
    private void Awake()
    {
        _dummy = GetComponent<UnitEntity>();
    }
    private  void Update()
    {
        if (!_dummy.IsAlive)
        {
            if(reviveAtOnce)
            {
               _dummy.Revive();
            }

        }
    }
}
