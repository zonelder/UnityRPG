using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ISelectable:MonoBehaviour
{
    [SerializeField]
    private  Material s_unselectMaterial;
    [SerializeField]
    private  Material s_selectMaterial;
    public void Select()
    {
        GetComponent<MeshRenderer>().material= s_selectMaterial;
    }


    public void Deselect()
    {
        GetComponent<MeshRenderer>().material = s_unselectMaterial;
    } 
}
