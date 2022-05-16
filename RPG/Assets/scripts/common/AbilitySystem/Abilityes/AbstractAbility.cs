using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AbstractAbility
{
    [SerializeField]
    private string _name;
    [HideInInspector]
    public bool isActive = false;

    protected AbstractAbility(string name)
    {
        _name = name;
    }
    protected AbstractAbility()
    {

    }
    public abstract void StartAbility();
    public abstract void EndAbility();




    public abstract bool IsActiveAbility();
    public abstract bool IsPassiveAbility();

}
